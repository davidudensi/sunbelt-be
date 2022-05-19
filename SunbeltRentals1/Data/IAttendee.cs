using System;
using System.Collections.Generic;
using SunbeltRentals1.Models;

namespace SunbeltRentals1.Data
{
    public interface IAttendee
    {
        List<Attendee> GetAttendees(Guid partyId);

        Attendee GetAttendee(Guid partyId, Guid personId);

        void AddAttendee(Attendee attendee);
    }
}
