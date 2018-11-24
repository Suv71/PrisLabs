using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PassportData { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }

    }
}
