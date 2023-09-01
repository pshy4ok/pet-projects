namespace PotionInventory;

public class InputValidation
{
    public static Logger _logger = new();
    public static PotionReader _jsonFilter = new();

    public static void ValidInput()
    {
        while (true)
        {
            _logger.Log("Type 'attack' or 'restoration' to choose potion type that you want or 'q' to exit:\n");
            string input = InputReader.ReadInput();
            if (input.ToLower() == "attack")
            {
                List<Potion> filteredPotions = _jsonFilter.ReadPotions(input);
                _logger.LogPotions(filteredPotions);
            }
            else if (input.ToLower() == "restoration")
            {
                List<Potion> filteredPotions = _jsonFilter.ReadPotions(input);
                _logger.LogPotions(filteredPotions);
            }
            else if (input.ToLower() == "q")
            {
                _logger.Log("See you soon!");
                return;
            }
            else
            {
                _logger.Log("JSON file does not exist!");
            }
        }
        
    }
}