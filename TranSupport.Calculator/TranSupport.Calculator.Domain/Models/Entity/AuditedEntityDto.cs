namespace TranSupport.Calculator.Shared.Models.Entity;

public class AuditedEntityDto<T> : EntityDto<T>
{
    public DateTime? ModifiedAt { get; set; }

    public Guid CreatorId { get; set; }

    public Guid? ModifierId { get; set; }

    public string ConcurrencyStamp { get; set; }
}
