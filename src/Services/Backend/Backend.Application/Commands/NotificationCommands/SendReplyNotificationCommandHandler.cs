using Backend.Application.Specifications.CaseDocumentSpecs;
using Backend.Application.Specifications.CaseStatusSpecs;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;

namespace Backend.Application.Commands.NotificationCommands;

public class SendReplyNotificationCommandHandler : IRequestHandler<SendReplyNotificationCommand, EntityResponse<bool>>
{
    private readonly IRepository<CaseEntity> _repository;
    private readonly IRepository<User> _userRepository;
    private readonly INotificationService _notificationService;
    private readonly IRepository<DocumentEntity> _documentRepository;
    private readonly IRepository<Brand> _brandRepository;
    private readonly IRepository<TypeRequirement> _typeRepository;
    private readonly IRepository<Department> _departmentRepository;
    private readonly IRepository<OriginDocument> _originRepository;
    private readonly IRepository<CaseStatus> _caseStatusRepository;

    public SendReplyNotificationCommandHandler(IRepository<CaseEntity> repository, IRepository<User> userRepository,
        INotificationService notificationService, IRepository<DocumentEntity> documentRepository, 
        IRepository<Brand> brandRepository, IRepository<TypeRequirement> typeRepository,
        IRepository<Department> departmentRepository, IRepository<OriginDocument> originRepository,
        IRepository<CaseStatus> caseStatusRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
        _notificationService = notificationService;
        _documentRepository = documentRepository;
        _brandRepository = brandRepository;
        _typeRepository = typeRepository;
        _departmentRepository = departmentRepository;
        _originRepository = originRepository;
        _caseStatusRepository = caseStatusRepository;
    }

    public async Task<EntityResponse<bool>> Handle(SendReplyNotificationCommand command, CancellationToken cancellationToken)
    {
        var caseEntity = await _repository.GetByIdAsync(command.CaseEntityId, cancellationToken);
        if (caseEntity is null)
        {
            return EntityResponse.Success(false); 
        }
        
        var brand = await _brandRepository.GetByIdAsync(caseEntity.BrandId, cancellationToken);
        var typeRequirement = await _typeRepository.GetByIdAsync(caseEntity.TypeRequirementId, cancellationToken);
        var originDocument = await _originRepository.GetByIdAsync(caseEntity.OriginDocumentId, cancellationToken);
        var department = await _departmentRepository.GetByIdAsync(caseEntity.DepartmentId, cancellationToken);
        var statusSpec = new CaseStatusSpec("RESPONDIDO");
        var statusId = await _caseStatusRepository.GetBySpecAsync(statusSpec, cancellationToken);
        
        var destinationUser = await _userRepository.GetByIdAsync(caseEntity.UserOriginId, cancellationToken);
        var originUser = await _userRepository.GetByIdAsync(caseEntity.UserId, cancellationToken);
        var receptionDateShort = Convert.ToDateTime(caseEntity.ReceptionDate);

        string body = new("<p><br/>"
                          + "A continuación se adjunta un detalle de la respuesta al caso :<br/><br/>"
                          + "<b>Tipo Requerimiento:</b> " + typeRequirement!.Description + "<br/>"
                          + "<b>Fecha de Recepción: </b>" + receptionDateShort.ToShortDateString() + "<br/>"
                          + "<b>Origen del Documento: </b>" + originDocument!.Description + "<br/>"
                          + "<b>Nro. Documento: </b>" + caseEntity.DocumentNumber + "<br/>"
                          + "<b>Descripción: </b>" + caseEntity.Description + "<br/>"
                          + "<b>Entidad: </b>" + brand!.Description + "<br/>"
                          + "<b>Area Responsable: </b>" + department!.Description + "<br/>"
                          + "<b>Fecha de Contestación: </b>" + caseEntity.ReplyDate!.Value.ToShortDateString() + "<br/>"
                          + "<b>Observaciones: </b>" + caseEntity.Comments+ "<br/>"
                          + "<a href=https://openkmapp/workflow/#/auth/login>Por favor haga click en el siguiente enlace</a>"
                          + "</p>");
        
        if (destinationUser is not null)
        {
            _notificationService.SendEmailNotification(new EmailNotifictionModel()
            {
                Subject = string.IsNullOrEmpty(caseEntity.Subject) ? "NOTIFICACION RESPUESTA A SECRETARIA" : caseEntity.Subject,
                To = destinationUser.Email,
                Cc = originUser!.Email,
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