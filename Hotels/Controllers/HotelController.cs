using Hotels.Interfaces;
using Hotels.Models;
using Hotels.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IRepo<int, HotelDetails> _repo;
        private readonly HotelService _hotelService;

        public HotelController(IRepo<int, HotelDetails> repo, HotelService service)
        {
            _repo = repo;
            _hotelService = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ICollection<HotelDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelDetails> Post(HotelDetails hotel)
        {
            HotelDetails hoteldetails = _repo.Add(hotel);
            return Created("HotelsList", hoteldetails);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<HotelDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDetails>> Get()
        {
            IList<HotelDetails> hotels = _repo.GetAll().ToList();
            if (hotels == null)
                return NotFound("Sorry,No hotels available at this moment");
            return Ok(hotels);
        }

        [HttpGet("GetHotelsByLocation")]
        [ProducesResponseType(typeof(ICollection<HotelDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDetails>> GetHotelsByLocation(string location)
        {
            var filteredHotels = _hotelService.GetHotelsByLocation(location);
            if(filteredHotels != null && filteredHotels.Any())
            {
                return Ok(filteredHotels);
            }
            return NotFound("Sorry,No hotels available at this location");
            
        }

        [HttpGet("GetHotelsByAmenities")]
        [ProducesResponseType(typeof(ICollection<HotelDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDetails>> GetHotelsByAmenities(string amenities)
        {
            var filteredHotels = _hotelService.GetHotelsByAmenities(amenities);
            if (filteredHotels != null && filteredHotels.Any())
            {
                return Ok(filteredHotels);
            }
            return NotFound("Sorry,No hotels available with the specified amenities");

        }
    }
}

