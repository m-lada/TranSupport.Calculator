using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Data.Entities.Intersections;
using TranSupport.Calculator.Shared.Constans;

namespace TranSupport.Calculator.Data.Entities;

public class Project : AuditedDbEntity<Guid>
{
    [Required]
    [MinLength(StringLengthConstraints.MinNameLength)]
    [MaxLength(StringLengthConstraints.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    public Guid OwnerId { get; set; }

    public User Owner { get; set; }

    public List<Intersection> Intersections { get; set; }
}
