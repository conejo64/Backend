using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.ReminderResponses;
using Backend.Application.Queries.ManagerUserQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.ReminderSpecs;

namespace Backend.Application.Queries.ReminderQueries;

public class ReadRemindersQueryHandler : IRequestHandler<ReadRemindersQuery,
    EntityResponse<GetEntitiesResponse<ReminderResponse>>>
{
    #region Constructor & Properties

    private readonly IReadRepository<Reminder> _repository;

    public ReadRemindersQueryHandler(IReadRepository<Reminder> repository)
    {
        _repository = repository;
    }

    #endregion

    public async Task<EntityResponse<GetEntitiesResponse<ReminderResponse>>> Handle(ReadRemindersQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new ReminderSpec(query.Description, query.IsPagingEnabled, query.Page, query.PageSize);

        //Get the total amount of entities
        var total = await _repository.CountAsync(spec, cancellationToken);

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

        return new GetEntitiesResponse<ReminderResponse>(
            entityCollection.Select(ReminderResponse.FromEntity).ToList(),
            filterResponse
        );
    }
}