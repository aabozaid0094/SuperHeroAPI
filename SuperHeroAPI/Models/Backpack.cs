namespace SuperHeroAPI.Models
{
    public class Backpack
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int SuperHeroId { get; set; }
        public SuperHero? SuperHero { get; set; }
    }
}
