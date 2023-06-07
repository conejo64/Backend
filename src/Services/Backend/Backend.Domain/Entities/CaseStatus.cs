using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class CaseStatus : BaseEntity
{
    public string? Description { get; set; }
    public string Status { get; set; } = CatalogsStatus.Active;

    public CaseStatus(string? description)
    {
        Description = description;
    }
}