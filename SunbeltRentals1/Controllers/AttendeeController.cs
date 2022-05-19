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
    public class AttendeeController : Controller
    {
        private IAttendee _attendee;
        public AttendeeController(IAttendee attendee)
        {
            _attendee = attendee;
        }

        // GET: api/values
        [HttpGet("party/{partyId}")]
        public IActionResult GetPartyAttendees(Guid partyId)
        {
            var attendees = _attendee.GetAttendees(partyId);
            if (attendees.Count == 0) return NotFound("No attendee has registered");
            return Ok(attendees);
        }

        // GET api/values/5
        [HttpGet("{partyId}/{personId}")]
        public IActionResult Get(Guid partyId, Guid personId)
        {
            var attendee = _attendee.GetAttendee(partyId, personId);
            if (attendee != null) return NotFound("Attendee not found");
            return Ok(attendee);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Attendee attendee)
        {
            try
            {
                _attendee.AddAttendee(attendee);
                return Ok(_attendee.GetAttendee(attendee.PartyId, attendee.PersonId));
            }
            catch (Exception ex)
            {
                return BadRequest("An error occured " + ex.Message);
            }
        }
    }
}
