using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.ReminderResponses;

namespace Backend.Application.Queries.ReminderQueries
{
    public class ReadAllRemindersQuery : IRequest<EntityResponse<List<ReminderResponse>>>
    {
        public ReadAllRemindersQuery()
        {

        }
    }
}