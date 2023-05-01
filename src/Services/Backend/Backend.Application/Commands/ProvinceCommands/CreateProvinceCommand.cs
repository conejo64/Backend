namespace Backend.Application.Commands.ProvinceCommands

{
    public class CreateProvinceCommand : IRequest<EntityResponse<Guid>>
    {
        public string Description { get; }

        public CreateProvinceCommand(string description)
        {
            Description = description;
        }
    }
}