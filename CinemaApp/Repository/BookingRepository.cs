using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public class BookingRepository
    {
        private readonly DataContext _context;
        public BookingRepository(DataContext context )
        {
            _context = context;
        }

        public async Task DisabledSeatAndCancelBooking(int bookingId)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var booking = _context.Set<BookingEntity>().FirstOrDefault(e => e.Id == bookingId);
                if (booking == null)
                {
                    transaction.Rollback();
                    return;
                }
                booking.Seat.Status = false;
                booking.Status = false;
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public List<BookingEntity>  GetEntitiesByHorrorGenreAndRangeDate(DateTime startDate, DateTime endDate)
        {
            return _context.Booking.Where(booking =>
                booking.Billboard.Movie.Genre == MovieGenreEnum.HORROR &&
                booking.Date >= startDate &&
                booking.Date <= endDate)
            .ToList();
        }
    }
}
