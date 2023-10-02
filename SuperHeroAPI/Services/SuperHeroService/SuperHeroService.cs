using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _dataContext;

        public SuperHeroService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero superHero)
        {
            await _dataContext.SuperHeroes.AddAsync(superHero);
            await _dataContext.SaveChangesAsync();
            
            return await _dataContext.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var superHero = await _dataContext.SuperHeroes.FindAsync(id);
            if (superHero is null)
                return null;

            _dataContext.SuperHeroes.Remove(superHero);
            await _dataContext.SaveChangesAsync();
            
            return await _dataContext.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            return await _dataContext.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            return await _dataContext.SuperHeroes.FindAsync(id);
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero updatedSuperHero)
        {
            var superHero = await _dataContext.SuperHeroes.FindAsync(id);
            if (superHero is null)
                return null;

            superHero.Name = string.IsNullOrEmpty(updatedSuperHero.Name) ? superHero.Name : updatedSuperHero.Name;
            superHero.FirstName = string.IsNullOrEmpty(updatedSuperHero.FirstName) ? superHero.FirstName : updatedSuperHero.FirstName;
            superHero.LastName = string.IsNullOrEmpty(updatedSuperHero.LastName) ? superHero.LastName : updatedSuperHero.LastName;
            superHero.Place = string.IsNullOrEmpty(updatedSuperHero.Place) ? superHero.Place : updatedSuperHero.Place;
            await _dataContext.SaveChangesAsync();

            return await _dataContext.SuperHeroes.ToListAsync();
        }
    }
}
