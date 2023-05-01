namespace Backend.Application.Commands.CaseStatusCommands
{
    public class CreateCaseStatusCommandHandler : IRequestHandler<CreateCaseStatusCommand, EntityResponse<Guid>>
    {
        private readonly IRepository<CaseStatus> _repository;

        public CreateCaseStatusCommandHandler(IRepository<CaseStatus> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<Guid>> Handle(CreateCaseStatusCommand command, CancellationToken cancellationToken)
        {
            var entity = new CaseStatus(command.Description);
            await _repository.AddAsync(entity, cancellationToken);
            
            return EntityResponse.Success(entity.Id);
        }
    }
}