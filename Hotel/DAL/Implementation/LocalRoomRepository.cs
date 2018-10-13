using DAL.Interfaces;
using Model;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class LocalRoomRepository : IRoomRepository
    {
        private IEnumerable<Room> _rooms;
        private IRoomTypeRepository _roomTypeRepository;

        public LocalRoomRepository(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;

            _rooms = new List<Room>()
            {
                new Room()
                {
                    Id = Guid.NewGuid(),
                    Number = 1,
                    RoomTypeId = RoomTypes.Standard,
                    Capacity = 2,
                    Cost = _roomTypeRepository.GetById(RoomTypes.Standard).BaseCost * 2
                },
                new Room()
                {
                    Id = Guid.NewGuid(),
                    Number = 2,
                    RoomTypeId = RoomTypes.Standard,
                    Capacity = 3,
                    Cost = _roomTypeRepository.GetById(RoomTypes.Standard).BaseCost * 3
                },
                new Room()
                {
                    Id = Guid.NewGuid(),
                    Number = 3,
                    RoomTypeId = RoomTypes.SemiLuxe,
                    Capacity = 2,
                    Cost = _roomTypeRepository.GetById(RoomTypes.SemiLuxe).BaseCost * 2
                },
                new Room()
                {
                    Id = Guid.NewGuid(),
                    Number = 4,
                    RoomTypeId = RoomTypes.Luxe,
                    Capacity = 2,
                    Cost = _roomTypeRepository.GetById(RoomTypes.Luxe).BaseCost * 2
                }
            };
        }

        public IEnumerable<Room> GetAll()
        {
            return _rooms;
        }
    }
}
