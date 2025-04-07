using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranSupport.Calculator.API.Authorization;
using TranSupport.Calculator.BusinessLogic.Authentication.Interfaces;
using TranSupport.Calculator.Shared.Models.Authenticate;
using TranSupport.Calculator.Shared.Models.Enums;

namespace TranSupport.Calculator.API.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : BaseController
{
    private IAuthenticationService _authService;

    public AuthenticationController(
        IAuthenticationService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthenticateResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult?> Login([FromBody] AuthenticateRequest authenticateRequest)
    {
        try
        {
            var user = await _authService.Authenticate(authenticateRequest);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
        catch (Exception e)
        {
            throw new Exception();
        }
    }

    [Authorization(UserRole.FreeUser)]
    [HttpGet("auth-free-user-test")]
    public IActionResult authU()
    {
        return Ok("OK");
    }

    [Authorization(UserRole.Admin)]
    [HttpGet("auth-admin-test")]
    public IActionResult authA()
    {
        return Ok("OK");
    }

    [AllowAnonymous()]
    [HttpGet("auth-test")]
    public IActionResult auth()
    {
        return Ok("OK");
    }
}
