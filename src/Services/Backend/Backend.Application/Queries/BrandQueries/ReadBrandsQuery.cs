using Backend.Application.DTOs.Responses.BrandResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.BrandQueries;

public class ReadBrandsQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<BrandResponse>>>
{
    public string? Description { get; set; }

    public ReadBrandsQuery(string? description, bool loadChildren,
        bool isPagingEnabled, int page, int pageSize)
    {
        Description = description;
        LoadChildren = loadChildren;
        IsPagingEnabled = isPagingEnabled;
        Page = page;
        PageSize = pageSize;
    }
}