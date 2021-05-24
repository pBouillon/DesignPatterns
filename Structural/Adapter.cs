void Main()
{
    // Using the class adapter
    IEmployeeNotificationService notificationService = new ClassAdapter();

    var employeeService = new EmployeeService(notificationService);
    employeeService.GiveRaiseTo(1337, 42);

    // Using the method adapter
    var emailNotifier = new EmailNotifier();
    notificationService = new MethodAdapter(emailNotifier);

    employeeService = new EmployeeService(notificationService);
    employeeService.GiveRaiseTo(1970, 01.01);
}


// Interface allowing the two services (EmployeeService & EmailNotifier) to communicate
// even tho their APIs are incompatible
public interface IEmployeeNotificationService
{
    void Notify(int id, string reason);
}


// Service that needs to consume an incompatible interface
public class EmployeeService
{
    IEmployeeNotificationService _notificationService;

    public EmployeeService(IEmployeeNotificationService notificationService)
        => _notificationService = notificationService;

    public void GiveRaiseTo(int id, double amount)
        => _notificationService.Notify(id, $"You have earned a raise of ${amount}!");
}


// "Third party" class with an API that is incompatible with ours
// In this case, the notification from IEmployeeNotificationService is using
// the employee's id and a reason, but in the EmailNotifier API we are using
// a subject, a body and a destination address
public class EmailNotifier
{
    public void SendEmail(string subject, string body, string destination)
        => new { Subject = subject, Body = body, Destination = destination }
            .Dump("Email received:");
}


// Concrete adapters:
// - The class adapter is also part of the element it adapts. In this case,
//   the adapter is a subclass of the EmailNotifier, and implements the logic of
//   IEmployeeNotificationService as part of the subclass
// - The method adapter aims to only use a reference of the class to adapt and implement
//   the incompatible logic using this instance
public class ClassAdapter : EmailNotifier, IEmployeeNotificationService
{
    public ClassAdapter()
        : base() { }

    public void Notify(int id, string reason)
        => SendEmail(
            $"New notification from {this.GetType().Name}",
            reason, $"employee-{id}@company.com");
}

public class MethodAdapter : IEmployeeNotificationService
{
    EmailNotifier _emailNotifier;

    public MethodAdapter(EmailNotifier emailNotifier)
        => _emailNotifier = emailNotifier;

    public void Notify(int id, string reason)
        => _emailNotifier.SendEmail(
            $"New notification from {this.GetType().Name}",
            reason, $"employee-{id}@company.com");
}
