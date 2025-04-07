using System.ComponentModel.DataAnnotations;
using TranSupport.Calculator.Data.Repositories.Interfaces.Database;

namespace TranSupport.Calculator.Data.Entities.Database;

public class AuditedDbEntity<T> : IAuditedDbEntity<T>, IDbEntity<T>
{
    [Required]
    public T Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public Guid CreatorId { get; set; }

    public Guid? ModifierId { get; set; }

    [Required]
    public string ConcurrencyStamp { get; set; }
}
