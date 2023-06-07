using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.OriginDocumentResponses;

namespace Backend.Application.Queries.ManagerUserQueries;

public class ReadManagerUserQuery : IRequest<EntityResponse<ReadUserResponse>>
{
    public Guid UserId { get; }

    public ReadManagerUserQuery(Guid userId)
    {
        UserId = userId;
    }
}