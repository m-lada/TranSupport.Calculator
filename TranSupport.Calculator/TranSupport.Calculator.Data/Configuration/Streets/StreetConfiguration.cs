using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities.Streets;

namespace TranSupport.Calculator.Data.Configuration.Streets;

internal class StreetConfiguration : IEntityTypeConfiguration<Street>
{
    public void Configure(EntityTypeBuilder<Street> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.IntersectionId)
            .IsRequired();

        builder.HasOne(x => x.Intersection)
            .WithMany(x => x.Streets)
            .HasForeignKey(x => x.IntersectionId);

        builder.HasMany(en => en.EntryStreetVolumes)
            .WithOne(p => p.EntryStreet)
            .HasForeignKey(m => m.EntryStreetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(en => en.ExitStreetVolumes)
            .WithOne(p => p.ExitStreet)
            .HasForeignKey(m => m.ExitStreetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
