using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities.Streets;

namespace TranSupport.Calculator.Data.Configuration.Streets;

internal class StreetScenarioConfiguration : IEntityTypeConfiguration<StreetScenario>
{
    public void Configure(EntityTypeBuilder<StreetScenario> builder)
    {
        builder.Property(x => x.StreetId)
            .IsRequired();

        builder.Property(x => x.IntersectionScenarioId)
            .IsRequired();

        builder.HasOne(x => x.IntersectionScenario)
            .WithMany(x => x.StreetScenario)
            .HasForeignKey(x => x.IntersectionScenarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Street)
            .WithMany(x => x.StreetScenarios)
            .HasForeignKey(x => x.StreetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.ConcurrencyStamp)
            .IsConcurrencyToken()
            .IsRequired();
    }
}
