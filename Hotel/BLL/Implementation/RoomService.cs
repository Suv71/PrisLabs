using System;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Add(Room room)
        {
            if (_roomRepository.GetAll().Any(r => r.Number == room.Number))
            {
                throw new InvalidOperationException("Комната с таким номером уже существует!");
            }
            _roomRepository.Add(room);
        }

        public void Update(Guid roomId, Room room)
        {
            _roomRepository.Update(roomId, room);
        }

        public void Delete(Guid roomId)
        {
            _roomRepository.Delete(roomId);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Room GetById(Guid id)
        {
            return _roomRepository.GetById(id);
        }
    }
}
