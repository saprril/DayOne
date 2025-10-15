namespace DebugDivideAndConquer
{
    public static class SalesAnalyzer
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

            double avgRevenuePerProduct = totalRevenue / productTotals.Count;
            double avgUnitsSold = productTotals.Values.Average(v => v.units);
            Console.WriteLine($"DEBUG averages: avgRevenue={avgRevenuePerProduct}, avgUnits={avgUnitsSold}");

            // --- Bug likely hides here ---
            Console.WriteLine("DEBUG halfway: product totals:");
            var performanceScores = new Dictionary<string, double>();
            foreach (var kv in productTotals)
            {
                double ratio = kv.Value.revenue / avgRevenuePerProduct;
                performanceScores[kv.Key] = ratio * (kv.Value.units / avgUnitsSold);
                Console.WriteLine($"  {kv.Key} → units={kv.Value.units}, revenue={kv.Value.revenue}");
            }

            Console.WriteLine("DEBUG scores:");
            foreach (var kv in performanceScores)
                Console.WriteLine($"  {kv.Key}: {kv.Value}");


            // --- Bug hides here (sorting logic) ---
            var ranked = performanceScores
                .OrderByDescending(x => x.Value)
                .ToList();
            Console.WriteLine("DEBUG ranked:");
            foreach (var kv in ranked)
                Console.WriteLine($"  {kv.Key}: {kv.Value}");
                
            var topProduct = ranked[0].Value; // Should be ranked[0].Key

            Console.WriteLine("Finished analyzing.");

            return new Dictionary<string, object>
            {
                ["total_revenue"] = totalRevenue,
                ["average_revenue"] = avgRevenuePerProduct,
                ["rankings"] = ranked,
                ["top_product"] = topProduct
            };
        }
    }
}