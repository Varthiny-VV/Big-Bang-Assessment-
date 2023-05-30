using Booking.Interfaces;
using Booking.Models;
using System.Reflection.Metadata.Ecma335;

namespace Booking.Services
{
    public class BookingService
    {
        private readonly IRepo<int, BookingDetails> _repo;
        public BookingService(IRepo<int, BookingDetails> repo)
        {
            _repo = repo;
        }

        public BookingDetails CheckStatusOfRoom(BookingDetails booking)
        {
            ICollection<BookingDetails> bookingDetails = _repo.GetAll().Where(u=>u.Hotel_Id == booking.Hotel_Id).ToList();
            if (bookingDetails.Count > 0)
            {
                var bookings = bookingDetails.FirstOrDefault(u=>u.Room_Number == booking.Room_Number);
                if (bookings != null )
                {
                    return bookings;
                }

            }
            return null;

        }
       

    }
}
