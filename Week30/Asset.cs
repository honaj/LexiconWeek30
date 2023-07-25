public class Asset
{
    DateOnly purchaseDate;
    string name;
    double price;
    public bool IsDeprecated => purchaseDate.AddYears(3) > DateOnly.FromDateTime(DateTime.Now);
    public bool IsCloseToDeprecated => purchaseDate.AddYears(2).AddMonths(9) > DateOnly.FromDateTime(DateTime.Now);

    public DateOnly PurchaseDate
    {
        get => purchaseDate;
        set
        {
            if (value > DateOnly.FromDateTime(DateTime.Today))
                throw new ArgumentException("Purchase date cannot be in the future.");
            purchaseDate = value;
        }
    }

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty or null.");
            name = value;
        }
    }

    public double Price
    {
        get => price;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("Price must be greater than 0.");
            price = value;
        }
    }

    public Asset(DateOnly purchaseDate, string name, double price)
    {
        PurchaseDate = purchaseDate;
        Name = name;
        Price = price;
    }
}