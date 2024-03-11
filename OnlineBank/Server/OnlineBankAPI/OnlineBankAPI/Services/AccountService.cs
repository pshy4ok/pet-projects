using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineBankAPI.Data;
using OnlineBankAPI.Data.Entities;
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

    public async Task<decimal> GetBalanceAsync(string userId)
    {
        var account = await _applicationContext.Accounts.FirstOrDefaultAsync(a => a.UserId == userId);

        if (account != null)
        {
            return account.Balance;
        }

        throw new Exception("Account not found!");
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