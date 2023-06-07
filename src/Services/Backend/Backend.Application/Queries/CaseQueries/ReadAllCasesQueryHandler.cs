using Backend.Application.DTOs.Responses.BrandResponses;
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

public class ReadAllCasesQueryHandler : IRequestHandler<ReadAllCasesQuery,
    EntityResponse<List<CaseResponse>>>
{
    private readonly IRepository<CaseEntity> _repository;

    public ReadAllCasesQueryHandler(IRepository<CaseEntity> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<List<CaseResponse>>> Handle(ReadAllCasesQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseSpec();

        //Get entity list
        var entityCollection = await _repository.ListAsync(spec, cancellationToken);

        return entityCollection.Select(CaseResponse.FromEntity).ToList();
    }
}