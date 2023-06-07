using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.CaseStatusResponses;

namespace Backend.Application.Queries.CaseStatusQueries;

public class ReadCaseStatusQuery : IRequest<EntityResponse<CaseStatusResponse>>
{
    public Guid Id { get; }

    public ReadCaseStatusQuery(Guid id)
    {
        Id= id;
    }
}