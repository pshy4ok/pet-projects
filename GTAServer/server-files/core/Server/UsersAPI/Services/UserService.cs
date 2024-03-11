using System.Security.Cryptography;
using System.Text;
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
        var existingEmail = await _applicationContext.Users.FirstOrDefaultAsync(e => e.Email == userModel.Email);
        var existingUsername =
            await _applicationContext.Users.FirstOrDefaultAsync(u => u.Username == userModel.Username);

        if (existingEmail != null)
        {
            throw new Exception("This email is already registered");
        }

        if (existingUsername != null)
        {
            throw new Exception("This username is already registered");
        }

        using (SHA512 sha512 = new SHA512Managed())
        {
            var hashedPassword = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(userModel.Password)));
            var user = new User
            {
                Username = userModel.Username,
                Password = hashedPassword,
                Email = userModel.Email
            };

            await _applicationContext.Users.AddAsync(user);
            await _applicationContext.SaveChangesAsync();

            return userModel;
        }
    }

    public async Task<User?> LoginUserAsync(string username, string password)
    {
        using (SHA512 sha512 = new SHA512Managed())
        {
            var hashedInputPassword = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(password)));
            var user = await _applicationContext.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null || user.Password != hashedInputPassword)
            {
                throw new Exception("Invalid username or password.");
            }

            return user;
        }
    }
}