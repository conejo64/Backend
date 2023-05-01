namespace Backend.Application.Events.Domain
{
    public class UserDeletedDomainEvent : INotification
    {
        public User ApplicationUser { get; }

        public UserDeletedDomainEvent(User applicationUser)
        {
            ApplicationUser = applicationUser;
        }
    }
}