using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.OriginDocumentResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.ManagerUserQueries;

public class ReadManagerUsersQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<ReadUsersResponse>>>
{
    public string? QueryParam { get; set; }

    public ReadManagerUsersQuery(string? queryParam, bool loadChildren,
        bool isPagingEnabled, int page, int pageSize)
    {
        QueryParam = queryParam;
        LoadChildren = loadChildren;
        IsPagingEnabled = isPagingEnabled;
        Page = page;
        PageSize = pageSize;
    }
}