namespace Backend.Application.Events.Domain;

public class UserCreatedDomainEvent : INotification
{
    public User ApplicationUser { get; }

    public UserCreatedDomainEvent(User applicationUser)
    {
        ApplicationUser = applicationUser;
    }
}