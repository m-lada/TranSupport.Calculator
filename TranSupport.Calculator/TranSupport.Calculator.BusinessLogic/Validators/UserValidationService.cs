using TranSupport.Calculator.BusinessLogic.Common;
using TranSupport.Calculator.Shared.Interfaces.Repositories;
using TranSupport.Calculator.Shared.Interfaces.Validators;

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
