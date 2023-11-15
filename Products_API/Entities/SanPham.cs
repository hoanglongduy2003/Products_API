namespace Products_API.Entities
{
    public class SanPham
    {
        public int SanPhamID { get; set; }
        public int LoaiSanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public double GiaTien{ get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string KiHieuSanPham { get; set; }
        public virtual LoaiSanPham? LoaiSanPham { get; set; }
    }
}
