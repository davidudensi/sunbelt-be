using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SunbeltRentals1.Data;
using SunbeltRentals1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SunbeltRentals1.Controllers
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        private IDrink _drink;

        public DrinkController(IDrink drink)
        {
            _drink = drink;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var drinks = _drink.GetDrinks();
            if (drinks.Count == 0)
                return NotFound("No drinks added");
            return Ok(drinks);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var drink = _drink.GetDrink(id);
            if (drink != null) return Ok(drink);
            return NotFound("Drink not found");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Drink drink)
        {
            try
            {
                _drink.AddDrink(drink);
                return Ok(drink);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occured " + ex.Message);
            }
        }
    }
}
