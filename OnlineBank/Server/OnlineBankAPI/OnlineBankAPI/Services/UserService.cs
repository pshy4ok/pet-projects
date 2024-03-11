using Microsoft.AspNetCore.Identity;
using OnlineBankAPI.Data.Entities;
using OnlineBankAPI.Models;
using OnlineBankAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace OnlineBankAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IJWTService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IJWTService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
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
                Email = userModel.Email,
                Account = new Account
                {
                    AccountNumber = AccountNumberGenerator.GenerateAccountNumber(),
                    Balance = 0
                }
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User registration failed. Errors: {errors}");
            }


            return new UserModel
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };
        }

        public async Task<object> LoginUserAsync(LoginRequestModel loginRequestModel)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestModel.Email);

            if (user == null)
            {
                throw new Exception("User doesn't exist!");
            }

            var token = await _jwtService.GenerateTokenAsync(user);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginRequestModel.Password, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                throw new Exception("Invalid email or password!");
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return new { AccessToken = token };
        }


        public async Task<object> GetUserAsync(HttpContext httpContext)
        {
            var user = await _userManager.GetUserAsync(httpContext.User);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new { UserFirstName = user.FirstName}; 
        }
    }
}
