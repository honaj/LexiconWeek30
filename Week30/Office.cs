public enum Currency
{
    USD,
    EUR,
    SEK
}

public class Office
{
    public string Location { get; }
    readonly List<Asset> assets = new();
    public IReadOnlyList<Asset> Assets => assets.AsReadOnly();
    public IEnumerable<Asset> OrderedAssets => 
        assets.OrderByDescending(asset => asset is Computer).
            ThenByDescending(asset => asset.PurchaseDate);

    public Office(string location)
    {
        Location = location;
    }

    public void AddAsset(Asset asset)
    {
        assets.Add(asset);
    }
}