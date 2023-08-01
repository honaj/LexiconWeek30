// For testing purposes, create a few offices and assign them some assets
var offices = new List<Office>
{
    new("Malmö") {Assets =
    {
        new Phone(new DateOnly(2022, 8, 15), "Google Pixel", 11000, CurrencyType.SEK),
        new Computer(new DateOnly(2020, 5, 3), "Apple Macbook", 25000, CurrencyType.SEK),
        new Phone(new DateOnly(2020, 12, 15), "Apple iPhone", 10000, CurrencyType.SEK)
    }}, 
    new("Madrid") {Assets =
    {
        new Computer(new DateOnly(2023, 7, 14), "Dell XPS", 2200, CurrencyType.EUR),
        new Phone(new DateOnly(2019, 8, 15), "Apple iPhone", 1100, CurrencyType.EUR)
    }}, 
    new("Miami") {Assets =
    {
        new Computer(new DateOnly(2018, 11, 18), "HP Envy", 1800, CurrencyType.USD),
        new Phone(new DateOnly(2021, 1, 17), "Samsung Galaxy", 800, CurrencyType.USD),
        new Computer(new DateOnly(2020, 9, 4), "Google Chromebook", 700, CurrencyType.USD)
    }}
};

PrintAllAssets();
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
                AddAsset();
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

//Let the user select an office to add the new asset to
string? SelectOffice()
{
    Console.Clear();
    Console.WriteLine("Please select an office:");

    //Check that the entered office actually exists
    string? officeInput;
    do
    {
        Console.WriteLine("Please enter a valid office location");
        officeInput = Console.ReadLine();
    } while (!offices.Any(office => string.Equals(office.Location, officeInput, StringComparison.OrdinalIgnoreCase)));

    return officeInput;
}

Type AssetType()
{
    
}

//Create a new asset
void AddAsset()
{
    var office = SelectOffice();
}

void PrintAllAssets()
{
    Console.Clear();
    var converter = new CurrencyConverter();
    
    // Print categories in columns
    Console.ForegroundColor = ConsoleColor.White;
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

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("(1) Add new asset");
    Console.WriteLine("(2) Quit");
    
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.D1:
            SelectOffice();
            break;
        case ConsoleKey.D2:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid key input");
            break;
    }
}