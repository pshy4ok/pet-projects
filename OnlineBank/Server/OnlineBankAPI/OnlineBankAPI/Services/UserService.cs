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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
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
                    AccountNumber = "ACC-" + Guid.NewGuid().ToString().Substring(0, 9)
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

        public async Task<string> LoginUserAsync(LoginRequestModel loginRequestModel)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestModel.Email);

            if (user == null)
            {
                throw new Exception("User doesn't exists!");
            }
            
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes
                (_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginRequestModel.Password, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                throw new Exception("Invalid email or password!");
            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            return tokenHandler.WriteToken(token);
        }

        public async Task<string> GetUserAsync(HttpContext httpContext)
        {
            var user = await _userManager.GetUserAsync(httpContext.User);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user.FirstName; 
        }


    }
}
