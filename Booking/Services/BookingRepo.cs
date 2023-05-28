using Booking.Interfaces;
using Booking.Models;
using System.Diagnostics;

namespace Booking.Services
{
    public class BookingRepo : IRepo<int, BookingDetails>
    {
        private readonly BookingContext _context;

        public BookingRepo(BookingContext context)
        {
            _context = context;
        }
        public BookingDetails Add(BookingDetails item)
        {
            _context.Bookings.Add(item);
            _context.SaveChanges();
            return item;
        }
        public ICollection<BookingDetails> GetAll()
        {
            return _context.Bookings.ToList();
        }
        public BookingDetails Get(int key)
        {
            BookingDetails booking = _context.Bookings.SingleOrDefault(p => p.Booking_Id == key);
            return booking;
        }
        public BookingDetails Delete(int key)
        {
            try
            {
                var deleteBooking = Get(key);
                if (deleteBooking != null)
                {
                    _context.Bookings.Remove(deleteBooking);
                    _context.SaveChanges();
                    return deleteBooking;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        
    }

}
