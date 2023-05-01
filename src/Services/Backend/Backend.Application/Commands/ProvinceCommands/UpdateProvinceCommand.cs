namespace Backend.Application.Commands.ProvinceCommands
{
    public class UpdateProvinceCommand : IRequest<EntityResponse<bool>>
    {
        public Guid Id { get; }
        public string Description { get; }

        public UpdateProvinceCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}