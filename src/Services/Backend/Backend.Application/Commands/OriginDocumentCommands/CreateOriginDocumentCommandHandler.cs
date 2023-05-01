namespace Backend.Application.Commands.OriginDocumentCommands
{
    public class CreateOriginDocumentCommandHandler : IRequestHandler<CreateOriginDocumentCommand, EntityResponse<Guid>>
    {
        private readonly IRepository<OriginDocument> _repository;

        public CreateOriginDocumentCommandHandler(IRepository<OriginDocument> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<Guid>> Handle(CreateOriginDocumentCommand command, CancellationToken cancellationToken)
        {
            var entity = new OriginDocument(command.Description);
            await _repository.AddAsync(entity, cancellationToken);
            
            return EntityResponse.Success(entity.Id);
        }
    }
}