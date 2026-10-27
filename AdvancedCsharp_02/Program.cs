
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCsharp_02
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        // Task 01: Smart Product Search
        public static List<Product> SearchProducts(
            List<Product> catalog,
            Func<Product, bool> predicate)
        {
            return catalog.Where(predicate).ToList();
        }

        // Task 03: Custom Report Generator
        public static void PrintReport(
            List<Product> products,
            Action<Product> printAction)
        {
            foreach (Product p in products)
            {
                printAction(p);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
            };

            // ==============================
            // Task 01: Smart Product Search
            // ==============================

            // 1. All Electronics products
            List<Product> electronics =
                Product.SearchProducts(catalog,
                    p => p.Category == "Electronics");

            // 2. Products cheaper than $50
            List<Product> cheaperThan50 =
                Product.SearchProducts(catalog,
                    p => p.Price < 50);

            // 3. Products that are in stock
            List<Product> inStock =
                Product.SearchProducts(catalog,
                    p => p.Stock > 0);

            // 4. Clothing products under $100
            List<Product> clothingUnder100 =
                Product.SearchProducts(catalog,
                    p => p.Category == "Clothing" && p.Price < 100);

            Console.WriteLine("===== TASK 01: SMART PRODUCT SEARCH =====");

            PrintProducts("Electronics", electronics);
            PrintProducts("Products cheaper than $50", cheaperThan50);
            PrintProducts("Products in stock", inStock);
            PrintProducts("Clothing under $100", clothingUnder100);

            // ==================================
            // Task 03: Custom Report Generator
            // ==================================

            Console.WriteLine("\n===== TASK 03: CUSTOM REPORT GENERATOR =====");

            // Scenario 1: Short Report
            Action<Product> shortReportPrintAction =
                p => Console.WriteLine($"{p.Name} - ${p.Price}");

            Console.WriteLine("\n--- Short Report ---");

            Product.PrintReport(catalog, shortReportPrintAction);

            // Scenario 2: Detailed Report
            Action<Product> detailedReportPrintAction =
                p => Console.WriteLine(
                    $"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}");

            Console.WriteLine("\n--- Detailed Report ---");

            Product.PrintReport(catalog, detailedReportPrintAction);
        }

        // Helper method for Task 01
        static void PrintProducts(string title, List<Product> products)
        {
            Console.WriteLine($"\n--- {title} ---");

            foreach (Product p in products)
            {
                Console.WriteLine(
                    $"{p.Name} | Category: {p.Category} | Price: ${p.Price} | Stock: {p.Stock}");
            }
        }
    }
}
