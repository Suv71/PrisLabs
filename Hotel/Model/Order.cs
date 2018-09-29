using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public DateTime LeavedDate { get; set; }
        public bool IsActive { get; set; }

        public Order()
        {
        }
    }
}
