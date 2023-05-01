using Backend.Application.DTOs.Responses.ReminderResponses;
using Shared.Domain.Specification;

namespace Backend.Application.Queries.ReminderQueries
{
    public class ReadRemindersQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<ReminderResponse>>>
    {
        public string? Description { get; set; }

        public ReadRemindersQuery(string? description, bool loadChildren,
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