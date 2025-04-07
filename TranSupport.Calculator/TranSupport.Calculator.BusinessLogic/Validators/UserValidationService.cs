using TranSupport.Calculator.BusinessLogic.Common;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces.Validators;
using TranSupport.Calculator.Data.Repositories.Interfaces;

namespace TranSupport.Calculator.BusinessLogic.Validators;

public class UserValidationService : IUserValidationService
{
    private readonly IUserRepository _repository;

    public UserValidationService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateUserEmail(string userName)
    {
        if (await _repository.GetByEmailAsync(userName) != null)
        {
            throw new AppException($"The user name: \"{userName}\" already exists.");
        }
    }
}
