using Model.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public double Cost { get; set; }

        [ForeignKey(nameof(RoomType))]
        public RoomTypes RoomTypeId { get; set; }


        public RoomType RoomType { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Room()
        {
            Id = Guid.NewGuid();
        }
    }
}
