using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Data.Entities;
using UsersAPI.Models;
using UsersAPI.Services.Interfaces;


namespace UsersAPI.Services;

public class UserService : IUserService
{
    private readonly ApplicationContext _applicationContext;

    public UserService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    public async Task<UserModel> RegisterUserAsync(UserModel userModel)
    {
        var user = new User
        {
            Username = userModel.Username,
            Password = userModel.Password,
            Email = userModel.Email
        };
        
        await _applicationContext.Users.AddAsync(user);
        await _applicationContext.SaveChangesAsync();

        return userModel;
    }
}