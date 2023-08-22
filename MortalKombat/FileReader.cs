using System.Text;

namespace MortalKombat;

public class FileReader
{
    private static Logger _logger = new();

    public static void ReadFile()
    {
        string path = @"types.txt";
        string typeFromFile = File.ReadAllText(path, Encoding.Default);
        Console.WriteLine(typeFromFile);
    }
}
