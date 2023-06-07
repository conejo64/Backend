using Ardalis.Specification;
using Shared.Domain.Specification;

namespace Backend.Application.Specifications.ReminderSpecs;

public sealed class ReminderSpec : Ardalis.Specification.Specification<Reminder>, ISingleResultSpecification
{

    public ReminderSpec(Guid id)
    {
        Query
            .Where(x => x.Status != CatalogsStatus.Deleted && x.Id == id);
    }

    public ReminderSpec(string? description, bool isPagingEnabled, int page, int pageSize)
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

    public ReminderSpec()
    {
        Query
            .Where(x => x.Status != CatalogsStatus.Deleted)
            .OrderBy(x => x.Description);

    }
}