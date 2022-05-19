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
    [ApiController]
    [Route("api/[controller]")]
    public class PartyController : ControllerBase
    {
        private IParty _party;
        public PartyController(IParty party)
        {
            _party = party;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var parties = _party.GetParties();
            if (parties.Count == 0)
                return NotFound("No parties listed");
            return Ok(parties);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var party = _party.GetParty(id);
            if (party != null) return Ok(party);
            return NotFound("Party not found");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Party party)
        {
            try
            {
                _party.AddParty(party);
                return Ok(party);
            }catch(Exception ex)
            {
                return BadRequest("An error occured " + ex.Message);
            }
        }
    }
}
