using SOLID.OpenClosePrinciple.Products;

namespace SOLID.OpenClosePrinciple.Filters
{
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
}
