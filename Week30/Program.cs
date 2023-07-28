// For testing purposes, create a few offices and assign them some assets
var offices = new List<Office>
{
    new("Malmö") {Assets =
    {
        new Phone(new DateOnly(2022, 8, 15), "Google Pixel", 11000),
        new Computer(new DateOnly(2020, 5, 3), "Apple Macbook", 25000),
        new Phone(new DateOnly(2020, 12, 15), "Apple iPhone", 10000)
    }}, 
    new("Madrid") {Assets =
    {
        new Computer(new DateOnly(2023, 7, 14), "Dell XPS", 22000),
        new Phone(new DateOnly(2019, 8, 15), "Apple iPhone", 11000)
    }}, 
    new("Miami") {Assets =
    {
        new Computer(new DateOnly(2018, 11, 18), "HP Envy", 18000),
        new Phone(new DateOnly(2021, 1, 17), "Samsung Galaxy", 8000),
        new Computer(new DateOnly(2020, 9, 4), "Google Chromebook", 7000)
    }}
};

MainMenu();
return;

// Let user select between adding new asset, showing all assets or quitting
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

// void AddAsset(Office selectedOffice)
// {
//     Console.Clear();
//     Console.WriteLine("Select asset type:");
//     Console.WriteLine("(1) Laptop");
//     Console.WriteLine("(2) Phone");
//     
//     Asset newAsset;
// }

void PrintAllAssets()
{
    Console.WriteLine("Esc to go back");
    // Print categories in columns
    Console.WriteLine($"{"LOCATION",-20} {"TYPE",-20} {"NAME",-20} {"PRICE",-20} {"PURCHASE DATE",-20}");
    //Loop through all offices in alphabetic order
    foreach (var office in offices.OrderBy(office => office.Location))
    {
        foreach (var asset in office.OrderedAssets)
        {
            // Set text color based on asset status
            Console.ForegroundColor = asset.IsDeprecated ? ConsoleColor.Red :
                asset.IsCloseToDeprecated ? ConsoleColor.Yellow :
                ConsoleColor.White;
            
            // Print asset data in nice columns
            Console.WriteLine($"{office.Location,-20} {asset.GetType().Name,-20} {asset.Name,-20} {asset.Price,-20} {asset.PurchaseDate:yyyy-MM-dd}");
        }
    }

    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
    {
        MainMenu();
    }
}