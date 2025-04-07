using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.BusinessLogic.Authentication.Interfaces;

public interface IJwtUtils
{
    public string GenerateJwtToken(UserDto userDto);
    public Guid? ValidateJwtToken(string token);
}
