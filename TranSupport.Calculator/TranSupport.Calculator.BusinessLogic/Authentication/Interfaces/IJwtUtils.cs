using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.Shared.Interfaces.Services.Authentication;

public interface IJwtUtils
{
    public string GenerateJwtToken(UserDto userDto);
    public Guid? ValidateJwtToken(string token);
}
