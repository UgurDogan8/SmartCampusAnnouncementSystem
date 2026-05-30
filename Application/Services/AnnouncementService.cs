using SmartCampusAnnouncementSystem.Domain.Announcements;
using SmartCampusAnnouncementSystem.Infrastructure.Data;
using SmartCampusAnnouncementSystem.Infrastructure.Factories;
using SmartCampusAnnouncementSystem.Infrastructure.Singleton;

namespace SmartCampusAnnouncementSystem.Application.Services;

public class AnnouncementService
{
    private readonly InMemoryDataStore _dataStore;

    public AnnouncementService(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
    }

    public IAnnouncement CreateAnnouncement(string announcementType, string title, string content)
    {
        if (string.IsNullOrWhiteSpace(announcementType))
        {
            throw new ArgumentException("Duyuru tipi boş olamaz.", nameof(announcementType));
        }

        var announcement = AnnouncementFactory.CreateAnnouncement(announcementType, title, content);

        _dataStore.AddAnnouncement(announcement);

        return announcement;
    }

    public void PublishAnnouncement(IAnnouncement announcement)
    {
        ArgumentNullException.ThrowIfNull(announcement);

        NotificationCenter.Instance.PublishAnnouncement(announcement);
    }

    public void PublishAnnouncement(IAnnouncement announcement, string targetUserType)
    {
        ArgumentNullException.ThrowIfNull(announcement);

        if (string.IsNullOrWhiteSpace(targetUserType))
        {
            throw new ArgumentException("Hedef kullanıcı tipi boş olamaz.", nameof(targetUserType));
        }

        NotificationCenter.Instance.PublishAnnouncement(announcement, targetUserType);
    }

    public IAnnouncement CreateAndPublishAnnouncement(string announcementType, string title, string content)
    {
        var announcement = CreateAnnouncement(announcementType, title, content);

        PublishAnnouncement(announcement);

        return announcement;
    }

    public IAnnouncement CreateAndPublishAnnouncement(string announcementType, string title, string content, string targetUserType)
    {
        var announcement = CreateAnnouncement(announcementType, title, content);

        PublishAnnouncement(announcement, targetUserType);

        return announcement;
    }

    public IReadOnlyList<IAnnouncement> GetAllAnnouncements()
    {
        return _dataStore.GetAnnouncements();
    }
}
