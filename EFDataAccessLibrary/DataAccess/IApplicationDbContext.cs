using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProCodeGuide.Samples.EFCore.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Person { get; set; }

        Task<int> SaveChanges();
    }
}
