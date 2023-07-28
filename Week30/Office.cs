// Represents available currencies.
public enum Currency
{
    USD, // US Dollar
    EUR, // Euro
    SEK  // Swedish Krona
}

// Represents an office with assets
public class Office
{
    // Office location
    public string Location { get; }

    // Holds office assets.
    public readonly List<Asset> Assets = new();

    // Assets ordered by type (Computer first) and purchase date
    public IEnumerable<Asset> OrderedAssets => 
        Assets.OrderByDescending(asset => asset is Computer).
            ThenByDescending(asset => asset.PurchaseDate);

    // Constructor with office's location
    public Office(string location)
    {
        Location = location;
    }
}