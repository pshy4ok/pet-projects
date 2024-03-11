using Microsoft.AspNetCore.Identity;

namespace OnlineBankAPI.Data.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Account Account { get; set; }
}