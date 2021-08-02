using SOLID.OpenClosePrinciple.Filters;
using SOLID.OpenClosePrinciple.Products;
using System;
using System.Collections;

namespace SOLID.OpenClosePrinciple
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Product apple = new Product("Apple", Colour.Green, Size.Small);
            Product tree = new Product("Tree", Colour.Green, Size.Medium);
            Product house = new Product("House", Colour.Red, Size.Large);

            Product[] products = { apple, tree, house };

            ProductFilter productFilter = new ProductFilter();

            Console.WriteLine("Green products: ");
            foreach (Product product in productFilter.Filter(products, new ColourSpecification(Colour.Green)))
            {
                Console.WriteLine($"- {product.Name} is {product.Colour}");
            }

            Console.WriteLine("Large red products: ");
            foreach (Product product in productFilter
                .Filter(products, 
                new AndSpecification<Product>(
                    new ColourSpecification(Colour.Red),
                    new SizeSpecification(Size.Large)
                    )))
            {
                Console.WriteLine($"- {product.Name} is {product.Colour.ToString().ToLower()} and {product.Size.ToString().ToLower()}");
            }
        }
    }
}
