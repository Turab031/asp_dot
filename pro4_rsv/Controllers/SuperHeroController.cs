using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pro4_rsv.Models;
using pro4_rsv.Services;

namespace pro4_rsv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHero()
        {
            return Ok(_superHeroService.GetSuperHero());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroById(int id)
        {
            SuperHero? hero = _superHeroService.GetHeroById(id);

            if (hero == null)
            {
                return NotFound("superhero not found");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {
            _superHeroService.AddSuperHero(hero);

            return Ok(_superHeroService.GetSuperHero());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id, SuperHero newHero)
        {
            SuperHero? hero = _superHeroService.GetHeroById(id);

            if (hero == null)
            {
                return NotFound("hero not found");
            }

            _superHeroService.UpdateHero(id, newHero);

            return Ok(_superHeroService.GetHeroById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            SuperHero? hero = _superHeroService.GetHeroById(id);

            if (hero == null)
            {
                return NotFound("hero not found");
            }

            _superHeroService.DeleteHero(id);

            return Ok(hero);
        }
    }
}