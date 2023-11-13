namespace FizzBuzz.Common;

public interface IMatchedStorage
{
  void Append(ITag tag);
  IEnumerable<ITag> GetTags();

}