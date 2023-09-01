using Newtonsoft.Json;

namespace PotionInventory;

public class JsonFileReader
{
    public static string jsonTypes = File.ReadAllText(jsonFilePath);
    public static Logger _logger = new();
    public const string jsonFilePath =
        "/Users/Олег/Documents/GitHub/pshy4ok/PotionInventory/PotionInventory/bin/Debug/net7.0/potions.json";

    public static bool CheckIfFileExists()
    {
        return File.Exists(jsonFilePath);
    }
    
    public static T ReadJson<T>()
    {
        if (!CheckIfFileExists())
        {
            throw new FileNotFoundException("Could not found JSON file");
        }
        
        return JsonConvert.DeserializeObject<T>(jsonFilePath);
    }
}