namespace FizzBuzz.Common;

public class Tag<T> : ITag
{
  private readonly T _data;
  public Tag(T data)
      => _data = data;
  public virtual string? Get => _data?.ToString();
}