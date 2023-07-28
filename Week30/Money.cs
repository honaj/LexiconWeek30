//Simple class for 
public class Money
{
    public string Name { get; }
    public double DollarValue { get; }

    public Money(string name, double dollarValue)
    {
        Name = name;
        DollarValue = dollarValue;
    }
}