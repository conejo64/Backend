using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.DocumentResponses
{
    public class DocumentResponse
    {
        public Guid Id { get; }
        public string Status { get; set; }
        public Guid? CaseId { get; set; }
        public CaseEntity? CaseEntity { get; set; }
        public string? Document64 { get; set; }
        public string? Documnet64Name { get; set; }

        public DocumentResponse(Guid? caseId, CaseEntity? caseEntity, string? document64, string? documnet64Name, Guid id, string status)
        {
            CaseId = caseId;
            CaseEntity = caseEntity;
            Document64 = document64;
            Documnet64Name = documnet64Name;
            Id = id;
            Status = status;
        }

        public static DocumentResponse FromEntity(DocumentEntity documentEntity)
        {
            return new DocumentResponse(documentEntity.CaseId, documentEntity.CaseEntity, documentEntity.Document64, documentEntity.Document64Name, 
                documentEntity.Id, documentEntity.Status);
        }
    }
}
