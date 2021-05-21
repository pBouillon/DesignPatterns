<Query Kind="Program" />

void Main()
{
    var owner = new Owner(null);
    var manager = new Manager(owner);
    var employee = new Employee(manager);

    employee.Handle("Bankruptcy");
    "---".Dump();
    employee.Handle("Unhappy customer");
    "---".Dump();
    employee.Handle("Empty shelve");
}

public interface IReportedEventHandler
{
    void Handle(string eventName);
}

public abstract class Worker : IReportedEventHandler
{
    protected readonly IReportedEventHandler? Superior;

    protected Worker(IReportedEventHandler? superior)
        => Superior = superior;

    public abstract void Handle(string eventName);
}

public class Employee : Worker
{
    public Employee(IReportedEventHandler? superior)
        : base(superior) { }

    public override void Handle(string eventName)
    {
        if (eventName == "Empty shelve")
        {
            "Filling the empty shelve".Dump(nameof(Employee));
            return;
        }

        $"Unable to handle event '{eventName}'".Dump(nameof(Employee));
        Superior?.Handle(eventName);
    }
}

public class Manager : Worker
{
    public Manager(IReportedEventHandler? superior)
        : base(superior) { }

    public override void Handle(string eventName)
    {
        if (eventName == "Unhappy customer")
        {
            "Handling unhappy customer".Dump(nameof(Manager));
            return;
        }

        $"Unable to handle event '{eventName}'".Dump(nameof(Manager));
        Superior?.Handle(eventName);
    }
}

public class Owner : Worker
{
    public Owner(IReportedEventHandler? superior)
        : base(superior) { }

    public override void Handle(string eventName)
    {
        if (eventName == "Bankruptcy")
        {
            "Selling the shop".Dump(nameof(Owner));
            return;
        }

        $"Unable to handle event '{eventName}'".Dump(nameof(Owner));
        Superior?.Handle(eventName);
    }
}
