using System;

namespace SOLID.OpenClosePrinciple.Products
{
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
}
