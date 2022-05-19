using System;
using System.Collections.Generic;
using SunbeltRentals1.Data;
using SunbeltRentals1.Models;

namespace SunbeltRentals1.MockData
{
    public class MockAttendee : IAttendee
    {
        public List<Attendee> attendees = new List<Attendee>();

        private IPerson _person;
        private IParty _party;
        private IDrink _drink;
        public MockAttendee(IPerson person, IParty party, IDrink drink)
        {
            _person = person;
            _party = party;
            _drink = drink;
        }

        public void AddAttendee(Attendee attendee)
        {
            attendee.Id = Guid.NewGuid();
            attendees.Add(attendee);
        }

        public Attendee GetAttendee(Guid partyId, Guid personId)
        {
            var attendee = attendees.Find(x => x.PartyId == partyId
                && x.PersonId == personId);
            if(attendee != null)
            {
                attendee.Person = _person.GetPerson(attendee.PersonId);
                attendee.Party = _party.GetParty(attendee.PartyId);
                attendee.Drink = _drink.GetDrink(attendee.DrinkId);
            }
            return attendee; 
        }

        public List<Attendee> GetAttendees(Guid partyId)
        {
            var result = attendees.FindAll(x => x.PartyId == partyId);
            foreach(var attendee in result)
            {
                attendee.Person = _person.GetPerson(attendee.PersonId);
                attendee.Party = _party.GetParty(attendee.PartyId);
                attendee.Drink = _drink.GetDrink(attendee.DrinkId);
            }
            return result;
        }
    }
}
