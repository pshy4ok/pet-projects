namespace PotionInventory;

public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void LogMessages(string[] messages)
    {
        foreach (string message in messages)
        {
            Console.WriteLine(message);
        }
    }
}