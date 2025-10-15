namespace DebugDivideAndConquer
{
    public class Program
    {
        public static void Main()
        {
            var sales = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object> { ["product"] = "Widget", ["region"] = "East", ["units_sold"] = 100, ["unit_price"] = 5.0 },
            new Dictionary<string, object> { ["product"] = "Widget", ["region"] = "West", ["units_sold"] = 150, ["unit_price"] = 5.0 },
            new Dictionary<string, object> { ["product"] = "Gadget", ["region"] = "East", ["units_sold"] = 200, ["unit_price"] = 2.5 },
            new Dictionary<string, object> { ["product"] = "Gadget", ["region"] = "West", ["units_sold"] = 300, ["unit_price"] = 2.5 },
            new Dictionary<string, object> { ["product"] = "Thingy", ["region"] = "East", ["units_sold"] = 0, ["unit_price"] = 10.0 }
        };

            var result = SalesAnalyzer.AnalyzeSales(sales);
            Console.WriteLine($"Top product: {result["top_product"]}");
        }
    }
}
