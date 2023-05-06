using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class UpdateExtensionCaseCommandHandler : IRequestHandler<UpdateExtensionCaseCommand, EntityResponse<bool>>
    {
        private readonly IRepository<CaseEntity> _repository;
        private readonly INotificationService _notificationService;
        private readonly IRepository<User> _userRepository;

        public UpdateExtensionCaseCommandHandler(IRepository<CaseEntity> repository, INotificationService notificationService, IRepository<User> userRepository)
        {
            _repository = repository;
            _notificationService = notificationService;
            _userRepository = userRepository;
        }

        public async Task<EntityResponse<bool>> Handle(UpdateExtensionCaseCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id, cancellationToken);

            if (entity == null)
            {
                return EntityResponse<bool>.Error(EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
            }

            entity.ExtensionRequestDate = command.ExtensionRequestDate;
            entity.NewExtensionRequestDate = command.NewExtensionRequestDate;
            entity.ObservationExtension = command.ObservationExtension;
            entity.Deadline = command.NewExtensionRequestDate;
            await _repository.UpdateAsync(entity, cancellationToken);
            var destinationUser = await _userRepository.GetByIdAsync(entity.UserId, cancellationToken);
            var originUser = await _userRepository.GetByIdAsync(entity.UserOriginId, cancellationToken);
            string body = new("<p>Se le ha asignado una nueva tarea.<br/>"
                    + "A continuaciòn se adjunta un detalle de la Prorroga:<br/><br/>"
                    + "Fecha de Prorroga: " + command.ExtensionRequestDate + "<br/>"
                    + "fecha Limite: " + command.NewExtensionRequestDate + "<br/>"
                    + "Observaciones: " + command.ObservationExtension + "<br/>"
                    + "</p>");
            if (destinationUser is not null)
            {
                _notificationService.SendEmailNotification(new EmailNotifictionModel()
                {
                    Subject = string.IsNullOrEmpty(entity.Subject) ? "NOTIFICACION SECRETARIA EXTENSION DE CASO" : entity.Subject,
                    To = destinationUser.Email,
                    Cc = originUser!.Email,
                    Body = body
                });
            }

            return true;
        }

    }
}
