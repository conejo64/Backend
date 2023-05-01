using Backend.Application.Queries.OriginDocumentQueries;
using Backend.Application.Queries.ProfileQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.OriginDocumentRequests;

public class ReadOriginDocumentRequest
{
    private Guid Id { get; }

    public ReadOriginDocumentRequest(Guid id)
    {
        Id = id;
    }

    public ReadOriginDocumentQuery ToApplicationRequest()
    {
        return new ReadOriginDocumentQuery(Id);
    }
}