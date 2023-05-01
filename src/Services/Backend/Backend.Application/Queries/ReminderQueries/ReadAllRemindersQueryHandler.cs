using Backend.Application.DTOs.Responses.ReminderResponses;
using Backend.Application.Queries.ReminderQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.ReminderSpecs;

namespace Backend.Application.Queries.ReminderQueries
{
    public class ReadAllRemindersQueryHandler : IRequestHandler<ReadAllRemindersQuery,
        EntityResponse<List<ReminderResponse>>>
    {
        private readonly IRepository<Reminder> _repository;

        public ReadAllRemindersQueryHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<EntityResponse<List<ReminderResponse>>> Handle(ReadAllRemindersQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new ReminderSpec();

            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            return entityCollection.Select(ReminderResponse.FromEntity).ToList();
        }
    }
}