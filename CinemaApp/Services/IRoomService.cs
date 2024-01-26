using CinemaApp.Models;

namespace CinemaApp.Services
{
    public interface IRoomService
    {
        bool saveRoom(RoomEntity room);

        IEnumerable<RoomEntity> GetAllRooms();

        RoomEntity? GetRoomById(int id);
    }
}
