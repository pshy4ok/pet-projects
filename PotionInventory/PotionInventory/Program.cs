namespace PotionInventory;

public class Program
{
    public static Logger _logger = new();
    public static JsonFileReader _jsonReader = new();
    public static JsonTypeFilter _jsonFilter = new();

    static void Main(string[] args)
    {
        if (File.Exists(JsonFileReader.jsonFilePath))
        {
            while (true)
            {
                _logger.Log("Type 'attack' or 'restoration' to choose potion type that you want or 'q' to exit:\n");
                string input = InputReader.ReadInput();
                if (input.ToLower() == "attack")
                {
                    _jsonFilter.FilterType("attack");
                }
                else if (input.ToLower() == "restoration")
                {
                    _jsonFilter.FilterType("restoration");
                }
                else if (input.ToLower() == "q")
                {
                    _logger.Log("See you soon!");
                    break;
                }
            }


            /*_jsonReader.ReadJson();*/
        }
    }
}