using HotelSearch.API.Common;
using HotelSearch.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HotelSearch.API.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelSearchController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelSearchController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("getAllHotels")]
        public async Task<ActionResult<IEnumerable<HotelModel>>> GetHotels()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        // GET: api/hotels/getHotel/{id}
        [HttpGet("getHotel/{id}")]
        public async Task<ActionResult<HotelModel>> GetHotel(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        // POST: api/hotels/addHotel
        [HttpPost("addHotel")]
        public async Task<ActionResult<HotelModel>> CreateHotel(HotelModel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }

            var createdHotel = await _hotelService.CreateHotelAsync(hotel);
            return CreatedAtAction(nameof(GetHotel), new { id = createdHotel.Id }, createdHotel);
        }

        // PUT: api/hotels/updateHotel/{id}
        [HttpPut("updateHotel/{id}")]
        public async Task<ActionResult> UpdateHotel(int id, HotelModel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            var updatedHotel = await _hotelService.UpdateHotelAsync(hotel);
            if (updatedHotel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/hotels/delete/{id}
        [HttpDelete("deleteHotel/{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            var result = await _hotelService.DeleteHotelAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/hotels/searchHotels
        [HttpPost("searchHotels")]
        public async Task<ActionResult<IEnumerable<HotelModel>>> SearchHotels(SearchParametersModel searchParams)
        {
            var hotels = await _hotelService.SearchHotelsAsync(new LocationModel() { Latitude = searchParams.Latitude, Longitude = searchParams.Longitude });
            var pagedHotels = hotels.Skip((searchParams.PageNumber - 1) * searchParams.PageSize).Take(searchParams.PageSize);
            return Ok(pagedHotels);
        }
    }
}