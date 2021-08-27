using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.EFCore.Repository
{
    public interface IPersonRepository
    {
        Task<int> Create(Person employee);
        Task<List<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<string> Update(int id, Person employee);
        Task<string> Delete(int id);
    }
}
