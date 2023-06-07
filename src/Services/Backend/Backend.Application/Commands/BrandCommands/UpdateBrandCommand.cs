namespace Backend.Application.Commands.BrandCommands;

public class UpdateBrandCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }
    public string Description { get; }

    public UpdateBrandCommand(Guid id, string description)
    {
        Id = id;
        Description = description;
    }
}