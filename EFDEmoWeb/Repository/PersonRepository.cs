using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.EFCore.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private PeopleContext db;
        public PersonRepository(PeopleContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(Person person)
        {
            db.People.AddRange(person);
            db.SaveChanges();
            return person.Id;
        }

        public async Task<List<Person>> GetAll()
        {
            var people = await db.People.ToListAsync<Person>();
            return people;
        }

        public async Task<Person> GetById(int id)
        {
            var person = await db.People.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return person;
        }

        public async Task<string> Update(int id, Person person)
        {
            var personupt = await db.People.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (personupt == null) return "Person does not exists";

            personupt.Age = person.Age;
            personupt.Addresses = person.Addresses;
            personupt.EmailAddresses = person.EmailAddresses;
       
            db.SaveChanges();
            return "Person details successfully modified";
        }

        public async Task<string> Delete(int id)
        {
            var persondel = db.People.Where(empid => empid.Id == id).FirstOrDefault();
            if (persondel == null) return "Person does not exists";

            db.People.Remove(persondel);
            db.SaveChanges();
            return "Person details deleted modified";
        }
    }
}
