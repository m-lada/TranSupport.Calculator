using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Shared.Models.Entity;
using TranSupport.Calculator.Shared.Models.Intersections;
using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.Shared.Models.Projects;

public class ProjectDto : AuditedEntityDto<Guid>
{
    [Required]
    [MaxLength(200)]
    [MinLength(1)]
    public string Name { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public UserDto User { get; set; }

    public virtual List<IntersectionDto> Intersections { get; set; }
}
