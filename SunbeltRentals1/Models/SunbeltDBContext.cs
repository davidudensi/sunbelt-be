using System;
using Microsoft.EntityFrameworkCore;

namespace SunbeltRentals1.Models
{
    public class SunbeltDBContext : DbContext
    {
        public SunbeltDBContext(DbContextOptions<SunbeltDBContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Party> Parties { get; set; }
    }
}
