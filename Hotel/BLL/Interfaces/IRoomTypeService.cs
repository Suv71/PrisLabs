using Model;
using System.Collections.Generic;
using Model.Helper;

namespace BLL.Interfaces
{
    public interface IRoomTypeService
    {
        IEnumerable<RoomType> GetAll();

        RoomType GetById(RoomTypes id);
    }
}
