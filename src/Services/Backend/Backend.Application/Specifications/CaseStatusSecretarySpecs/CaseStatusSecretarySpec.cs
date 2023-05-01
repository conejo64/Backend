using Ardalis.Specification;
using Shared.Domain.Specification;

namespace Backend.Application.Specifications.CaseStatusSecretarySpecs
{
    public sealed class CaseStatusSecretarySpec : Ardalis.Specification.Specification<CaseStatusSecretary>, ISingleResultSpecification
    {

        public CaseStatusSecretarySpec(Guid id)
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted && x.Id == id);
        }

        public CaseStatusSecretarySpec(string? description, bool isPagingEnabled, int page, int pageSize)
        {
            Query.Where(x => x.Status != CatalogsStatus.Deleted);

            if (!string.IsNullOrEmpty(description))
                Query.Where(x => x.Description!.ToLower().Contains(description.ToLower()));

            if (isPagingEnabled)
                Query
                    .OrderBy(x => x.CreatedAt)
                    .Skip(PaginationHelper.CalculateSkip(pageSize, page))
                    .Take(PaginationHelper.CalculateTake(pageSize));
        }

        public CaseStatusSecretarySpec()
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted)
                .OrderBy(x => x.Description);

        }
    }
}