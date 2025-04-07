using AutoMapper;
using TranSupport.Calculator.Data.Entities;
using TranSupport.Calculator.Data.Repositories.Interfaces;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.Data.Repositories;

public class ProjectRepository : CrudRepository<Project, ProjectDto, Guid>, IProjectRepository
{
    public ProjectRepository(DatabaseContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
        : base(dbContext, mapper, currentUserService)
    {
    }
}
