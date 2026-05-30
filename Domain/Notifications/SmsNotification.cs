using SmartCampusAnnouncementSystem.Domain.Announcements;

namespace SmartCampusAnnouncementSystem.Domain.Notifications;

public class SmsNotification : INotification
{
    public string Send(string receiverName, string receiverType, IAnnouncement announcement)
    {
        Validate(receiverName, receiverType, announcement);

        return $"[SMS] {receiverType} {receiverName} kullanıcısına bildirim gönderildi: " +
               $"{announcement.GetAnnouncementType()} - {announcement.Title}";
    }

    private static void Validate(string receiverName, string receiverType, IAnnouncement announcement)
    {
        if (string.IsNullOrWhiteSpace(receiverName))
        {
            throw new ArgumentException("Alıcı adı boş olamaz.", nameof(receiverName));
        }

        if (string.IsNullOrWhiteSpace(receiverType))
        {
            throw new ArgumentException("Alıcı tipi boş olamaz.", nameof(receiverType));
        }

        ArgumentNullException.ThrowIfNull(announcement);
    }
}
