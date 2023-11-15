using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_API.Entities;
using Products_API.Helper;
using Products_API.IServices;
using Products_API.Services;

namespace Products_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonServices hoaDonServices;
        public HoaDonController()
        {
            hoaDonServices = new HoaDonServices();
        }

        [HttpPost("add")]
        public IActionResult AddHoaDon([FromBody] HoaDon hoaDon)
        {
            var result = hoaDonServices.AddHoaDon(hoaDon);
            if (result == ErrorHelper.ThanhCong)
            {
                return Ok("Them thanh cong!");
            }
            else
            {
                return BadRequest("Them that bai!");
            }
        }
        [HttpPatch("edit")]
        public IActionResult SuaHoaDon([FromBody] HoaDon hoaDon)
        {
            var result = hoaDonServices.EditHoaDon(hoaDon);
            if (result == ErrorHelper.ThanhCong)
            {
                return Ok("Sua thanh cong!");
            }
            else
            {
                return BadRequest("Sua that bai!");
            }
        }
        [HttpDelete("delete/{hoaDonID}")]
        public IActionResult DeleteHoaDon(int hoaDonID)
        {
            var result = hoaDonServices.DeleteHoaDon(hoaDonID);
            if (result == ErrorHelper.ThanhCong)
            {
                return Ok("Xoa thanh cong!");
            }
            else
            {
                return BadRequest("Xoa that bai!");
            }
        }
    }
}
