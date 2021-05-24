void Main()
{
    var properties1 = Properties.Instance;
    var properties2 = Properties.Instance;

    $"Using {nameof(properties1)}, the application name is: {properties1.ApplicationName}".Dump();
    $"Using {nameof(properties2)}, the application name is: {properties2.ApplicationName}".Dump();
}


// Singleton class, allows for at most one unique instance of an object to exist
public class Properties
{
    // Unique instance that can be accessed by the outside
    // Using the lazy initialization, we only create the element once: when requested
    // for the first time
    private static Lazy<Properties> _lazyInstance = new Lazy<Properties>(() => new Properties());

    public string ApplicationName { get; private set; } = string.Empty;

    public static Properties Instance { get => _lazyInstance.Value; }

    // The constructor must be private to ensure that no other instance can be
    // created from the outside
    private Properties()
        => LoadProperties();

    // This may be the parsing of a file, a database or else
    private void LoadProperties()
    {
        ApplicationName = "Singleton Demo";
        "Properties loaded !".Dump();
    }
}
