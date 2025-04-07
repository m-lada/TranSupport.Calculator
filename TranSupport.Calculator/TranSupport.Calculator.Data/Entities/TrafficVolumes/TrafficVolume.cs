using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Data.Entities.Intersections;
using TranSupport.Calculator.Shared.Constans;

namespace TranSupport.Calculator.Data.Entities.TrafficVolumes;

public class TrafficVolume : AuditedDbEntity<Guid>
{
    [Required]
    [MinLength(StringLengthConstraints.MinNameLength)]
    [MaxLength(StringLengthConstraints.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    public DateTime DateAndTime { get; set; }

    [Required]
    public Guid IntersectionId { get; set; }

    public Intersection Intersection { get; set; }

    public virtual List<StreetVolumeDetail> StreetVolumeDetails { get; set; }
}
