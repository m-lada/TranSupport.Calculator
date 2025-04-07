using Microsoft.EntityFrameworkCore;
using TranSupport.Calculator.Data.Entities;
using TranSupport.Calculator.Shared.Models.Enums;

namespace TranSupport.Calculator.Data.Seed;

public static class SeedDataCollector
{
    public static void CollectSeeds(ModelBuilder builder)
    {
        builder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("AB87B1CD-8B67-44F8-BCA0-4511DA8D9C9C"),
                    Email = "admin@ts.pl",
                    UserRole = UserRole.Admin,
                    CreatedAt = new DateTime(),
                    // Password: 1234qwer
                    PasswordHash = "$2a$11$DNEo7Gt7Asse1B0szA4Ls.SX2dR9YjKjpf/EnRQZyXg7S3ImMEZWy"
                }
            );
    }
}
