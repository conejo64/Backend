using Backend.Application.Specifications.CaseDocumentSpecs;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;

namespace Backend.Application.Commands.NotificationCommands;

public class SendCreateNotificationCommandHandler : IRequestHandler<SendCreateNotificationCommand, EntityResponse<bool>>
{
    private readonly IMediator _mediator;
    private readonly IRepository<CaseEntity> _repository;
    private readonly IRepository<CaseStatus> _repositoryCaseStatus;
    private readonly INotificationService _notificationService;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<OriginDocument> _originRepository;
    private readonly IRepository<Brand> _brandRepository;
    private readonly IRepository<TypeRequirement> _typeRepository;
    private readonly IRepository<Department> _departmentRepository;
    private readonly IRepository<DocumentEntity> _documentRepository;
    private readonly IRepository<Reminder> _reminderRepository;

    public SendCreateNotificationCommandHandler(IMediator mediator, IRepository<CaseEntity> repository,
        IRepository<CaseStatus> repositoryCaseStatus, INotificationService notificationService,
        IRepository<User> userRepository, IRepository<OriginDocument> originRepository, 
        IRepository<Brand> brandRepository, IRepository<TypeRequirement> typeRepository, 
        IRepository<Department> departmentRepository, IRepository<DocumentEntity> documentRepository,
        IRepository<Reminder> reminderRepository)
    {
        _mediator = mediator;
        _repository = repository;
        _repositoryCaseStatus = repositoryCaseStatus;
        _notificationService = notificationService;
        _userRepository = userRepository;
        _originRepository = originRepository;
        _brandRepository = brandRepository;
        _typeRepository = typeRepository;
        _departmentRepository = departmentRepository;
        _documentRepository = documentRepository;
        _reminderRepository = reminderRepository;
    }

    public async Task<EntityResponse<bool>> Handle(SendCreateNotificationCommand command, CancellationToken cancellationToken)
    {
        var caseEntity = await _repository.GetByIdAsync(command.CaseEntityId, cancellationToken);
        if (caseEntity is null)
        {
            return EntityResponse.Success(false); 
        }
        
        var destinationUser = await _userRepository.GetByIdAsync(caseEntity.UserId, cancellationToken);
        var brand = await _brandRepository.GetByIdAsync(caseEntity.BrandId, cancellationToken);
        var typeRequirement = await _typeRepository.GetByIdAsync(caseEntity.TypeRequirementId, cancellationToken);
        var originDocument = await _originRepository.GetByIdAsync(caseEntity.OriginDocumentId, cancellationToken);
        var department = await _departmentRepository.GetByIdAsync(caseEntity.DepartmentId, cancellationToken);
        var body = GetBody(typeRequirement!.Description, caseEntity.ReceptionDate.ToString(), originDocument!.Description, caseEntity.DocumentNumber, caseEntity.Description, brand!.Description,
            department!.Description, destinationUser!.FullName, caseEntity.Deadline.ToString());
        var bodyAttachment = GetBodyAttachment(typeRequirement!.Description, caseEntity.ReceptionDate.ToString(), originDocument!.Description, caseEntity.DocumentNumber, caseEntity.Description, brand!.Description,
            department!.Description, destinationUser!.FullName, caseEntity.Deadline.ToString());
        //Notification Attachement
        var spec = new CaseDocumentSpec(caseEntity.Id, DocumentSourceEnum.Create);
        var entities = await _documentRepository.ListAsync(spec, cancellationToken);
        var documentList = new List<string>();
        var documentNamesList = new List<string>();
        
        if (entities.Any())
        {
            for (int i = 0; i < entities.Count; i++)
            {
                var documentName = entities.ElementAt(i).Document64Name;
                documentNamesList.Add(documentName!);
                var pathFile = string.Format("{0}/{1}", caseEntity!.DocumentNumber, documentName);
                var base64 = GetImage(pathFile, command.ContentRootPath!);
                documentList.Add(base64);
            }
        }
        var attachemt = documentList;
        if (!string.IsNullOrEmpty(caseEntity.Notification))
        {
            _notificationService.SendEmailNotification(new EmailNotifictionModel()
            {
                Subject = string.IsNullOrEmpty(caseEntity.Subject) ? "NOTIFICACION SECRETARIA" : caseEntity.Subject,
                To = caseEntity.Notification!,
                Attachment = attachemt!,
                AttachmentNames = documentNamesList!,
                Body = bodyAttachment
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