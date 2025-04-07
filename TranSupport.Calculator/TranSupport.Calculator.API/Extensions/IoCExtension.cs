using FluentValidation;
using TranSupport.Calculator.BusinessLogic.Authentication;
using TranSupport.Calculator.BusinessLogic.Authentication.Interfaces;
using TranSupport.Calculator.BusinessLogic.Services;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces.Validators;
using TranSupport.Calculator.BusinessLogic.Validators;
using TranSupport.Calculator.Data.Repositories;
using TranSupport.Calculator.Data.Repositories.Common;
using TranSupport.Calculator.Data.Repositories.Interfaces;
using TranSupport.Calculator.Shared.Models.Users;
using TranSupport.Calculator.Shared.Models.Validators;

namespace TranSupport.Calculator.API.Extensions;

public static class IoCExtension
{
    public static void RegiterServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtUtils, JwtUtils>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAuthenticateValidationService, AuthenticateValidationService>();

        services.AddScoped<IUserValidationService, UserValidationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProjectService, ProjectService>();

        services.AddScoped<ICurrentUserService, CurrentUserService>();
    }
    public static void RegiterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
    }
    public static void RegiterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
    }
}
