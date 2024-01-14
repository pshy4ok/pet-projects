using Microsoft.AspNetCore.Mvc;
using OnlineBankAPI.Models;

namespace OnlineBankAPI.Services.Interfaces;

public interface IUserService
{
    Task<UserModel> RegisterUserAsync(UserModel userModel);
    Task<string> LoginUserAsync(LoginRequestModel loginRequestModel);
}