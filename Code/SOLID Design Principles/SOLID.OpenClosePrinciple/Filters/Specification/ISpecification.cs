namespace SOLID.OpenClosePrinciple.Filters
{
    public interface ISpecification<T> 
    {
        bool IsSatisfied(T t);
    }
}
