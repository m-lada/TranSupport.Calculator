using System.ComponentModel.DataAnnotations;

namespace TranSupport.Calculator.Shared.Models.Entity;

public class EntityDto<T>
{
    [Required]
    public T Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
}
