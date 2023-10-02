namespace SuperHeroAPI.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public Backpack? Backpack { get; set; }
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Faction> Factions { get; set; } = new List<Faction>();
    }
}
