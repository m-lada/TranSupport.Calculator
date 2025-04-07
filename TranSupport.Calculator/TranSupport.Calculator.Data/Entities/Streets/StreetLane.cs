using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Shared.Models.Enums;

namespace TranSupport.Calculator.Data.Entities.Streets;

public class StreetLane : AuditedDbEntity<Guid>
{
    [Required]
    public TurnRelationType TurnRelationType { get; set; }

    [Required]
    public int LineNumber { get; set; }

    [Required]
    public Guid StreetScenarioId { get; set; }

    public StreetScenario StreetScenario { get; set; }
}
