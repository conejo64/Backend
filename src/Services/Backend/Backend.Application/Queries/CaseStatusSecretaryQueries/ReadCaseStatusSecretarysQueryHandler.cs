using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.CaseStatusSecretaryResponses;
using Backend.Application.Queries.ManagerUserQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.CaseStatusSecretarySpecs;

namespace Backend.Application.Queries.CaseStatusSecretaryQueries
{
    public class ReadCaseStatusSecretarysQueryHandler : IRequestHandler<ReadCaseStatusSecretarysQuery,
        EntityResponse<GetEntitiesResponse<CaseStatusSecretaryResponse>>>
    {
        #region Constructor & Properties

        private readonly IReadRepository<CaseStatusSecretary> _repository;

        public ReadCaseStatusSecretarysQueryHandler(IReadRepository<CaseStatusSecretary> repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<EntityResponse<GetEntitiesResponse<CaseStatusSecretaryResponse>>> Handle(ReadCaseStatusSecretarysQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new CaseStatusSecretarySpec(query.Description, query.IsPagingEnabled, query.Page, query.PageSize);

            //Get the total amount of entities
            var total = await _repository.CountAsync(spec, cancellationToken);

            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

            return new GetEntitiesResponse<CaseStatusSecretaryResponse>(
                entityCollection.Select(CaseStatusSecretaryResponse.FromEntity).ToList(),
                filterResponse
            );
        }
    }
}