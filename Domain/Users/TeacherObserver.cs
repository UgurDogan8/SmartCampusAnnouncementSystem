namespace SmartCampusAnnouncementSystem.Domain.Users;

public class TeacherObserver : BaseUserObserver
{
    public TeacherObserver(string fullName, string preferredNotificationType)
        : base(fullName, preferredNotificationType)
    {
    }

    public override string UserType => "Öğretmen";
}
