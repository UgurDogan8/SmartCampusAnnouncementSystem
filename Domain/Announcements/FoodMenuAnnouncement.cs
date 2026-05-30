namespace SmartCampusAnnouncementSystem.Domain.Announcements;

public class FoodMenuAnnouncement : BaseAnnouncement
{
    public FoodMenuAnnouncement(string title, string content)
        : base(title, content)
    {
    }

    public override string GetAnnouncementType()
    {
        return "Yemekhane Duyurusu";
    }
}
