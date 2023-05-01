using Backend.Application.Queries.ReminderQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.ReminderRequests;

public class ReadReminderRequest
{
    private Guid Id { get; }

    public ReadReminderRequest(Guid id)
    {
        Id = id;
    }

    public ReadReminderQuery ToApplicationRequest()
    {
        return new ReadReminderQuery(Id);
    }
}