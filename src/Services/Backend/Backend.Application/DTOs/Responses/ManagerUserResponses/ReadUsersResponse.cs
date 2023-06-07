namespace Backend.Application.DTOs.Responses.ManagerUserResponses;

public record ReadUsersResponse(Guid Id, string UserName, string Email, string? FirstName, string? LastName,
    string? identification, string? phone, string Status, string? avatar, string fullName, List<ReadUsersProfileDto> Profiles)
{
    public static ReadUsersResponse FromEntity(User applicationUser)
    {
        List<ReadUsersProfileDto> profiles = new();

        var userProfiles = applicationUser.UserProfiles.Any();
        if (userProfiles)
        {
            profiles = applicationUser.UserProfiles
                .Select(userProfile => ReadUsersProfileDto.FromEntity(userProfile.Profile))
                .ToList();
        }

        return new ReadUsersResponse(applicationUser.Id, applicationUser.Username, applicationUser.Email, applicationUser.FirstName, applicationUser.LastName,
            applicationUser.Identification, applicationUser.Phone, applicationUser.Status, applicationUser.Avatar, applicationUser.FullName, profiles);
    }
}

public record ReadUsersProfileDto(Guid Id, string Name, string Description)
{
    public static ReadUsersProfileDto FromEntity(Profile profile)
    {
        return new ReadUsersProfileDto(profile.Id, profile.Name, profile.Description);
    }
}