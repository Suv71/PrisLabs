using DAL.Interfaces;
using Model;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DAL.Implementation
{
    public class LocalRoomRepository : IRoomRepository
    {
        private readonly List<Room> _rooms;

        public LocalRoomRepository(IRoomTypeRepository roomTypeRepository)
        {
            _rooms = new List<Room>
            {
                new Room()
                {
                    Id = Guid.NewGuid(),
                    Number = 1,
                    RoomTypeId = RoomTypes.Standard,
                    Capacity = 2,
                    Cost = roomTypeRepository.GetById(RoomTypes.Standard).BaseCost * 2
                },
                new Room()
                {
                    Id = Guid.NewGuid(),
                    Number = 2,
                    RoomTypeId = RoomTypes.Standard,
                    Capacity = 3,
                    Cost = roomTypeRepository.GetById(RoomTypes.Standard).BaseCost * 3
                },
                new Room()
                {
                    Id = Guid.NewGuid(),
                    Number = 3,
                    RoomTypeId = RoomTypes.SemiLuxe,
                    Capacity = 2,
                    Cost = roomTypeRepository.GetById(RoomTypes.SemiLuxe).BaseCost * 2
                },
                new Room()
                {
                    Id = Guid.NewGuid(),
                    Number = 4,
                    RoomTypeId = RoomTypes.Luxe,
                    Capacity = 2,
                    Cost = roomTypeRepository.GetById(RoomTypes.Luxe).BaseCost * 2
                }
            };
        }

        public void Add(Room room)
        {
            _rooms.Add(room);
        }

        public void Update(Guid roomId, Room room)
        {
            var roomForUpdate = _rooms.Single(r => r.Id == roomId);
            roomForUpdate.Number = room.Number;
            roomForUpdate.Capacity = room.Capacity;
            roomForUpdate.RoomTypeId = room.RoomTypeId;
            roomForUpdate.Cost = room.Cost;
        }

        public void Delete(Guid roomId)
        {
            var roomForDelete = _rooms.Single(r => r.Id == roomId);
            _rooms.Remove(roomForDelete);
        }

        public IEnumerable<Room> GetAll()
        {
            return _rooms;
        }

        public Room GetById(Guid id)
        {
            return _rooms.Single(x => x.Id == id);
        }
    }
}
