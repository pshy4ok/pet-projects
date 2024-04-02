namespace OnlineBankAPI.Models;

public class TransferModel
{
    public string DestinationAccountNumber { get; set; }
    public decimal Amount { get; set; }
}