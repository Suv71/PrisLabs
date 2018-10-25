using Model;
using Model.Helper;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRoomTypeRepository
    {
        IEnumerable<RoomType> GetAll();
        RoomType GetById(RoomTypes id);
    }
}
