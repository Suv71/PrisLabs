using Model;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRoomRepository
    {
        void Add(Room room);

        void Update(Guid roomId, Room room);

        void Delete(Guid roomId);

        IEnumerable<Room> GetAll();
    }
}
