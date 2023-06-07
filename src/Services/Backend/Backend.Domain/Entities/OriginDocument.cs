using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class OriginDocument : BaseEntity
{
    public string? Description { get; set; }
    public string Status { get; set; } = CatalogsStatus.Active;

    public OriginDocument(string? description)
    {
        Description = description;
    }
}