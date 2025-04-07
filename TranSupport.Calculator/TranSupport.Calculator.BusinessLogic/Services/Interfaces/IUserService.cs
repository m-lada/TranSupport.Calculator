using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.Shared.Interfaces.Services;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserCreateDto newUser);
    Task DeleteUserAsync(Guid id);
    Task<UserDto> GetByIdAsync(Guid userId);
}
