using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rooms.Interfaces;
using Rooms.Models;
using Rooms.Services;

namespace Rooms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        private readonly IRepo<int, RoomDetails> _repo;
        private readonly RoomsService _roomService;

        public RoomsController(IRepo<int, RoomDetails> repo, RoomsService service)
        {
            _repo = repo;
            _roomService = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<RoomDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomDetails> Post(RoomDetails rooms)
        {
            RoomDetails roomdetails = _repo.Add(rooms);
            return Created("RoomsList", roomdetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<RoomDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<RoomDetails>> Get()
        {
            IList<RoomDetails> rooms = _repo.GetAll().ToList();
            if (rooms == null)
                return NotFound("Sorry,No rooms available at this moment");
            return Ok(rooms);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateRoomStatus")]
        [ProducesResponseType(typeof(ICollection<RoomDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RoomDetails> Edit(int id, RoomDetails rooms)
        {
            RoomDetails newRoom = _repo.Get(id);
            if (newRoom == null)
                return NotFound(new Error(2, "No such room is present in the given id"));
            newRoom = _repo.Update(rooms);
            if (newRoom == null)
                return BadRequest(new Error(1, "Unable to update room info"));
            return Ok(newRoom);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteRoomDetails")]
        [ProducesResponseType(typeof(ICollection<RoomDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RoomDetails> Delete(int id)
        {
            RoomDetails newRoom = _repo.Get(id);
            if (newRoom == null)
                return NotFound(new Error(2, "No such Room is present in the given id "));
            newRoom = _repo.Delete(id);
            if (newRoom == null)
                return BadRequest(new Error(1, "Unable to delete room"));
            return Ok(newRoom);
        }

        [HttpGet("GetRoomsByType")]
        [ProducesResponseType(typeof(ICollection<RoomDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<RoomDetails>> GetRoomsByType(string type)
        {
            var filteredRooms = _roomService.GetRoomsByType(type);
            if (filteredRooms != null && filteredRooms.Any())
            {
                return Ok(filteredRooms);
            }
            return NotFound("Sorry,No rooms available at this type");

        }

        [HttpGet("GetRoomsByPrice")]
        [ProducesResponseType(typeof(ICollection<RoomDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<RoomDetails>> Get(int min, int max)
        {
            List<RoomDetails> rooms = _roomService.GetRoomsByPrice(min, max);
            if (rooms != null)
                return Ok(rooms);
            return NotFound("No rooms in this range");
        }

        [HttpGet("GetRoomsByLevel")]
        [ProducesResponseType(typeof(ICollection<RoomDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<RoomDetails>> GetRoomsByLevel(string level)
        {
            var filteredRooms = _roomService.GetRoomsByLevel(level);
            if (filteredRooms != null && filteredRooms.Any())
            {
                return Ok(filteredRooms);
            }
            return NotFound("Sorry,No rooms available at " + level + " level");

        }

        [HttpGet("GetRoomsByAvailability")]
        [ProducesResponseType(typeof(ICollection<RoomDetails>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<RoomDetails>> GetRoomsByAvailability(string availability)
        {
            var filteredRooms = _roomService.GetRoomsByAvailability(availability);
            if (filteredRooms != null && filteredRooms.Any())
            {
                return Ok(filteredRooms);
            }
            return NotFound("Sorry,No rooms are available now");

        }
    }
}
