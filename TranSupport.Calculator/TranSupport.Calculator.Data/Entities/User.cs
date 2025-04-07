using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TranSupport.Calculator.Data.Entities.Database;
using TranSupport.Calculator.Shared.Constans;
using TranSupport.Calculator.Shared.Models.Enums;

namespace TranSupport.Calculator.Data.Entities;

public class User : DbEntity<Guid>
{
    [Required]
    [MinLength(StringLengthConstraints.MinUserEmailLength)]
    [MaxLength(StringLengthConstraints.MaxUserEmailLength)]
    public string Email { get; set; }

    [Required]
    public UserRole UserRole { get; set; }

    [JsonIgnore]
    [Required]
    public string PasswordHash { get; set; }

    public List<Project>? Projects { get; set; }
}
