namespace TranSupport.Calculator.Shared.Interfaces.Validators;

public interface IAuthenticateValidationService
{
    Task<bool> ValidateHashPassword(string hashPasswordToCheck, string hashPasswortFromDb);
}
