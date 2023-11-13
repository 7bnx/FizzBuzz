namespace FizzBuzz.Common;

internal class MatchedStorageFactory : IMatchedStorageFactory
{

  public IMatchedStorage Create()
    => new MatchedStorage();
}