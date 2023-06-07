namespace Backend.Application.Commands.ProvinceCommands;

public class DeleteProvinceCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }

    public DeleteProvinceCommand(Guid id)
    {
        Id = id;
    }
}