using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero superHero);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero superHero);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
