using CinemaApp.Models;

namespace CinemaApp.Services
{
    public interface ISeatService
    {
        Task DisabledSeatAndCancelBillboard(int billboardId);

        IEnumerable<SeatEntity> getAllSeats();

        bool postSeat(SeatEntity seat);

        SeatEntity? getSeatById(int seatId);

    }
}
