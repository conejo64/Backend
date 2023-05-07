using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands
{
    public class CreateCaseCommand : IRequest<EntityResponse<Guid>>
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
        // Attachement
        public Guid? UserOriginId { get; set; }
        public List<string>? DocumentString { get; set; }
        public List<string>? DocumentStringNames { get; set; }

        public CreateCaseCommand(string? requirementNumber, DateTime? receptionDate, Guid? originDocumentId, string? physicallyReceived, string? digitallyReceived, 
            string? documentNumber, string? sbsNumber, string? judgmentNumber, DateTime? issueDate, string? description, Guid? brandId, Guid? departmentId, 
            Guid? userId, Guid? typeRequirementId, string? notification, string? subject, DateTime? transferDate, DateTime? deadline, Guid? provinceId, 
            DateTime? dueDate, Guid? reminderId, DateTime? replyDate, string? comments, DateTime? responseDate, Guid? caseStatusId, 
            string? observationDepartment, Guid? caseStatusSecretaryId, DateTime? acknowledgmentDate, DateTime? extensionRequestDate, DateTime? newExtensionRequestDate, 
            string? observationExtension, Guid? userOriginId, List<string>? documentString, List<string>? documentStringNames)
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
            UserOriginId = userOriginId;
            DocumentString = documentString;
            DocumentStringNames = documentStringNames;
        }
    }
}
