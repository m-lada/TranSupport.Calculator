using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Shared.Models.Entity;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.Shared.Models.Intersections;

public class IntersectionDto : EntityDto<Guid>
{
    [Required]
    [MaxLength(200)]
    [MinLength(1)]
    public string Name { get; set; }

    [Required]
    public Guid ProjectId { get; set; }

    public virtual ProjectDto Project { get; set; }
}
