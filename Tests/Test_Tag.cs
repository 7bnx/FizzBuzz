namespace FizzBuzz.Tests;

[TestClass]
public class Test_Tag
{

  [TestMethod]
  [DataRow("Test")]
  public void TypeStringValidInputGetSameOutput(string input)
  {
    Tag<string> testObject = new(input);
    var actual = testObject.Get;
    Assert.AreEqual(input, testObject.Get, $"Expected value({input}) not equals actual{actual}");
  }

  [TestMethod]
  public void TypeStringEmptyInputGetEmptyOutput()
  {
    Tag<string> testObject = new(string.Empty);
    var actual = testObject.Get;
    Assert.IsTrue(actual == string.Empty, $"Actual{actual} value not empty");
  }

  [TestMethod]
  public void TypeStringNullInputGetEmptyOutput()
  {
    Tag<string> testObject = new(null!);
    var actual = testObject.Get;
    Assert.IsTrue(actual is null, $"Actual{actual} value not null");
  }

  [TestMethod]
  [DataRow(int.MinValue)]
  [DataRow(int.MaxValue)]
  [DataRow(0)]
  [DataRow(12)]
  public void TypeIntValidInputGetValidOutput(int input)
  {
    Tag<int> testObject = new(input);
    var actual = testObject.Get;
    Assert.AreEqual($"{input}", testObject.Get, $"Expected value({input}) not equals actual{actual}");
  }
}