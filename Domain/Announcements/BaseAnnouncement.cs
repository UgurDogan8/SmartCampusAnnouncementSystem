namespace SmartCampusAnnouncementSystem.Domain.Announcements;

public abstract class BaseAnnouncement : IAnnouncement
{
    protected BaseAnnouncement(string title, string content)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Duyuru başlığı boş olamaz.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentException("Duyuru içeriği boş olamaz.", nameof(content));
        }

        Title = title;
        Content = content;
        CreatedAt = DateTime.Now;
    }

    public string Title { get; }

    public string Content { get; }

    public DateTime CreatedAt { get; }

    public abstract string GetAnnouncementType();

    public string GetSummary()
    {
        return $"Duyuru Tipi: {GetAnnouncementType()}{Environment.NewLine}" +
               $"Başlık: {Title}{Environment.NewLine}" +
               $"İçerik: {Content}{Environment.NewLine}" +
               $"Oluşturulma Tarihi: {CreatedAt:dd.MM.yyyy HH:mm}";
    }
}
