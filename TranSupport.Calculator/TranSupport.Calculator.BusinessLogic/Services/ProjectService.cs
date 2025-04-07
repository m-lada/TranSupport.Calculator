using TranSupport.Calculator.Shared.Interfaces.Repositories;
using TranSupport.Calculator.Shared.Interfaces.Services;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.BusinessLogic.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ProjectDto> CreateAsync()
    {
        return await _projectRepository.AddAsync(new ProjectDto());
    }

    public async Task<ProjectDto> GetByIdAsync(Guid projectId)
    {
        return await _projectRepository.GetByIdAsync(projectId);
    }
}
