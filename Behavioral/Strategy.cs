void Main()
{
    var paidWithCash = new ShoppingCart(new PayWithCash());
    paidWithCash.Checkout();

    var paidWithCard = new ShoppingCart(new PayWithCreditCard());
    paidWithCard.Checkout();
}

public class ShoppingCart
{
    readonly PaymentStrategy _paymentStrategy;

    int Total { get; set; } = 5;

    public ShoppingCart(PaymentStrategy paymentStrategy)
        => _paymentStrategy = paymentStrategy;

    public void Checkout()
        => _paymentStrategy.Checkout(Total);
}

public interface PaymentStrategy
{
    void Checkout(int amount);
}

public class PayWithCash : PaymentStrategy
{
    public void Checkout(int amount)
        => $"Paying {amount}€ in cash".Dump(nameof(PayWithCash));
}

public class PayWithCreditCard : PaymentStrategy
{
    public void Checkout(int amount)
        => $"Paying {amount}€ in card".Dump(nameof(PayWithCreditCard));
}
