using System.Collections;
using System.Collections.Generic;
using Model.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public RoomTypes Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double BaseCost { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public RoomType()
        {}
    }
}
