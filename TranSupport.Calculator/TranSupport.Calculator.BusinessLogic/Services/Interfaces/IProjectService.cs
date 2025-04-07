using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.Shared.Interfaces.Services;

public interface IProjectService
{
    Task<ProjectDto> CreateAsync();

    Task<ProjectDto> GetByIdAsync(Guid projectId);
}
