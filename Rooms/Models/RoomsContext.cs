using Microsoft.EntityFrameworkCore;

namespace Rooms.Models
{
    public class RoomsContext : DbContext
    {
        
            public RoomsContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<RoomDetails> Rooms { get; set; }

        
    }
}
