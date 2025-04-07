namespace TranSupport.Calculator.Shared.Interfaces.Validators;

public interface IUserValidationService
{
    Task ValidateUserEmail(string userEmail);
}
