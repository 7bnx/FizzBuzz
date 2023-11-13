namespace FizzBuzz.Common;

public class Handler : HandlerBase
{
  public override ITag Tag { get; }
  private readonly ISpecification _specification;

  public Handler(ITag tag, ISpecification specification)
    => (Tag, _specification) = (tag, specification);

  public override bool IsMatch(int num)
    => _specification.IsSatisfiedBy(num);

  public override bool Equals(HandlerBase? obj)
  {
    if (obj is Handler other)
      return this._specification.Equals(other._specification);
    return false;
  }

  public override void Handle(IMatchedStorage storage, int num)
  {
    if (IsMatch(num))
      storage.Append(Tag);
    _next?.Handle(storage, num);
  }
}