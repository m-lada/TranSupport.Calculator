namespace TranSupport.Calculator.BusinessLogic.Services.Interfaces.Validators;

public interface IUserValidationService
{
    Task ValidateUserEmail(string userEmail);
}
