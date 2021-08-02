using System.Collections.Generic;
using SOLID.OpenClosePrinciple.Products;

namespace SOLID.OpenClosePrinciple.Filters
{
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
}
