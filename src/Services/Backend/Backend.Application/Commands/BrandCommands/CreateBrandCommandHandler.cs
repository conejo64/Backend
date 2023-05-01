namespace Backend.Application.Commands.BrandCommands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, EntityResponse<Guid>>
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<Guid>> Handle(CreateBrandCommand command, CancellationToken cancellationToken)
        {
            var entity = new Brand(command.Description);
            await _repository.AddAsync(entity, cancellationToken);
            
            return EntityResponse.Success(entity.Id);
        }
    }
}