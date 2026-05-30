using SmartCampusAnnouncementSystem.Domain.Announcements;
using SmartCampusAnnouncementSystem.Domain.Users;

namespace SmartCampusAnnouncementSystem.Infrastructure.Data;

public class InMemoryDataStore
{
    private readonly List<IUserObserver> _users = new();
    private readonly List<IAnnouncement> _announcements = new();

    public void AddUser(IUserObserver user)
    {
        ArgumentNullException.ThrowIfNull(user);

        if (UserExists(user.FullName, user.UserType))
        {
            return;
        }

        _users.Add(user);
    }

    public IReadOnlyList<IUserObserver> GetUsers()
    {
        return _users.ToList().AsReadOnly();
    }

    public bool RemoveUser(IUserObserver user)
    {
        ArgumentNullException.ThrowIfNull(user);

        var existingUser = _users.FirstOrDefault(currentUser =>
            string.Equals(currentUser.FullName.Trim(), user.FullName.Trim(), StringComparison.OrdinalIgnoreCase) &&
            string.Equals(currentUser.UserType.Trim(), user.UserType.Trim(), StringComparison.OrdinalIgnoreCase));

        if (existingUser is null)
        {
            return false;
        }

        _users.Remove(existingUser);
        return true;
    }

    public void AddAnnouncement(IAnnouncement announcement)
    {
        ArgumentNullException.ThrowIfNull(announcement);

        _announcements.Add(announcement);
    }

    public IReadOnlyList<IAnnouncement> GetAnnouncements()
    {
        return _announcements.ToList().AsReadOnly();
    }

    public bool UserExists(string fullName, string userType)
    {
        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(userType))
        {
            return false;
        }

        return _users.Any(user =>
            string.Equals(user.FullName.Trim(), fullName.Trim(), StringComparison.OrdinalIgnoreCase) &&
            string.Equals(user.UserType.Trim(), userType.Trim(), StringComparison.OrdinalIgnoreCase));
    }
}
