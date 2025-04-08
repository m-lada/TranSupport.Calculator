namespace TranSupport.Calculator.Shared.Models.Entity;

public class AuditedEntityDto<T> : EntityDto<T>
{
    public string ConcurrencyStamp { get; set; }
}
