using SmartCampusAnnouncementSystem.Domain.Announcements;

namespace SmartCampusAnnouncementSystem.Domain.Users;

public abstract class BaseUserObserver : IUserObserver
{
    protected BaseUserObserver(string fullName, string preferredNotificationType)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Kullanıcı adı boş olamaz.", nameof(fullName));
        }

        if (string.IsNullOrWhiteSpace(preferredNotificationType))
        {
            throw new ArgumentException("Tercih edilen bildirim tipi boş olamaz.", nameof(preferredNotificationType));
        }

        FullName = fullName;
        PreferredNotificationType = preferredNotificationType;
    }

    public string FullName { get; }

    public abstract string UserType { get; }

    public string PreferredNotificationType { get; }

    public IAnnouncement? LastReceivedAnnouncement { get; private set; }

    public virtual void Update(IAnnouncement announcement)
    {
        LastReceivedAnnouncement = announcement ?? throw new ArgumentNullException(nameof(announcement));
    }
}
