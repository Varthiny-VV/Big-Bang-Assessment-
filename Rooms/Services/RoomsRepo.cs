using Rooms.Interfaces;
using Rooms.Models;
using System.Diagnostics;

namespace Rooms.Services
{
    public class RoomsRepo : IRepo<int, RoomDetails>
    {
        private readonly RoomsContext _context;

        public RoomsRepo(RoomsContext context)
        {
            _context = context;
        }
        public RoomDetails Add(RoomDetails item)
        {
            _context.Rooms.Add(item);
            _context.SaveChanges();
            return item;
        }
        public ICollection<RoomDetails> GetAll()
        {
            return _context.Rooms.ToList();
        }
        public RoomDetails Get(int key)
        {
            RoomDetails room = _context.Rooms.SingleOrDefault(p => p.Room_Id == key);
            return room;
        }

        public RoomDetails Delete(int key)
        {
            try
            {
                var room = Get(key);
                if (room != null)
                {
                    _context.Rooms.Remove(room);
                    _context.SaveChanges();
                    return room;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        public RoomDetails Update(RoomDetails item)
        {
            try
            {
                var room = Get(item.Room_Id);
                if (room != null)
                {
                    room.Room_Number = item.Room_Number;
                    room.Room_Price = item.Room_Price;
                    room.Room_Level = item.Room_Level;
                    room.Room_Type = item.Room_Type;
                    room.Room_Availability = item.Room_Availability;
                    _context.SaveChanges();
                    return room;
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
