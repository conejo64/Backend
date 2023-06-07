using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class Reminder : BaseEntity
{
    public string? Description { get; set; }
    public string Status { get; set; } = CatalogsStatus.Active;

    public Reminder(string? description)
    {
        Description = description;
    }
}