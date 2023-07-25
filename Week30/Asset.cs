public class Asset
{
    public DateOnly purchaseDate;
    public string Name;

    public Asset(DateOnly purchaseDate, string name)
    {
        this.purchaseDate = purchaseDate;
        Name = name;
    }
}