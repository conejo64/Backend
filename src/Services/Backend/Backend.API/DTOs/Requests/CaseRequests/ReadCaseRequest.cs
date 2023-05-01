using Backend.Application.Queries.CaseQueries;

namespace Backend.API.DTOs.Requests.CaseRequests
{
    public class ReadCaseRequest
    {
        private Guid Id { get; }

        public ReadCaseRequest(Guid id)
        {
            Id = id;
        }

        public ReadCaseQuery ToApplicationRequest()
        {
            return new ReadCaseQuery(Id);
        }
    }
}
