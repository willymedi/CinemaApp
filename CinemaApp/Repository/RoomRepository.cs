using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public class RoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        public bool saveRoom(RoomEntity room)
        {
            _context.Room.Add(room);
            _context.SaveChanges();
            return true;

        }

        public IEnumerable<RoomEntity> GetAll()
        {
            return _context.Room.Where(room => room.Status).ToArray();
        }

        public RoomEntity? Get(int id)
        {
            return _context.Room.Find(id);
        }
    }
}
