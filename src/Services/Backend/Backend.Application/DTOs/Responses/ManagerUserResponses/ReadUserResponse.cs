namespace Backend.Application.DTOs.Responses.ManagerUserResponses;
public class ReadUserResponse
    {
        public Guid Id { get; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? Identification { get; set; }
        public string? Phone { get; set; }
        public string? MobileId { get; set; }
        public string Status { get; set; }
        public string? Avatar { get; set; }
    public string FullName { get; set; }

    public List<ReadUserProfileDto> Profiles { get; } = new();

    public ReadUserResponse(Guid id, string username, string email, string firstName, string lastName,
        string? identification, string? phone, string status, string? avatar, List<ReadUserProfileDto> profiles)
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Identification = identification;
        Phone = phone;
        Status = status;
        Avatar = avatar;
        Profiles = profiles;
        FullName = $"{firstName} {lastName}";
    }

    public static ReadUserResponse FromEntity(User applicationUser)
        {
            List<ReadUserProfileDto> profiles = new();

            var userProfiles = applicationUser.UserProfiles.Any();
            if (userProfiles)
            {
                profiles = applicationUser.UserProfiles
                    .Select(userProfile => ReadUserProfileDto.FromEntity(userProfile.Profile))
                    .ToList();
            }

            return new ReadUserResponse(applicationUser.Id, applicationUser.Username, applicationUser.Email, applicationUser.FirstName, applicationUser.LastName, 
                applicationUser.Identification, applicationUser.Phone, applicationUser.Status, applicationUser.Avatar, profiles);
        }
    }

    public record ReadUserProfileDto(Guid Id, string Name, string Description)
    {
        public static ReadUserProfileDto FromEntity(Profile profile)
        {
            return new ReadUserProfileDto(profile.Id, profile.Name, profile.Description);
        }
    }
