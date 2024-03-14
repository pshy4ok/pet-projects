using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineBankAPI.Data;
using OnlineBankAPI.Data.Entities;
using OnlineBankAPI.Exceptions;
using OnlineBankAPI.Models;
using OnlineBankAPI.Services.Interfaces;

namespace OnlineBankAPI.Services;

public class AccountService : IAccountService
{
    private readonly ApplicationContext _applicationContext;

    public AccountService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<object> GetAccountAsync(HttpContext httpContext)
    {

        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var account = await _applicationContext.Accounts.FirstOrDefaultAsync(a => a.UserId == userId);
        
        if (account != null)
        {
            return new { AccountNumber = account.AccountNumber, Balance = account.Balance };
        }
        
        throw new AccountNotFoundException("Account data not found!");
    }
    
    public async Task SetBalanceAsync(string userId, decimal newBalance)
    {
        var account = await _applicationContext.Accounts.FirstOrDefaultAsync(a => a.UserId == userId);
        if (account != null)
        {
            account.Balance = newBalance;
            await _applicationContext.SaveChangesAsync();
        }
    }
}