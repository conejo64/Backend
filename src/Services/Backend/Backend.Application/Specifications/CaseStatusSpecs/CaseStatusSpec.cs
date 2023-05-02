using Ardalis.Specification;
using Shared.Domain.Specification;

namespace Backend.Application.Specifications.CaseStatusSpecs
{
    public sealed class CaseStatusSpec : Ardalis.Specification.Specification<CaseStatus>, ISingleResultSpecification
    {

        public CaseStatusSpec(Guid id)
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted && x.Id == id);
        }

        public CaseStatusSpec(string description)
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted && x.Description!.ToUpper() == description.ToUpper());
        }

        public CaseStatusSpec(string? description, bool isPagingEnabled, int page, int pageSize)
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

        public CaseStatusSpec()
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted)
                .OrderBy(x => x.Description);

        }

    }
}