using Microsoft.AspNetCore.Http;
using TranSupport.Calculator.Data.Repositories.Interfaces;

namespace TranSupport.Calculator.Data.Repositories.Common;

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