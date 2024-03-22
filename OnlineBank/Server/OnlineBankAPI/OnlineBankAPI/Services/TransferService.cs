using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using OnlineBankAPI.Data;
using OnlineBankAPI.Exceptions;
using OnlineBankAPI.Models;
using OnlineBankAPI.Services.Interfaces;

namespace OnlineBankAPI.Services;

public class TransferService : ITransferService
{
    private readonly ApplicationContext _applicationContext;

    public TransferService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public async Task TransferAsync(HttpContext httpContext, TransferModel transferModel)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var accountFrom = await _applicationContext.Accounts.FirstOrDefaultAsync(a => a.UserId == userId);

        if (accountFrom == null)
        {
            throw new AccountNotFoundException("Source account not found!");
        }

        var accountTo = await _applicationContext.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == transferModel.DestinationAccountNumber);

        if (accountTo == null)
        {
            throw new AccountNotFoundException(
                $"Destination account with Account Number {transferModel.DestinationAccountNumber} not found!");
        }

        if (accountFrom.Balance < transferModel.Amount)
        {
            throw new InvalidOperationException("The balance should not be less than the amount of the transfer");
        }

        accountFrom.Balance -= transferModel.Amount;
        accountTo.Balance += transferModel.Amount;

        await _applicationContext.SaveChangesAsync();
    }
}