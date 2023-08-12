namespace MortalKombat;

internal abstract class Program
{
    static void Main()
    {
        Console.WriteLine("MORTAL KOMBAT SIMULATOR\n");

        do
        {
            Console.Write("Type 'start' to begin or 'q' to quit the game: ");
            string? action = Console.ReadLine();

            if (action?.ToLower() == "start")
            {
                Battle();
            }
            else if (action?.ToLower() == "q")
            {
                Console.WriteLine("\nSee you soon!");
                break;
            }
            else
            {
                Console.WriteLine("\nUnknown command! Please try again!");
            }
        } while (true);
    }
    
    static void Battle()
    {
        int playerHp = 100;
        int computerHp = 100;
        Random random = new Random();
        bool isPlayerTurn = random.Next(2) == 0;
        
        Console.WriteLine("\nFIGHT");

        while (playerHp > 0 && computerHp > 0)
        {
            int damage = random.Next(15, 26);
            int doubleDamage = 2 * damage;
            
            if (isPlayerTurn)
            {
                Console.WriteLine($"\nYour HP: {playerHp} || Computer HP: {computerHp}");
                Console.WriteLine($"\nChoose the type of your attack: \nl - light attack (15-25 damage) || h - heavy attack (30-50 damage, but you will skip the next move!)");

                string? type = Console.ReadLine();
                    
                if (type?.ToLower() == "l")
                {
                    computerHp -= damage;
                    Console.WriteLine($"\nGood punch, you dealt {damage} damage to computer! Computer has {computerHp} HP now!");
                }
                else if (type?.ToLower() == "h")
                {
                    computerHp -= doubleDamage;
                    Console.WriteLine(
                        $"\nFatality! You dealt {doubleDamage} damage to computer! Computer has {computerHp} HP now! You will skip the next move!");

                    playerHp -= damage;
                    Console.WriteLine($"\nYou skipped the move! Computer dealt {damage} damage to you! You have {playerHp} now!");
                }
                else
                {
                    Console.WriteLine("\nWrong move! Please try again!");
                    continue;
                }
            }
            else
            {
                playerHp -= damage;
                Console.WriteLine($"\nComputer dealt {damage} damage to you! You have {playerHp} now!");
            }
                
            isPlayerTurn = !isPlayerTurn;
        }

        if (playerHp <= 0)
        {
            Console.WriteLine("\nYou are a looser! Computer wins!\n");
        }
        else if (computerHp <= 0)
        {
            Console.WriteLine("\nExcellent! You win!\n");
        }
    }
}

