namespace TranSupport.Calculator.Shared.Interfaces.Database;

public interface IDbEntity<T>
{
    public T Id { get; set; }

    public DateTime CreatedAt { get; set; }
}
