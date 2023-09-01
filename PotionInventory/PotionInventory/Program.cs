namespace PotionInventory;

public class Program
{
    public static Logger _logger = new();
    public static JsonFileReader _jsonReader = new();
    public static PotionReader _jsonFilter = new();

    static void Main(string[] args)
    {
        if (JsonFileReader.CheckIfFileExists())
        {
                InputValidation.ValidInput();
        }
    }
}