using System.Diagnostics;
using User.Interfaces;
using User.Models;

namespace User.Services
{
    public class UserRepo : IBaseRepo<string, UserDetails>
    {
        private readonly UserContext _context;

        public UserRepo(UserContext context)
        {
            _context = context;
        }
        public UserDetails Add(UserDetails item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }

        public UserDetails Get(string key)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == key);
            return user;
        }

    }
}
