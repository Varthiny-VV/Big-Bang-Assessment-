using Microsoft.EntityFrameworkCore;

namespace Hotels.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<HotelDetails> Hotels { get; set; }
    }
}
