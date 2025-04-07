namespace TranSupport.Calculator.BusinessLogic.Services.Interfaces.Validators;

public interface IAuthenticateValidationService
{
    Task<bool> ValidateHashPassword(string hashPasswordToCheck, string hashPasswortFromDb);
}
