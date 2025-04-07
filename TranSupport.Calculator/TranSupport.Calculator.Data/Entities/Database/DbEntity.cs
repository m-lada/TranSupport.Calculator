using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TranSupport.Calculator.Shared.Interfaces.Database;

namespace TranSupport.Calculator.Data.Entities.Database;

public abstract class DbEntity<T> : IDbEntity<T>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
}
