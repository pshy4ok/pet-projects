using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Entities;
using UsersAPI.Models;
using UsersAPI.Services.Interfaces;

namespace UsersAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/registration")]
    public async Task<UserModel> RegisterUserAsync([FromBody] UserModel userModel)
    {
        return await _userService.RegisterUserAsync(userModel);
    }
    
    [HttpPost("/login")]
    public async Task<User?> LoginUserAsync([FromBody] LoginRequestModel loginRequestModel)
    {
        return await _userService.LoginUserAsync(loginRequestModel.Username, loginRequestModel.Password);
    }
}