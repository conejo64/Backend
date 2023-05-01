using Backend.Application.Events.Domain;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Utils;

namespace Backend.Application.Commands.UserCommands
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, EntityResponse<Guid>>
    {
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IRepository<User> _repository;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IRepository<User> repository,
            IRepository<UserProfile> userProfileRepository, IMediator mediator)
        {
            _userProfileRepository = userProfileRepository;
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<EntityResponse<Guid>> Handle(CreateUserCommand command,
            CancellationToken cancellationToken)
        {
            var spec = new UserSpec(command.Email, UserTypes.Manager);
            var User = await _repository.GetBySpecAsync(spec, cancellationToken);
            if (User != null)
            {
                return EntityResponse<Guid>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.UserFound));
            }

            var managerUser = CreateUser(command);
            await _repository.AddAsync(managerUser, cancellationToken);

            if (command.ProfileIds.Any())
            {
                foreach (var profileId in command.ProfileIds)
                {
                    await _userProfileRepository.AddAsync(new UserProfile
                    {
                        ProfileId = Guid.Parse(profileId),
                        UserId = managerUser.Id
                    }, cancellationToken);
                }
            }

            await _repository.SaveChangesAsync(cancellationToken);           

            return EntityResponse.Success(managerUser.Id);
        }

        private static User CreateUser(CreateUserCommand command)
        {
            var newUser = new User(command.Username, command.FirstName, command.LastName, command.Email,
                 command.Identification, command.Phone, UserState.Active, command.Avatar)
            {
                Password = StringHandler.CreateMD5Hash(command.Identification)
            };
            return newUser;
        }

    }
}