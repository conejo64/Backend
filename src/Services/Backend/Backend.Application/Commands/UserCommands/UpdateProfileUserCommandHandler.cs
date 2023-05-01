using Backend.Application.Specifications.MemberSpecs;

namespace Backend.Application.Commands.UserCommands
{
    public class UpdateProfileUserCommandHandler
        : IRequestHandler<UpdateProfileUserCommand, EntityResponse<bool>>
    {
        private readonly IRepository<User> _repository;

        public UpdateProfileUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateProfileUserCommand command,
            CancellationToken cancellationToken)
        {
            var spec = new ManagerSpec(command.UserId);
            var User = await _repository.GetBySpecAsync(spec, cancellationToken);
            if (User == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.UserFound));
            }

            await UpdateUser(command, cancellationToken, User);

            return true;
        }

        private async Task UpdateUser(UpdateProfileUserCommand command, CancellationToken cancellationToken,
            User applicationUser)
        {
            applicationUser.Email = command.Email ?? applicationUser.Email;
            applicationUser.FirstName = command.FirstName ?? applicationUser.FirstName;
            applicationUser.LastName = command.LastName ?? applicationUser.LastName;
            applicationUser.Username = command.Username ?? applicationUser.Username;
            applicationUser.Phone = command.Phone ?? applicationUser.Phone;
            applicationUser.Identification = command.Identification ?? applicationUser.Identification;

            await _repository.UpdateAsync(applicationUser, cancellationToken);
        }
    }
}