using System;
using System.Collections.Generic;
using SunbeltRentals1.Data;
using SunbeltRentals1.Models;

namespace SunbeltRentals1.MockData
{
    public class MockDrink : IDrink
    {
        public List<Drink> drinks = new List<Drink>()
        {
            new Drink()
            {
                Id = Guid.NewGuid(),
                Name = "Apple juice",
            },
            new Drink()
            {
                Id = Guid.NewGuid(),
                Name = "Orange juice",
            }
        };

        public void AddDrink(Drink drink)
        {
            drink.Id = Guid.NewGuid();
            drinks.Add(drink);
        }

        public Drink GetDrink(Guid id)
        {
            var drink = drinks.Find(x => x.Id == id);
            return drink;
        }

        public List<Drink> GetDrinks()
        {
            return drinks;
        }
    }
}
