using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.Data.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserDto> CreateAsync(UserDto userDto);
    Task<UserDto> GetByIdAsync(Guid userId);
    Task<IList<UserDto>> GetAllAsync();
    Task<UserDto> UpdateAsync(UserDto item);
    Task<UserDto> GetByEmailAsync(string userName);
    Task DeleteAsync(Guid id);
}
