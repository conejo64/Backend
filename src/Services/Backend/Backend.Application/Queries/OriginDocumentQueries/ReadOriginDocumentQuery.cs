using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.OriginDocumentResponses;

namespace Backend.Application.Queries.OriginDocumentQueries;

public class ReadOriginDocumentQuery : IRequest<EntityResponse<OriginDocumentResponse>>
{
    public Guid Id { get; }
            
    public ReadOriginDocumentQuery(Guid id)
    {
        Id= id;
    }
}