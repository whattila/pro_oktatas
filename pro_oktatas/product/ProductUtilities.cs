using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_oktatas.product
{
    public class ProductUtilities
    {
        public static List<Product> ParseProducts(string[] lines)
        {
            List<Product> result = new List<Product>();
            for (int i = 1; i < lines.Length; i++) // We start from the second line to skip header
            {
                string[] line = lines[i].Split(';');
                try
                {
                    int id = int.Parse(line[0]);
                    string name = line[1];
                    string category = line[2];
                    int price = int.Parse(line[3]);
                    result.Add(new Product { Id = id, Name = name, Category = category, Price = price });
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Hibás sor kihagyva: {lines[i]} | Ok: {e.Message}");
                }
            }
            return result;
        }

        public static void PrintProductCountAndAvgPriceByCategory(List<Product> products)
        {
            var productGroups =
                from product in products
                group product by product.Category into productGroup
                select productGroup;
            foreach (var productGroup in productGroups)
                Console.WriteLine($"{productGroup.First().Category}: Number of products: {productGroup.Count()}, Average price: {Math.Round(productGroup.Average(product => product.Price))}");
        }
    }
}
