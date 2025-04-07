using System.ComponentModel.DataAnnotations;

namespace TranSupport.Calculator.Shared.Models.Authenticate;

public class AuthenticateResponse
{
    [Required]
    public string Token { get; set; }

    public AuthenticateResponse(string token)
    {
        Token = token;
    }
}
