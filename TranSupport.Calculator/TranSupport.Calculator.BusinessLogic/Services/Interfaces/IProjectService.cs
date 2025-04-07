using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.BusinessLogic.Services.Interfaces;

public interface IProjectService
{
    Task<ProjectDto> CreateAsync();

    Task<ProjectDto> GetByIdAsync(Guid projectId);
}
