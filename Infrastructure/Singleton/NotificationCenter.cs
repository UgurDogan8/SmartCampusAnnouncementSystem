using SmartCampusAnnouncementSystem.Domain.Announcements;
using SmartCampusAnnouncementSystem.Domain.Users;
using SmartCampusAnnouncementSystem.Infrastructure.Factories;

namespace SmartCampusAnnouncementSystem.Infrastructure.Singleton;

// Bu sınıf Singleton Pattern ile tek bildirim merkezi olarak tasarlanmıştır.
// Observer Pattern kapsamında kullanıcı listesini tutar.
// Yeni duyuru yayınlandığında tüm observer kullanıcıları bilgilendirir.
public sealed class NotificationCenter
{
    private static readonly NotificationCenter _instance = new();
    private readonly List<IUserObserver> _observers = [];
    private Action<string>? _logger;

    private NotificationCenter()
    {
    }

    public static NotificationCenter Instance => _instance;

    public void Subscribe(IUserObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        if (_observers.Any(existingObserver => IsSameObserver(existingObserver, observer)))
        {
            return;
        }

        _observers.Add(observer);
        Log($"{observer.FullName} adlı {observer.UserType} sisteme abone edildi.");
    }

    public void Unsubscribe(IUserObserver observer)
    {
        if (observer is null)
        {
            Log("Abonelikten çıkarılacak kullanıcı bulunamadı.");
            return;
        }

        var existingObserver = _observers.FirstOrDefault(currentObserver => IsSameObserver(currentObserver, observer));

        if (existingObserver is null)
        {
            Log($"{observer.FullName} adlı {observer.UserType} sistemde kayıtlı olmadığı için abonelikten çıkarılamadı.");
            return;
        }

        _observers.Remove(existingObserver);
        Log($"{observer.FullName} adlı {observer.UserType} abonelikten çıkarıldı.");
    }

    // Bu metot Observer Pattern'in notify aşamasını temsil eder.
    public void PublishAnnouncement(IAnnouncement announcement)
    {
        PublishAnnouncement(announcement, "Herkes");
    }

    public void PublishAnnouncement(IAnnouncement announcement, string targetUserType)
    {
        ArgumentNullException.ThrowIfNull(announcement);

        if (string.IsNullOrWhiteSpace(targetUserType))
        {
            throw new ArgumentException("Hedef kullanıcı tipi boş olamaz.", nameof(targetUserType));
        }

        var normalizedTargetUserType = targetUserType.Trim();
        var targetObservers = _observers
            .Where(observer => IsTargetObserver(observer, normalizedTargetUserType))
            .ToList();

        Log("----------------------------------------");
        Log("Yeni duyuru yayınlandı");
        Log($"Duyuru Tipi: {announcement.GetAnnouncementType()}");
        Log($"Hedef Kullanıcı: {normalizedTargetUserType}");
        Log($"Başlık: {announcement.Title}");
        Log($"İçerik: {announcement.Content}");
        Log("----------------------------------------");

        if (targetObservers.Count == 0)
        {
            Log("Bu hedef kullanıcı tipi için kayıtlı kullanıcı bulunamadı.");
            return;
        }

        foreach (var observer in targetObservers)
        {
            try
            {
                observer.Update(announcement);

                var notification = NotificationFactory.CreateNotification(observer.PreferredNotificationType);
                var notificationMessage = notification.Send(observer.FullName, observer.UserType, announcement);

                Log(notificationMessage);
            }
            catch (Exception exception)
            {
                Log($"{observer.FullName} adlı {observer.UserType} kullanıcısına bildirim gönderilirken hata oluştu: {exception.Message}");
            }
        }
    }

    public void SetLogger(Action<string> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    private static bool IsSameObserver(IUserObserver firstObserver, IUserObserver secondObserver)
    {
        return string.Equals(firstObserver.FullName, secondObserver.FullName, StringComparison.OrdinalIgnoreCase)
            && string.Equals(firstObserver.UserType, secondObserver.UserType, StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsTargetObserver(IUserObserver observer, string targetUserType)
    {
        return string.Equals(targetUserType, "Herkes", StringComparison.OrdinalIgnoreCase)
            || string.Equals(observer.UserType, targetUserType, StringComparison.OrdinalIgnoreCase);
    }

    private void Log(string message)
    {
        _logger?.Invoke(message);
    }
}
