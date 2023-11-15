namespace Products_API.Entities
{
    public class LoaiSanPham
    {
        public int LoaiSanPhamID { get; set; }
        public string TenLoai { get; set; }
        public virtual IEnumerable<SanPham>? SanPhams { get; set; }
    }
}
