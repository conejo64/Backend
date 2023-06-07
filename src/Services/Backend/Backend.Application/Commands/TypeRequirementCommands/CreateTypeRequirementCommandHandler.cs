namespace Backend.Application.Commands.TypeRequirementCommands;

public class CreateTypeRequirementCommandHandler : IRequestHandler<CreateTypeRequirementCommand, EntityResponse<Guid>>
{
    private readonly IRepository<TypeRequirement> _repository;

    public CreateTypeRequirementCommandHandler(IRepository<TypeRequirement> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<Guid>> Handle(CreateTypeRequirementCommand command, CancellationToken cancellationToken)
    {
        var entity = new TypeRequirement(command.Description);
        await _repository.AddAsync(entity, cancellationToken);
            
        return EntityResponse.Success(entity.Id);
    }
}