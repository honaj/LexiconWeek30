namespace Week30;

// Class for offices
public class Office
{
    // Office location and currency type
    public string Location { get; }
    public Currency Currency { get; }

    // Holds office assets.
    public readonly List<Asset> Assets = new();

    // Assets ordered by type (Computer first) and purchase date
    public IEnumerable<Asset> OrderedAssets => 
        Assets.OrderByDescending(asset => asset is Computer).
            ThenByDescending(asset => asset.PurchaseDate);
    
    public Office(string location, Currency currency)
    {
        Location = location;
        Currency = currency;
    }
}