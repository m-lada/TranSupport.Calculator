using TranSupport.Calculator.BusinessLogic.Authentication.Interfaces;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces.Validators;
using TranSupport.Calculator.Data.Repositories.Interfaces;
using TranSupport.Calculator.Shared.Models.Authenticate;

namespace TranSupport.Calculator.BusinessLogic.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private IJwtUtils _jwtUtils;
    private IUserRepository _userRepository;
    private IAuthenticateValidationService _authenticateValidationService;

    public AuthenticationService(IJwtUtils jwtUtils, IUserRepository userRepository, IAuthenticateValidationService authenticateValidationService)
    {
        _jwtUtils = jwtUtils;
        _userRepository = userRepository;
        _authenticateValidationService = authenticateValidationService;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest userLogin)
    {
        var currentUser = await _userRepository.GetByEmailAsync(userLogin.Email);

        if (currentUser == null)
        {
            throw new Exception("Username is incorrect");
        }

        try
        {
            await _authenticateValidationService.ValidateHashPassword(userLogin.Password, currentUser.PasswordHash);
        }
        catch (Exception e)
        {
            throw new Exception("Password is incorrect");
        }

        return new AuthenticateResponse(_jwtUtils.GenerateJwtToken(currentUser));
    }
}