using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Slick.Api.Dtos;
using Slick.Models.Contracts;
using Slick.Models.People;
using Slick.Services.Contracts;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantsService consService;
        private readonly IContractsService contractService;

        public ConsultantsController(IConsultantsService consService, IContractsService contractsService)
        {
            this.consService = consService;
            this.contractService = contractsService;
        }

        [HttpPost]
        public IActionResult Post(Consultant cons)
        {
            var newcons = consService.Create(cons);
            if (newcons.Id == Guid.Empty) return StatusCode(500);
            return Ok(newcons);
        }

        //[HttpGet]
        //public IActionResult Get(string sort)
        //{
        //    return Ok(consService.GetAll(sort));
        //}

        //[controller]?sort=firstname&filter=firstname&value=kvein
        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery]string filter, [FromQuery]string value)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                if (string.IsNullOrEmpty(value)) return BadRequest("Parameten searches gave been disabled");

                IList<ConsultantDto> consultants = new List<ConsultantDto>();
                IList<Consultant> consultantsFromDb = new List<Consultant>();


                if (filter == "firstname") return Ok(this.consService.FindByFirstName(value, sort));
                if (filter == "lastname") return Ok(this.consService.FindByLastName(value, sort));

                foreach (var c in consultantsFromDb)
                {
                    consultants.Add(new ConsultantDto()
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        WorkEmail = c.WorkEmail,
                        Telephone = c.Telephone,
                        Street = c.Address.Street,
                        Number = c.Address.Number,
                        City = c.Address.City,
                        Zip = c.Address.Zip
                    });
                }
                return Ok(consultants);
            }
            return Ok(this.consService.GetAll(sort));
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid Id)
        {
            var c = consService.GetById(Id);
            if (c == null) return NotFound();
            var consultant = new ConsultantDto()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                WorkEmail = c.WorkEmail,
                Telephone = c.Telephone,
                Street = c.Address?.Street,
                Number = c.Address?.Number,
                City = c.Address?.City,
                Zip = c.Address?.Zip
            };
            var contractsFromDb = this.contractService.GetContractsFromConsultant(Id);
            consultant.Contracts = new List<ContractDto>();
            foreach (Contract cont in contractsFromDb)
            {
                consultant.Contracts.Add(new ContractDto()
                {
                    EndDate = cont.EndDate,
                    StartDate = cont.StartDate,
                    DocumentUrl = cont.DocumentUrl,
                    Salary = cont.Salary,
                    SignedDate = cont.SignedDate
                });
            }

            return Ok(consultant);
        }

        [HttpDelete]
        public IActionResult Delete(Consultant cons)
        {
            consService.Delete(cons);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Consultant cons)
        {
            consService.Update(cons);
            return Ok(cons);
        }



    }
}