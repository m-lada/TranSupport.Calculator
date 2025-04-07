using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TranSupport.Calculator.BusinessLogic.Authentication.Interfaces;
using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.BusinessLogic.Authentication;

public class JwtUtils : IJwtUtils
{
    private readonly AuthenticationSettings _authSettings;

    public JwtUtils(IOptions<AuthenticationSettings> authenticationSettings)
    {
        _authSettings = authenticationSettings.Value;
    }

    public string GenerateJwtToken(UserDto userDto)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("Id", userDto.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, userDto.Email),
            new Claim(ClaimTypes.Role, userDto.UserRole.ToString())
        };

        var token = new JwtSecurityToken(_authSettings.Issuer,
            _authSettings.Audience,
            claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public Guid? ValidateJwtToken(string token)
    {
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_authSettings.SecretKey);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);

            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return null;
        }
    }
}