using Backend.Application.Queries.CaseQueries;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class ReadCaseDocumentRequest
    {
        private Guid CaseId { get; }
        private Guid AttachementId { get; }

        public ReadCaseDocumentRequest(Guid caseId, Guid attachementId)
        {
            CaseId = caseId;
            AttachementId = attachementId;
        }

        public ReadAttachmentCaseQuery ToApplicationRequest(string contentRootPath)
        {
            return new ReadAttachmentCaseQuery(CaseId, AttachementId, contentRootPath);
        }
    }
}
