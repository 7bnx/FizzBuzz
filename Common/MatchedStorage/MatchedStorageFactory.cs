namespace FizzBuzz.Common;

public class MatchedStorageFactory : IMatchedStorageFactory
{

  public IMatchedStorage Create()
    => new MatchedStorage();
}