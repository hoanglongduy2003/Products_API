using Products_API.Entities;
using Products_API.Helper;

namespace Products_API.IServices
{
    public interface IHoaDonServices
    {
        ErrorHelper AddHoaDon(HoaDon hoaDon);
        ErrorHelper EditHoaDon(HoaDon hoaDon);
        ErrorHelper DeleteHoaDon(int hoaDonID);
        public IQueryable<HoaDon> GetHoaDon
            (
            string? keywords,
            int? month =null,
            int? year = null,
            DateTime? tuNgay = null,
            DateTime? denNgay = null,
            int? giaMin = null,
            int? giaMax = null,
            Pagination pagination = null
            );
    }
}
