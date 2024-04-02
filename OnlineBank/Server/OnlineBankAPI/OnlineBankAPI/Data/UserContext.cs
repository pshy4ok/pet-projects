using System.Security.Claims;

namespace OnlineBankAPI.Data;

public class UserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
}