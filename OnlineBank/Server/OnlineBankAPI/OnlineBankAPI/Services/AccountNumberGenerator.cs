using System.Text;

namespace OnlineBankAPI.Services;

public class AccountNumberGenerator
{
    public static Random random = new Random();
    
    public static string GenerateAccountNumber()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(random.Next(1, 10));
        
        for (int i = 0; i < 15; i++)
        {
            sb.Append(random.Next(0, 10));
        }

        return sb.ToString();
    }
}