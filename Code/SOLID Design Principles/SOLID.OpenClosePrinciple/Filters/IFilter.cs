using System.Collections.Generic;

namespace SOLID.OpenClosePrinciple.Filters
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> product, ISpecification<T> specification);
    }
}
