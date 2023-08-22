namespace MortalKombat;

class Program
{
    private static Logger _logger = new();

    static void Main()
    {
        ReadMethod();
    }

    public static EnumMethods ReadMethod()
    {
        _logger.Log("Choose the method of reading the type of attack!\nType 'file' or 'console':");
        var methodReading = InputReader.ReadInput();

        if (methodReading.ToLower() == "file")
        {
            FileReader.ReadFile();
            return EnumMethods.File;
        }
        else if (methodReading.ToLower() == "console")
        {
            return EnumMethods.Console;
        }
    }
}
