using Microsoft.AspNetCore.Mvc;
using TranSupport.Calculator.API.Authorization;
using TranSupport.Calculator.BusinessLogic.Services.Interfaces;
using TranSupport.Calculator.Shared.Models.Enums;

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

    [HttpPost]
    [Authorization(UserRole.Admin)]
    public async Task<IActionResult> Create()
    {
        var project = await _projectService.CreateAsync();

        return Ok(project);
    }
}
