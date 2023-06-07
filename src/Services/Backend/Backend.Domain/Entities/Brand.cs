using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class Brand : BaseEntity
{
    public string? Description { get; set; }
    public string Status { get; set; } = CatalogsStatus.Active;

    public Brand(string? description)
    {
        Description = description;
    }
}