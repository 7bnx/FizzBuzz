namespace FizzBuzz.Tests;

[TestClass]
public class Test_FizzBuzzConverter
{

  [TestMethod]
  public void NotMatchedAnyConditionReturnInput()
  {
    int num = 156;
    var mockHandler = new Mock<HandlerBase>();
    var mockFactory = new Mock<IMatchedStorageFactory>();
    var mockStorage = new Mock<IMatchedStorage>();
    mockStorage.Setup(s => s.GetTags()).Returns(Array.Empty<ITag>());
    mockFactory.Setup(f => f.Create()).Returns(mockStorage.Object);

    var testObject = new FizzBuzzConverter(null!, mockHandler.Object, mockFactory.Object);
    var actual = testObject.Convert(num);

    Assert.AreEqual(num.ToString(), actual);
  }

  [TestMethod]
  public void MatchedOneConditionReturnInput()
  {
    var tagStr = "Test";
    var mockHandler = new Mock<HandlerBase>();
    var mockFactory = new Mock<IMatchedStorageFactory>();
    var mockStorage = new Mock<IMatchedStorage>();
    var mockStrategy = new Mock<IAppendStrategy>();
    mockStorage.Setup(s => s.GetTags()).Returns(new ITag[] { new Mock<ITag>().Object });
    mockFactory.Setup(f => f.Create()).Returns(mockStorage.Object);
    mockStrategy.Setup(s => s.Execute(It.IsAny<IEnumerable<ITag>>())).Returns(tagStr);

    var testObject = new FizzBuzzConverter(mockStrategy.Object, mockHandler.Object, mockFactory.Object);
    var actual = testObject.Convert(0);

    Assert.AreEqual(tagStr, actual);
  }

  [TestMethod]
  public void MatchedSeveralConditionReturnConcatString()
  {
    var tagStr1 = "Fizz";
    var tagStr2 = "Buzz";
    var mockHandler = new Mock<HandlerBase>();
    var mockFactory = new Mock<IMatchedStorageFactory>();
    var mockStorage = new Mock<IMatchedStorage>();
    var mockStrategy = new Mock<IAppendStrategy>();
    var mockTag1 = new Mock<ITag>();
    var mockTag2 = new Mock<ITag>();
    mockTag1.SetupGet(t => t.Get).Returns(tagStr1);
    mockTag2.SetupGet(t => t.Get).Returns(tagStr2);
    mockStorage.Setup(s => s.GetTags()).Returns(new ITag[] { mockTag1.Object, mockTag2.Object });
    mockFactory.Setup(f => f.Create()).Returns(mockStorage.Object);
    mockStrategy.Setup(s => s.Execute(It.IsAny<IEnumerable<ITag>>())).Returns((IEnumerable<ITag> t) => string.Concat(t.Select(z => z.Get)));

    var testObject = new FizzBuzzConverter(mockStrategy.Object, mockHandler.Object, mockFactory.Object);
    var actual = testObject.Convert(0);

    Assert.AreEqual(tagStr1 + tagStr2, actual);
  }
}