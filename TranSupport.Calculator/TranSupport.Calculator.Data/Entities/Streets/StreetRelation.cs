using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Data.Entities.TrafficVolumes;

namespace TranSupport.Calculator.Data.Entities.Streets;

public class StreetRelation : AuditedDbEntity<Guid>
{
    [Required]
    public Guid EntryStreetId { get; set; }

    [Required]
    public Guid ExitStreetId { get; set; }

    public Street EntryStreet { get; set; }

    public Street ExitStreet { get; set; }

    public List<StreetVolumeDetail> StreetVolumeDetails { get; set; }
}
