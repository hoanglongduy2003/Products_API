using Microsoft.EntityFrameworkCore;

namespace Products_API.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-F4G8HOR\\SQLEXPRESS; Database = QLSanPham; Trusted_Connection = True;Encrypt=false;TrustServerCertificate=true");

        }
    }
}
