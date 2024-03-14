using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using OnlineBankAPI.Data.Entities;
using OnlineBankAPI.Models;

namespace OnlineBankAPI.Services.Interfaces;

public interface IUserService
{
    Task<UserModel> RegisterUserAsync(UserModel userModel);
    Task<object> LoginUserAsync(LoginRequestModel loginRequestModel);
    Task<object> GetUserAsync(HttpContext httpContext);
}