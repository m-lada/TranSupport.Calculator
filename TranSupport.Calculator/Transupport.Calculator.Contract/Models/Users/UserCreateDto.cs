using System.ComponentModel.DataAnnotations;

namespace TranSupport.Calculator.Shared.Models.Users;

public class UserCreateDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    public string Password { get; set; }
}
