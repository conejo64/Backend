using Backend.Application.Queries.CaseStatusQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.CaseStatusRequests;

public class ReadCaseStatusRequest
{
    private Guid Id { get; }

    public ReadCaseStatusRequest(Guid id)
    {
        Id = id;
    }

    public ReadCaseStatusQuery ToApplicationRequest()
    {
        return new ReadCaseStatusQuery(Id);
    }
}