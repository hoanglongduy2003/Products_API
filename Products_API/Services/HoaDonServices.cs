using Microsoft.EntityFrameworkCore;
using Products_API.Entities;
using Products_API.Helper;
using Products_API.IServices;

namespace Products_API.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly AppDbContext DbContext;

        public HoaDonServices()
        {
            DbContext = new AppDbContext();
        }
        private  string TaoMaGiaoDich()
        {
            var time = DateTime.Now.ToString("yyyyMMdd") + "_";
            var countDay = DbContext.HoaDon.Count(x => x.ThoiGianTao.Date == DateTime.Now.Date);
            if (countDay > 0)
            {
                int temp = countDay + 1;
                if (temp < 10) return time + "00" + temp.ToString();
                else if (temp < 100) return time + "0" + temp.ToString();
                else return time + temp.ToString();

            }
            else return time + "001";
        }
        public ErrorHelper AddHoaDon(HoaDon hoaDon)
        {
            using(var trans = DbContext.Database.BeginTransaction())
            {
                hoaDon.ThoiGianTao = DateTime.Now;
                hoaDon.MaGiaoDich = TaoMaGiaoDich();
                var listChiTiet = hoaDon.ChiTietHoaDons;
                hoaDon.ChiTietHoaDons = null;
                DbContext.Add(hoaDon);
                DbContext.SaveChanges();
                foreach(var chitiet in listChiTiet)
                {
                    if (DbContext.SanPham.Any(x => x.SanPhamID == chitiet.SanPhamID))
                    {
                        chitiet.HoaDonID = hoaDon.HoaDonID;
                        var sanPham = DbContext.SanPham.FirstOrDefault(x => x.SanPhamID == chitiet.SanPhamID);
                        chitiet.ThanhTien = chitiet.SoLuong * sanPham.GiaTien;
                        DbContext.Add(chitiet);
                        DbContext.SaveChanges();
                    }
                    else
                    {
                        return ErrorHelper.SanPhamKhongTonTai;
                    }
                }
                hoaDon.TongTien = listChiTiet.Sum(x => x.ThanhTien);
                DbContext.SaveChanges();
                trans.Commit();
                return ErrorHelper.ThanhCong;
            }
        }

        public ErrorHelper EditHoaDon(HoaDon hoaDon)
        {
            using (var trans = DbContext.Database.BeginTransaction())
            {
                if (!DbContext.HoaDon.Any(x => x.HoaDonID == hoaDon.HoaDonID))
                {
                    return ErrorHelper.HoaDonKhongTonTai;
                }
                
                if (hoaDon.ChiTietHoaDons == null || hoaDon.ChiTietHoaDons.Count() == 0)
                {
                    var listCTHD = DbContext.ChiTietHoaDon.Where(x => x.HoaDonID == hoaDon.HoaDonID);
                    DbContext.RemoveRange(listCTHD);
                    DbContext.SaveChanges();
                }
                else
                {
                    var listCTHD = DbContext.ChiTietHoaDon.Where(x => x.HoaDonID == hoaDon.HoaDonID).ToList();
                    var listNewCTHS = new List<ChiTietHoaDon>();
                    foreach (var chiTiet in listCTHD)
                    {
                        if (!hoaDon.ChiTietHoaDons.Any(x => x.ChiTietHoaDonID == chiTiet.ChiTietHoaDonID))
                        {
                            listNewCTHS.Add(chiTiet);
                        }
                        else
                        {
                            var chiTietMoi = hoaDon.ChiTietHoaDons.FirstOrDefault(x => x.ChiTietHoaDonID == chiTiet.ChiTietHoaDonID);
                            chiTiet.SanPhamID = chiTietMoi.SanPhamID;
                            chiTiet.DVT = chiTietMoi.DVT;
                            chiTiet.SoLuong = chiTietMoi.SoLuong;
                            var sanPhamMoi = DbContext.SanPham.FirstOrDefault(x => x.SanPhamID == chiTietMoi.SanPhamID);
                            chiTiet.ThanhTien = sanPhamMoi.GiaTien * chiTietMoi.SoLuong;
                            DbContext.Update(chiTiet);
                            DbContext.SaveChanges();
                        }
                    }
                    DbContext.RemoveRange(listNewCTHS);
                    DbContext.SaveChanges();
                    foreach (var chiTiet in hoaDon.ChiTietHoaDons)
                    {
                        if (!listCTHD.Any(x => x.ChiTietHoaDonID == chiTiet.ChiTietHoaDonID))
                        {
                            chiTiet.HoaDonID = hoaDon.HoaDonID;
                            var sanPham = DbContext.SanPham.FirstOrDefault(x => x.SanPhamID == chiTiet.SanPhamID);
                            chiTiet.ThanhTien = sanPham.GiaTien * chiTiet.SoLuong;
                            DbContext.Add(chiTiet);
                            DbContext.SaveChanges();
                        }
                    }
                }
                var hoaDonCu = DbContext.HoaDon.Find(hoaDon.HoaDonID);
                hoaDon.MaGiaoDich = hoaDonCu.MaGiaoDich;
                hoaDon.ThoiGianTao = hoaDonCu.ThoiGianTao;
                var tongTienMoi = DbContext.ChiTietHoaDon.Where(x => x.HoaDonID == hoaDon.HoaDonID).Sum(x => x.ThanhTien);
                hoaDon.TongTien = tongTienMoi;
                hoaDon.ThoiGianCapNhat = DateTime.Now;
                hoaDon.ChiTietHoaDons = null;
                DbContext.Entry(hoaDonCu).CurrentValues.SetValues(hoaDon);
                DbContext.SaveChanges();
                trans.Commit();
                return ErrorHelper.ThanhCong;
            }
        }

        public ErrorHelper DeleteHoaDon(int hoaDonID)
        {
            var checkHoaDon = DbContext.HoaDon.Find(hoaDonID);
            if (checkHoaDon == null) return ErrorHelper.HoaDonKhongTonTai;
            var checkCTHoaDon = DbContext.ChiTietHoaDon.Where(x => x.HoaDonID == hoaDonID);
            DbContext.RemoveRange(checkCTHoaDon);
            DbContext.SaveChanges();
            DbContext.Remove(checkHoaDon);
            DbContext.SaveChanges();
            return ErrorHelper.ThanhCong;
        }

        public IQueryable<HoaDon> GetHoaDon(
            int? month = null,
            int? year = null,
            DateTime? tuNgay = null,
            DateTime? denNgay = null,
            int? giaMin = null,
            int? giaMax = null
            )
        {
            var query = DbContext.HoaDon.Include(x => x.ChiTietHoaDons).OrderByDescending(x => x.ThoiGianTao).AsQueryable();
            if (month.HasValue)
            {
                query = query.Where(x => x.ThoiGianTao.Month == month);
            }
            if (year.HasValue)
            {
                query = query.Where(x => x.ThoiGianTao.Year == year);
            }
            if (tuNgay.HasValue)
            {
                query = query.Where(x => x.ThoiGianTao.Date >= tuNgay);
            }
            if (denNgay.HasValue)
            {
                query = query.Where(x => x.ThoiGianTao.Date <= denNgay);
            }
            if (giaMin.HasValue)
            {
                query = query.Where(x => x.TongTien <= giaMin);
            }
            if (giaMax.HasValue)
            {
                query = query.Where(x => x.TongTien <= giaMax);
            }
            return query;
        }
    }
}