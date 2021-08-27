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
        private PeopleContext _dbcontext;
        public PersonRepository(PeopleContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Create(Person person)
        {
            _dbcontext.People.Add(person);
            _dbcontext.SaveChanges();
            return person.Id;
        }

        public async Task<List<Person>> GetAll()
        {
            var people = await _dbcontext.People.ToListAsync<Person>();
            return people;
        }

        public async Task<Person> GetById(int id)
        {
            var person = await _dbcontext.People.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return person;
        }

        public async Task<string> Update(int id, Person person)
        {
            var personupt = await _dbcontext.People.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (personupt == null) return "Person does not exists";

            personupt.Age = person.Age;
            personupt.Addresses = person.Addresses;
            personupt.EmailAddresses = person.EmailAddresses;
       
            _dbcontext.SaveChanges();
            return "Person details successfully modified";
        }

        public async Task<string> Delete(int id)
        {
            var persondel = _dbcontext.People.Where(empid => empid.Id == id).FirstOrDefault();
            if (persondel == null) return "Person does not exists";

            _dbcontext.People.Remove(persondel);
            _dbcontext.SaveChanges();
            return "Person details deleted modified";
        }
    }
}
