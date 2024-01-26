namespace OnlineBankAPI.Data.Entities;

public class Account
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}