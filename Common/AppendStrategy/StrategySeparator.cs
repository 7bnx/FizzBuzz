namespace FizzBuzz.Common;

public class StrategySeparator : IAppendStrategy
{
  private readonly string _separator;
  public StrategySeparator(string separator)
     => _separator = separator;
  public string Execute(IEnumerable<ITag> tags)
    => string.Join(_separator, tags.Select(t => t.Get));
}