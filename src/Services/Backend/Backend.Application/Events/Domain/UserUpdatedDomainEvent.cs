namespace Backend.Application.Events.Domain;

public class UserUpdatedDomainEvent : INotification
{
    public User ApplicationUser { get; }

    public UserUpdatedDomainEvent(User applicationUser)
    {
        ApplicationUser = applicationUser;
    }
}