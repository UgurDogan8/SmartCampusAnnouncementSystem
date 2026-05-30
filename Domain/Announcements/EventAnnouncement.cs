namespace SmartCampusAnnouncementSystem.Domain.Announcements;

public class EventAnnouncement : BaseAnnouncement
{
    public EventAnnouncement(string title, string content)
        : base(title, content)
    {
    }

    public override string GetAnnouncementType()
    {
        return "Etkinlik Duyurusu";
    }
}
