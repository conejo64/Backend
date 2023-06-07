using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Application.Queries.BrandQueries;
using Backend.Application.Specifications.BrandSpecs;
using Backend.Application.Specifications.CaseSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Queries.CaseQueries;

public class ReadOthersCasesQueryHandler : IRequestHandler<ReadOthersCasesQuery,
    EntityResponse<GetEntitiesResponse<CaseResponse>>>
{
    #region Constructor & Properties

    private readonly IReadRepository<CaseEntity> _repository;

    public ReadOthersCasesQueryHandler(IReadRepository<CaseEntity> repository)
    {
        _repository = repository;
    }

    #endregion

    public async Task<EntityResponse<GetEntitiesResponse<CaseResponse>>> Handle(ReadOthersCasesQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseSpec(query.UserId, query.OriginDocumentId, query.CaseStatusId, query.DepartmentId, query.InitialDate, query.FinalDate, query.IsPagingEnabled, query.Page, query.PageSize);

        //Get the total amount of entities
        var total = await _repository.CountAsync(spec, cancellationToken);

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        var filterResponse = new PaginationResponse(query.Page, query.PageSize, total);

        return new GetEntitiesResponse<CaseResponse>(
            entityCollection.Select(CaseResponse.FromEntity).ToList(),
            filterResponse
        );
    }
}