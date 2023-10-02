namespace SuperHeroAPI.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SuperHeroId { get; set; }
        public SuperHero? SuperHero { get; set; }

    }
}
