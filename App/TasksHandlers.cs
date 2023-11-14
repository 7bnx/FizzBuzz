using FizzBuzz.Common;

namespace FizzBuzz.App;

static public class TasksHandlers
{
  public static HandlerBase Task1Handler
    => FizzBuzz();

  public static HandlerBase Task2Handler
    => FizzBuzz().Add(MuzzGuzz());

  public static HandlerBase Task3Handler
    => new HandlerNotMatched(GoodBoy())
       .AddNotMatched(DogCat())
       .Add(MuzzGuzz());

  private static HandlerBase FizzBuzz()
    => new Handler(new TagString("fizz"), _mod3)
       .Add(new Handler(new TagString("buzz"), _mod5));

  private static HandlerBase MuzzGuzz()
    => new Handler(new TagString("muzz"), _mod4)
       .Add(new Handler(new TagString("guzz"), _mod7));

  private static HandlerBase DogCat()
    => new Handler(new TagString("dog"), _mod3)
      .Add(new Handler(new TagString("cat"), _mod5));
  private static Handler GoodBoy()
    => new(new TagString("good-boy"), _mod3.And(_mod5));

  private static readonly ModSpecification _mod3 = new(3);
  private static readonly ModSpecification _mod5 = new(5);
  private static readonly ModSpecification _mod4 = new(4);
  private static readonly ModSpecification _mod7 = new(7);
}