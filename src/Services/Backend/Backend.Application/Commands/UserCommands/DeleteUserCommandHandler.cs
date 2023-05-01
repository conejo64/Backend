namespace Backend.Application.Commands.UserCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, EntityResponse<bool>>
    {
        #region Constructor & Properties

        private readonly IMediator _mediator;
        private readonly IRepository<User> _userRepository;

        public DeleteUserCommandHandler(IMediator mediator, IRepository<User> userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }


        #endregion

        #region Public Methods

        public async Task<EntityResponse<bool>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var validateResponse = await Validations(command, cancellationToken);
            if (!validateResponse.IsSuccess)
            {
                return EntityResponse<bool>.Error(validateResponse);
            }

            var dbUser = validateResponse.Value;
            await UpdateUser(dbUser!, cancellationToken);

            return EntityResponse.Success(true);
        }

        #endregion

        #region Private Methods

        private async Task<EntityResponse<User>> Validations(DeleteUserCommand command,
            CancellationToken cancellationToken)
        {
            var area = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

            return area is null
                ? EntityResponse<User>.Error(MessageHandler.UserNotFound)
                : EntityResponse.Success(area);
        }

        private async Task UpdateUser(User applicationUser, CancellationToken cancellationToken)
        {
            applicationUser.Status = CatalogsStatus.Deleted;
            await _userRepository.UpdateAsync(applicationUser, cancellationToken);
        }

        #endregion
    }
}