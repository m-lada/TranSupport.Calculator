using TranSupport.Calculator.Shared.Models.Entity;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.Shared.Models.Intersections;

public class IntersectionDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public ProjectDto Project { get; set; }
}
