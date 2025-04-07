using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Data.Entities.Intersections;
using TranSupport.Calculator.Shared.Constans;

namespace TranSupport.Calculator.Data.Entities.Streets;

public class Street : AuditedDbEntity<Guid>
{
    [Required]
    [MinLength(StringLengthConstraints.MinNameLength)]
    [MaxLength(StringLengthConstraints.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    public Guid IntersectionId { get; set; }

    public Intersection Intersection { get; set; }

    public List<StreetRelation> EntryStreetVolumes { get; set; }

    public List<StreetRelation> ExitStreetVolumes { get; set; }

    public List<StreetScenario> StreetScenarios { get; set; }
}
