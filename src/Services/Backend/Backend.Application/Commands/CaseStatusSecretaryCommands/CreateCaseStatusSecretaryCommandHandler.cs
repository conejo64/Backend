namespace Backend.Application.Commands.CaseStatusSecretaryCommands
{
    public class CreateCaseStatusSecretaryCommandHandler : IRequestHandler<CreateCaseStatusSecretaryCommand, EntityResponse<Guid>>
    {
        private readonly IRepository<CaseStatusSecretary> _repository;

        public CreateCaseStatusSecretaryCommandHandler(IRepository<CaseStatusSecretary> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<Guid>> Handle(CreateCaseStatusSecretaryCommand command, CancellationToken cancellationToken)
        {
            var entity = new CaseStatusSecretary(command.Description);
            await _repository.AddAsync(entity, cancellationToken);
            
            return EntityResponse.Success(entity.Id);
        }
    }
}