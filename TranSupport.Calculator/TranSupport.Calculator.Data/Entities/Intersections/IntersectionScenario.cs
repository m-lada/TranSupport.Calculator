using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Data.Entities.Streets;
using TranSupport.Calculator.Shared.Constans;
using TranSupport.Calculator.Shared.Models.Enums;

namespace TranSupport.Calculator.Data.Entities.Intersections;

public class IntersectionScenario : AuditedDbEntity<Guid>
{
    [Required]
    [MinLength(StringLengthConstraints.MinNameLength)]
    [MaxLength(StringLengthConstraints.MaxNameLength)]
    public string Name { get; set; }

    [AllowNull]
    [MaxLength(StringLengthConstraints.MaxDescriptionLength)]
    public string Description { get; set; }

    [Required]
    public Guid IntersectionId { get; set; }

    public Intersection Intersection { get; set; }

    [Required]
    public IntersectionType IntersectionType { get; set; }

    public List<StreetScenario> StreetScenario { get; set; }
}
