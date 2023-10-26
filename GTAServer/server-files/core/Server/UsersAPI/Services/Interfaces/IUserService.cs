using UsersAPI.Models;

namespace UsersAPI.Services.Interfaces;

public interface IUserService
{
    Task<UserModel> RegisterUserAsync(UserModel userModel);
}