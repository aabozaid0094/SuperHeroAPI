using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.DTOs;
using SuperHeroAPI.Models;
using System.Linq;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _dataContext;

        public SuperHeroService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<SuperHero>> AddHero(SuperHeroCreateDto request)
        {
            var backpack = new Backpack() { Description = request.Backpack.Description };
            var weapons = request.Weapons.Select(w => new Weapon() { Name = w.Name }).ToList();
            var factions = request.Factions.Select(f => new Faction() { Name = f.Name }).ToList();
            var superHero = new SuperHero() { Name = request.Name, FirstName = request.FirstName, LastName = request.LastName, Backpack = backpack, Weapons = weapons };
            await _dataContext.SuperHeroes.AddAsync(superHero);
            await _dataContext.SaveChangesAsync();
            
            return await _dataContext.SuperHeroes.Include(sh => sh.Backpack).Include(sh => sh.Weapons).Include(sh => sh.Factions).ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var superHero = await _dataContext.SuperHeroes.FindAsync(id);
            if (superHero is null)
                return null;

            _dataContext.SuperHeroes.Remove(superHero);
            await _dataContext.SaveChangesAsync();
            
            return await _dataContext.SuperHeroes.Include(sh => sh.Backpack).Include(sh => sh.Weapons).Include(sh => sh.Factions).ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            return await _dataContext.SuperHeroes.Include(sh => sh.Backpack).Include(sh => sh.Weapons).Include(sh => sh.Factions).ToListAsync();
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            return await _dataContext.SuperHeroes.Include(sh => sh.Backpack).Include(sh => sh.Weapons).Include(sh => sh.Factions).FirstOrDefaultAsync(sh => sh.Id == id);
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHeroCreateDto request)
        {
            var superHero = await _dataContext.SuperHeroes.Include(sh => sh.Backpack).Include(sh => sh.Weapons).Include(sh => sh.Factions).FirstOrDefaultAsync(sh => sh.Id == id);
            if (superHero is null)
                return null;



            superHero.Name = string.IsNullOrEmpty(request.Name) ? superHero.Name : request.Name;
            superHero.FirstName = string.IsNullOrEmpty(request.FirstName) ? superHero.FirstName : request.FirstName;
            superHero.LastName = string.IsNullOrEmpty(request.LastName) ? superHero.LastName : request.LastName;
            superHero.Place = string.IsNullOrEmpty(request.Place) ? superHero.Place : request.Place;

            var backpack = new Backpack() { Description = request.Backpack.Description };
            var weapons = request.Weapons.Select(w => w.Name).Except(superHero.Weapons.Select(shw => shw.Name)).Select(wn => new Weapon() { Name = wn }).ToList();
            var factions = request.Factions.Select(f => f.Name).Except(superHero.Factions.Select(shf => shf.Name)).Select(fn => new Faction() { Name = fn }).ToList();

            superHero.Backpack = (!string.IsNullOrEmpty(request.Backpack.Description)) ? superHero.Backpack : backpack;
            if (weapons.Count < 1) superHero.Weapons.AddRange(weapons);
            if (factions.Count < 1) superHero.Factions.AddRange(factions);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.SuperHeroes.Include(sh => sh.Backpack).Include(sh => sh.Weapons).Include(sh => sh.Factions).ToListAsync();
        }
    }
}
