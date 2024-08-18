using AgoraDotNet.Data;
using AgoraDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgoraDotNet.Repositories
{
    public class SuperHeroRepository
    {
        private readonly DataContext _context;

        public SuperHeroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetHero(int id)
        {
            return await _context.SuperHeroes.FindAsync(id);
        }

        public async Task AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHero(SuperHero hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);

            if (dbHero != null)
            {
                dbHero.Name = hero.Name;
                dbHero.FirstName = hero.FirstName;
                dbHero.LastName = hero.LastName;
                await _context.SaveChangesAsync();
            }
        }
    }
}