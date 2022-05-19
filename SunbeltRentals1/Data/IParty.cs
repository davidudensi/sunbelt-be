using System;
using System.Collections.Generic;
using SunbeltRentals1.Models;

namespace SunbeltRentals1.Data
{
    public interface IParty
    {
        List<Party> GetParties();

        Party GetParty(Guid id);

        void AddParty(Party party);
    }
}
