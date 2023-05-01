using Backend.Application.DTOs.Responses.TypeRequirementResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.TypeRequirementQueries
{
    public class ReadTypeRequirementsQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<TypeRequirementResponse>>>
    {
        public string? Description { get; set; }

        public ReadTypeRequirementsQuery(string? description, bool loadChildren,
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