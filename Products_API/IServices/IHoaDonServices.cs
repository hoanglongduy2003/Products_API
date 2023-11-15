using Products_API.Entities;
using Products_API.Helper;

namespace Products_API.IServices
{
    public interface IHoaDonServices
    {
        ErrorHelper AddHoaDon(HoaDon hoaDon);
        ErrorHelper EditHoaDon(HoaDon hoaDon);
        ErrorHelper DeleteHoaDon(int hoaDonID);
    }
}
