var offices = new Office[]
{
    new("Malmö"), 
    new("Madrid"), 
    new("Miami")
};

Console.WriteLine("Welcome to your asset manager! Press P to view all assets in all offices, press A to add an asset to an office, or Q to quit.");

while (true)
{
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.A:
            AddAsset();
            break;
        case ConsoleKey.P:
            PrintAllAssets();
            break;
        case ConsoleKey.Q:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid key input");
            break;
    }
}

return;

void PrintAllAssets()
{
    foreach (var office in offices)
    {
        Console.WriteLine(office.Location.ToUpper());
        
        foreach (var asset in office.OrderedAssets)
        {
            //Set text color based on asset status
            Console.ForegroundColor = asset.IsDeprecated ? ConsoleColor.Red :
                asset.IsCloseToDeprecated ? ConsoleColor.Yellow :
                ConsoleColor.White;
        }
    }
}

void AddAsset()
{
    
}