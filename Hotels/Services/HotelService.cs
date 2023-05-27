using Hotels.Interfaces;
using Hotels.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Services
{
    public class HotelService
    {
        private readonly IRepo<int, HotelDetails> _repo;

        public HotelService(IRepo<int, HotelDetails> repo)
        {
            _repo = repo;
        }

        public List<HotelDetails> GetHotelsByLocation(string location)
        {
            
            List<HotelDetails> hotels = _repo.GetAll().ToList();
            hotels = hotels.Where(h => h.Hotel_Location == location ).ToList();
            return hotels;
        }

    }
}
