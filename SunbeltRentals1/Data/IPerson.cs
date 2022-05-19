using System;
using System.Collections.Generic;
using SunbeltRentals1.Models;

namespace SunbeltRentals1.Data
{
    public interface IPerson
    {
        List<Person> GetPeople();

        Person GetPerson(Guid id);

        void AddPerson(Person person);
    }
}
