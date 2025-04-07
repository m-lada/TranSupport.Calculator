using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranSupport.Calculator.Data.Entities;

namespace TranSupport.Calculator.Data.Configuration;

internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Projects)
            .HasForeignKey(x => x.OwnerId);

        builder.Property(p => p.OwnerId)
            .IsRequired();

        builder.Property(e => e.ConcurrencyStamp)
            .IsConcurrencyToken()
            .IsRequired();
    }
}
