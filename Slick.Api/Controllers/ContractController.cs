using System;
using Microsoft.AspNetCore.Mvc;
using Slick.Models.Contracts;
using Slick.Services.Contracts;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractsService contractsService;

        public ContractController(IContractsService contractsService)
        {
            this.contractsService = contractsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(contractsService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid Id)
        {
            var sl = contractsService.GetById(Id);
            if (sl == null) return NotFound();
            return Ok(sl);
        }

        [HttpPost]
        public IActionResult Post(Contract con)
        {
            var newcon = contractsService.Create(con);
            if (newcon.Id == Guid.Empty) return StatusCode(500);
            return Ok(newcon);
        }

        [HttpDelete]
        public IActionResult Delete(Contract con)
        {
            contractsService.Delete(con);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Contract con)
        {
            contractsService.Update(con);
            return Ok(con);
        }


    }
}