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
            while (true)
            {
                _logger.Log("Type 'attack' or 'restoration' to choose potion type that you want or 'q' to exit:\n");
                string input = InputReader.ReadInput();
                if (input.ToLower() == "attack")
                {
                    List<Potion> filteredPotions = _jsonFilter.ReadPotions(input);
                    LogPotions(filteredPotions);
                }
                else if (input.ToLower() == "restoration")
                {
                    List<Potion> filteredPotions = _jsonFilter.ReadPotions(input);
                    LogPotions(filteredPotions);
                }
                else if (input.ToLower() == "q")
                {
                    _logger.Log("See you soon!");
                    break;
                }
                else
                {
                    _logger.Log("JSON file does not exist!");
                }
            }

            static void LogPotions(List<Potion> potions)
            {
                foreach (Potion potion in potions)
                {
                    _logger.Log(
                        $"Name: {potion.PotionName} | Type: {potion.PotionType} | Action: {potion.PotionAction} | Recovery: {potion.PotionRecovery} | Damage: {potion.PotionDamage}\n");
                }
            }
        }
    }
}