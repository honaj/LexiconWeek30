var offices = new List<Office>
{
    new("Malmö"), 
    new("Madrid"), 
    new("Miami")
};

MainMenu();
return;

void MainMenu()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Welcome to your asset manager!");
        Console.WriteLine("(1) Add new asset");
        Console.WriteLine("(2) View all assets");
        Console.WriteLine("(3) Quit");
    
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                SelectOffice();
                break;
            case ConsoleKey.D2:
                PrintAllAssets();
                break;
            case ConsoleKey.D3:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid key input");
                break;
        }
    }
}

void SelectOffice()
{
    if (offices == null)
    {
        throw new Exception("No offices exist");
    }
    foreach (var office in offices)
    {
        Console.WriteLine($"({offices.IndexOf(office) + 1}) {office.Location}");
    }
}

void AddAsset(Office selectedOffice)
{
    Console.Clear();
    Console.WriteLine("Select asset type:");
    Console.WriteLine("(1) Laptop");
    Console.WriteLine("(2) Phone");
    
    Asset newAsset;
}

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
            
            Console.WriteLine($"{asset.GetType().Name,-10} {asset.Name,-20} {asset.Price,10:N2} {asset.PurchaseDate:yyyy-MM-dd}");
        }
    }
}