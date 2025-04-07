using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TranSupport.Calculator.Shared.Models.Entity;
using TranSupport.Calculator.Shared.Models.Enums;
using TranSupport.Calculator.Shared.Models.Projects;

namespace TranSupport.Calculator.Shared.Models.Users;

public class UserDto : EntityDto<Guid>
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public UserRole UserRole { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }

    public List<ProjectDto> Projects { get; set; }
}
