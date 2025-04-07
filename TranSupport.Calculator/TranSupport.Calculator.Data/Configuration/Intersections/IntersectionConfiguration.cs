using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities.Intersections;

namespace TranSupport.Calculator.Data.Configuration.Intersections;

internal class IntersectionConfiguration : IEntityTypeConfiguration<Intersection>
{
    public void Configure(EntityTypeBuilder<Intersection> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.ProjectId)
            .IsRequired();

        builder.HasOne(x => x.Project)
            .WithMany(x => x.Intersections)
            .HasForeignKey(x => x.ProjectId);

        builder.Property(e => e.ConcurrencyStamp)
            .IsConcurrencyToken()
            .IsRequired();
    }
}