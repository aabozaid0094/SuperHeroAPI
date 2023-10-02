using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Faction> Factions { get; set; }
    }
}
