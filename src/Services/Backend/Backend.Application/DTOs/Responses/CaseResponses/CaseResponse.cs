using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.CaseResponses;

public class CaseResponse
{
    public Guid Id { get; }
    public string Status { get; set; }
    public string? RequirementNumber { get; set; }
    public DateTime? ReceptionDate { get; set; }
    public Guid? OriginDocumentId { get; set; }
    public string? OriginDocumentDescription { get; set; }
    public string? PhysicallyReceived { get; set; }
    public string? DigitallyReceived { get; set; }
    public string? DocumentNumber { get; set; }
    public string? SbsNumber { get; set; }
    public string? JudgmentNumber { get; set; }
    public DateTime? IssueDate { get; set; }
    public string? Description { get; set; }
    public Guid? BrandId  { get; set; }
    public string? BrandDescription  { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? DepartmentDescription { get; set; }
    public Guid? UserId{ get; set; }
    public string? UserDescription{ get; set; }
    public Guid? TypeRequirementId { get; set; }
    public string? TypeRequirementDescription { get; set; }
    public string? Notification { get; set; }
    public string? Subject { get; set; }
    public DateTime? TransferDate { get; set; }
    public DateTime? Deadline { get; set; }
    public Guid? ProvinceId { get; set; }
    public string? ProvinceDescription { get; set; }
    public DateTime? DueDate { get; set; }
    public Guid? ReminderId { get; set; }
    public string? ReminderDescription { get; set; }
    //Screen Department
    public DateTime? ReplyDate { get; set; }
    public string? Comments { get; set; }
    //Screen Close Secretary
    public DateTime? ResponseDate { get; set; }
    public Guid? CaseStatusId { get; set; }
    public string? CaseStatusDescription { get; set; }
    public string? ObservationDepartment { get; set; }
    public Guid? CaseStatusSecretaryId { get; set; }
    public string? CaseStatusSecretaryDescription { get; set; }
    public DateTime? AcknowledgmentDate { get; set; }
    //Screen Prorrogation
    public DateTime? ExtensionRequestDate { get; set; }
    public DateTime? NewExtensionRequestDate { get; set; }
    public string? ObservationExtension { get; set; }
    public DateTime? ReminderDate { get; set; }
    public string CaseStage { get; set; }

    public CaseResponse(Guid id, string status, string? requirementNumber, DateTime? receptionDate, 
        Guid? originDocumentId, string? originDocumentDescription, string? physicallyReceived, 
        string? digitallyReceived, string? documentNumber, string? sbsNumber, string? judgmentNumber,
        DateTime? issueDate, string? description, Guid? brandId, string? brandDescription, 
        Guid? departmentId, string? departmentDescription, Guid? userId, string? userDescription, 
        Guid? typeRequirementId, string? typeRequirementDescription, string? notification, 
        string? subject, DateTime? transferDate, DateTime? deadline, Guid? provinceId, 
        string? provinceDescription, DateTime? dueDate, Guid? reminderId, string? reminderDescription,
        DateTime? replyDate, string? comments, DateTime? responseDate, Guid? caseStatusId, 
        string? caseStatusDescription, string? observationDepartment, Guid? caseStatusSecretaryId,
        string? caseStatusSecretaryDescription, DateTime? acknowledgmentDate, DateTime? extensionRequestDate,
        DateTime? newExtensionRequestDate, string? observationExtension, DateTime? reminderDate, string caseStage)
    {
        Id = id;
        Status = status;
        RequirementNumber = requirementNumber;
        ReceptionDate = receptionDate;
        OriginDocumentId = originDocumentId;
        OriginDocumentDescription = originDocumentDescription;
        PhysicallyReceived = physicallyReceived;
        DigitallyReceived = digitallyReceived;
        DocumentNumber = documentNumber;
        SbsNumber = sbsNumber;
        JudgmentNumber = judgmentNumber;
        IssueDate = issueDate;
        Description = description;
        BrandId = brandId;
        BrandDescription = brandDescription;
        DepartmentId = departmentId;
        DepartmentDescription = departmentDescription;
        UserId = userId;
        UserDescription = userDescription;
        TypeRequirementId = typeRequirementId;
        TypeRequirementDescription = typeRequirementDescription;
        Notification = notification;
        Subject = subject;
        TransferDate = transferDate;
        Deadline = deadline;
        ProvinceId = provinceId;
        ProvinceDescription = provinceDescription;
        DueDate = dueDate;
        ReminderId = reminderId;
        ReminderDescription = reminderDescription;
        ReplyDate = replyDate;
        Comments = comments;
        ResponseDate = responseDate;
        CaseStatusId = caseStatusId;
        CaseStatusDescription = caseStatusDescription;
        ObservationDepartment = observationDepartment;
        CaseStatusSecretaryId = caseStatusSecretaryId;
        CaseStatusSecretaryDescription = caseStatusSecretaryDescription;
        AcknowledgmentDate = acknowledgmentDate;
        ExtensionRequestDate = extensionRequestDate;
        NewExtensionRequestDate = newExtensionRequestDate;
        ObservationExtension = observationExtension;
        ReminderDate = reminderDate;
        CaseStage = caseStage;
    }

    public static CaseResponse FromEntity(CaseEntity caseEntity)
    {
        return new CaseResponse(caseEntity.Id, caseEntity.Status, caseEntity.RequirementNumber, caseEntity.ReceptionDate, 
            caseEntity!.OriginDocumentId, caseEntity?.OriginDocument?.Description, caseEntity?.PhysicallyReceived,
            caseEntity?.DigitallyReceived, caseEntity?.DocumentNumber, caseEntity?.SbsNumber, caseEntity?.JudgmentNumber, 
            caseEntity?.IssueDate, caseEntity?.Description, caseEntity!.BrandId, caseEntity?.Brand!.Description,
            caseEntity!.DepartmentId, caseEntity?.Department?.Description, caseEntity!.UserId,
            caseEntity?.User?.FullName, caseEntity!.TypeRequirementId, caseEntity?.TypeRequirement?.Description, 
            caseEntity?.Notification, caseEntity?.Subject, caseEntity?.TransferDate, caseEntity?.Deadline, caseEntity!.ProvinceId,
            caseEntity?.Province?.Description, caseEntity?.DueDate, caseEntity!.ReminderId,
            caseEntity?.Reminder?.Description, caseEntity?.ReplyDate, caseEntity?.Comments,
            caseEntity?.ResponseDate, caseEntity!.CaseStatusId, caseEntity?.CaseStatus?.Description,
            caseEntity?.ObservationDepartment, caseEntity!.CaseStatusSecretaryId, caseEntity?.CaseStatusSecretary?.Description,
            caseEntity?.AcknowledgmentDate, caseEntity?.ExtensionRequestDate, caseEntity?.NewExtensionRequestDate, caseEntity?.ObservationExtension,
            caseEntity!.ReminderDate, caseEntity.CaseStage!);
    }
}