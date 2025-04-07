using TranSupport.Calculator.BusinessLogic.Services.Interfaces.Validators;
using BCryptNet = BCrypt.Net.BCrypt;

namespace TranSupport.Calculator.BusinessLogic.Validators;

public class AuthenticateValidationService : IAuthenticateValidationService
{
    public async Task<bool> ValidateHashPassword(string hashPasswordToCheck, string hashPasswortFromDb)
    {
        return BCryptNet.Verify(hashPasswordToCheck, hashPasswortFromDb);
    }
}
