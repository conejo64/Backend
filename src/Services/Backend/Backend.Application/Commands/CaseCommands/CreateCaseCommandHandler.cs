using Backend.Application.Specifications.CaseStatusSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;
using Backend.Domain.Entities;
using System.Security.Policy;
using System.Drawing.Drawing2D;

namespace Backend.Application.Commands.CaseCommands;

public class CreateCaseCommandHandler : IRequestHandler<CreateCaseCommand, EntityResponse<Guid>>
{
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
    private readonly IOpenKmService _openKmService;
    public CreateCaseCommandHandler(IRepository<CaseEntity> repository, IRepository<CaseStatus> repositoryCaseStatus,
        INotificationService notificationService, IRepository<User> userRepository, IRepository<Brand> brandRepository,
        IRepository<OriginDocument> originRepository, IRepository<TypeRequirement> typeRepository,
        IRepository<Department> departmentRepository, IRepository<DocumentEntity> documentRepository,
        IRepository<Reminder> reminderRepository, IOpenKmService openKmService)
    {
        _repository = repository;
        _repositoryCaseStatus = repositoryCaseStatus;
        _notificationService = notificationService;
        _userRepository = userRepository;
        _brandRepository = brandRepository;
        _originRepository = originRepository;
        _typeRepository = typeRepository;
        _departmentRepository = departmentRepository;
        _documentRepository = documentRepository;
        _reminderRepository = reminderRepository;
        _openKmService = openKmService;
    }

