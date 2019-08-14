using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Api.Dtos;
using Slick.Models.Costumers;
using Slick.Services.Contracts;
using Slick.Services.Costumers;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountConsultantsController : ControllerBase
    {
        private readonly IAccountsConsultantsService accConService;
        private readonly IContractsService contractService;


        public AccountConsultantsController(IAccountsConsultantsService accConService, IContractsService contractsService)
        {
            this.accConService = accConService;
            this.contractService = contractsService;
        }
        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery]string filter, [FromQuery]string value)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                if (string.IsNullOrEmpty(value)) return BadRequest("Parameten searches gave been disabled");

                IList<AccountConsultantDto> accountConsultants = new List<AccountConsultantDto>();
                IList<AccountConsultant> accountconsultantsFromDb = new List<AccountConsultant>();


                if (filter == "firstname") return Ok(this.accConService.FindByFirstName(value, sort));
                if (filter == "lastname") return Ok(this.accConService.FindByLastName(value, sort));

                foreach (var c in accountconsultantsFromDb)
                {
                    accountConsultants.Add(new AccountConsultantDto()
                    {
                        FirstName = c.Consultant.FirstName,
                        LastName = c.Consultant.LastName,
                        Email = c.Consultant.Email,
                        WorkEmail = c.Consultant.WorkEmail,
                        Telephone = c.Consultant.Telephone,
                        Street = c.Consultant.Address.Street,
                        Number = c.Consultant.Address.Number,
                        City = c.Consultant.Address.City,
                        Zip = c.Consultant.Address.Zip
                    });
                }
                return Ok(accountConsultants);
            }
            return Ok(this.accConService.GetAll(sort));
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid Id)
        {
            var c = accConService.GetById(Id);
            if (c == null) return NotFound();
            var consultant = new AccountConsultantDto()
            {
                FirstName = c.Consultant.FirstName,
                LastName = c.Consultant.LastName,
                Email = c.Consultant.Email,
                WorkEmail = c.Consultant.WorkEmail,
                Telephone = c.Consultant.Telephone,
                Street = c.Consultant.Address?.Street,
                Number = c.Consultant.Address?.Number,
                City = c.Consultant.Address?.City,
                Zip = c.Consultant.Address?.Zip
            };         

            return Ok(consultant);
        }

        [HttpPost]
        public IActionResult Post(AccountConsultant cons)
        {
            var newcons = accConService.Create(cons);
            if (newcons.Id == Guid.Empty) return StatusCode(500);
            return Ok(newcons);
        }

        [HttpDelete]
        public IActionResult Delete(AccountConsultant cons)
        {
            accConService.Delete(cons);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(AccountConsultant cons)
        {
            accConService.Update(cons);
            return Ok(cons);
        }

    }
}