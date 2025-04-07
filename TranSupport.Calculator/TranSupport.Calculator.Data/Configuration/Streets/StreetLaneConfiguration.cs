using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities.Streets;

namespace TranSupport.Calculator.Data.Configuration.Streets;

internal class StreetLaneConfiguration : IEntityTypeConfiguration<StreetLane>
{
    public void Configure(EntityTypeBuilder<StreetLane> builder)
    {
        builder.Property(x => x.TurnRelationType)
            .IsRequired();

        builder.Property(x => x.LineNumber)
            .IsRequired();

        builder.HasOne(x => x.StreetScenario)
            .WithMany(x => x.StreetLane)
            .HasForeignKey(x => x.StreetScenarioId);

        builder.Property(e => e.ConcurrencyStamp)
            .IsConcurrencyToken()
            .IsRequired();
    }
}