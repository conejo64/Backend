using Backend.Application.Commands.AuthJwtCommands;
using Backend.Application.DTOs.Responses.UserResponses;
using Backend.Application.Queries.UserQueries;
using Backend.Application.Services.Reads;
using Backend.Application.Specifications.UserByEmailSpecs;
using Backend.Application.Utils;

namespace Backend.Application.Commands.UserCommands
{
    public class RecoverPasswordCommandHandler : IRequestHandler<RecoverPasswordCommand, EntityResponse<bool>>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<User> _repository;

        private User? _user;

        public RecoverPasswordCommandHandler(IMediator mediator, IRepository<User> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<EntityResponse<bool>> Handle(RecoverPasswordCommand command, CancellationToken cancellationToken)
        {
            var spec = new UserByEmailSpec(command.Email);
            var user = await _repository.GetBySpecAsync(spec, cancellationToken);
            if (user is null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.EmailFound));
            }

            var newPassword = GeneratePassword();

            //Send email
            var sendEmailModel = new SendEmailNotificationCommand(command.Email,"","","Backend - Recuperar contrase�a",
                String.Format("Se ha generado su nueva contrase�a: <br> Contrase�a: {0}", newPassword),new List<string>());
            await _mediator.Send(sendEmailModel, cancellationToken);

            user.Password = StringHandler.CreateMD5Hash(newPassword); 
            await _repository.UpdateAsync(user, cancellationToken);

            return EntityResponse<bool>.Success(true);
        }

        #region Private methods

        private string GeneratePassword()
        {
            Random random = new Random();
            var passLineal = string.Format("SV{0}", random.Next(1000000));
            return passLineal;
        }

        #endregion
    }
}