using AutoMapper;
using FluentValidation;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces.Validators;
using TranSupport.Calculator.Data.Repositories.Interfaces;
using TranSupport.Calculator.Shared.Models.Enums;
using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<UserDto> _userValidator;
    private readonly IUserValidationService _userValidationService;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper, IUserValidationService userValidationService, IValidator<UserDto> userValidator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userValidationService = userValidationService;
        _userValidator = userValidator;
    }

    public async Task<UserDto> CreateUserAsync(UserCreateDto newUser)
    {
        var userDto = _mapper.Map<UserDto>(newUser);

        var validationResult = _userValidator.Validate(userDto);
        if (!validationResult.IsValid) throw new ValidationException(string.Join(',', validationResult.Errors));

        _userValidationService.ValidateUserEmail(userDto.Email);

        userDto.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
        //TODO - parametryzacja 
        userDto.UserRole = UserRole.FreeUser;

        return await _userRepository.CreateAsync(userDto);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<UserDto> GetByIdAsync(Guid userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }
}
