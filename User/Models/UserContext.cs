using Microsoft.EntityFrameworkCore;

namespace User.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserDetails> Users { get; set; }
       
    }
}