    public async Task<EntityResponse<Guid>> Handle(CreateCaseCommand command, CancellationToken cancellationToken)
    {
        var statusSpec = new CaseStatusSpec("ABIERTO");
        var statusId = await _repositoryCaseStatus.GetBySpecAsync(statusSpec, cancellationToken);
        var reminderSelect = await _reminderRepository.GetByIdAsync(command.ReminderId!, cancellationToken);
        var reminderDate = DateTime.Now;
        if (reminderSelect != null)
        {
            var hour = Int32.Parse(reminderSelect.Description!);
            reminderDate = reminderDate.AddHours(hour);
        }
        var entity = new CaseEntity(command.RequirementNumber, DateTime.Now, command.OriginDocumentId, command.PhysicallyReceived, command.DigitallyReceived, command.DocumentNumber,
            command.SbsNumber, command.JudgmentNumber, command.IssueDate, command.Description, command.BrandId, command.DepartmentId, command.UserId, command.TypeRequirementId,
            command.Notification, command.Subject, command.TransferDate, command.Deadline, command.ProvinceId, command.DueDate, command.ReminderId, command.ReplyDate, command.Comments,
            command.ResponseDate, statusId!.Id, command.ObservationDepartment, command.CaseStatusSecretaryId, command.AcknowledgmentDate, command.ExtensionRequestDate, command.NewExtensionRequestDate,
            command.ObservationExtension, command.UserOriginId, reminderDate, command.CaseStage);
        await _repository.AddAsync(entity, cancellationToken);

        var destinationUser = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);
        var brand = await _brandRepository.GetByIdAsync(command.BrandId, cancellationToken);
        var typeRequirement = await _typeRepository.GetByIdAsync(command.TypeRequirementId, cancellationToken);
        var originDocument = await _originRepository.GetByIdAsync(command.OriginDocumentId, cancellationToken);
        var department = await _departmentRepository.GetByIdAsync(command.DepartmentId, cancellationToken);
        var body = GetBody(typeRequirement!.Description, command.ReceptionDate.ToString(), originDocument!.Description, command.DocumentNumber, command.Description, brand!.Description,
            department!.Description, destinationUser!.FullName, command.Deadline.ToString());
        // var bodyAttachment = GetBodyAttachment(typeRequirement!.Description, command.ReceptionDate.ToString(), originDocument!.Description, command.DocumentNumber, command.Description, brand!.Description,
        //     department!.Description, destinationUser!.FullName, command.Deadline.ToString());
        //Notification
        if (destinationUser is not null)
        {
            _notificationService.SendEmailNotification(new EmailNotifictionModel()
            {
                Subject = string.IsNullOrEmpty(command.Subject) ? "NOTIFICACION SECRETARIA" : command.Subject,
                To = destinationUser.Email,
                Body = body
            });
        }
        //Notification Attachement
        // var documentList = new List<string>();
        // var documentNamesList = new List<string>();
        // if (command.DocumentString != null)
        // {
        //     for (int i = 0; i < command.DocumentString!.Count; i++)
        //     {
        //         var documentSplit = command.DocumentString.ElementAt(i).Split(',');
        //         documentList.Add(documentSplit[1]);
        //         documentNamesList.Add(command.DocumentStringNames!.ElementAt(i));
        //     }
        // }
        // var attachemt = documentList;
        // if (!string.IsNullOrEmpty(command.Notification))
        // {
        //     _notificationService.SendEmailNotification(new EmailNotifictionModel()
        //     {
        //         Subject = string.IsNullOrEmpty(command.Subject) ? "NOTIFICACION SECRETARIA" : command.Subject,
        //         To = command.Notification!,
        //         Attachment = attachemt!,
        //         AttachmentNames = documentNamesList!,
        //         Body = bodyAttachment
        //     });
        // }
        //Save Documents
        // if (command.DocumentString != null && command.DocumentStringNames != null)
        // {
        //     for (int i = 0; i < command.DocumentString!.Count; i++)
        //     {
        //         var documentSplit = command.DocumentString.ElementAt(i).Split(',');
        //         var contentTypeSplit = documentSplit[0].Split(':');
        //         var document = new DocumentEntity
        //         {
        //             CaseEntityId = entity.Id,
        //             DocumentSource = DocumentSourceEnum.Create,
        //             Document64 = String.Empty, 
        //             Document64Name = command.DocumentStringNames!.ElementAt(i),
        //             ContextType = contentTypeSplit[1].Split(';')[0],
        //         };
        //         await _documentRepository.AddAsync(document, cancellationToken);
        //         byte[] bytes = Convert.FromBase64String(documentSplit[1]);
        //         var stream = new MemoryStream(bytes);
        //         var fileName = command.DocumentStringNames!.ElementAt(i);
        //         var path = $"Cases/{command.DocumentNumber}";
        //
        //         await SaveFile(stream, fileName, command.ContentRootPath!,path,  cancellationToken);
        //         //await _documentRepository.AddAsync(document, cancellationToken);
        //         document = new DocumentEntity();
        //     }
        //     
        //     await _documentRepository.SaveChangesAsync(cancellationToken);
        //     _openKmService.SendOpenKm(command.DocumentString, command.DocumentString);
        // }
            
        return EntityResponse.Success(entity.Id);
    }

    public static string GetBody(string? descriptiontype, string? receptionDate, string? descriptionOrigin, string? number, string? description, string? entidad,
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

    public static string GetBodyAttachment(string? descriptiontype, string? receptionDate, string? descriptionOrigin, string? number, string? description, string? entidad,
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
    
    #region Files
    public string GetSavePath(string fileName, string prefix, string contentRootPath)
    {
        var dir = $"{contentRootPath}/AppFiles";
        if (prefix != null)
            dir = Path.Combine(dir, prefix);

        return Path.Combine(dir, fileName);
    }

    private async Task SaveFile(Stream fileStream, string fileName, string contentRootPath, string prefix = default,
        CancellationToken cancellationToken = default)
    {
        var savePath = GetSavePath(fileName, prefix, contentRootPath);
        var dir = $"{contentRootPath}/AppFiles";
        if (prefix != null)
            dir = Path.Combine(dir, prefix);

        var exist = Directory.Exists(dir);
        if (!exist)
        {
            Directory.CreateDirectory(dir);
        }

        await using var stream = File.Create(savePath);
        await fileStream.CopyToAsync(stream, cancellationToken);
    }
    #endregion
}