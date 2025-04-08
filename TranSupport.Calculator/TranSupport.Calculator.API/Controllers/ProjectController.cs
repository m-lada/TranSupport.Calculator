using Microsoft.AspNetCore.Mvc;
using TranSupport.Calculator.API.Authorization;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces;
using TranSupport.Calculator.Shared.Models.Enums;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.API.Controllers;

[Route("api/project")]
[ApiController]
public class ProjectController : BaseController
{
    private IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    [Authorization(UserRole.Admin, UserRole.Client, UserRole.FreeUser)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var project = await _projectService.GetByIdAsync(id);

        return Ok(project);
    }

    [HttpGet]
    [Authorization(UserRole.Admin, UserRole.Client, UserRole.FreeUser)]
    public async Task<IActionResult> GetAllForOwner([FromRoute] Guid id)
    {
        var project = await _projectService.GetByIdAsync(id);

        return Ok(project);
    }

    [HttpPost]
    [Authorization(UserRole.Admin, UserRole.Client, UserRole.FreeUser)]
    public async Task<IActionResult> Create([FromBody] CreateProjectDto createDto)
    {
        var project = await _projectService.CreateAsync(createDto);

        return Ok(project);
    }

    [HttpPut]
    [Authorization(UserRole.Admin, UserRole.Client, UserRole.FreeUser)]
    public async Task<IActionResult> Update([FromBody] UpdateProjectDto updateDto)
    {
        var project = await _projectService.UpdateAsync(updateDto);

        return Ok(project);
    }
}
