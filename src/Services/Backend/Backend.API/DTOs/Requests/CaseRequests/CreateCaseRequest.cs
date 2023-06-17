using Backend.Application.Commands.CaseCommands;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class CreateCaseRequest
    {
        public string? RequirementNumber { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public Guid? OriginDocumentId { get; set; }
        public string? PhysicallyReceived { get; set; }
        public string? DigitallyReceived { get; set; }
        public string? DocumentNumber { get; set; }
        public string? SbsNumber { get; set; }
        public string? JudgmentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? Description { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TypeRequirementId { get; set; }
        public string? Notification { get; set; }
        public string? Subject { get; set; }
        public DateTime? TransferDate { get; set; }
        public DateTime? Deadline { get; set; }
        public Guid? ProvinceId { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? ReminderId { get; set; }
        //Screen Department
        public DateTime? ReplyDate { get; set; }
        public string? Comments { get; set; }
        //Screen Close Secretary
        public DateTime? ResponseDate { get; set; }
        public Guid? CaseStatusId { get; set; }
        public string? ObservationDepartment { get; set; }
        public Guid? CaseStatusSecretaryId { get; set; }
        public DateTime? AcknowledgmentDate { get; set; }
        //Screen Prorrogation
        public DateTime? ExtensionRequestDate { get; set; }
        public DateTime? NewExtensionRequestDate { get; set; }
        public string? ObservationExtension { get; set; }
        public List<string>? DocumentString { get; set; }
        public List<string>? DocumentStringNames { get; set; }
        public string? CaseStage { get; set; }
        public CreateCaseRequest(string? requirementNumber, DateTime? receptionDate, Guid? originDocumentId, string? physicallyReceived, string? digitallyReceived, 
                string? documentNumber, string? sbsNumber, string? judgmentNumber, DateTime? issueDate, string? description, Guid? brandId, Guid? departmentId, Guid? userId, 
                Guid? typeRequirementId, string? notification, string? subject, DateTime? transferDate, DateTime? deadline, Guid? provinceId, DateTime? dueDate, 
                Guid? reminderId, DateTime? replyDate, string? comments, DateTime? responseDate, Guid? caseStatusId, string? observationDepartment, 
                Guid? caseStatusSecretaryId, DateTime? acknowledgmentDate, DateTime? extensionRequestDate, DateTime? newExtensionRequestDate, string? observationExtension,
                List<string>? documentString,  List<string>? documentStringNames, string? caseStage)
        {
            RequirementNumber = requirementNumber;
            ReceptionDate = receptionDate;
            OriginDocumentId = originDocumentId;
            PhysicallyReceived = physicallyReceived;
            DigitallyReceived = digitallyReceived;
            DocumentNumber = documentNumber;
            SbsNumber = sbsNumber;
            JudgmentNumber = judgmentNumber;
            IssueDate = issueDate;
            Description = description;
            BrandId = brandId;
            DepartmentId = departmentId;
            UserId = userId;
            TypeRequirementId = typeRequirementId;
            Notification = notification;
            Subject = subject;
            TransferDate = transferDate;
            Deadline = deadline;
            ProvinceId = provinceId;
            DueDate = dueDate;
            ReminderId = reminderId;
            ReplyDate = replyDate;
            Comments = comments;
            ResponseDate = responseDate;
            CaseStatusId = caseStatusId;
            ObservationDepartment = observationDepartment;
            CaseStatusSecretaryId = caseStatusSecretaryId;
            AcknowledgmentDate = acknowledgmentDate;
            ExtensionRequestDate = extensionRequestDate;
            NewExtensionRequestDate = newExtensionRequestDate;
            ObservationExtension = observationExtension;
            DocumentString= documentString;
            DocumentStringNames = documentStringNames;
            CaseStage = caseStage;
        }

        public CreateCaseCommand ToApplicationRequest(Guid? userOriginId, string contentRootPath)
        {
            return new CreateCaseCommand(RequirementNumber, ReceptionDate, OriginDocumentId, PhysicallyReceived, DigitallyReceived, DocumentNumber, SbsNumber, JudgmentNumber, 
                IssueDate, Description, BrandId, DepartmentId, UserId, TypeRequirementId, Notification, Subject, TransferDate, Deadline, ProvinceId, DueDate, ReminderId, ReplyDate, 
                Comments, ResponseDate, CaseStatusId, ObservationDepartment, CaseStatusSecretaryId, AcknowledgmentDate, ExtensionRequestDate, NewExtensionRequestDate, ObservationExtension, 
                userOriginId, DocumentString, DocumentStringNames, CaseStage, contentRootPath);
        }
    }
}
