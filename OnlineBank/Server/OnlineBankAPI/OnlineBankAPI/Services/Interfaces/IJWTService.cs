using OnlineBankAPI.Data.Entities;

namespace OnlineBankAPI.Services.Interfaces;

public interface IJWTService
{
    Task<string> GenerateTokenAsync(User user);
}