﻿using CinemaApp.Models;
using CinemaApp.Repository;

namespace CinemaApp.Services
{
    public class RoomService : IRoomService
    {
        private readonly RoomRepository _roomRepository;

        public RoomService(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public bool saveRoom(RoomEntity room)
        {
            return _roomRepository.saveRoom(room);
        }

        public IEnumerable<RoomEntity> GetAllRooms()
        {
            return _roomRepository.GetAll();
        }

        public RoomEntity? GetRoomById(int id)
        {
            return _roomRepository.Get(id);
        }
    }
}
