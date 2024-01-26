using CinemaApp.Models;
using CinemaApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("seat")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }


        [HttpGet(Name = "GetSeats")]
        public IEnumerable<SeatEntity> Get()
        {
            return _seatService.getAllSeats();
        }

        [HttpPost(Name = "PostSeat")]
        public ActionResult PostSeat(SeatEntity seat)
        {
            _seatService.postSeat(seat);
            return Ok("El asiento se guardo con exito");
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public ActionResult GetSeatById(int id)
        {
            SeatEntity? seat = _seatService.getSeatById(id);
            if (seat == null)
            {
                return NotFound();
            }
            return Ok(seat);
        }



    }
}
