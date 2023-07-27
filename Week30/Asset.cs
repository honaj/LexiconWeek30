public abstract class Asset
{
    DateOnly purchaseDate;
    string name;
    double price;

    // Checks if the asset is older than 3 years
    public bool IsDeprecated => purchaseDate.AddYears(3) > DateOnly.FromDateTime(DateTime.Now);
    
    // Checks if the asset is about to be deprecated (older than 2 years and 9 months)
    public bool IsCloseToDeprecated => purchaseDate.AddYears(2).AddMonths(9) > DateOnly.FromDateTime(DateTime.Now);

    public DateOnly PurchaseDate
    {
        get => purchaseDate;
        set
        {
            // Ensures that the asset's purchase date isn't set in the future
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
            // Ensures that the name is not an empty or whitespace string
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
            // Ensures that the price is a positive value
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