namespace Backend.Application.Commands.ProvinceCommands;

public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, EntityResponse<Guid>>
{
    private readonly IRepository<Province> _repository;

    public CreateProvinceCommandHandler(IRepository<Province> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<Guid>> Handle(CreateProvinceCommand command, CancellationToken cancellationToken)
    {
        var entity = new Province(command.Description);
        await _repository.AddAsync(entity, cancellationToken);
            
        return EntityResponse.Success(entity.Id);
    }
}