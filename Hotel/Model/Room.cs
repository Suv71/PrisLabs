using Model.Helper;
using System;

namespace Model
{
    public class Room
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public RoomTypes RoomTypeId { get; set; }
        public double Cost { get; set; }


        public RoomType RoomType { get; set; }

        public Room()
        {
            Id = Guid.NewGuid();
        }
    }
}
