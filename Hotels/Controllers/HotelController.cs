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
                return NotFound("Sorry,No hotels availbile at this moment");
            return Ok(hotels);
        }

        [HttpGet("GetHotelsByLocation")]
        [ProducesResponseType(typeof(ICollection<HotelDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<HotelDetails>> GetHotelsByLocation(string location)
        {
            IList<HotelDetails> hotels = _repo.GetAll().ToList();
            if (location == null)
                return NotFound("Sorry,No hotels availbile at this location");
            var filteredHotels = _hotelService.GetHotelsByLocation( location);
            return Ok(filteredHotels);
        }
    }
}

