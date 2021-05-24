void Main()
{
    var coffeeMachine = new CoffeeMachine();

    coffeeMachine.BrewCoffee();

    coffeeMachine.PressPowerButton();
    coffeeMachine.BrewCoffee();
    coffeeMachine.BrewCoffee();
    coffeeMachine.PressPowerButton();

    coffeeMachine.BrewCoffee();

    coffeeMachine.PressPowerButton();
    coffeeMachine.BrewCoffee();
}

public partial class CoffeeMachine
{
    public int CoffeeLevel { get; set; } = 1;

    private State _state = new Off();

    private void SetState(State state)
        => _state = state;

    public void BrewCoffee()
        => _state.BrewCoffee(this);

    public void PressPowerButton()
        => _state.PressPowerButton(this);
}

public partial class CoffeeMachine
{
    private interface State
    {
        void BrewCoffee(CoffeeMachine coffeeMachine);
        void PressPowerButton(CoffeeMachine coffeeMachine);
    }

    private class Off : State
    {
        public void BrewCoffee(CoffeeMachine coffeeMachine)
            => "/!\\ The coffee machine is not turned on".Dump(nameof(BrewCoffee));

        public void PressPowerButton(CoffeeMachine coffeeMachine)
        {
            State state = coffeeMachine.CoffeeLevel == 0
                ? new NoCoffee()
                : new Ready();

            coffeeMachine.SetState(state);

            "Coffee machine turned on".Dump(nameof(PressPowerButton));
        }
    }

    private class Ready : State
    {
        public void BrewCoffee(CoffeeMachine coffeeMachine)
        {
            if (coffeeMachine.CoffeeLevel == 0)
            {
                coffeeMachine.SetState(new NoCoffee());
                "/!\\ No more coffee".Dump(nameof(BrewCoffee));
                return;
            }

            --coffeeMachine.CoffeeLevel;
            "Brewing a cup of coffee ...".Dump(nameof(BrewCoffee));
        }

        public void PressPowerButton(CoffeeMachine coffeeMachine)
        {
            coffeeMachine.SetState(new Off());
            "Shuting down".Dump(nameof(PressPowerButton));
        }
    }

    private class NoCoffee : State
    {
        public void BrewCoffee(CoffeeMachine coffeeMachine)
            => "/!\\ You need to refill the machine in coffee".Dump(nameof(BrewCoffee));

        public void PressPowerButton(CoffeeMachine coffeeMachine)
        {
            coffeeMachine.SetState(new Off());
            "Shuting down".Dump(nameof(PressPowerButton));
        }
    }
}
