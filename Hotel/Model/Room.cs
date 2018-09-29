using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Room
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public Guid RoomTypeId { get; set; }
        public double Cost { get; set; }

        public Room()
        {
        }
    }
}
