using System.Text;

namespace MortalKombat;

public class FileReader
{

    public static string[] ReadFileLines(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath, Encoding.Default);
        return lines;
    }
}
