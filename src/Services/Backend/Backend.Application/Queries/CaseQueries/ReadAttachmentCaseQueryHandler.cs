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

public class ReadAttachmentCaseQueryHandler : IRequestHandler<ReadAttachmentCaseQuery, EntityResponse<DocumentResponse>>
{
    private readonly IReadRepository<DocumentEntity> _repository;
    private readonly IRepository<CaseEntity> _caseRepository;

    public ReadAttachmentCaseQueryHandler(IReadRepository<DocumentEntity> repository, IRepository<CaseEntity> caseRepository)
    {
        _repository = repository;
        _caseRepository = caseRepository;
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

        var caseEntity = await _caseRepository.GetByIdAsync(query.CaseId, cancellationToken);
        var pathFile = string.Format("{0}/{1}", caseEntity!.DocumentNumber, entity.Document64Name);
        var response = DocumentResponse.FromEntity(entity!);
        var base64 = GetImage(pathFile, query.ContentRootPath!);
        response.Document64 = base64;
        return response;
    }
    
    public string GetImage(string pathFile, string contentRootPath)
    {
        try
        {
            var base64 = string.Empty;
            var dir = $"{contentRootPath}/AppFiles/Cases";
            dir = Path.Combine(dir, pathFile);

            if (File.Exists(dir))
            {
                var arrayByte = File.ReadAllBytes(dir);
                if (arrayByte != null)
                {
                    base64 = Convert.ToBase64String(arrayByte);
                }
            }

            return base64;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}