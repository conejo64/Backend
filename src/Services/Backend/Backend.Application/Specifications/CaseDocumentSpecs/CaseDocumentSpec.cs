using Ardalis.Specification;
using Backend.Application.Specifications.UserGlobalPermissionSpecs;
using Shared.Domain.Specification;

namespace Backend.Application.Specifications.CaseDocumentSpecs
{
    public sealed class CaseDocumentSpec : Ardalis.Specification.Specification<DocumentEntity>, ISingleResultSpecification
    {
        public CaseDocumentSpec(Guid caseId)
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted && x.CaseEntityId == caseId);
        }
        
        public CaseDocumentSpec(Guid caseId, Guid attachmentId)
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted
                            && x.CaseEntityId == caseId
                            && x.Id == attachmentId);
        }

    }
}
