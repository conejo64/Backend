using Ardalis.Specification;

namespace Backend.Application.Specifications.UserProfileSpecs;

public sealed class UserProfileSpec : Ardalis.Specification.Specification<UserProfile>, ISingleResultSpecification
{
    public UserProfileSpec(Guid? UserId, Guid? profileId)
    {
        if (UserId != null)
        {
            Query.Where(profile => profile.UserId == UserId);
        }

        if (profileId != null)
        {
            Query.Where(profile => profile.ProfileId == profileId);
        }

        Query.OrderBy(profile => profile.CreatedAt);
    }
}