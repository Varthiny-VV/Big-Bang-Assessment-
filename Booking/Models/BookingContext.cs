using Microsoft.EntityFrameworkCore;

namespace Booking.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BookingDetails> Bookings { get; set; }

    }
}
