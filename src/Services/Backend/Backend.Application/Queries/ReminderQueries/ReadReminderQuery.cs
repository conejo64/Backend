using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.ReminderResponses;

namespace Backend.Application.Queries.ReminderQueries;

public class ReadReminderQuery : IRequest<EntityResponse<ReminderResponse>>
{
    public Guid Id { get; }

    public ReadReminderQuery(Guid id)
    {
        Id= id;
    }
}