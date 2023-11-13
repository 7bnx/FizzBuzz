namespace FizzBuzz.Common;

public interface ISpecification : IEquatable<ISpecification>
{
  bool IsSatisfiedBy(int num);
}