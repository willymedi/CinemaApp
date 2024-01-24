using CinemaApp.Models;
using CinemaApp.Repository;

namespace CinemaApp.Services
{
    public class SeatService : ISeatService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly SeatRepository _seatRepository;

        public SeatService(BookingRepository bookingRepository, SeatRepository seatRepository)
        {
            _bookingRepository = bookingRepository;
            _seatRepository = seatRepository;
        }


        public async Task DisabledSeatAndCancelBillboard(int billboardId)
        {
            await _bookingRepository.DisabledSeatAndCancelBooking(billboardId);
        }

        public IEnumerable<SeatEntity> getAllSeats()
        {
            return _seatRepository.getAllSeats();
        }

        public bool postSeat(SeatEntity seat)
        {
            return _seatRepository.saveSeat(seat);
        }
    }
}
