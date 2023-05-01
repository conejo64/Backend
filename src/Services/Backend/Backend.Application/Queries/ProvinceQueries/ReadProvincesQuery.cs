using Backend.Application.DTOs.Responses.ProvinceResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.ProvinceQueries
{
    public class ReadProvincesQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<ProvinceResponse>>>
    {
        public string? Description { get; set; }

        public ReadProvincesQuery(string? description, bool loadChildren,
            bool isPagingEnabled, int page, int pageSize)
        {
            Description = description;
            LoadChildren = loadChildren;
            IsPagingEnabled = isPagingEnabled;
            Page = page;
            PageSize = pageSize;
        }
    }
}