using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranSupport.Calculator.API.Authorization;
using TranSupport.Calculator.Shared.Interfaces.Services;
using TranSupport.Calculator.Shared.Models.Enums;
using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : BaseController
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] UserCreateDto newUser)
    {
        var userDto = await _userService.CreateUserAsync(newUser);

        return Ok(userDto);
    }

    [HttpGet("{id}")]
    [Authorization(UserRole.Admin)]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);

        return Ok(user);
    }

    [HttpDelete("{id}")]
    [Authorization(UserRole.Admin)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userDto = _userService.DeleteUserAsync(id);
        return Ok(userDto);
    }
}
