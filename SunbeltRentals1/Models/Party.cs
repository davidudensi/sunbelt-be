using System;
using System.ComponentModel.DataAnnotations;

namespace SunbeltRentals1.Models
{
    public class Party
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime PartyDate { get; set; }
        [Required]
        public String Location { get; set; }
    }
}
