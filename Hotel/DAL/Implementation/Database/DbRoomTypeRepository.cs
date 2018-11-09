using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using Model;
using Model.Helper;

namespace DAL.Implementation.Database
{
    public class DbRoomTypeRepository : IRoomTypeRepository
    {
        private readonly DatabaseContext _context;

        public DbRoomTypeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _context.RoomTypes.ToList();
        }

        public RoomType GetById(RoomTypes id)
        {
            return _context.RoomTypes.Single(t => t.Id == id);
        }
    }
}