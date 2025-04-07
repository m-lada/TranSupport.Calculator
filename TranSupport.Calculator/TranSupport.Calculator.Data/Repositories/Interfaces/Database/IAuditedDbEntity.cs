namespace TranSupport.Calculator.Data.Repositories.Interfaces.Database;

public interface IAuditedDbEntity<T> : IDbEntity<T>
{
    public DateTime? ModifiedAt { get; set; }

    public Guid CreatorId { get; set; }

    public Guid? ModifierId { get; set; }

    public string ConcurrencyStamp { get; set; }
}
