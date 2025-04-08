using TranSupport.Calculator.Shared.Models.Entity;
using TranSupport.Calculator.Shared.Models.Intersections;

namespace TranSupport.Calculator.Shared.Models.Projects;

public class ProjectDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public Guid OwnerId { get; set; }

    public List<IntersectionDto> Intersections { get; set; }
}
