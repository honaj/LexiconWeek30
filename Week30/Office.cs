public enum Currency
{
    USD,
    EUR,
    SEK
}

public class Office
{
    public string Location { get; set; }
    private readonly List<Asset> assets = new();
    private readonly List<Asset> deprecatedAssets = new();

    public IReadOnlyList<Asset> Assets => assets.AsReadOnly();
    public IReadOnlyList<Asset> DeprecatedAssets => deprecatedAssets.AsReadOnly();

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