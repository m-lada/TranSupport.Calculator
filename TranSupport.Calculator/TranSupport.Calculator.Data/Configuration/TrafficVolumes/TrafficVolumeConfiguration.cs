using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities.TrafficVolumes;

namespace TranSupport.Calculator.Data.Configuration.TrafficVolumes;
internal class TrafficVolumeConfiguration : IEntityTypeConfiguration<TrafficVolume>
{
    public void Configure(EntityTypeBuilder<TrafficVolume> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.IntersectionId)
            .IsRequired();

        builder.Property(x => x.DateAndTime)
            .IsRequired();

        builder.HasOne(x => x.Intersection)
            .WithMany(x => x.TrafficVolumes)
            .HasForeignKey(x => x.IntersectionId);
    }
}
