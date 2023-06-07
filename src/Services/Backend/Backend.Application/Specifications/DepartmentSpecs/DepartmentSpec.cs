using Ardalis.Specification;
using Shared.Domain.Specification;

namespace Backend.Application.Specifications.DepartmentSpecs;

public sealed class DepartmentSpec : Ardalis.Specification.Specification<Department>, ISingleResultSpecification
{

    public DepartmentSpec(Guid id)
    {
        Query
            .Where(x => x.Status != CatalogsStatus.Deleted && x.Id == id);
    }

    public DepartmentSpec(string? description, bool isPagingEnabled, int page, int pageSize)
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

    public DepartmentSpec()
    {
        Query
            .Where(x => x.Status != CatalogsStatus.Deleted)
            .OrderBy(x => x.Description);

    }
}