using DAL.Interfaces;
using Model;
using Model.Helper;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Implementation
{
    public class LocalRoomTypeRepository : IRoomTypeRepository
    {
        private List<RoomType> _roomTypes;

        public LocalRoomTypeRepository()
        {
            _roomTypes = new List<RoomType>()
            {
                new RoomType()
                {
                    Id = Model.Helper.RoomTypes.Luxe,
                    BaseCost = 5000,
                    Title = "Люкс"
                },
                new RoomType()
                {
                    Id = Model.Helper.RoomTypes.SemiLuxe,
                    BaseCost = 3000,
                    Title = "Полу-люкс"
                },
                new RoomType()
                {
                    Id = Model.Helper.RoomTypes.Standard,
                    BaseCost = 1000,
                    Title = "Стандарт"
                }
            };
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _roomTypes;
        }

        public RoomType GetById(RoomTypes id)
        {
            return _roomTypes.Single(x => x.Id == id);
        }
    }
}
