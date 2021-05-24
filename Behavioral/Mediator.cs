void Main()
{
    var airport = new Airport();
    airport.Board();
    "---".Dump();
    airport.TakeOff();
}

// Mediator
class Airport
{
    Aircraft Aircraft;
    GroundControl GroundControl;
    Passengers Passengers;

    public Airport()
        => (GroundControl, Passengers, Aircraft)
        = (new GroundControl(this), new Passengers(this), new Aircraft(this));

    public void TakeOff()
    {
        nameof(TakeOff).Dump(nameof(Airport));

        GroundControl.AcknowledgeTakeOffOf(Aircraft);
        Aircraft.TakeOff();
    }

    public void Board()
    {
        nameof(Board).Dump(nameof(Airport));

        Passengers.GoOnto(Aircraft);
        Aircraft.PrepareForTakeOff();
    }
}

// Concrete classes, interacting together
class GroundControl
{
    Airport Airport;

    public GroundControl(Airport airport)
        => Airport = airport;

    public void AcknowledgeTakeOffOf(Aircraft airplane)
        => nameof(AcknowledgeTakeOffOf).Dump(nameof(GroundControl));
}

class Passengers
{
    Airport Airport;

    public Passengers(Airport airport)
        => Airport = airport;

    public void GoOnto(Aircraft aircraft)
        => nameof(GoOnto).Dump(nameof(Passengers));
}

class Aircraft
{
    Airport Airport;

    public Aircraft(Airport airport)
        => Airport = airport;

    public void PrepareForTakeOff()
        => nameof(PrepareForTakeOff).Dump(nameof(Aircraft));

    public void TakeOff()
        => nameof(PrepareForTakeOff).Dump(nameof(Aircraft));
}
