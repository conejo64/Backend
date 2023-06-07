using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class Province : BaseEntity
{
    public string? Description { get; set; }
    public string Status { get; set; } = CatalogsStatus.Active;

    public Province(string? description)
    {
        Description = description;
    }
}