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
        public string? Document64 { get; set; }
        public string? Document64Name { get; set; }
        public string? ContentType { get; set; }
        public string? DocumentSource { get; set; }

        public DocumentResponse(Guid id, Guid? caseId, string? document64, string? document64Name, string status, string? contentType, string? documentSource)
        {
            CaseId = caseId;
            Document64 = document64;
            Document64Name = document64Name;
            Id = id;
            Status = status;
            ContentType = contentType;
            DocumentSource = documentSource;
        }

        public static DocumentResponse FromEntity(DocumentEntity documentEntity)
        {
            return new DocumentResponse(documentEntity.Id, documentEntity.CaseEntityId, documentEntity.Document64, documentEntity.Document64Name, 
                documentEntity.Status, documentEntity.ContextType, documentEntity.DocumentSource);
        }
    }
}
