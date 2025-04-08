using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TranSupport.Calculator.Data.Entities;
using TranSupport.Calculator.Data.Repositories.Interfaces;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.Data.Repositories;

public class ProjectRepository : CrudRepository<Project, ProjectDto, CreateProjectDto, UpdateProjectDto, Guid>, IProjectRepository
{
    public ProjectRepository(DatabaseContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        : base(dbContext, mapper, currentUserService)
    {
    }

    public async Task<IList<ProjectDto>> GetAllAsync()
    {
        var userId = _currentUserService.UserId;

        var entities = await DbSet.AsNoTracking()
            .Where(x => x.OwnerId == userId)
            .ToListAsync();

        return entities
            .Select(x => _mapper.Map<ProjectDto>(x))
            .ToList();
    }
}
