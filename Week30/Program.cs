// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var offices = new Office[]
{
    new("Malmö"), 
    new("Madrid"), 
    new("Chicago")
};
return;

void PrintAllAssets()
{
    var allAssets = new List<Asset>();
    if (offices == null) return;
    foreach (var office in offices)
    {
        allAssets.Concat(office.OrderedAssets);
    }

    foreach (var asset in allAssets)
    {
        if (asset.IsDeprecated)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (asset.IsCloseToDeprecated)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}