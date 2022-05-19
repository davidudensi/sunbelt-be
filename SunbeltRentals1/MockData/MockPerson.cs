using System;
using System.Collections.Generic;
using SunbeltRentals1.Data;
using SunbeltRentals1.Models;

namespace SunbeltRentals1.MockData
{
    public class MockPerson : IPerson
    {
        public List<Person> people = new List<Person>()
        {
            new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "David",
                LastName = "Udensi",
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Chinedu",
                LastName = "Udensi",
            }
        };

        public void AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            people.Add(person);
        }

        public List<Person> GetPeople()
        {
            return people;
        }

        public Person GetPerson(Guid id)
        {
            return people.Find(x => x.Id == id);
        }
    }
}
