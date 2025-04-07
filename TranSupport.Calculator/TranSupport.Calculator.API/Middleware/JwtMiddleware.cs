using Microsoft.Extensions.Options;
using TranSupport.Calculator.BusinessLogic.Authentication;
using TranSupport.Calculator.Shared.Interfaces.Services;
using TranSupport.Calculator.Shared.Interfaces.Services.Authentication;

namespace TranSupport.Calculator.API.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AuthenticationSettings _authSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AuthenticationSettings> appSettings)
    {
        _next = next;
        _authSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = await userService.GetByIdAsync(userId.Value);
            }

        }

        await _next(context);
    }
}
