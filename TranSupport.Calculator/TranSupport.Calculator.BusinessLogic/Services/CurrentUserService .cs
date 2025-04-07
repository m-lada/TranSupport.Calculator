using Microsoft.AspNetCore.Http;
using TranSupport.Calculator.Shared.Interfaces.Services;

namespace TranSupport.Calculator.BusinessLogic.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("Id")?.Value;
            return userId != null ? Guid.Parse(userId) : Guid.Empty;
        }
    }
}