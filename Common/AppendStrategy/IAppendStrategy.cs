namespace FizzBuzz.Common;

public interface IAppendStrategy
{
  string Execute(IEnumerable<ITag> tags);
}