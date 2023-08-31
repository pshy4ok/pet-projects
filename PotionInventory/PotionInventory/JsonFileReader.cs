using Newtonsoft.Json;

namespace PotionInventory;

public class JsonFileReader
{
    public static string jsonTypes = File.ReadAllText(jsonFilePath);
    public static Logger _logger = new();
    public const string jsonFilePath =
        "/Users/Олег/Documents/GitHub/pshy4ok/PotionInventory/PotionInventory/bin/Debug/net7.0/potions.json";
    
    public void ReadJson()
    {
        List <PotionReader> potions = JsonConvert.DeserializeObject<List<PotionReader>>(jsonTypes);

        foreach (PotionReader potion in potions)
        {
            _logger.Log($"Name: {potion.PotionName} | Type: {potion.PotionType} | Action: {potion.PotionAction} | Recovery: {potion.PotionRecovery} | Damage: {potion.PotionDamage}\n");
        }

        InputReader.ReadInput();
    }
}