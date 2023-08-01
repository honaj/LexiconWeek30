public class Phone : Asset
{
    public Phone(DateOnly purchaseDate, string name, double price, CurrencyType currency) : base(purchaseDate, name, price, currency)
    {
    }
}