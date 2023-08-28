namespace MortalKombat;

class Program
{
    private static Logger _logger = new();

    static void Main()
    {
        EnumInputMethods attackInputMethod = ReadMethod();
        BattleLogic.RunBattle(attackInputMethod);
    }

    public static EnumInputMethods ReadMethod()
    {
        _logger.Log("Choose the method of reading the type of attack!\nType 'file' or 'console':");
        var methodReading = InputReader.ReadInput();

        if (methodReading.ToLower() == "file")
        {
            return EnumInputMethods.File;
        }
        else if (methodReading.ToLower() == "console")
        {
            return EnumInputMethods.Console;
        }
        else
        {
            _logger.Log("Invalid input. Please enter 'file' or 'console'.");
            return ReadMethod();
        }
    }
}
