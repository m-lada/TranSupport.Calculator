using TranSupport.Calculator.Shared.Models.Entity;

namespace TranSupport.Calculator.Shared.Models.Projects;

public class UpdateProjectDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
}
