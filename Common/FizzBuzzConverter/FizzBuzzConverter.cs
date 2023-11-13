namespace FizzBuzz.Common;

public record FizzBuzzConverter
(
  IAppendStrategy AppendStrategy,
  HandlerBase Handler,
  IMatchedStorageFactory StorageFactory
) : IFizzBuzzConverter
{
  public string Convert(int num)
  {
    IMatchedStorage storage = StorageFactory.Create();
    Handler.Handle(storage, num);
    var matchedTags = storage.GetTags();
    return matchedTags.Any() ? AppendStrategy.Execute(matchedTags) : num.ToString();
  }
}