using Week30;

// For testing purposes, create a few offices and assign them some assets
var offices = new List<Office>
{
    new("Malmö", Currency.Sek) {Assets =
    {
        new Phone(new DateOnly(2022, 8, 15), "Google Pixel", 1100),
        new Computer(new DateOnly(2020, 5, 3), "Apple Macbook", 2500),
        new Phone(new DateOnly(2020, 12, 15), "Apple iPhone", 1000)
    }}, 
    new("Madrid", Currency.Eur) {Assets =
    {
        new Computer(new DateOnly(2023, 7, 14), "Dell XPS", 2200),
        new Phone(new DateOnly(2019, 8, 15), "Apple iPhone", 1100)
    }}, 
    new("Miami", Currency.Usd) {Assets =
    {
        new Computer(new DateOnly(2018, 11, 18), "HP Envy", 1800),
        new Phone(new DateOnly(2021, 1, 17), "Samsung Galaxy", 800),
        new Computer(new DateOnly(2020, 9, 4), "Google Chromebook", 700)
    }}
};

// Fake exchange rates, for actual usage you would want to fetch current rates from a service
Dictionary<Currency, double> dollarExchangeRates = new()
{
    {Currency.Usd, 1},
    {Currency.Eur, 0.9},
    {Currency.Sek, 10.5}
};

PrintAllAssets();
return;

// Print all assets in all offices
void PrintAllAssets(bool printHeadings = true)
{
    Console.Clear();
    
    // Print categories in columns
    if (printHeadings)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{"LOCATION",-20} {"TYPE",-20} {"NAME",-20} {"PRICE",-20} {"PURCHASE DATE",-20}");
    }
    
    // Loop through all offices in alphabetic order
    foreach (var office in offices.OrderBy(office => office.Location))
    {
        foreach (var asset in office.OrderedAssets)
        {
            // Set text color based on asset status
            Console.ForegroundColor = asset.IsDeprecated ? ConsoleColor.Red :
                asset.IsCloseToDeprecated ? ConsoleColor.Yellow :
                ConsoleColor.White;
            
            // Convert the dollar price to local currency
            var localPrice = asset.Price * dollarExchangeRates[office.Currency];    
        
            // Print asset data in nice columns
            Console.WriteLine($"{office.Location,-20} {asset.GetType().Name,-20} {asset.Name,-20} {localPrice,-20} {asset.PurchaseDate:yyyy-MM-dd}");
        }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("(1) Add new asset");
    Console.WriteLine("(2) Quit");
    
    //Allow user to add a new asset or quit the app
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.D1:
            AddAsset();
            break;
        case ConsoleKey.D2:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid key input");
            break;
    }
}

//Create a new asset
void AddAsset()
{
    //Ask the user to enter all necessary data
    var chosenOffice = SelectOffice();
    var assetClassName = ChooseNewAssetClassName();
    var date = ChooseAssetPurchaseDate();
    var name = ChooseAssetName();
    var price = ChooseAssetPrice();

    // Instantiate a subclass of Asset
    chosenOffice.Assets.Add(assetClassName switch
    {
        "computer" => new Computer(date, name, price),
        "phone" => new Phone(date, name, price),
        _ => throw new ArgumentOutOfRangeException()
    });
    
    PrintAllAssets(false);
}

//Let the user select an office to add the new asset to
Office SelectOffice()
{
    Office? selectedOffice;
    
    do
    {
        // Print all existing offices
        Console.Clear();
        Console.WriteLine("Available offices: ");
        foreach (var office in offices)
        {
            Console.WriteLine(office.Location);
        }

        // Get input and check that it matches an existing office
        Console.WriteLine("Please enter a valid office location");
        var officeInput = Console.ReadLine();
        selectedOffice = offices.FirstOrDefault(office => string.Equals(office.Location, officeInput, StringComparison.OrdinalIgnoreCase));
    } while (selectedOffice == null);

    return selectedOffice;
}

// Let the user select a type for the new asset. In a larger app you would probably want something fancier where you actually look through all the names of subclasses of Asset
string ChooseNewAssetClassName()
{
    //Check that the input is either a computer or phone
    string? typeInput;
    do
    {
        Console.Clear();
        Console.WriteLine("Please enter a valid asset type: 'computer' or 'phone'");
        typeInput = Console.ReadLine()?.ToLower();
    } while (typeInput != "computer" && typeInput != "phone");

    // Return the string name of the chosen asset type
    return typeInput.ToLower();
}

//Let the user enter a purchase date for the new asset
DateOnly ChooseAssetPurchaseDate()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Please enter a valid date in the format YYYY-MM-DD. The date must not be in the future.");

        var dateInput = Console.ReadLine();
        
        //Check that the entered date is valid and not in the future
        if(DateTime.TryParse(dateInput, out var parsedDate))
        {
            if(parsedDate.Date <= DateTime.Today)
            {
                return DateOnly.FromDateTime(parsedDate);
            }

            Console.WriteLine("The date is in the future. Please try again.");
        }
        else
        {
            Console.WriteLine("Invalid date format. Please try again.");
        }
    }
}

// Let user enter a name for the new asset, it should not be empty
string ChooseAssetName()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Please enter the name of the new asset. It should not be empty.");
        var nameInput = Console.ReadLine();
        // Validate that the string is not empty
        if (!string.IsNullOrEmpty(nameInput))
        {
            return nameInput;
        }
    }
}

// Let the user enter a price for the new product
double ChooseAssetPrice()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Please enter a price in US dollars. It must be greater than 0.");

        var numberInput = Console.ReadLine();
        
        // Validate that the price is a number above 0
        if(double.TryParse(numberInput, out var parsedPrice))
        {
            if(parsedPrice > 0.0)
            {
                return parsedPrice;
            }

            Console.WriteLine("The price is too low. Please try again.");
        }
        else
        {
            Console.WriteLine("Invalid entry. Please try again.");
        }
    }
}