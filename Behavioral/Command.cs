// Simulate the calls
WashingMachine washingMachine = new();
Queue<Command> commands = new();

void Main()
{
    OnNewClothes("T-Shirt", "Socks");
    OnNewClothes("More Socks");
    OnStartButtonPressed();
}

// May be an HTTP endpoint / delegate
public void OnNewClothes(params string[] clothes)
    => commands.Enqueue(new AddToQuickWash(washingMachine, clothes));

// May be an HTTP endpoint / delegate
public void OnStartButtonPressed()
{
    commands.Enqueue(new StartQuickWash(washingMachine));

    commands.ToList()
        .ForEach(command => command.Execute());
}


public class WashingMachine
{
    public List<string> Clothes { get; } = new ();

    public string Program { get; set; } = string.Empty;

    public void RunProgram()
        => Clothes.ForEach(cloth => $"Washing {cloth} ...".Dump());
}

public interface Command
{
    void Execute();
}

public class AddToQuickWash : Command
{
    private readonly List<string> _clothes;

    private readonly WashingMachine _washingMachine;

    public AddToQuickWash(WashingMachine washingMachine, params string[] clothes)
        => (_washingMachine, _clothes) = (washingMachine, clothes.ToList());

    public void Execute()
    {
        _clothes.Dump(nameof(AddToQuickWash));
        _washingMachine.Clothes.AddRange(_clothes);
    }
}

public class StartQuickWash : Command
{
    private readonly WashingMachine _washingMachine;

    public StartQuickWash(WashingMachine washingMachine)
        => _washingMachine = washingMachine;

    public void Execute()
    {
        _washingMachine.Program = "QuickWash";

        "Running".Dump(nameof(StartQuickWash));
        _washingMachine.RunProgram();
        "Done !".Dump(nameof(StartQuickWash));
    }
}
