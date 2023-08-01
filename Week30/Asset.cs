namespace Week30;

//Base class for assets
public abstract class Asset
{
    public DateOnly PurchaseDate { get; }
    public string Name { get; }
    public double Price { get; }

    // Checks if the asset is less than three months from being deprecated
    public bool IsDeprecated => PurchaseDate < DateOnly.FromDateTime(DateTime.Now).AddYears(-2).AddMonths(-9);
    
    // Checks if the asset is less than six months from being deprecated
    public bool IsCloseToDeprecated => PurchaseDate < DateOnly.FromDateTime(DateTime.Now).AddYears(-2).AddMonths(-6);

    protected Asset(DateOnly purchaseDate, string name, double price)
    {
        PurchaseDate = purchaseDate;
        Name = name;
        Price = price;
    }
}