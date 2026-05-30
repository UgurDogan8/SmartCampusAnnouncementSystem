using SmartCampusAnnouncementSystem.Domain.Announcements;

namespace SmartCampusAnnouncementSystem.Domain.Users;

public interface IUserObserver
{
    string FullName { get; }

    string UserType { get; }

    string PreferredNotificationType { get; }

    void Update(IAnnouncement announcement);
}
