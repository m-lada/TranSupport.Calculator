using Microsoft.EntityFrameworkCore;
using TranSupport.Calculator.Data.Configuration;
using TranSupport.Calculator.Data.Configuration.Intersections;
using TranSupport.Calculator.Data.Configuration.Streets;
using TranSupport.Calculator.Data.Configuration.TrafficVolumes;
using TranSupport.Calculator.Data.Entities;
using TranSupport.Calculator.Data.Entities.Intersections;
using TranSupport.Calculator.Data.Entities.Streets;
using TranSupport.Calculator.Data.Entities.TrafficVolumes;
using TranSupport.Calculator.Data.Seed;

namespace TranSupport.Calculator.Data;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Intersection> Intersections { get; set; }
    public DbSet<IntersectionScenario> IntersectionScenarios { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<StreetScenario> StreetScenarios { get; set; }
    public DbSet<TrafficVolume> TrafficVolumes { get; set; }
    public DbSet<StreetRelation> StreetRelations { get; set; }
    public DbSet<StreetVolumeDetail> StreetVolumeDetails { get; set; }
    public DbSet<StreetLane> StreetLanes { get; set; }

    public DatabaseContext() { }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new IntersectionConfiguration());
        modelBuilder.ApplyConfiguration(new IntersectionScenarioConfiguration());

        modelBuilder.ApplyConfiguration(new StreetConfiguration());
        modelBuilder.ApplyConfiguration(new StreetLaneConfiguration());
        modelBuilder.ApplyConfiguration(new StreetRelationConfiguration());
        modelBuilder.ApplyConfiguration(new StreetScenarioConfiguration());

        modelBuilder.ApplyConfiguration(new StreetVolumeDetailConfiguration());
        modelBuilder.ApplyConfiguration(new TrafficVolumeConfiguration());

        SeedDataCollector.CollectSeeds(modelBuilder);
    }
}
