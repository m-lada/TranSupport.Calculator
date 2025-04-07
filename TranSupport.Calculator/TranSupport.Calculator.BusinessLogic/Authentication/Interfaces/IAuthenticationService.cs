using TranSupport.Calculator.Shared.Models.Authenticate;

namespace TranSupport.Calculator.BusinessLogic.Authentication.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest userLogin);
}
