namespace DebugMakeItFail;
public class SalesAnalyzer
{
    public static Dictionary<string, object> AnalyzeSales(List<Dictionary<string, object>> salesData)
    {
        Console.WriteLine("Starting sales analysis...");
        double totalRevenue = 0;
        var productTotals = new Dictionary<string, (int units, double revenue)>();

        foreach (var entry in salesData)
        {
            int unitsSold = Convert.ToInt32(entry["units_sold"]);
            double unitPrice = Convert.ToDouble(entry["unit_price"]);
            string product = entry["product"].ToString();

            double revenue = unitsSold * unitPrice;
            totalRevenue += revenue;

            if (!productTotals.ContainsKey(product))
                productTotals[product] = (0, 0);

            var current = productTotals[product];
            current.units += unitsSold;
            current.revenue += revenue;
            productTotals[product] = current;
        }

        double avgUnitsSold = productTotals.Values.Average(v => v.units); // potential failure point
        double avgRevenuePerProduct = totalRevenue / productTotals.Count;
        

        var performanceScores = new Dictionary<string, double>();
        foreach (var kv in productTotals)
        {
            // Bug: Division by avgUnitsSold can fail when avgUnitsSold == 0
            double ratio = kv.Value.revenue / avgRevenuePerProduct;
            performanceScores[kv.Key] = ratio * (kv.Value.units / avgUnitsSold);
            Console.WriteLine($"DEBUG avgUnitsSold={performanceScores[kv.Key]}");
        }

        var ranked = performanceScores.OrderByDescending(x => x.Value).ToList();
        var topProduct = ranked[0].Key;

        Console.WriteLine("Finished analyzing.");
        return new Dictionary<string, object>
        {
            ["top_product"] = topProduct,
            ["rankings"] = ranked,
            ["avg_units"] = avgUnitsSold
        };
    }
}