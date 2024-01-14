using OnlineBankAPI.Models;

namespace OnlineBankAPI.Services.Interfaces;

public interface IAccountService
{
    Task<AccountModel> CreateAccountAsync(AccountModel accountModel);
}