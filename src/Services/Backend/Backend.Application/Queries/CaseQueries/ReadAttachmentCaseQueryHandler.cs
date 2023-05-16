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

namespace Backend.Application.Queries.CaseQueries
{
    public class ReadAttachmentCaseQueryHandler : IRequestHandler<ReadAttachmentCaseQuery, EntityResponse<DocumentResponse>>
    {
        private readonly IReadRepository<DocumentEntity> _repository;

    public ReadAttachmentCaseQueryHandler(IReadRepository<DocumentEntity> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<DocumentResponse>> Handle(ReadAttachmentCaseQuery query,
        CancellationToken cancellationToken)
    {
        var spec = new CaseDocumentSpec(query.CaseId, query.AttachmentId);
        var entity = await _repository.GetBySpecAsync(spec, cancellationToken);
        if (entity == null)
        {
            return EntityResponse<DocumentResponse>.Error(
                EntityResponseUtils.GenerateMsg(MessageHandler.AttachmentNotFound));
        }

        return DocumentResponse.FromEntity(entity!);
    }
}
}
