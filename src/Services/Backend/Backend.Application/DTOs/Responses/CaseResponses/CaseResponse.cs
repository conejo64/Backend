using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.CaseResponses
{
    public class CaseResponse
    {
        public Guid Id { get; }
        public string Status { get; set; }
        public string? RequirementNumber { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public string? OriginDocumentDescription { get; set; }
        public string? PhysicallyReceived { get; set; }
        public string? DigitallyReceived { get; set; }
        public string? DocumentNumber { get; set; }
        public string? SbsNumber { get; set; }
        public string? JudgmentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? Description { get; set; }
        public string? BrandDescription  { get; set; }
        public string? DepartmentDescription { get; set; }
        public string? UserDescription{ get; set; }
        public string? TypeRequirementDescription { get; set; }
        public string? Notification { get; set; }
        public string? Subject { get; set; }
        public DateTime? TransferDate { get; set; }
        public DateTime? Deadline { get; set; }
        public string? ProvinceDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public string? ReminderDescription { get; set; }
        //Screen Department
        public DateTime? ReplyDate { get; set; }
        public string? Comments { get; set; }
        //Screen Close Secretary
        public DateTime? ResponseDate { get; set; }
        public string? CaseStatusDescription { get; set; }
        public string? ObservationDepartment { get; set; }
        public string? CaseStatusSecretaryDescription { get; set; }
        public DateTime? AcknowledgmentDate { get; set; }
        //Screen Prorrogation
        public DateTime? ExtensionRequestDate { get; set; }
        public DateTime? NewExtensionRequestDate { get; set; }
        public string? ObservationExtension { get; set; }

        public CaseResponse(Guid id, string status, string? requirementNumber, DateTime? receptionDate, string? originDocumentDescription, string? physicallyReceived, 
                            string? digitallyReceived, string? documentNumber, string? sbsNumber, string? judgmentNumber, DateTime? issueDate, string? description, 
                            string? brandDescription, string? departmentDescription, string? userDescription, string? typeRequirementDescription, string? notification, 
                            string? subject, DateTime? transferDate, DateTime? deadline, string? provinceDescription, DateTime? dueDate, string? reminderDescription, 
                            DateTime? replyDate, string? comments, DateTime? responseDate, string? caseStatusDescription, string? observationDepartment, 
                            string? caseStatusSecretaryDescription, DateTime? acknowledgmentDate, DateTime? extensionRequestDate, DateTime? newExtensionRequestDate, 
                            string? observationExtension)
        {
            Id = id;
            Status = status;
            RequirementNumber = requirementNumber;
            ReceptionDate = receptionDate;
            OriginDocumentDescription = originDocumentDescription;
            PhysicallyReceived = physicallyReceived;
            DigitallyReceived = digitallyReceived;
            DocumentNumber = documentNumber;
            SbsNumber = sbsNumber;
            JudgmentNumber = judgmentNumber;
            IssueDate = issueDate;
            Description = description;
            BrandDescription = brandDescription;
            DepartmentDescription = departmentDescription;
            UserDescription = userDescription;
            TypeRequirementDescription = typeRequirementDescription;
            Notification = notification;
            Subject = subject;
            TransferDate = transferDate;
            Deadline = deadline;
            ProvinceDescription = provinceDescription;
            DueDate = dueDate;
            ReminderDescription = reminderDescription;
            ReplyDate = replyDate;
            Comments = comments;
            ResponseDate = responseDate;
            CaseStatusDescription = caseStatusDescription;
            ObservationDepartment = observationDepartment;
            CaseStatusSecretaryDescription = caseStatusSecretaryDescription;
            AcknowledgmentDate = acknowledgmentDate;
            ExtensionRequestDate = extensionRequestDate;
            NewExtensionRequestDate = newExtensionRequestDate;
            ObservationExtension = observationExtension;
        }
        public static CaseResponse FromEntity(CaseEntity caseEntity)
        {
            return new CaseResponse(caseEntity.Id, caseEntity.Status, caseEntity.RequirementNumber, caseEntity.ReceptionDate, caseEntity?.OriginDocument?.Description, 
                                    caseEntity?.PhysicallyReceived, caseEntity?.DigitallyReceived, caseEntity?.DocumentNumber, caseEntity?.SbsNumber, caseEntity?.JudgmentNumber,
                                    caseEntity?.IssueDate, caseEntity?.Description, caseEntity?.Brand?.Description, caseEntity?.Department?.Description, caseEntity?.User?.FullName,
                                    caseEntity?.TypeRequirement?.Description, caseEntity?.Notification, caseEntity?.Subject, caseEntity?.TransferDate, caseEntity?.Deadline,
                                    caseEntity?.Province?.Description, caseEntity?.DueDate, caseEntity?.Reminder?.Description, caseEntity?.ReplyDate, caseEntity?.Comments,
                                    caseEntity?.ResponseDate, caseEntity?.CaseStatus?.Description, caseEntity?.ObservationDepartment, caseEntity?.CaseStatusSecretary?.Description,
                                    caseEntity?.AcknowledgmentDate, caseEntity?.ExtensionRequestDate, caseEntity?.NewExtensionRequestDate, caseEntity?.ObservationExtension);
        }
    }
}
