namespace PotionInventory;

public class InputValidator
{
    private static string[] ValidInputs = new[] { "attack", "restoration" };


    public static bool ValidateInput(string input)
    {
        return ValidInputs.Contains(input);
    }
}