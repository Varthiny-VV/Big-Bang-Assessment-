using Hotels.Interfaces;
using Hotels.Models;

namespace Hotels.Services
{
    public class HotelRepo : IRepo<int, HotelDetails>
    {
        private readonly HotelContext _context;

        public HotelRepo(HotelContext context)
        {
            _context = context;
        }
        public HotelDetails Add(HotelDetails item)
        {
            _context.Hotels.Add(item);
            _context.SaveChanges();
            return item;
        }
        public ICollection<HotelDetails> GetAll()
        {
            return _context.Hotels.ToList();
        }
    }
}