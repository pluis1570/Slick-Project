using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Models.Costumers;
using Slick.Services.Costumers;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(accountsService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid Id)
        {
            var sl = accountsService.GetById(Id);
            if (sl == null) return NotFound();
            return Ok(sl);
        }

        [HttpPost]
        public IActionResult Post(Account acc)
        {
            var newcon = accountsService.Create(acc);
            if (newcon.Id == Guid.Empty) return StatusCode(500);
            return Ok(newcon);
        }

        [HttpDelete]
        public IActionResult Delete(Account acc)
        {
            accountsService.Delete(acc);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Account acc)
        {
            accountsService.Update(acc);
            return Ok(acc);
        }
    }
}