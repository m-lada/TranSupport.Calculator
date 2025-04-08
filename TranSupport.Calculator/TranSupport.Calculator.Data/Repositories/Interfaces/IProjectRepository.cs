using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.Data.Repositories.Interfaces;

public interface IProjectRepository : IRepository<Guid, ProjectDto, CreateProjectDto, UpdateProjectDto>
{
}
