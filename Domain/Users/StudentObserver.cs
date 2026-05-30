namespace SmartCampusAnnouncementSystem.Domain.Users;

public class StudentObserver : BaseUserObserver
{
    public StudentObserver(string fullName, string preferredNotificationType)
        : base(fullName, preferredNotificationType)
    {
    }

    public override string UserType => "Öğrenci";
}
