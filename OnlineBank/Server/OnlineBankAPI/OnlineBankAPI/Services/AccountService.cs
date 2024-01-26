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


    public async Task<AccountModel> CreateAccountAsync(AccountModel accountModel)
    {
        var account = new Account
        {
            AccountNumber = accountModel.AccountNumber,
            UserId = accountModel.UserId
        };

        await _applicationContext.Accounts.AddAsync(account);
        await _applicationContext.SaveChangesAsync();

        return accountModel;
    }
}