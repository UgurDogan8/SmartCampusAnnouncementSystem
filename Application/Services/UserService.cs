using System.Globalization;
using SmartCampusAnnouncementSystem.Domain.Users;
using SmartCampusAnnouncementSystem.Infrastructure.Data;
using SmartCampusAnnouncementSystem.Infrastructure.Factories;
using SmartCampusAnnouncementSystem.Infrastructure.Singleton;

namespace SmartCampusAnnouncementSystem.Application.Services;

public class UserService
{
    private static readonly CultureInfo TurkishCulture = CultureInfo.GetCultureInfo("tr-TR");
    private readonly InMemoryDataStore _dataStore;

    public UserService(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
    }

    public IUserObserver CreateUser(string userType, string fullName, string preferredNotificationType)
    {
        if (string.IsNullOrWhiteSpace(userType))
        {
            throw new ArgumentException("Kullanıcı tipi boş olamaz.", nameof(userType));
        }

        var normalizedType = userType.Trim().ToLowerInvariant();
        var normalizedTurkishType = userType.Trim().ToLower(TurkishCulture);

        if (IsSupported(normalizedType, normalizedTurkishType, "öğrenci", "ogrenci", "student"))
        {
            return CreateStudent(fullName, preferredNotificationType);
        }

        if (IsSupported(normalizedType, normalizedTurkishType, "öğretmen", "ogretmen", "teacher"))
        {
            return CreateTeacher(fullName, preferredNotificationType);
        }

        throw new ArgumentException(
            $"Desteklenmeyen kullanıcı tipi: {userType}. Desteklenen tipler: öğrenci, ogrenci, student, öğretmen, ogretmen, teacher.",
            nameof(userType));
    }

    public IUserObserver CreateStudent(string fullName, string preferredNotificationType)
    {
        ValidateNotificationType(preferredNotificationType);

        var student = new StudentObserver(fullName, preferredNotificationType);

        _dataStore.AddUser(student);
        SubscribeUser(student);

        return student;
    }

    public IUserObserver CreateTeacher(string fullName, string preferredNotificationType)
    {
        ValidateNotificationType(preferredNotificationType);

        var teacher = new TeacherObserver(fullName, preferredNotificationType);

        _dataStore.AddUser(teacher);
        SubscribeUser(teacher);

        return teacher;
    }

    public void SubscribeUser(IUserObserver user)
    {
        ArgumentNullException.ThrowIfNull(user);

        NotificationCenter.Instance.Subscribe(user);
    }

    public bool DeleteUser(string fullName, string userType)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Kullanıcı adı boş olamaz.", nameof(fullName));
        }

        if (string.IsNullOrWhiteSpace(userType))
        {
            throw new ArgumentException("Kullanıcı tipi boş olamaz.", nameof(userType));
        }

        var user = _dataStore.GetUsers().FirstOrDefault(currentUser =>
            string.Equals(currentUser.FullName.Trim(), fullName.Trim(), StringComparison.OrdinalIgnoreCase) &&
            string.Equals(currentUser.UserType.Trim(), userType.Trim(), StringComparison.OrdinalIgnoreCase));

        if (user is null)
        {
            return false;
        }

        var removed = _dataStore.RemoveUser(user);

        if (removed)
        {
            NotificationCenter.Instance.Unsubscribe(user);
        }

        return removed;
    }

    public IReadOnlyList<IUserObserver> GetAllUsers()
    {
        return _dataStore.GetUsers();
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

    private static void ValidateNotificationType(string preferredNotificationType)
    {
        NotificationFactory.CreateNotification(preferredNotificationType);
    }
}
