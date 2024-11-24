
using BookingSystem.BLL.Interface;
using BookingSystem.Common.Exceptions;
using BookingSystem.DAL;
using BookingSystem.DAL.Common;
using BookingSystem.DAL.ConfigModel;
using BookingSystem.DAL.DbModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookingSystem.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : BaseController
    {
        private readonly IHotelLogic     _hotelLogic;

        public HotelController(IHotelLogic hotelLogic)
        {
            _hotelLogic = hotelLogic;
        }

        [HttpPost]
        [SwaggerOperation(
    Summary = "Create an entity",
    Description = "This endpoint requires a custom header called `X-Custom-Header`.")]
        public async Task<IActionResult> CreateOrUpdateAsync(HotelDTO hotel)
        {
            try
            {
              
               var result =await _hotelLogic.CreateOrUpdateAsync(hotel);
                return SaveOk(result.Id);
            }
            catch (Exception ex) when (ex is InvalidDataFormatException or DuplicateDataException)
            {
                return ProcessError(ex.Message);
            }
            catch (Exception ex)
            {
                return SaveError();
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(string Id)
        {
            try
            {
                await _hotelLogic.DeleteAsync(Id);
                return DeleteOk(Id);
            }
            catch (Exception ex)
            {
                return DeleteError();
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            try
            {
                var result = await _hotelLogic.GetByIdAsync(Id);
                return RetriveOk(result);
            }
            catch (Exception ex)
            {
                return RetriveError();
            }
        }

        [HttpPost("list")]
        public IActionResult GetPaging([FromBody] DAL.Common.Pagination paging)
        {
            try
            {
                var result = _hotelLogic.GetPaging(paging);
                return RetriveOk(result);
            }
            catch (Exception ex)
            {
                return RetriveError();
            }
        }

    }
}
