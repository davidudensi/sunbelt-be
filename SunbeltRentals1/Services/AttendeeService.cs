using SunbeltRentals1.Data;
using SunbeltRentals1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltRentals1.Services
{
    public class AttendeeService : IAttendee
    {
        private readonly SunbeltDBContext _db;
        private IPerson _person;
        private IParty _party;
        private IDrink _drink;
        public AttendeeService(SunbeltDBContext db, IPerson person, IParty party, IDrink drink)
        {
            _db = db;
            _person = person;
            _party = party;
            _drink = drink;
        }
        public void AddAttendee(Attendee attendee)
        {
            attendee.Id = Guid.NewGuid();
            _db.Attendees.Add(attendee);
            _db.SaveChanges();
        }
        public Attendee GetAttendee(Guid partyId, Guid personId)
        {
            var attendee = _db.Attendees.Where(x => x.PartyId == partyId && x.PersonId == personId).FirstOrDefault();
            return attendee;
        }
        public List<Attendee> GetAttendees(Guid partyId)
        {
            //return _db.Attendees.Where(x => x.PartyId == partyId).ToList();
            var result = _db.Attendees.Where(x => x.PartyId == partyId).ToList();
            foreach (var attendee in result)
            {
                attendee.Person = _person.GetPerson(attendee.PersonId);
                attendee.Party = _party.GetParty(attendee.PartyId);
                attendee.Drink = _drink.GetDrink(attendee.DrinkId);
            }
            return result;
        }
    }
}
