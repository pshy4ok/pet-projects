using OnlineBankAPI.Models;

namespace OnlineBankAPI.Services.Interfaces;

public interface IAccountService
{
    Task<object> GetAccountAsync(HttpContext httpContext);
    Task SetBalanceAsync(string userId, decimal setBalance);
}