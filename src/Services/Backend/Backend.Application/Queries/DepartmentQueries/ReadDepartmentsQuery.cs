using Backend.Application.DTOs.Responses.DepartmentResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.DepartmentQueries
{
    public class ReadDepartmentsQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<DepartmentResponse>>>
    {
        public string? Description { get; set; }

        public ReadDepartmentsQuery(string? description, bool loadChildren,
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