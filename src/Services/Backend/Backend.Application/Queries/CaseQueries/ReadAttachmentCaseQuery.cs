using Backend.Application.DTOs.Responses.CaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.DTOs.Responses.DocumentResponses;

namespace Backend.Application.Queries.CaseQueries;

public class ReadAttachmentCaseQuery : IRequest<EntityResponse<DocumentResponse>>
{
    public Guid CaseId { get; }
    public Guid AttachmentId { get; }
    public string? ContentRootPath { get; set; }

    public ReadAttachmentCaseQuery(Guid caseId, Guid attachmentId, string? contentRootPath)
    {
        CaseId = caseId;
        AttachmentId = attachmentId;
        ContentRootPath = contentRootPath;
    }
}