using CinemaApp.Models;
using CinemaApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost(Name = "PostRoom")]
        public ActionResult PostRoom(RoomEntity room)
        {
            _roomService.saveRoom(room);
            return Ok();
        }

        [HttpGet(Name = "GetAllRooms")]
        public IEnumerable<RoomEntity> GetAllRoom()
        {
            return _roomService.GetAllRooms();
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public ActionResult<RoomEntity> GetRoomById(int id)
        {
            RoomEntity? room = _roomService.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }
    }
}
