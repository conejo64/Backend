using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class TypeRequirement : BaseEntity
{
    public string? Description { get; set; }
    public string Status { get; set; } = CatalogsStatus.Active;

    public TypeRequirement(string? description)
    {
        Description = description;
    }
}