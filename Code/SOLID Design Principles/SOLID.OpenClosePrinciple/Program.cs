using System;
using System.Collections;
using System.Collections.Generic;

namespace SOLID.OpenClosePrinciple
{
    public enum Colour 
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large
    }

    public class Product
    {
        public string Name;
        public Colour Colour;
        public Size Size;

        public Product(string name, Colour colour, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }

            Name = name;
            Colour = colour;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (Product product in products)
            {
                if (product.Size == size)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FilterByColour(IEnumerable<Product> products, Colour colour)
        {
            foreach (Product product in products)
            {
                if (product.Colour == colour)
                {
                    yield return product;
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Product apple = new Product("Apple", Colour.Green, Size.Small);
            Product tree = new Product("Tree", Colour.Green, Size.Medium);
            Product house = new Product("House", Colour.Red, Size.Large);

            Product[] products = { apple, tree, house };

            ProductFilter productFilter = new ProductFilter();

            Console.WriteLine("Green products (old): ");
            foreach (Product product in productFilter.FilterByColour(products, Colour.Green))
            {
                Console.WriteLine($"- {product.Name} is {product.Colour}");
            }
        }
    }
}
