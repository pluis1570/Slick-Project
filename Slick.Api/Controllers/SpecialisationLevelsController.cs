using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Models.Skills;
using Slick.Services.Skills;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialisationLevelsController : ControllerBase
    {
        private readonly SpecialisationLevelsService specLevelService;

        public SpecialisationLevelsController(SpecialisationLevelsService specLevelService)
        {
            this.specLevelService = specLevelService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(specLevelService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid Id)
        {
            var sl = specLevelService.GetById(Id);
            if (sl == null) return NotFound();
            return Ok(sl);
        }



        [HttpPost]
        public IActionResult Post(SpecialisationLevel level)
        {
            var newLevel = specLevelService.Create(level);
            if (newLevel.Id == Guid.Empty) return StatusCode(500);
            return Ok(newLevel);
        }



    }

}