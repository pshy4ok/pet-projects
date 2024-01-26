using Microsoft.AspNetCore.Mvc;
using OnlineBankAPI.Models;
using OnlineBankAPI.Services.Interfaces;

namespace OnlineBankAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/signup")]
    public async Task<UserModel> RegisterUserAsync([FromBody] UserModel userModel)
    {
        return await _userService.RegisterUserAsync(userModel);
    }

    [HttpPost("/login")]
    public async Task<string> LoginUserAsync([FromBody] LoginRequestModel loginRequestModel)
    {
        return await _userService.LoginUserAsync(loginRequestModel);
    }
}