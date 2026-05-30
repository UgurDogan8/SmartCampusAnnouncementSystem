using SmartCampusAnnouncementSystem.Domain.Announcements;

namespace SmartCampusAnnouncementSystem.Domain.Notifications;

public interface INotification
{
    string Send(string receiverName, string receiverType, IAnnouncement announcement);
}
