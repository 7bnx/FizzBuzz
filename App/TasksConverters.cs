using FizzBuzz.Common;
using static FizzBuzz.App.TasksHandlers;

namespace FizzBuzz.App;

public static class TasksConverters
{
  public static IFizzBuzzConverter[] Get()
  {
    var converterTask1 = new FizzBuzzConverter
    (
      AppendStrategy: new StrategySeparator("-"),
      Handler: Task1Handler,
      StorageFactory: new MatchedStorageFactory()
    );
    var converterTask2 = converterTask1 with { Handler = Task2Handler };
    var converterTask3 = converterTask1 with { Handler = Task3Handler };
    return new[] { converterTask1, converterTask2, converterTask3 };
  }
}