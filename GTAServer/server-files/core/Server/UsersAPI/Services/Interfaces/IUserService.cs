using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Entities;
using UsersAPI.Models;

namespace UsersAPI.Services.Interfaces;

public interface IUserService
{
    Task<UserModel> RegisterUserAsync(UserModel userModel);
    Task<User?> LoginUserAsync(string username, string password);
}