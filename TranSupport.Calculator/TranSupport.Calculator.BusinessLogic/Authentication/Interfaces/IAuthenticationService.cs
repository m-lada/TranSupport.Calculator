using TranSupport.Calculator.Shared.Models.Authenticate;

namespace TranSupport.Calculator.Shared.Interfaces.Services.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest userLogin);
}
