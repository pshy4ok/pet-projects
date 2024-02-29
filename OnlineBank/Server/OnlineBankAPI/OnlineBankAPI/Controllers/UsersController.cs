using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginRequestModel loginRequestModel)
    {
        var token = await _userService.LoginUserAsync(loginRequestModel);

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized("User does not exist!");
        }

        return Ok(token);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("/user")]
    public async Task<string> GetUserAsync()
    {
        var userName = await _userService.GetUserAsync(HttpContext);
        return userName;
    }
}