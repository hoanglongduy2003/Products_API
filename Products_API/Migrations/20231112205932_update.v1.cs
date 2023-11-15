using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products_API.Migrations
{
    /// <inheritdoc />
    public partial class updatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_SanPham_SanPhamID1",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_SanPhamID1",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "SanPhamID1",
                table: "ChiTietHoaDon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SanPhamID1",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_SanPhamID1",
                table: "ChiTietHoaDon",
                column: "SanPhamID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_SanPham_SanPhamID1",
                table: "ChiTietHoaDon",
                column: "SanPhamID1",
                principalTable: "SanPham",
                principalColumn: "SanPhamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
