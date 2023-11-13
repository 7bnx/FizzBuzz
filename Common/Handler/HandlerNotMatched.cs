namespace FizzBuzz.Common;

public class HandlerNotMatched : HandlerBase
{
  public override ITag Tag => _handler.Tag;
  private readonly Handler _handler;
  private HandlerBase? _notMatchedHandler;

  public HandlerNotMatched(Handler handler)
    => _handler = handler;
  public override bool IsMatch(int num)
    => _handler.IsMatch(num);

  public override void Handle(IMatchedStorage storage, int num)
  {
    if (!IsMatch(num))
      _notMatchedHandler?.Handle(storage, num);
    else
      _handler?.Handle(storage, num);
    _next?.Handle(storage, num);
  }

  public HandlerNotMatched AddNotMatched(HandlerBase notMatchedHandler)
  {
    _notMatchedHandler = notMatchedHandler;
    return this;
  }

  public override bool Equals(HandlerBase? other)
    => _handler.Equals(other);
}