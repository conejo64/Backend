using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.TypeRequirementResponses;
using Backend.Application.Queries.ManagerUserQueries;
using Backend.Application.Specifications.MemberSpecs;
using Backend.Application.Specifications.TypeRequirementSpecs;

namespace Backend.Application.Queries.TypeRequirementQueries
{
    public class ReadTypeRequirementsQueryHandler : IRequestHandler<ReadTypeRequirementsQuery,
        EntityResponse<GetEntitiesResponse<TypeRequirementResponse>>>
    {
        #region Constructor & Properties

        private readonly IReadRepository<TypeRequirement> _repository;

        public ReadTypeRequirementsQueryHandler(IReadRepository<TypeRequirement> repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<EntityResponse<GetEntitiesResponse<TypeRequirementResponse>>> Handle(ReadTypeRequirementsQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new TypeRequirementSpec(query.Description, query.IsPagingEnabled, query.Page, query.PageSize);

            //Get the total amount of entities
            var total = await _repository.CountAsync(spec, cancellationToken);

            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

            return new GetEntitiesResponse<TypeRequirementResponse>(
                entityCollection.Select(TypeRequirementResponse.FromEntity).ToList(),
                filterResponse
            );
        }
    }
}