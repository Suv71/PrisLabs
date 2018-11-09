using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Implementation.Database
{
    public class DbRoomRepository : IRoomRepository
    {
        private readonly DatabaseContext _context;

        public DbRoomRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Update(Guid roomId, Room room)
        {
            var updatedRoom = _context.Rooms.Single(o => o.Id == roomId);
            updatedRoom.Capacity = room.Capacity;
            updatedRoom.Cost = room.Cost;
            updatedRoom.Number = room.Number;
            updatedRoom.RoomTypeId = room.RoomTypeId;
            _context.SaveChanges();
        }

        public void Delete(Guid roomId)
        {
            var deletingRoom = _context.Rooms.Single(o => o.Id == roomId);
            _context.Rooms.Remove(deletingRoom);
            _context.SaveChanges();
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.Include(o => o.RoomType).ToList();
        }

        public Room GetById(Guid id)
        {
            return _context.Rooms.Include(r => r.RoomType).Single(t => t.Id == id);
        }
    }
}