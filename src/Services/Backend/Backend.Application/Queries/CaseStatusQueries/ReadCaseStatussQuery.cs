using Backend.Application.DTOs.Responses.CaseStatusResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.CaseStatusQueries
{
    public class ReadCaseStatussQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<CaseStatusResponse>>>
    {
        public string? Description { get; set; }

        public ReadCaseStatussQuery(string? description, bool loadChildren,
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