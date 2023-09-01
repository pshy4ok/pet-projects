namespace PotionInventory;

public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void LogPotions(List<Potion> potions)
    {
        foreach (Potion potion in potions)
        {
            Console.WriteLine(
                $"Name: {potion.PotionName} | Type: {potion.PotionType} | Action: {potion.PotionAction} | Recovery: {potion.PotionRecovery} | Damage: {potion.PotionDamage}\n");
        }
    }
}