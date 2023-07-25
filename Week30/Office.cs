public enum Currency
{
    USD,
    EUR,
    SEK
}

public class Office
{
    public string Location { get; set; }
    readonly List<Asset> assets = new();
    readonly List<Asset> deprecatedAssets = new();
    public IReadOnlyList<Asset> Assets => assets.AsReadOnly();
    public IReadOnlyList<Asset> DeprecatedAssets => deprecatedAssets.AsReadOnly();
    public IOrderedEnumerable<Asset> OrderedAssets => assets.OrderByDescending(asset => asset.PurchaseDate).ThenByDescending(asset => asset is Computer);

    public Office(string location)
    {
        Location = location;
    }

    public void AddAsset(Asset asset)
    {
        assets.Add(asset);
    }

    public void DeprecateAsset(Asset asset)
    {
        assets.Remove(asset);
        deprecatedAssets.Add(asset);
    }
}