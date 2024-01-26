using Microsoft.AspNetCore.Mvc;
using OnlineBankAPI.Models;
using OnlineBankAPI.Services.Interfaces;

namespace OnlineBankAPI.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;
    
    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost("/account")]
    public async Task<AccountModel> CreateAccountAsync([FromBody] AccountModel accountModel)
    {
        return await _accountService.CreateAccountAsync(accountModel);
    }
    
}