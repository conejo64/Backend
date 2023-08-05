using Backend.Application.Specifications.CaseDocumentSpecs;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;

namespace Backend.Application.Commands.NotificationCommands;

public class SendCloseNotificationCommandHandler : IRequestHandler<SendCloseNotificationCommand, EntityResponse<bool>>
{
    private readonly IRepository<CaseEntity> _repository;
    private readonly IRepository<CaseStatus> _repositoryCaseStatus;
    private readonly INotificationService _notificationService;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<CaseStatusSecretary> _repositoryCaseStatusSecretary;
    private readonly IRepository<DocumentEntity> _documentRepository;

    public SendCloseNotificationCommandHandler(IRepository<CaseEntity> repository, 
        IRepository<CaseStatus> repositoryCaseStatus, INotificationService notificationService,
        IRepository<User> userRepository, IRepository<CaseStatusSecretary> repositoryCaseStatusSecretary,
        IRepository<DocumentEntity> documentRepository)
    {
        _repository = repository;
        _repositoryCaseStatus = repositoryCaseStatus;
        _notificationService = notificationService;
        _userRepository = userRepository;
        _repositoryCaseStatusSecretary = repositoryCaseStatusSecretary;
        _documentRepository = documentRepository;
    }

    public async Task<EntityResponse<bool>> Handle(SendCloseNotificationCommand command, CancellationToken cancellationToken)
    {
        var caseEntity = await _repository.GetByIdAsync(command.CaseEntityId, cancellationToken);
        if (caseEntity is null)
        {
            return EntityResponse.Success(false); 
        }
        
        var receptionDateShort = Convert.ToDateTime(caseEntity.ResponseDate);
        var deadLineDateShort = Convert.ToDateTime(caseEntity.AcknowledgmentDate);
        var destinationUser = await _userRepository.GetByIdAsync(caseEntity.UserId, cancellationToken);
        var origintionUser = await _userRepository.GetByIdAsync(caseEntity.UserOriginId, cancellationToken);
        var caseStatus = await _repositoryCaseStatus.GetByIdAsync(caseEntity.CaseStatusId, cancellationToken);
        var caseStatusSecretary = await _repositoryCaseStatusSecretary.GetByIdAsync(caseEntity.CaseStatusSecretaryId, cancellationToken);
        string body = new string("<p><b>Se ha finalizado la gestión del Caso.</b><br/>"
                                 + "A continuación se adjunta un detalle del caso cerrado:<br/><br/>"
                                 + "<b>Fecha Respuesta: </b>" + receptionDateShort.ToShortDateString() + "<br/>"
                                 + "<b>Estado del Caso: </b>" + caseStatus!.Description + "<br/>"
                                 + "<b>Comentarios Finales: </b>" + caseEntity.ObservationDepartment! + "<br/>"
                                 + "<b>Revisión de Secretaria: </b>" + caseStatusSecretary!.Description + "<br/>"
                                 + "<b>Fecha Acuse recibido: </b>" + deadLineDateShort.ToShortDateString() + "<br/>"
                                 + "<b>Nro. Documento: </b>" + caseEntity.DocumentNumber + "<br/>"
                                 + "<b>Descripción: </b>" + caseEntity.Description + "<br/>"
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
        if (destinationUser is not null && caseEntity.CaseStatus!.Description == "CERRADO")
        {
            _notificationService.SendEmailNotification(new EmailNotifictionModel()
            {
                Subject = string.IsNullOrEmpty(caseEntity.Subject) ? "NOTIFICACION CIERRE DE REQUERIMIENTO SECRETARIA" : caseEntity.Subject,
                To = destinationUser.Email,
                Cc = origintionUser!.Email,
                Body = body
            });
        }
        
        return EntityResponse.Success(true);
    }

    #region Private methods
private static string GetBody(string? descriptiontype, string? receptionDate, string? descriptionOrigin, string? number, string? description, string? entidad,
        string? department, string? user, string? transferDate)
    {
        var receptionDateShort = Convert.ToDateTime(receptionDate);
        var deadLineDateShort = Convert.ToDateTime(transferDate);
        var body = "<p><br/>"
                   + "A continuación se adjunta un detalle del caso:<br/><br/>"
                   + "<b>Tipo Requerimiento:</b> " + descriptiontype + "<br/>"
                   + "<b>Fecha de Recepción: </b>" + receptionDateShort.ToShortDateString() + "<br/>"
                   + "<b>Origen del Documento: </b>" + descriptionOrigin + "<br/>"
                   + "<b>Nro. Documento: </b>" + number + "<br/>"
                   + "<b>Descripción: </b>" + description + "<br/>"
                   + "<b>Entidad: </b>" + entidad + "<br/>"
                   + "<b>Area Responsable: </b>" + department + "<br/>"
                   + "<b>Destinatario Responsable: </b>" + user + "<br/>"
                   + "<b>Fecha Límite: </b>" + deadLineDateShort.ToShortDateString() + "<br/>"
                   + "<a href=https://openkmapp/workflow/#/auth/login" + ">Por favor haga click en el siguiente enlace</a>"
                   + "<br />"
                   + "<br />"
                   + "<br />"
                   + "<b>Atentamente" + "<br/>"
                   + "<b>Secretaria General</b>"
                   + "<br />"
                   + "<br />"
                   + "<b>PD: Cualquier duda o inquietud comunicarse con Secretaria General (secretariageneral@dinersclub.com.ec)</b>"
                   + "</p>";
        return body!;
    }

    private static string GetBodyAttachment(string? descriptiontype, string? receptionDate, string? descriptionOrigin, string? number, string? description, string? entidad,
        string? department, string? user, string? transferDate)
    {
        var receptionDateShort = Convert.ToDateTime(receptionDate);
        var deadLineDateShort = Convert.ToDateTime(transferDate);
        var body = "<p><br/>"
                   + "A continuación se adjunta un detalle del caso:<br/><br/>"
                   + "<b>Tipo Requerimiento:</b> " + descriptiontype + "<br/>"
                   + "<b>Fecha de Recepción: </b>" + receptionDateShort.ToShortDateString() + "<br/>"
                   + "<b>Origen del Documento: </b>" + descriptionOrigin + "<br/>"
                   + "<b>Nro. Documento: </b>" + number + "<br/>"
                   + "<b>Descripción: </b>" + description + "<br/>"
                   + "<b>Entidad: </b>" + entidad + "<br/>"
                   + "<b>Area Responsable: </b>" + department + "<br/>"
                   + "<b>Destinatario Responsable: </b>" + user + "<br/>"
                   + "<b>Fecha Límite: </b>" + deadLineDateShort.ToShortDateString() + "<br/>"
                   + "<br />"
                   + "<br />"
                   + "<br />"
                   + "<b>Atentamente" + "<br/>"
                   + "<b>Secretaria General</b>"
                   + "<br />"
                   + "<br />"
                   + "<b>PD: Cualquier duda o inquietud comunicarse con Secretaria General</b>"
                   + "</p>";
        return body!;
    }
    
    private string GetImage(string pathFile, string contentRootPath)
    {
        try
        {
            var base64 = string.Empty;
            var dir = $"{contentRootPath}/AppFiles/Cases";
            dir = Path.Combine(dir, pathFile);

            if (File.Exists(dir))
            {
                var arrayByte = File.ReadAllBytes(dir);
                if (arrayByte != null)
                {
                    base64 = Convert.ToBase64String(arrayByte);
                }
            }

            return base64;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #endregion
}