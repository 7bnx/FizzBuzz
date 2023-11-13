using System.Collections.Immutable;

namespace FizzBuzz.Common;
public class MatchedStorage : IMatchedStorage
{
  private readonly List<ITag> _list = new();
  public void Append(ITag tag)
    => _list.Add(tag);

  public IEnumerable<ITag> GetTags()
    => _list.ToImmutableList();
}