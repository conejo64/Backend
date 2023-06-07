namespace Backend.Application.Commands.DepartmentCommands;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, EntityResponse<Guid>>
{
    private readonly IRepository<Department> _repository;

    public CreateDepartmentCommandHandler(IRepository<Department> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<Guid>> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var entity = new Department(command.Description);
        await _repository.AddAsync(entity, cancellationToken);
            
        return EntityResponse.Success(entity.Id);
    }
}