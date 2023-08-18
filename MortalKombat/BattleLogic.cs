namespace MortalKombat;

public class BattleLogic
{
    public static int playerHP = 100;
    public static int computerHP = 100;
    public static Random random = new Random();
    public static bool isPlayerTurn = false;
    public static string type = ConsoleLogic.type;

    public static void Battle()
    {
        isPlayerTurn = random.Next(2) == 0;
        int dmg = random.Next(15, 30);
        int ddmg = 2 * dmg;

        while (playerHP > 0 && computerHP > 0)
        {
            if (isPlayerTurn)
            {
                ConsoleLogic.Messages(type);
                if (type.ToLower() == "l")
                {
                    computerHP -= dmg;
                    Console.WriteLine(
                        $"\nGood punch, you dealt {dmg} damage to computer! Computer has {computerHP} HP now!");
                }
                else if (type.ToLower() == "h")
                {
                    computerHP -= ddmg;
                    Console.WriteLine(
                        $"\nFatality! You dealt {ddmg} damage to computer! Computer has {computerHP} HP now! You will skip the next move!");

                    playerHP -= dmg;
                    Console.WriteLine(
                        $"\nYou skipped the move! Computer dealt {dmg} damage to you! You have {playerHP} now!");
                }
                else
                {
                    Console.WriteLine("\nWrong move! Please try again!");
                    continue;
                }
            }
            else
            {
                playerHP -= dmg;
                Console.WriteLine($"\nComputer dealt {dmg} damage to you! You have {playerHP} now!");
            }

            isPlayerTurn = !isPlayerTurn;
        }

        if (playerHP <= 0)
        {
            Console.WriteLine("\nYou are a looser! Computer wins!\n");
        }
        else if (computerHP <= 0)
        {
            Console.WriteLine("\nExcellent! You win!\n");
        }
    }
}