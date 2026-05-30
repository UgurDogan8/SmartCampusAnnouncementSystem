using System.Globalization;
using SmartCampusAnnouncementSystem.Domain.Notifications;

namespace SmartCampusAnnouncementSystem.Infrastructure.Factories;

// Bu sınıf Factory Pattern amacıyla kullanılmıştır.
// Nesne oluşturma sorumluluğunu merkezi hale getirir.
// Uygulama içinde dağınık new kullanımını azaltır.
public static class NotificationFactory
{
    private static readonly CultureInfo TurkishCulture = CultureInfo.GetCultureInfo("tr-TR");

    public static INotification CreateNotification(string notificationType)
    {
        if (string.IsNullOrWhiteSpace(notificationType))
        {
            throw new ArgumentException("Bildirim tipi boş olamaz.", nameof(notificationType));
        }

        var normalizedType = notificationType.Trim().ToLowerInvariant();
        var normalizedTurkishType = notificationType.Trim().ToLower(TurkishCulture);

        return (normalizedType, normalizedTurkishType) switch
        {
            ({ } type, { } turkishType) when IsSupported(type, turkishType, "email", "e-posta", "eposta") => new EmailNotification(),
            ({ } type, { } turkishType) when IsSupported(type, turkishType, "sms") => new SmsNotification(),
            ({ } type, { } turkishType) when IsSupported(type, turkishType, "push", "mobil", "mobile") => new PushNotification(),
            _ => throw new ArgumentException(
                $"Desteklenmeyen bildirim tipi: {notificationType}. Desteklenen tipler: email, e-posta, eposta, sms, push, mobil, mobile.",
                nameof(notificationType))
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
