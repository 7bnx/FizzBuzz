namespace FizzBuzz.Common;

public class ModSpecification : ISpecification
{
  private readonly int _divider;
  public ModSpecification(int divider)
  {
    if (divider == 0)
      throw new ArgumentException("Divider can't be 0");
    _divider = divider;
  }

  public bool Equals(ISpecification? obj)
  {
    if (obj is ModSpecification other)
      return _divider == other._divider;
    return false;
  }

  public bool IsSatisfiedBy(int num)
    => num % _divider == 0;
}