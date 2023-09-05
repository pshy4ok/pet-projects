namespace PotionInventory;

public class Program
{
    public static Logger _logger = new();
    public static PotionReader _potionReader = new();
    

    static void Main(string[] args)
    {
        if (JsonFileReader.CheckIfFileExists())
        {
            while (true)
            {
                _logger.Log("Type 'attack' or 'restoration' to choose a potion type that you want or 'q' to exit:");
                string input = Console.ReadLine();

                if (InputHandler.CheckIfToCloseProgram(input))
                {
                    _logger.Log("See you soon!");
                    break;
                }
                else if (!InputValidator.ValidateInput(input))
                {
                    _logger.Log("Input is invalid. Please try again");
                    continue;
                }
                
                var filteredPotions = _potionReader.ReadPotions(input.ToLower());
                List<string> potionMessages = new List<string>();
                foreach (Potion potion in filteredPotions)
                {
                    string potionMessage = $"Name: {potion.PotionName} | Type: {potion.PotionType} | Action: {potion.PotionAction} | Recovery: {potion.PotionRecovery} | Damage: {potion.PotionDamage}\n";
                    potionMessages.Add(potionMessage);
                }
                _logger.LogMessages(potionMessages.ToArray());
            }
        }
    }
}