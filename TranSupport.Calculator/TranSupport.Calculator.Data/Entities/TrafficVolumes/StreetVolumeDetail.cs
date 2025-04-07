using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Data.Entities.Streets;

namespace TranSupport.Calculator.Data.Entities.TrafficVolumes;

public class StreetVolumeDetail : AuditedDbEntity<Guid>
{
    [Required]
    public Guid TrafficVolumeId { get; set; }

    [Required]
    public TrafficVolume TrafficVolume { get; set; }

    [Required]
    public Guid StreetRelationId { get; set; }

    [Required]
    public StreetRelation StreetRelation { get; set; }

    public int VolumeMotorcycles { get; set; }

    public int VolumeCars { get; set; }

    public int VolumeVans { get; set; }

    public int VolumeTrucks { get; set; }

    public int VolumeTrucksWithTrailers { get; set; }

    public int VolumeBuses { get; set; }

    public int VolumeTractors { get; set; }
}
