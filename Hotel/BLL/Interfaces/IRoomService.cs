using Model;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IRoomService
    {
        void Add(Room room);

        void Update(Guid roomId, Room room);

        void Delete(Guid roomId);

        IEnumerable<Room> GetAll();

        Room GetById(Guid id);
    }
}
