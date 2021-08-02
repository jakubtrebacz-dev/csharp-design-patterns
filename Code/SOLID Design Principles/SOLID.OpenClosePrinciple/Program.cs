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

    public interface ISpecification<T> 
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> product, ISpecification<T> specification);
    }

    public class ColourSpecification : ISpecification<Product>
    {
        private Colour colour;

        public ColourSpecification(Colour colour)
        {
            this.colour = colour;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Colour == colour;
        }
    }

    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> specification)
        {
            foreach (Product product in products)
            {
                if (specification.IsSatisfied(product))
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
            foreach (Product product in productFilter.Filter(products, new ColourSpecification(Colour.Green)))
            {
                Console.WriteLine($"- {product.Name} is {product.Colour}");
            }
        }
    }
}
