using AgoraDotNet.Entities;
using AgoraDotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgoraDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        private readonly SuperHeroService _service;

        public SuperHeroController(SuperHeroService service)
        {
            _service = service;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _service.GetAllHeroes();
            return Ok(heroes);
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _service.GetHero(id);
            if (hero is null)
                return NotFound("Hero not found");

            return Ok(hero);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var heroes = await _service.AddHero(hero);
            return Ok(heroes);
        }

        // PUT
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var heroes = await _service.UpdateHero(hero);
            return Ok(heroes);
        }
    }
}