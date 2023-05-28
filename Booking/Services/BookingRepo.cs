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
            BookingDetails product = _context.Bookings.SingleOrDefault(p => p.Booking_Id == key);
            return product;
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

        public BookingDetails Update(BookingDetails item)
        {
            try
            {
                var updateBooking = Get(item.Booking_Id);
                if (updateBooking != null)
                {
                    updateBooking.Room_Number = item.Room_Number;
                    updateBooking.Hotel_Name = item.Hotel_Name;
                    updateBooking.UserName = item.UserName;
                    updateBooking.Room_Type = item.Room_Type;
                    updateBooking.Room_Level = item.Room_Level;
                    updateBooking.CheckIn_DateAndTime = item.CheckIn_DateAndTime;
                    updateBooking.CheckOut_DateAndTime = item.CheckOut_DateAndTime;
                    _context.SaveChanges();
                    return updateBooking;
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
