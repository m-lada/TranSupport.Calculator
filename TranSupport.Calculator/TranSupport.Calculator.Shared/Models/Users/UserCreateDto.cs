using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Shared.Constans;

namespace TranSupport.Calculator.Shared.Models.Users;

public class UserCreateDto
{
    [Required]
    [MinLength(StringLengthConstraints.MinUserEmailLength)]
    [MaxLength(StringLengthConstraints.MaxUserEmailLength)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [MinLength(StringLengthConstraints.MinPasswordLength)]
    [MaxLength(StringLengthConstraints.MaxPasswordLength)]
    public string Password { get; set; }
}
