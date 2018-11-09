using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Database
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<RoomType> RoomTypes { get; set; }

        /// <summary/>
        public DatabaseContext(DbContextOptions options) : base(options)
        {}
    }
}