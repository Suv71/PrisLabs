using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Database
{
    public class DatabaseInitializer
    {
        private readonly DatabaseContext _context;

        public DatabaseInitializer(DatabaseContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.Migrate();

            if (!_context.RoomTypes.Any())
            {
                var roomTypes = new List<RoomType>
                {
                    new RoomType
                    {
                        Id = Model.Helper.RoomTypes.Luxe,
                        BaseCost = 5000,
                        Title = "Люкс"
                    },
                    new RoomType
                    {
                        Id = Model.Helper.RoomTypes.SemiLuxe,
                        BaseCost = 3000,
                        Title = "Полу-люкс"
                    },
                    new RoomType
                    {
                        Id = Model.Helper.RoomTypes.Standard,
                        BaseCost = 1000,
                        Title = "Стандарт"
                    }
                };
                _context.RoomTypes.AddRange(roomTypes);
            }

            _context.SaveChanges();
        }
    }
}