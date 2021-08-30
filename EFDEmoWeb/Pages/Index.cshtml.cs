using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFDEmoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private PeopleContext db;
        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            LoadSampleDataAsync();
            //_ = GetAllAsync();
             //  AddMikah();
           // _ = EditAsync();
           _ = DeleteAsync();

        }

        void LoadSampleDataAsync()
        {


            if (db.People.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("generated.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                db.AddRange(people);
                db.SaveChanges();
            }
        }

        async Task EditAsync()
        {
            //var getPeople = await db.People.ToListAsync<Person>();
            var personupt = await db.People.Where(empid => empid.Id == 1).FirstOrDefaultAsync();
            personupt.Age = 50;
            personupt.FirstName = "Geoff";
            //db.People.Add(personupt);
            await db.SaveChangesAsync();
        //    _ = GetAllAsync();
        }

        async Task GetAllAsync()
        {
            //get all
            var getPeople = await db.People.ToListAsync<Person>();
            _logger.LogInformation("There are " + getPeople.Count.ToString() + " People in DataBase.");
        }

        void AddMikah()
        {

            //create
            string mikahFile = System.IO.File.ReadAllText("mikah.json");
            var mikah = JsonSerializer.Deserialize<List<Person>>(mikahFile);
            db.People.AddRange(mikah);
            db.SaveChanges();
            _logger.LogInformation("Added Mikah to DataBase");
            _ = GetAllAsync();
        }

        async Task DeleteAsync()
        {
            //delete mikah
            //var getPeople = await db.People.ToListAsync<Person>();
            var persondel = await db.People.Where(empid => empid.Id == 120).FirstOrDefaultAsync();
            db.People.Remove(persondel);
            await db.SaveChangesAsync();

        }


    }
}

