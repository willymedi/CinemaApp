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
        [Route("")]
        public ActionResult PostRoom(RoomEntity room)
        {
            _roomService.saveRoom(room);
            return Ok();
        }
    }
}
