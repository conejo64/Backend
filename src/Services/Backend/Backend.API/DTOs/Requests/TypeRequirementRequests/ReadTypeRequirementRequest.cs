using Backend.Application.Queries.TypeRequirementQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.TypeRequirementRequests;

public class ReadTypeRequirementRequest
{
    private Guid Id { get; }

    public ReadTypeRequirementRequest(Guid id)
    {
        Id = id;
    }

    public ReadTypeRequirementQuery ToApplicationRequest()
    {
        return new ReadTypeRequirementQuery(Id);
    }
}