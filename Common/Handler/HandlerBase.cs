namespace FizzBuzz.Common;

abstract public class HandlerBase : IEquatable<HandlerBase>
{
  protected HandlerBase _next = null!;

  public abstract ITag Tag { get; }
  public abstract bool IsMatch(int num);

  public abstract void Handle(IMatchedStorage storage, int num);

  public HandlerBase Add(HandlerBase next)
  {
    if (this.Equals(next))
      throw new ArgumentException("Chain of responsibilities should not contain equals elements", nameof(next));
    if (_next != null) _next.Add(next);
    else _next = next;
    return this;
  }

  abstract public bool Equals(HandlerBase? other);
}