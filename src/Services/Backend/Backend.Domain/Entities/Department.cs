using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class Department : BaseEntity
{
    public string? Description { get; set; }
    public string Status { get; set; } = CatalogsStatus.Active;

    public Department(string? description)
    {
        Description = description;
    }

}