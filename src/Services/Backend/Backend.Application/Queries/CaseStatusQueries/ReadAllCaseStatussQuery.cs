using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.CaseStatusResponses;

namespace Backend.Application.Queries.CaseStatusQueries;

public class ReadAllCaseStatussQuery : IRequest<EntityResponse<List<CaseStatusResponse>>>
{
    public ReadAllCaseStatussQuery()
    {

    }
}