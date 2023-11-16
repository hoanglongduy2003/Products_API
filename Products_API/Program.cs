using Products_API.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var DbContext = new AppDbContext();
//List<ChiTietHoaDon> cthd = new List<ChiTietHoaDon>
//{
//    new ChiTietHoaDon
//    {
//        SanPhamID= 1,
//        SoLuong= 15,
//        DVT= "gói"
//    },
//    new ChiTietHoaDon
//    {
//        SanPhamID= 2,
//        SoLuong= 9,
//        DVT= "cái"
//    },
//    new ChiTietHoaDon
//    {
//        SanPhamID= 3,
//        SoLuong= 5,
//        DVT= "hộp"
//    }
//};
//for (int i = 0; i < 94; i++)
//    {
//        var id = 1;
//        if (i % 2 == 0) id = 2;
//        var newHocSinh = new HoaDon()
//        {
//            KhachHangID= 3,
//            TenHoaDon= $"Hóa đơn {i+1}",
//            GhiChu= "Lẩu thái siêu siêu cay"
//        };
//        DbContext.HoaDon.Add(newHocSinh);
//    }
//    DbContext.SaveChanges();

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
