using Ardalis.Specification;
using Shared.Domain.Specification;

namespace Backend.Application.Specifications.BrandSpecs
{
    public sealed class BrandSpec : Ardalis.Specification.Specification<Brand>, ISingleResultSpecification
    {

        public BrandSpec(Guid id)
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted && x.Id == id);
        }

        public BrandSpec(string? description, bool isPagingEnabled, int page, int pageSize)
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

        public BrandSpec()
        {
            Query
                .Where(x => x.Status != CatalogsStatus.Deleted)
                .OrderBy(x => x.Description);

        }
    }
}