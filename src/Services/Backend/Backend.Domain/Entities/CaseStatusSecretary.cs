using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class CaseStatusSecretary : BaseEntity
{
    public string? Description { get; set; }
    public string Status { get; set; } = CatalogsStatus.Active;

    public CaseStatusSecretary(string? description)
    {
        Description = description;
    }
}