using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities.Intersections;

namespace TranSupport.Calculator.Data.Configuration.Intersections;

internal class IntersectionScenarioConfiguration : IEntityTypeConfiguration<IntersectionScenario>
{
    public void Configure(EntityTypeBuilder<IntersectionScenario> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.IntersectionType)
            .IsRequired();

        builder.HasOne(x => x.Intersection)
            .WithMany(x => x.IntersectionScenarios)
            .HasForeignKey(x => x.IntersectionId);

        builder.Property(e => e.ConcurrencyStamp)
            .IsConcurrencyToken()
            .IsRequired();
    }
}