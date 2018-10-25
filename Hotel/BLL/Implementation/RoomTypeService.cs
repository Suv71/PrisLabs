using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using Model.Helper;

namespace BLL.Implementation
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _roomTypeRepository.GetAll();
        }

        public RoomType GetById(RoomTypes id)
        {
            return _roomTypeRepository.GetById(id);
        }
    }
}
