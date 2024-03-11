using System.Text;
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
    
}