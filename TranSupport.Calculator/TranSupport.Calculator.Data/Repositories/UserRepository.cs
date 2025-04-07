using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TranSupport.Calculator.Data.Entities;
using TranSupport.Calculator.Shared.Interfaces.Repositories;
using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.Data.Repositories;

public class UserRepository : IUserRepository
{
    protected readonly IMapper _mapper;
    protected DatabaseContext _context { get; }
    protected DbSet<User> DbSet => _context.Set<User>();

    public UserRepository(DatabaseContext dbContext, IMapper mapper, DatabaseContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<IList<UserDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> CreateAsync(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        user.CreatedAt = DateTime.Now;

        await _context.Users.AddAsync(user);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return _mapper.Map<UserDto>(user);
    }

    public Task<UserDto> UpdateAsync(UserDto item)
    {
        //TODO
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        //TODO
        throw new NotImplementedException();
    }


    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        return _mapper.Map<UserDto>(await _context.Users.Where(r => r.Id == id).FirstOrDefaultAsync());
    }

    public async Task<UserDto> GetByEmailAsync(string userEmail)
    {
        var result = _context.Users.Where(r => r.Email.Equals(userEmail)).SingleOrDefault();
        return _mapper.Map<UserDto>(result);
    }

}
