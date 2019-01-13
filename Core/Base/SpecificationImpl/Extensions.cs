using Base.Specification;

namespace Base.SpecificationImpl
{
    public static class Extensions
    {
        public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right) => new And<T>(left, right);

        public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right) => new Or<T>(left, right);

        public static ISpecification<T> Negate<T>(this ISpecification<T> inner) => new Negated<T>(inner);
    }
}
