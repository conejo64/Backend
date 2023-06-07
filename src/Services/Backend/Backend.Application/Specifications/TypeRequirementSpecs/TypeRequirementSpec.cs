using Ardalis.Specification;
using Shared.Domain.Specification;

namespace Backend.Application.Specifications.TypeRequirementSpecs;

public sealed class TypeRequirementSpec : Ardalis.Specification.Specification<TypeRequirement>, ISingleResultSpecification
{

    public TypeRequirementSpec(Guid id)
    {
        Query
            .Where(x => x.Status != CatalogsStatus.Deleted && x.Id == id);
    }

    public TypeRequirementSpec(string? description, bool isPagingEnabled, int page, int pageSize)
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

    public TypeRequirementSpec()
    {
        Query
            .Where(x => x.Status != CatalogsStatus.Deleted)
            .OrderBy(x => x.Description);

    }
}