using Newtonsoft.Json;

namespace PotionInventory;

public class PotionReader
{
    public static Logger _logger = new();

    public List<Potion> ReadPotions(string type)
    {
        List<Potion> potions = JsonFileReader.ReadJson<List<Potion>>();

        var filteredPotions = potions.Where(p => p.PotionType.ToLower() == type.ToLower()).ToList();

        return filteredPotions;
    }
}