namespace Anshan.Framework.Domain.Specification
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}