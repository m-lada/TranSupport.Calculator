using AutoMapper;
using TranSupport.Calculator.Data.Entities;
using TranSupport.Calculator.Shared.Interfaces.Repositories;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.Data.Repositories;

public class ProjectRepository : CrudRepository<Project, ProjectDto, Guid>, IProjectRepository
{
    public ProjectRepository(DatabaseContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }
}
