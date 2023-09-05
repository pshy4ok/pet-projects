using Newtonsoft.Json;

namespace PotionInventory;

public class JsonFileReader
{
    public static string jsonTypes = File.ReadAllText(jsonFilePath);
    public static Logger _logger = new();

    public const string jsonFilePath = "potions.json";

    public static bool CheckIfFileExists()
    {
        return File.Exists(jsonFilePath);
    }

    public static T ReadJson<T>()
    {
        string jsonFile = File.ReadAllText(jsonFilePath);

        if (!CheckIfFileExists())
        {
            throw new FileNotFoundException("Could not found JSON file");
        }


        return JsonConvert.DeserializeObject<T>(jsonFile);
    }
}