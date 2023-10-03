using SuperHeroAPI.DTOs;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHeroCreateDto request);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHeroCreateDto request);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
