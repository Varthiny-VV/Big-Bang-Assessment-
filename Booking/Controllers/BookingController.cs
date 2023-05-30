using Booking.Interfaces;
using Booking.Models;
using Booking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IRepo<int, BookingDetails> _repo;
        private readonly BookingService _bookingService;
        public BookingController(IRepo<int, BookingDetails> repo, BookingService service)
        {
            _repo = repo;
            _bookingService = service;


        }

        //[Authorize(Roles = "Customer")]
        [HttpPost("BookRooms")]
        [ProducesResponseType(typeof(ICollection<BookingDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDetails> Post(BookingDetails bookings)
        {
            var roomStatus = _bookingService.CheckStatusOfRoom(bookings);
            if(roomStatus == null)
            {
                BookingDetails bookingDetails = _repo.Add(bookings);
                if(bookingDetails == null)
                {
                    return Created("BookingsList", bookingDetails);
                }
                return BadRequest(new Error(1, "Unable to book room"));
            }
            return NotFound(new Error(2, "Sorry,This room is already booked "));


        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllBookedRoomsDetails")]
        [ProducesResponseType(typeof(ICollection<BookingDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<BookingDetails>> Get()
        {
            IList<BookingDetails> bookings = _repo.GetAll().ToList();
            if (bookings == null)
                return NotFound("Sorry,There is no rooms available right now");
            return Ok(bookings);
        }

        [Authorize(Roles = "Customer")]
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
