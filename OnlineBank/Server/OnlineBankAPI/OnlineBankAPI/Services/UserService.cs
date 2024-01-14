using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineBankAPI.Data;
using OnlineBankAPI.Data.Entities;
using OnlineBankAPI.Models;
using OnlineBankAPI.Services.Interfaces;

namespace OnlineBankAPI.Services;

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

        if (existingEmail != null)
        {
            throw new Exception("This email is already registered");
        }

        using (SHA512 sha512 = new SHA512Managed())
        {
            var hashedPassword = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(userModel.Password)));
            var user = new User
            {
                FullName = userModel.FullName,
                Email = userModel.Email,
                Password = hashedPassword
            };

            await _applicationContext.Users.AddAsync(user);
            await _applicationContext.SaveChangesAsync();

            return userModel;
        }
    }

    public async Task<string> LoginUserAsync(LoginRequestModel loginRequestModel)
    {
        using (SHA512 sha512 = new SHA512Managed())
        {
            var hashedInputPassword = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(loginRequestModel.Password)));
            var user = await _applicationContext.Users.Include(x => x.Account).FirstOrDefaultAsync(u => u.Email == loginRequestModel.Email);

            if (user == null || user.Password != hashedInputPassword)
            {
                throw new Exception("Invalid username or password.");
            }

            return user.FullName;
        }
    }
}