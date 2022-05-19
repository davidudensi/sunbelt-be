using System;
using System.ComponentModel.DataAnnotations;

namespace SunbeltRentals1.Models
{
    public class Attendee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid PartyId { get; set; }
        [Required]
        public Guid PersonId { get; set; }
        public Guid DrinkId { get; set; }

        public virtual Party Party { get; set; }
        public virtual Person Person { get; set; }
        public virtual Drink Drink { get; set; }
    }
}
