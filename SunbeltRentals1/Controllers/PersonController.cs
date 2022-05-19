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
    public class PersonController : ControllerBase
    {
        private IPerson _person;

        public PersonController (IPerson person)
        {
            _person = person;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var people = _person.GetPeople();
            if (people.Count == 0)
                return NotFound("No person listed");
            return Ok(people);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_person.GetPerson(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            try
            {
                _person.AddPerson(person);
                return Ok(person);
            }catch(Exception ex)
            {
                return BadRequest("Unable to add person " + ex.Message);
            }
        }
    }
}
