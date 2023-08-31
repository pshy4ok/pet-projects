using Newtonsoft.Json;

namespace PotionInventory;

public class JsonTypeFilter
{
    public static Logger _logger = new();

    public void FilterType(string type)
    {
        List<PotionReader> potions = JsonConvert.DeserializeObject<List<PotionReader>>(JsonFileReader.jsonTypes);

        var filteredPotions = potions.Where(p => p.PotionType.ToLower() == type.ToLower()).ToList();

        foreach (PotionReader potion in filteredPotions)
        {
            _logger.Log(
                $"Name: {potion.PotionName} | Type: {potion.PotionType} | Action: {potion.PotionAction} | Recovery: {potion.PotionRecovery} | Damage: {potion.PotionDamage}\n");
        }
    }
}