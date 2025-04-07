using Microsoft.AspNetCore.Mvc;
using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.API.Controllers;

public class BaseController : ControllerBase
{
    protected UserDto? GetUserFromHttpContext()
    {
        return HttpContext.Items["User"] as UserDto;
    }
}
