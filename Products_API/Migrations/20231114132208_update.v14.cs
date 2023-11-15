using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products_API.Migrations
{
    /// <inheritdoc />
    public partial class updatev14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangID",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangID",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangID",
                table: "HoaDon",
                column: "KhachHangID",
                principalTable: "KhachHang",
                principalColumn: "KhachHangID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangID",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangID",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangID",
                table: "HoaDon",
                column: "KhachHangID",
                principalTable: "KhachHang",
                principalColumn: "KhachHangID");
        }
    }
}
