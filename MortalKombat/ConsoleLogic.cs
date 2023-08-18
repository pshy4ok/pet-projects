namespace MortalKombat;

public class ConsoleLogic
{
    public static string? type;

    public static void Messages(string type)
    {
        {
            Console.WriteLine("MORTAL COMBAT SIMULATOR\n");
            Console.WriteLine("FIGHT\n");
            Console.WriteLine($"\nYour HP: {BattleLogic.playerHP} || Computer HP: {BattleLogic.computerHP}");
            Console.WriteLine(
                $"\nChoose the type of your attack: \nl - light attack (15-25 damage) || h - heavy attack (30-50 damage, but you will skip the next move!)");
            type = Console.ReadLine();
        }
    }
}