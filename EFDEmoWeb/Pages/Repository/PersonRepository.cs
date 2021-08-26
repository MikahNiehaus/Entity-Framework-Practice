using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.EFCore.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.EFCore.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private IApplicationDbContext _dbcontext;
        public PersonRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Create(Person person)
        {
            _dbcontext.Person.Add(person);
            await _dbcontext.SaveChanges();
            return person.Id;
        }

        public async Task<List<Person>> GetAll()
        {
            var people = await _dbcontext.Person.ToListAsync<Person>();
            return people;
        }

        public async Task<Person> GetById(int id)
        {
            var person = await _dbcontext.Person.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            return person;
        }

        public async Task<string> Update(int id, Person person)
        {
            var personupt = await _dbcontext.Person.Where(empid => empid.Id == id).FirstOrDefaultAsync();
            if (personupt == null) return "Person does not exists";

           // personupt.Designation = person.age;

            await _dbcontext.SaveChanges();
            return "Person details successfully modified";
        }

        public async Task<string> Delete(int id)
        {
            var persondel = _dbcontext.Person.Where(empid => empid.Id == id).FirstOrDefault();
            if (persondel == null) return "Person does not exists";

            _dbcontext.Person.Remove(persondel);
            await _dbcontext.SaveChanges();
            return "Person details deleted modified";
        }
    }
}
