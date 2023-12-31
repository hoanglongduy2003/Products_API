﻿namespace Products_API.Entities
{
    public class HoaDon
    {
        public int HoaDonID { get; set; }
        public int KhachHangID { get; set; }
        public string TenHoaDon { get; set; }
        public string? MaGiaoDich { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public string? GhiChu { get; set; }
        public double? TongTien { get; set; }
        public KhachHang? KhachHang { get; set; }
        public IEnumerable<ChiTietHoaDon>? ChiTietHoaDons { get; set; }
    }
}
