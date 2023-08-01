using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class CurrencyConverter
{
    const string ApiKey = "885e4c5086f2448f8f6739846dc27236";  // Replace with your API Key
    const string BaseUrl = "https://openexchangerates.org/api/latest.json?app_id=";
    IDictionary<string, decimal> rates;

    public async Task LoadRates()
    {
        using var client = new HttpClient();
        var url = $"{BaseUrl}{ApiKey}";
        var json = await client.GetStringAsync(url);
        var data = JsonConvert.DeserializeObject<OpenExchangeRatesResponse>(json);
        rates = data.Rates;
    }

    public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
    {
        if (rates == null) throw new InvalidOperationException("Must LoadRates before converting.");
        var fromRate = rates[fromCurrency.ToUpper()];
        var toRate = rates[toCurrency.ToUpper()];
        return amount / fromRate * toRate;
    }
}

public class OpenExchangeRatesResponse
{
    public string Disclaimer { get; set; }
    public string License { get; set; }
    public int TimeStamp { get; set; }
    public string Base { get; set; }
    public IDictionary<string, decimal> Rates { get; set; }
}