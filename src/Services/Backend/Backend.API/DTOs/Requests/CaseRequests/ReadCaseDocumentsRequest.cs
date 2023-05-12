using Backend.Application.Queries.CaseQueries;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class ReadCaseDocumentsRequest
    {
        private Guid Id { get; }

        public ReadCaseDocumentsRequest(Guid id)
        {
            Id = id;
        }

        public ReadAttachmentsCaseQuery ToApplicationRequest()
        {
            return new ReadAttachmentsCaseQuery(Id);
        }
    }
}
