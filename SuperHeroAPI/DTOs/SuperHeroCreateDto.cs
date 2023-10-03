namespace SuperHeroAPI.DTOs
{
    public record struct SuperHeroCreateDto(string Name, string FirstName, string LastName, string Place, BackpackCreateDto Backpack, List<WeaponCreateDto> Weapons, List<FactionCreateDto> Factions);
}
