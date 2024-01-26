using Microsoft.AspNetCore.Identity;
using OnlineBankAPI.Data.Entities;
using OnlineBankAPI.Models;
using OnlineBankAPI.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnlineBankAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserModel> RegisterUserAsync(UserModel userModel)
        {
            var existingUser = await _userManager.FindByEmailAsync(userModel.Email);

            if (existingUser != null)
            {
                throw new Exception("This email is already registered");
            }

            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.FirstName + userModel.LastName,
                Email = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                throw new Exception($"User registration failed. {string.Join(", ", result.Errors)}");
            }

            return userModel;
        }

        public async Task<string> LoginUserAsync(LoginRequestModel loginRequestModel)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestModel.Email);

            if (user == null)
            {
                return null;
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginRequestModel.Password, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                return null;
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return user.FirstName;
        }

    }
}
