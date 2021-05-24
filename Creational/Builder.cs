void Main()
{
    ITableBuilder builder = new StoneTableBuilder();

    var manufacturer = new TableManufacturer(builder);
    manufacturer.BuildMinimumViableProduct()
        .Dump($"MVP built using a {builder.GetType().Name}");
    manufacturer.BuildFullyFinishedProduct()
        .Dump($"Full table built using a {builder.GetType().Name}");

    builder = new WoodTableBuilder();
    manufacturer.SetBuilder(builder);
    manufacturer.BuildMinimumViableProduct()
        .Dump($"MVP built using a {builder.GetType().Name}");
    manufacturer.BuildFullyFinishedProduct()
        .Dump($"Full table built using a {builder.GetType().Name}");
}


// Product class
public record Table(int NumberOfLegs, string ConstructionMaterial, bool IsPolished);


// Director class (optional), wrapping the building steps
public class TableManufacturer
{
    ITableBuilder _builder;

    public TableManufacturer(ITableBuilder builder)
        => _builder = builder;

    public Table BuildFullyFinishedProduct()
        => _builder.Reset()
            .SetPolished(true)
            .SetNumberOfLegs(4)
            .Build();

    public Table BuildMinimumViableProduct()
        => _builder.Reset()
            .SetPolished(false)
            .SetNumberOfLegs(3)
            .Build();

    public void SetBuilder(ITableBuilder builder)
        => _builder = builder;
}


// Builders' abstraction and concrete implementations
public interface ITableBuilder
{
    Table Build();
    ITableBuilder Reset();
    ITableBuilder SetNumberOfLegs(int numberOfLegs);
    ITableBuilder SetPolished(bool isPolished);
}

public class StoneTableBuilder : ITableBuilder
{
    Table _table = new Table(0, "Stone", false);

    public Table Build()
        => _table;

    public ITableBuilder Reset()
    {
        _table = new Table(0, "Stone", false);
        return this;
    }

    public ITableBuilder SetNumberOfLegs(int numberOfLegs)
    {
        _table = _table with { NumberOfLegs = numberOfLegs };
        return this;
    }

    public ITableBuilder SetPolished(bool isPolished)
    {
        _table = _table with { IsPolished = isPolished };
        return this;
    }
}

public class WoodTableBuilder : ITableBuilder
{
    Table _table = new Table(0, "Wood", false);

    public Table Build()
        => _table;

    public ITableBuilder Reset()
    {
        _table = new Table(0, "Wood", false);
        return this;
    }

    public ITableBuilder SetNumberOfLegs(int numberOfLegs)
    {
        _table = _table with { NumberOfLegs = numberOfLegs };
        return this;
    }

    public ITableBuilder SetPolished(bool isPolished)
    {
        _table = _table with { IsPolished = isPolished };
        return this;
    }
}
