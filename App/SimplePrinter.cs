namespace FizzBuzz.App;
public static class SimplePrinter
{
  const int ALIGNMENT = 25;
  static string FormatString(int alignment, IEnumerable<string> input)
    => string.Concat(input.Select(s => $"{s}".PadRight(alignment)));

  public static void Print(object head, IEnumerable<string> input)
  {
    var list = new List<string> { head.ToString()! };
    list.AddRange(input);
    Console.WriteLine(FormatString(ALIGNMENT, list));
  }
}