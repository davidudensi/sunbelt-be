using System;
using System.Collections.Generic;
using SunbeltRentals1.Data;
using SunbeltRentals1.Models;

namespace SunbeltRentals1.MockData
{
    

    public class MockParty : IParty
    {
        public List<Party> parties = new List<Party>()
        {
            new Party()
            {
                Id = Guid.NewGuid(),
                PartyDate = new DateTime(2022, 01, 01),
                Location = "Jane's house",
            },
            new Party()
            {
                Id = Guid.NewGuid(),
                PartyDate = new DateTime(2022, 02, 11),
                Location = "David's house",
            }
        };
        public void AddParty(Party party)
        {
            party.Id = Guid.NewGuid();
            parties.Add(party);
        }

        public List<Party> GetParties()
        {
            return parties;
        }

        public Party GetParty(Guid id)
        {
            var party = parties.Find(x => x.Id == id);
            return party;
        }
    }
}
