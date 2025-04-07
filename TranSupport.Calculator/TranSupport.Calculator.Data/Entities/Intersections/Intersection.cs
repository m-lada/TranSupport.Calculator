using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Data.Entities.Streets;
using TranSupport.Calculator.Data.Entities.TrafficVolumes;
using TranSupport.Calculator.Shared.Constans;

namespace TranSupport.Calculator.Data.Entities.Intersections;

public class Intersection : AuditedDbEntity<Guid>
{
    [Required]
    [MinLength(StringLengthConstraints.MinNameLength)]
    [MaxLength(StringLengthConstraints.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    public Guid ProjectId { get; set; }

    public Project Project { get; set; }

    public List<IntersectionScenario> IntersectionScenarios { get; set; }

    public List<Street> Streets { get; set; }

    public List<TrafficVolume> TrafficVolumes { get; set; }
}
