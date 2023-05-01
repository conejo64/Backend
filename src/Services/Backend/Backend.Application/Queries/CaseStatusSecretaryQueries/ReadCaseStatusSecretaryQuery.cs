using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.CaseStatusSecretaryResponses;

namespace Backend.Application.Queries.CaseStatusSecretaryQueries
{
    public class ReadCaseStatusSecretaryQuery : IRequest<EntityResponse<CaseStatusSecretaryResponse>>
    {
        public Guid Id { get; }

        public ReadCaseStatusSecretaryQuery(Guid id)
        {
            Id= id;
        }
    }
}