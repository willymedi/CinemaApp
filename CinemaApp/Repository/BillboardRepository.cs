using CinemaApp.Exceptions;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repository
{
    public class BillboardRepository
    {
        private readonly DataContext _context;

        public BillboardRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CancelBillboardById(int billboardId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var billboardToCancel = await _context.Billboard.FirstOrDefaultAsync(billboard => billboard.Id == billboardId);
                if (billboardToCancel == null)
                {
                    transaction.Rollback();
                    return;
                }
                if (billboardToCancel.StartTime < DateTime.Now.TimeOfDay)
                {
                    transaction.Rollback();
                    throw new BillboardFailedToCancel("No se puede cancelar funciones de la cartelera con fecha anterior a la actual");
                }
                var bookings = await  _context.Booking
                    .Where(booking => booking.BillboardId == billboardId)
                    .ToListAsync();
                if (bookings == null || bookings.Count == 0)
                {
                    transaction.Rollback();
                    return;
                }
                var billboard = await _context.Billboard
                    .Include(billboard => billboard.Room)
                    .FirstOrDefaultAsync(billboard => billboard.Id == billboardId);

                if (billboard == null)
                {
                    transaction.Rollback();
                }

                foreach (var booking in bookings)
                {
                    booking.Status = false;
                    booking.Billboard.Status = false;
                    booking.Seat.Status = true;
                }
                await _context.SaveChangesAsync();
                transaction.Commit();
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Booking cancel for customer: {booking.Customer.Name}");
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public Dictionary<string, (int Occupied, int Availables)> GetAvailablesAndBusySeatsByRoomToday()
        {
            var bookingsByRoom = _context.Booking
                .Where(booking => booking.Date.Date == DateTime.Now.Date)
                .GroupBy(booking => booking.Billboard.Room.Name)
                .Select(group => new
                {
                    Room = group.Key,
                    Occupied = group.Count(),
                })
                .ToList();
            var rooms = _context.Room.ToList();
            var roomsByBillboard = new Dictionary<string, (int Occupied, int Availables)>();
            foreach (var room in rooms)
            {
                var occupieds = bookingsByRoom
                    .Where(booking => booking.Room == room.Name)
                    .Select(booking => booking.Occupied)
                    .SingleOrDefault();

                var availables = room.Number - (occupieds > 0 ? occupieds : 0);

                roomsByBillboard[room.Name] = (occupieds, availables);
            }
            return roomsByBillboard;
        }
    }
}
