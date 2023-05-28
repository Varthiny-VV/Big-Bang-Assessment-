using Booking.Interfaces;
using Booking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IRepo<int, BookingDetails> _repo;
        

        public BookingController(IRepo<int, BookingDetails> repo)
        {
            _repo = repo;
            
        }

        [HttpPost("BookRooms")]
        [ProducesResponseType(typeof(ICollection<BookingDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDetails> Post(BookingDetails bookings)
        {
            BookingDetails bookingDetails = _repo.Add(bookings);
            return Created("BookingsList", bookingDetails);
        }

        [HttpGet("GetAllBookingDetails")]
        [ProducesResponseType(typeof(ICollection<BookingDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<BookingDetails>> Get()
        {
            IList<BookingDetails> bookings = _repo.GetAll().ToList();
            if (bookings == null)
                return NotFound("Sorry,There is no rooms available right now");
            return Ok(bookings);
        }

        [HttpPut("UpdateBookingStatus")]
        [ProducesResponseType(typeof(ICollection<BookingDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookingDetails> Edit(int id, BookingDetails bookings)
        {
            BookingDetails newBooking = _repo.Get(id);
            if (newBooking == null)
                return NotFound(new Error(2, "No such booking is present in the given id"));
            newBooking = _repo.Update(bookings);
            if (newBooking == null)
                return BadRequest(new Error(1, "Unable to update booking info"));
            return Ok(newBooking);
        }
        [HttpDelete("DeleteBookingDetails")]
        [ProducesResponseType(typeof(ICollection<BookingDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookingDetails> Delete(int id)
        {
            BookingDetails newBooking = _repo.Get(id);
            if (newBooking == null)
                return NotFound(new Error(2, "No such Booking is present in the given id "));
            newBooking = _repo.Delete(id);
            if (newBooking == null)
                return BadRequest(new Error(1, "Unable to delete booking info"));
            return Ok(newBooking);
        }
    }
}
