using Microsoft.AspNetCore.Mvc;
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
}