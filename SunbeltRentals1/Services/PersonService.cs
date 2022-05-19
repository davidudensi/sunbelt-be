using SunbeltRentals1.Data;
using SunbeltRentals1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltRentals1.Services
{
    public class PersonService : IPerson
    {
        private readonly SunbeltDBContext _db;
        public PersonService(SunbeltDBContext db)
        {
            _db = db;
        }
        public void AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            _db.People.Add(person);
            _db.SaveChanges();
        }
        public List<Person> GetPeople()
        {
            return _db.People.ToList();
        }
        public Person GetPerson(Guid id)
        {
            var person = _db.People.Where(x => x.Id == id).FirstOrDefault();
            return person;
        }
    }
}
