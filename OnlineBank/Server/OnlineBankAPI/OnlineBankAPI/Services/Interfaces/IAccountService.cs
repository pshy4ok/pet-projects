using OnlineBankAPI.Models;

namespace OnlineBankAPI.Services.Interfaces;

public interface IAccountService
{
    Task<decimal> GetBalanceAsync(string userId);
    Task SetBalanceAsync(string userId, decimal setBalance);
}