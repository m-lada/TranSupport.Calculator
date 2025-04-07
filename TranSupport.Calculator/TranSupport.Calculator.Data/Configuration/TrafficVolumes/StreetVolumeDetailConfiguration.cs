using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities.TrafficVolumes;

namespace TranSupport.Calculator.Data.Configuration.TrafficVolumes;

internal class StreetVolumeDetailConfiguration : IEntityTypeConfiguration<StreetVolumeDetail>
{
    public void Configure(EntityTypeBuilder<StreetVolumeDetail> builder)
    {
        builder.HasOne(x => x.StreetRelation)
            .WithMany(x => x.StreetVolumeDetails)
            .HasForeignKey(x => x.StreetRelationId);

        builder.HasOne(x => x.TrafficVolume)
            .WithMany(x => x.StreetVolumeDetails)
            .HasForeignKey(x => x.TrafficVolumeId);
    }
}
