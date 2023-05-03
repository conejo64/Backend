using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Application.Queries.BrandQueries;
using Backend.Application.Specifications.BrandSpecs;
using Backend.Application.Specifications.CaseSpecs;
using Shared.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Queries.CaseQueries
{
    public class ReadCaseQueryHandler : IRequestHandler<ReadCaseQuery, EntityResponse<CaseResponse>>
    {
        private readonly IReadRepository<CaseEntity> _repository;

    public ReadCaseQueryHandler(IReadRepository<CaseEntity> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<CaseResponse>> Handle(ReadCaseQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseSpec(query.Id);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity is null)
        {
            return EntityResponse<CaseResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.CaseNotFound));
        }

        return CaseResponse.FromEntity(entity);
    }
}
}
