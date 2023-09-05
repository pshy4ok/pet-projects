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
                Console.WriteLine("Type 'attack' or 'restoration' to choose a potion type that you want or 'q' to exit:");
                string input = Console.ReadLine();

                if (InputHandler.CheckIfToCloseProgram(input))
                {
                    _logger.Log("See you soon!");
                    break;
                }
                else if (InputValidator.ValidateInput(input))
                {
                    InputValidator.ValidateInput(input);
                }
                
                var filteredPotions = _potionReader.ReadPotions(input.ToLower());
                _logger.LogPotions(filteredPotions);
            }
        }
    }
}