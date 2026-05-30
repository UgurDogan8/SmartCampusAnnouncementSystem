using System.Globalization;
using SmartCampusAnnouncementSystem.Domain.Announcements;

namespace SmartCampusAnnouncementSystem.Infrastructure.Factories;

// Bu sınıf Factory Pattern amacıyla kullanılmıştır.
// Nesne oluşturma sorumluluğunu merkezi hale getirir.
// Uygulama içinde dağınık new kullanımını azaltır.
public static class AnnouncementFactory
{
    private static readonly CultureInfo TurkishCulture = CultureInfo.GetCultureInfo("tr-TR");

    public static IAnnouncement CreateAnnouncement(string announcementType, string title, string content)
    {
        if (string.IsNullOrWhiteSpace(announcementType))
        {
            throw new ArgumentException("Duyuru tipi boş olamaz.", nameof(announcementType));
        }

        var normalizedType = announcementType.Trim().ToLowerInvariant();
        var normalizedTurkishType = announcementType.Trim().ToLower(TurkishCulture);

        return (normalizedType, normalizedTurkishType) switch
        {
            ({ } type, { } turkishType) when IsSupported(type, turkishType, "exam", "sınav", "sinav") => new ExamAnnouncement(title, content),
            ({ } type, { } turkishType) when IsSupported(type, turkishType, "event", "etkinlik") => new EventAnnouncement(title, content),
            ({ } type, { } turkishType) when IsSupported(type, turkishType, "food", "yemekhane") => new FoodMenuAnnouncement(title, content),
            ({ } type, { } turkishType) when IsSupported(type, turkishType, "library", "kütüphane", "kutuphane") => new LibraryAnnouncement(title, content),
            _ => throw new ArgumentException(
                $"Desteklenmeyen duyuru tipi: {announcementType}. Desteklenen tipler: exam, sınav, sinav, event, etkinlik, food, yemekhane, library, kütüphane, kutuphane.",
                nameof(announcementType))
        };
    }

    private static bool IsSupported(string normalizedType, string normalizedTurkishType, params string[] supportedTypes)
    {
        foreach (var supportedType in supportedTypes)
        {
            if (normalizedType == supportedType || normalizedTurkishType == supportedType)
            {
                return true;
            }
        }

        return false;
    }
}
