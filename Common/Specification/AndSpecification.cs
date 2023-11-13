namespace FizzBuzz.Common;

public class AndSpecification : ISpecification
{
  private readonly ISpecification _specification1;
  private readonly ISpecification _specification2;

  public AndSpecification(ISpecification specification1, ISpecification specification2)
  {
    _specification1 = specification1;
    _specification2 = specification2;
  }

  public bool Equals(ISpecification? other)
    => _specification1.Equals(other) || _specification2.Equals(other);

  public bool IsSatisfiedBy(int num)
    => _specification1.IsSatisfiedBy(num) && _specification2.IsSatisfiedBy(num);
}