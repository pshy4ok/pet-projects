using OnlineBankAPI.Models;

namespace OnlineBankAPI.Services.Interfaces;

public interface IAccountService
{
    Task<object> GetAccountAsync(string userId);
    Task SetBalanceAsync(string userId, decimal setBalance);
}