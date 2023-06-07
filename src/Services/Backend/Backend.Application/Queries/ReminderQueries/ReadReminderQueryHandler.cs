using Backend.Application.DTOs.Responses.ReminderResponses;
using Backend.Application.Specifications.ReminderSpecs;

namespace Backend.Application.Queries.ReminderQueries;

public class ReadReminderQueryHandler : IRequestHandler<ReadReminderQuery, EntityResponse<ReminderResponse>>
{
    private readonly IReadRepository<Reminder> _repository;

    public ReadReminderQueryHandler(IReadRepository<Reminder> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<ReminderResponse>> Handle(ReadReminderQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new ReminderSpec(query.Id);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity is null)
        {
            return EntityResponse<ReminderResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.OriginDocumentNotFound));
        }

        return ReminderResponse.FromEntity(entity);
    }
}