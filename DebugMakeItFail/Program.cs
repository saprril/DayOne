namespace DebugMakeItFail;

public class Program
{
    public static void Main()
    {
        var sales = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object> { ["product"] = "Gadget", ["units_sold"] = 0, ["unit_price"] = 2.5 },
            new Dictionary<string, object> { ["product"] = "Thingy", ["units_sold"] = 0, ["unit_price"] = 10.0 }
        };
        var result = SalesAnalyzer.AnalyzeSales(sales);
        Console.WriteLine($"Top product: {result["top_product"]}");
    }
}