using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.OriginDocumentResponses;

namespace Backend.Application.Queries.OriginDocumentQueries;

public class ReadAllOriginDocumentsQuery : IRequest<EntityResponse<List<OriginDocumentResponse>>>
{
    public ReadAllOriginDocumentsQuery()
    {

    }
}