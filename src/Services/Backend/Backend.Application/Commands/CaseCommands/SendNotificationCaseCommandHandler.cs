using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class SendNotificationCaseCommandHandler : IRequestHandler<SendNotificationCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly INotificationService _notificationService;

        public SendNotificationCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<User> userRepository, INotificationService notificationService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public async Task<EntityResponse<bool>> Handle(SendNotificationCaseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.CaseId, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
            }

            var destinationUser = await _userRepository.GetByIdAsync(entity.UserId, cancellationToken);
            string body = new("<p><br/>"
                    + "A continuación los detalles de notficacion del caso:<br/><br/>"
                    + "<b>Fecha: </b>" + DateTime.Now.ToShortDateString() + "<br/>"
                    + "<b>Mensaje: </b>" + command.Message+ "<br/>"
                    + "<b>Nro. Documento: </b>" + entity.DocumentNumber + "<br/>"
                    + "<b>Descripción: </b>" + entity.Description + "<br/>"
                    + "<a href=https://openkmapp/workflow/#/auth/login" + ">Por favor haga click en el siguiente enlace</a>"
                    + "<br />"
                    + "<br />"
                    + "<br />"
                    + "<b>Atentamente" + "<br/>"
                    + "<b>Secretaria General</b>"
                    + "<br />"
                    + "<br />"
                    + "<b>PD: Cualquier duda o inquietud comunicarse con Lorena Moreira (mmoreira@dinersclub.com.ec)</b>"
                    + "</p>");
            //Notificar a responsable
            if (destinationUser is not null)
            {
                _notificationService.SendEmailNotification(new EmailNotifictionModel()
                {
                    Subject = $"NOTIFICACION SECRETARIA - CASO {entity.DocumentNumber}",
                    To = destinationUser.Email,
                    Cc = "",
                    Body = body
                });
            }

            return true;
        }

    }
}
