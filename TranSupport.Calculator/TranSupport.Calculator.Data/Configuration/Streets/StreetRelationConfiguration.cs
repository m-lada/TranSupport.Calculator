using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities.Streets;

namespace TranSupport.Calculator.Data.Configuration.Streets;

internal class StreetRelationConfiguration : IEntityTypeConfiguration<StreetRelation>
{
    public void Configure(EntityTypeBuilder<StreetRelation> builder)
    {
        builder
            .HasIndex(p => new { p.EntryStreetId, p.ExitStreetId })
            .IsUnique(true);

        builder.HasOne(x => x.EntryStreet)
            .WithMany(x => x.EntryStreetVolumes)
            .HasForeignKey(x => x.EntryStreetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ExitStreet)
            .WithMany(x => x.ExitStreetVolumes)
            .HasForeignKey(x => x.ExitStreetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
