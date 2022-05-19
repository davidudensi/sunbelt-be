using SunbeltRentals1.Data;
using SunbeltRentals1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltRentals1.Services
{
    public class PartyService : IParty
    {
        private readonly SunbeltDBContext _db;
        public PartyService(SunbeltDBContext db)
        {
            _db = db;
        }
        public void AddParty(Party party)
        {
            party.Id = Guid.NewGuid();
            _db.Parties.Add(party);
            _db.SaveChanges();
        }
        public List<Party> GetParties()
        {
            return _db.Parties.ToList();
        }
        public Party GetParty(Guid id)
        {
            var party = _db.Parties.Where(x => x.Id == id).FirstOrDefault();
            return party;
        }
    }
}
