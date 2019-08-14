using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Api.Dtos;
using Slick.Models.People;
using Slick.Services.Contracts;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeesService empService;

        public EmployeesController(IEmployeesService empService)
        {
            this.empService = empService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery]string filter, [FromQuery]string value)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                if (string.IsNullOrEmpty(value)) return BadRequest("Parameten searches gave been disabled");

                IList<EmployeeDto> employees = new List<EmployeeDto>();
                IList<Employee> employeesFromDb = new List<Employee>();


                if (filter == "firstname") return Ok(this.empService.FindByFirstName(value, sort));
                if (filter == "lastname") return Ok(this.empService.FindByLastName(value, sort));

                foreach (var c in employeesFromDb)
                {
                    employees.Add(new EmployeeDto()
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        Telephone = c.Telephone,
                        Street = c.Address.Street,
                        Number = c.Address.Number,
                        City = c.Address.City,
                        Zip = c.Address.Zip
                    });
                }
                return Ok(employees);

            }
            return Ok(this.empService.GetAll(sort));
        }

        [HttpPost]
        public IActionResult Post(Employee  emp)
        {
            var newemp = empService.Create(emp);
            if (newemp.Id == Guid.Empty) return StatusCode(500);
            return Ok(newemp);
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid Id)
        {
            var e = empService.GetById(Id);
            if (e == null) return NotFound();
            var employee = new EmployeeDto()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Telephone = e.Telephone,
                Street = e.Address?.Street,
                Number = e.Address?.Number,
                City = e.Address?.City,
                Zip = e.Address?.Zip
            };

            return Ok(employee);
        }

        [HttpDelete]
        public IActionResult Delete(Employee emp)
        {
            empService.Delete(emp);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Employee emp)
        {
            empService.Update(emp);
            return Ok(emp);
        }

    }
}