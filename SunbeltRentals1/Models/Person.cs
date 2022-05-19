using System;
using System.ComponentModel.DataAnnotations;

namespace SunbeltRentals1.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }
    }
}
