using System;
using System.Collections.Generic;
using SunbeltRentals1.Models;

namespace SunbeltRentals1.Data
{
    public interface IDrink
    {
        List<Drink> GetDrinks();

        Drink GetDrink(Guid id);

        void AddDrink(Drink drink);
    }
}
