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
    
    [HttpGet("{userId}/balance")]
    public async Task<IActionResult> GetBalanceAsync(string userId)
    {
        var balance = await _accountService.GetBalanceAsync(userId);
        return Ok(new { balance });
    }
    
    [HttpPut("{userId}/balance")]
    public async Task<IActionResult> SetBalanceAsync(string userId, [FromBody] decimal setBalance)
    {
        await _accountService.SetBalanceAsync(userId, setBalance);
        return Ok("Balance set successfully");
    }
}