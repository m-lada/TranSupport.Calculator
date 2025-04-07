using FluentValidation;
using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.Shared.Models.Validators;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(r => r.Email).NotEmpty();
        RuleFor(r => r.UserRole).IsInEnum();
    }
}
