using Backend.Application.Queries.ReminderQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.ReminderRequests;

public class ReadRemindersRequest : BaseFilterDto
{
    public string? Description { get; set; }

    public ReadRemindersQuery ToApplicationRequest()
    {
        return new ReadRemindersQuery(Description, LoadChildren, IsPagingEnabled, Page, PageSize);
    }
}