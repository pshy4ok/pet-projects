using Microsoft.AspNetCore.Identity;

namespace OnlineBankAPI.Models;

public class LoginRequestModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}