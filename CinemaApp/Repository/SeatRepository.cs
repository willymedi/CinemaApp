using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public class SeatRepository
    {
        private readonly DataContext _context;

        public SeatRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SeatEntity> getAllSeats()
        {
            return _context.Seatings.Where(seat => seat.Status).ToArray();
        }

        public bool saveSeat(SeatEntity seat)
        {
            _context.Seatings.Add(seat);
            _context.SaveChanges();
            return true;
        }
    }
}
