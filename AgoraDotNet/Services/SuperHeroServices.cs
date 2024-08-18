using AgoraDotNet.Entities;
using AgoraDotNet.Repositories;

namespace AgoraDotNet.Services
{
    public class SuperHeroService
    {
        private readonly SuperHeroRepository _repository;

        public SuperHeroService(SuperHeroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            return await _repository.GetAllHeroes();
        }

        public async Task<SuperHero?> GetHero(int id)
        {
            return await _repository.GetHero(id);
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            await _repository.AddHero(hero);
            return await _repository.GetAllHeroes();
        }

        public async Task<List<SuperHero>> UpdateHero(SuperHero hero)
        {
            await _repository.UpdateHero(hero);
            return await _repository.GetAllHeroes();
        }
    }
}