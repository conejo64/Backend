using Backend.Application.DTOs.Responses.CaseStatusSecretaryResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.CaseStatusSecretaryQueries
{
    public class ReadCaseStatusSecretarysQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<CaseStatusSecretaryResponse>>>
    {
        public string? Description { get; set; }

        public ReadCaseStatusSecretarysQuery(string? description, bool loadChildren,
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