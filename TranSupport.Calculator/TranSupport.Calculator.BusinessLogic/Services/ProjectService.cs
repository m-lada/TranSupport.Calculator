using AutoMapper;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces;
using TranSupport.Calculator.Data.Repositories.Interfaces;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.BusinessLogic.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper, ICurrentUserService currentUserService)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto createProjectDto)
    {
        createProjectDto.OwnerId = _currentUserService.UserId;

        return await _projectRepository.CreateAsync(createProjectDto);
    }

    public async Task<ProjectDto> UpdateAsync(UpdateProjectDto updateProjectDto)
    {
        return await _projectRepository.UpdateAsync(updateProjectDto);
    }

    public async Task<ProjectDto> GetByIdAsync(Guid projectId)
    {
        return await _projectRepository.GetAsync(projectId);
    }
}
