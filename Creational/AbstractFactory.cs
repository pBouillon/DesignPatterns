void Main()
{
    var regularCustomer = new Customer(new RegularClothingFactory());
    $"{nameof(regularCustomer)} buying clothes ...".Dump();
    regularCustomer.BuyClothes();

    var funkyCustomer = new Customer(new FunkyClothingFactory());
    $"{nameof(funkyCustomer)} buying clothes ...".Dump();
    funkyCustomer.BuyClothes();
}


// Client, using the abstract factory to hide the creation details
public class Customer
{
    ClothingFactory _factory;

    public Customer(ClothingFactory factory)
        => _factory = factory;

    public void BuyClothes()
    {
        _factory.CreateSweater().Dump("Bought:");
        _factory.CreateTrouser().Dump("Bought:");
    }
}


// Products' abstractions
public interface Sweater { }
public interface Trouser { }


// Concrete products
public record FunkySweater() : Sweater;
public record FunkyTrouser() : Trouser;

public record RegularSweater() : Sweater;
public record RegularTrouser() : Trouser;


// Abstract factory
public interface ClothingFactory
{
    Sweater CreateSweater();
    Trouser CreateTrouser();
}


// Concrete factories
public class FunkyClothingFactory : ClothingFactory
{
    public Sweater CreateSweater()
        => new FunkySweater();

    public Trouser CreateTrouser()
        => new FunkyTrouser();
}

public class RegularClothingFactory : ClothingFactory
{
    public Sweater CreateSweater()
        => new RegularSweater();

    public Trouser CreateTrouser()
        => new RegularTrouser();
}
