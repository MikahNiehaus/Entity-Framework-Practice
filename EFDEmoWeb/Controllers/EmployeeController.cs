using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.EFCore.DbContexts;
using ProCodeGuide.Samples.EFCore.Repository;

namespace ProCodeGuide.Samples.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IPersonRepository _personrepository;
        public EmployeeController(IPersonRepository personrepository)
        {
            _personrepository = personrepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> create([FromBody] Person employee)
        {
            int empid = await _personrepository.Create(employee);
            return Ok(empid);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var employees = await _personrepository.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await _personrepository.GetById(id);
            return Ok(employee);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, Person employee)
        {
            string resp = await _personrepository.Update(id, employee);
            return Ok(resp);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resp = await _personrepository.Delete(id);
            return Ok(resp);
        }
    }
}
