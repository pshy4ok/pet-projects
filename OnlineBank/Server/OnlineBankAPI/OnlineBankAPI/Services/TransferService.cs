using System.Data;
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
    private readonly UserContext _userContext;

    public TransferService(ApplicationContext applicationContext, UserContext userContext)
    {
        _applicationContext = applicationContext;
        _userContext = userContext;
    }
    
    public async Task TransferAsync(HttpContext httpContext, TransferModel transferModel)
    {
        var userId = _userContext.UserId;
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

        using var transaction = await _applicationContext.Database.BeginTransactionAsync(IsolationLevel.Serializable);

        try
        {
            accountFrom.Balance -= transferModel.Amount;
            accountTo.Balance += transferModel.Amount;

            await _applicationContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}