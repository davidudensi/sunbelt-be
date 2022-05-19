using SunbeltRentals1.Data;
using SunbeltRentals1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltRentals1.Services
{
    public class DrinkService : IDrink
    {
        private readonly SunbeltDBContext _db;
        public DrinkService(SunbeltDBContext db)
        {
            _db = db;
        }
        public void AddDrink(Drink drink)
        {
            drink.Id = Guid.NewGuid();
            _db.Add(drink);
            _db.SaveChanges();
        }
        public Drink GetDrink(Guid id)
        {
            var drink = _db.Drinks.Where(x => x.Id == id).FirstOrDefault();
            return drink;
        }
        public List<Drink> GetDrinks()
        {
            return _db.Drinks.ToList();
        }
    }
}
