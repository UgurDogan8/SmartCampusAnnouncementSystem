namespace SmartCampusAnnouncementSystem.Domain.Announcements;

public class LibraryAnnouncement : BaseAnnouncement
{
    public LibraryAnnouncement(string title, string content)
        : base(title, content)
    {
    }

    public override string GetAnnouncementType()
    {
        return "Kütüphane Duyurusu";
    }
}
