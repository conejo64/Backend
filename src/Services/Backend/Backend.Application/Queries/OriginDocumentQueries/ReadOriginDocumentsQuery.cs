using Backend.Application.DTOs.Responses.OriginDocumentResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.OriginDocumentQueries
{
    public class ReadOriginDocumentsQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<OriginDocumentResponse>>>
    {
        public string? Description { get; set; }

        public ReadOriginDocumentsQuery(string? description, bool loadChildren,
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