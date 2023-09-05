namespace PotionInventory;

public class InputHandler
{
    public static Logger _logger = new();
    private static string CloseInput = "q";

    public static bool CheckIfToCloseProgram(string input)
    {
        return CloseInput.Contains(input);
    }
}