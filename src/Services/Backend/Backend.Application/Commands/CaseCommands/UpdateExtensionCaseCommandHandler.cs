using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

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
        var extensionDate = Convert.ToDateTime(command.ExtensionRequestDate);
        var newExtensionDate = Convert.ToDateTime(command.NewExtensionRequestDate);
        entity.ExtensionRequestDate = command.ExtensionRequestDate;
        entity.NewExtensionRequestDate = command.NewExtensionRequestDate;
        entity.ObservationExtension = command.ObservationExtension;
        entity.Deadline = command.NewExtensionRequestDate;
        entity.CaseStage = StageEnum.Others;
        await _repository.UpdateAsync(entity, cancellationToken);
        var destinationUser = await _userRepository.GetByIdAsync(entity.UserId, cancellationToken);
        var originUser = await _userRepository.GetByIdAsync(entity.UserOriginId, cancellationToken);
        string body = new("<p>Se le ha asignado una nueva tarea.<br/>"
                          + "A continuaciòn se adjunta un detalle de la Prorroga:<br/><br/>"
                          + "<b>Fecha de Prorroga: </b>" + extensionDate.ToShortDateString() + "<br/>"
                          + "<b>fecha Limite: </b>" + newExtensionDate.ToShortDateString() + "<br/>"
                          + "<b>Observaciones: </b>" + command.ObservationExtension + "<br/>"
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
                          + "<b>PD: Cualquier duda o inquietud comunicarse con Secretaria General (secretariageneral@dinersclub.com.ec)</b>"
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