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
using Backend.Application.DTOs.Responses.DocumentResponses;
using Backend.Application.Specifications.CaseDocumentSpecs;

namespace Backend.Application.Queries.CaseQueries;

public class ReadAttachmentsCaseQueryHandler : IRequestHandler<ReadAttachmentsCaseQuery, EntityResponse<List<DocumentResponse>>>
{
    private readonly IReadRepository<DocumentEntity> _repository;

    public ReadAttachmentsCaseQueryHandler(IReadRepository<DocumentEntity> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<List<DocumentResponse>>> Handle(ReadAttachmentsCaseQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseDocumentSpec(query.Id);
        var entities = await _repository.ListAsync(spec, cancellationToken);
        if (!entities.Any())
        {
            return EntityResponse<List<DocumentResponse>>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.CaseAttachmentNotFound));
        }

        var result = new List<DocumentResponse>();
        foreach (var item in entities)
        {
            var doc = new DocumentResponse(item.Id, item.CaseEntityId, string.Empty, item.Document64Name,
                item.Status, item.ContextType, item.DocumentSource);
            result.Add(doc);

        }

        return result;
    }
}