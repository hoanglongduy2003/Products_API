namespace Products_API.Entities
{
    public class ChiTietHoaDon
    {
        public int ChiTietHoaDonID { get; set; }
        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public string DVT { get; set; }
        public double? ThanhTien { get; set; }
        public virtual HoaDon? HoaDon { get; set; }
        public virtual SanPham? SanPham { get; set; }
    }
}
