using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.CaseStatusSecretaryResponses;

namespace Backend.Application.Queries.CaseStatusSecretaryQueries;

public class ReadAllCaseStatusSecretarysQuery : IRequest<EntityResponse<List<CaseStatusSecretaryResponse>>>
{
    public ReadAllCaseStatusSecretarysQuery()
    {

    }
}