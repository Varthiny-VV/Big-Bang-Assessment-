using Rooms.Interfaces;
using Rooms.Models;

namespace Rooms.Services
{
    public class RoomsService
    {
        private readonly IRepo<int, RoomDetails> _repo;

        public RoomsService(IRepo<int, RoomDetails> repo)
        {
            _repo = repo;
        }

        public List<RoomDetails> GetRoomsByType(string type)
        {

            List<RoomDetails> rooms = _repo.GetAll().ToList();
            rooms = rooms.Where(r => r.Room_Type.ToLower() == type.ToLower()).ToList();
            return rooms;

        }

        public List<RoomDetails> GetRoomsByPrice(int min, int max)
        {
            if (max < min)
                return null;
            List<RoomDetails> rooms = _repo.GetAll().ToList();
            rooms = rooms.Where(p => p.Room_Price >= min && p.Room_Price <= max).ToList();
            return rooms;
        }

        public List<RoomDetails> GetRoomsByLevel(string level)
        {

            List<RoomDetails> rooms = _repo.GetAll().ToList();
            rooms = rooms.Where(r => r.Room_Level.ToLower() == level.ToLower()).ToList();
            return rooms;

        }

        public List<RoomDetails> GetRoomsByAvailability(string availability)
        {

            List<RoomDetails> rooms = _repo.GetAll().ToList();
            rooms = rooms.Where(r => r.Room_Availability.ToLower() == availability.ToLower()).ToList();
            return rooms;

        }

        public List<RoomDetails> GetRoomsByHotelId(int hotel_id)
        {

            List<RoomDetails> rooms = _repo.GetAll().ToList();
            rooms = rooms.Where(r => r.Hotel_Id == hotel_id).ToList();
            return rooms;

        }





    }
}
