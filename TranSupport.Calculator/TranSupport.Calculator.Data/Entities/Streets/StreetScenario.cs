using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Data.Entities.Intersections;

namespace TranSupport.Calculator.Data.Entities.Streets;

public class StreetScenario : AuditedDbEntity<Guid>
{
    [Required]
    public Guid StreetId { get; set; }

    public Street Street { get; set; }

    [Required]
    public Guid IntersectionScenarioId { get; set; }

    public IntersectionScenario IntersectionScenario { get; set; }

    public List<StreetLane> StreetLane { get; set; }
}
