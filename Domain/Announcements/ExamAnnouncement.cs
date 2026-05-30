namespace SmartCampusAnnouncementSystem.Domain.Announcements;

public class ExamAnnouncement : BaseAnnouncement
{
    public ExamAnnouncement(string title, string content)
        : base(title, content)
    {
    }

    public override string GetAnnouncementType()
    {
        return "Sınav Duyurusu";
    }
}
