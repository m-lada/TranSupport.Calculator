using System.ComponentModel.DataAnnotations;

namespace TranSupport.Calculator.Shared.Models.Authenticate;

public class AuthenticateRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
