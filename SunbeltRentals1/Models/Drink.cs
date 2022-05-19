using System;
using System.ComponentModel.DataAnnotations;

namespace SunbeltRentals1.Models
{
    public class Drink
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
