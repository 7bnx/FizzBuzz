namespace FizzBuzz.App;

static public class App
{

  static public void Run(params int[] inputNumbers)
  {
    var converters = TasksConverters.Get();

    SimplePrinter.Print("Number", Enumerable.Range(1, converters.Length).Select(i => $"Task {i}"));

    foreach (var number in inputNumbers)
      SimplePrinter.Print(number, converters.Select(c => c.Convert(number)));
  }
}