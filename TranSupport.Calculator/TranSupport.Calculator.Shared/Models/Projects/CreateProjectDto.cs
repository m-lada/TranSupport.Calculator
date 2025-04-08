namespace TranSupport.Calculator.Shared.Models.Projects;
public class CreateProjectDto
{
    public string Name { get; set; }
    public Guid? OwnerId { get; set; }
}
