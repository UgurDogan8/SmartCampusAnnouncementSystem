namespace SmartCampusAnnouncementSystem.Domain.Announcements;

public interface IAnnouncement
{
    string Title { get; }

    string Content { get; }

    DateTime CreatedAt { get; }

    string GetAnnouncementType();

    string GetSummary();
}
