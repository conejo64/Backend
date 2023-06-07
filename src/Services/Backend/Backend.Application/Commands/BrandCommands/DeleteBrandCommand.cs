namespace Backend.Application.Commands.BrandCommands;

public class DeleteBrandCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }

    public DeleteBrandCommand(Guid id)
    {
        Id = id;
    }
}