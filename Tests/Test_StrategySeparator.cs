namespace FizzBuzz.Tests;

[TestClass]
public class Test_StrategySeparator
{

  [TestMethod]
  [DataRow("-")]
  [DataRow("*")]
  public void ExecuteSingleCharacterSeparatorValidInput(string separator)
  {
    var testObject = new StrategySeparator(separator);
    var list = GetMockedTagsList(_tagsStrings);
    var actual = testObject.Execute(list);
    Assert.AreEqual(string.Join(separator, _tagsStrings), actual);
  }

  [TestMethod]
  public void ExecuteSingleCharacterSeparatorEmptyInputEmptyOutput()
  {
    var testObject = new StrategySeparator(string.Empty);
    var list = new List<ITag>();
    var actual = testObject.Execute(list);
    Assert.AreEqual(string.Empty, actual);
  }

  [TestMethod]
  [DataRow("-----")]
  [DataRow("******")]
  public void ExecuteStringSeparatorValidInput(string separator)
  {
    var testObject = new StrategySeparator(separator);
    var list = GetMockedTagsList(_tagsStrings);
    var actual = testObject.Execute(list);
    Assert.AreEqual(string.Join(separator, _tagsStrings), actual);
  }

  [TestMethod]
  public void ExecuteStringSeparatorEmptyInputEmptyOutput()
  {
    var testObject = new StrategySeparator(string.Empty);
    var list = new List<ITag>();
    var actual = testObject.Execute(list);
    Assert.AreEqual(string.Empty, actual);
  }

  [TestMethod]
  public void ExecuteEmptySeparatorValidInput()
  {
    var testObject = new StrategySeparator(string.Empty);
    var list = GetMockedTagsList(_tagsStrings);
    var actual = testObject.Execute(list);
    Assert.AreEqual(string.Join(string.Empty, _tagsStrings), actual);
  }

  [TestMethod]
  public void ExecuteEmptySeparatorEmptyInputEmptyOutput()
  {
    var testObject = new StrategySeparator(string.Empty);
    var list = new List<ITag>();
    var actual = testObject.Execute(list);
    Assert.AreEqual(string.Empty, actual);
  }

  [TestMethod]
  public void ExecuteNullSeparatorValidInput()
  {
    var testObject = new StrategySeparator(null!);
    var list = GetMockedTagsList(_tagsStrings);
    var actual = testObject.Execute(list);
    Assert.AreEqual(string.Join(null!, _tagsStrings), actual);
  }

  [TestMethod]
  public void ExecuteNullSeparatorEmptyInputEmptyOutput()
  {
    var testObject = new StrategySeparator(null!);
    var list = new List<ITag>();
    var actual = testObject.Execute(list);
    Assert.AreEqual(string.Empty, actual);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void ExecuteNullInputException()
  {
    var testObject = new StrategySeparator(null!);
    _ = testObject.Execute(null!);
  }

  private static List<ITag> GetMockedTagsList(IEnumerable<string> tagsString)
  {
    var list = new List<ITag>();
    foreach (var s in tagsString)
    {
      var mock = new Mock<ITag>();
      mock.Setup(x => x.Get).Returns(s);
      list.Add(mock.Object);
    }
    return list;
  }

  private static readonly string[] _tagsStrings = new string[] { "fizz", "buzz", "duzz", "muzz" };

}