using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.BusinessLogic.Services.Interfaces;

public interface IProjectService
{
    Task<ProjectDto> CreateAsync(CreateProjectDto projectDto);
    Task<ProjectDto> UpdateAsync(UpdateProjectDto updateProjectDto);
    Task<ProjectDto> GetByIdAsync(Guid projectId);
}
