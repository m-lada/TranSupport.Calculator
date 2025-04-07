using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.BusinessLogic.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserCreateDto newUser);
    Task DeleteUserAsync(Guid id);
    Task<UserDto> GetByIdAsync(Guid userId);
}
