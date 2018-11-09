using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Room))]
        public Guid RoomId { get; set; }

        [Required]
        public DateTime ArrivedDate { get; set; }

        [Required]
        public DateTime LeavedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public Room Room { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}
