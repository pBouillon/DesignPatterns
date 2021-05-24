void Main()
{
    var john = new Person("John");

    while (john.Age < 17) john.GrowUp();

    var olderJohn = (Person) john.Clone();
    olderJohn.GrowUp();

    john.Dump("Original John");
    olderJohn.Dump("Older John");
}


// Prototype interface, allows the prototype to be cloned without any external objects' references
public interface IPerson
{
    IPerson Clone();
}

public class Person : IPerson
{
    // Those properties can't be externally assigned
    public int Age { get; private set; }

    public DrivingLicense? DrivingLicense { get; private set; }

    public readonly string Name;

    public Person(string name)
        => Name = name;

    // This method is manipulating the state of the object from within
    public void GrowUp()
    {
        ++Age;

        if (Age == 18)
        {
            DrivingLicense = new DrivingLicense(Name, DateTime.Now);
        }
    }

    // The implementation of the clone method allows the object to copy itself
    // even if its internal state is hidden
    public IPerson Clone()
    {
        var clone = new Person(Name);

        clone.Age = Age;
        clone.DrivingLicense = DrivingLicense != null
            ? DrivingLicense with { }
            : null;

        return clone;
    }
}

public record DrivingLicense(string name, DateTime obtainedOn);
