namespace SuperHeroAPI.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<SuperHero> SuperHeroes { get; set; } = new List<SuperHero>();
    }
}
