namespace FizzBuzz.Common;

public static class ExtensionMethods
{

  public static ISpecification And(this ISpecification spec1, ISpecification spec2)
    => new AndSpecification(spec1, spec2);
}