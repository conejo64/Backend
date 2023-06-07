namespace Backend.Application.Commands.BrandCommands;

public class CreateBrandCommand : IRequest<EntityResponse<Guid>>
{
    public string Description { get; }

    public CreateBrandCommand(string description)
    {
        Description = description;
    }
}