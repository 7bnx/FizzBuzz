namespace FizzBuzz.Tests;

[TestClass]
public class Test_HandlerNotMatched
{
  [TestMethod]
  public void IsMatchTrue()
  {
    var mockHandler = new Mock<Handler>(null, null);
    mockHandler.Setup(h => h.IsMatch(It.IsAny<int>())).Returns(true);
    var testObject = new HandlerNotMatched(mockHandler.Object);

    var actual = testObject.IsMatch(It.IsAny<int>());

    Assert.IsTrue(actual);
  }

  [TestMethod]
  public void IsMatchFalse()
  {
    var mockHandler = new Mock<Handler>(null, null);
    mockHandler.Setup(h => h.IsMatch(It.IsAny<int>())).Returns(false);
    var testObject = new HandlerNotMatched(mockHandler.Object);

    var actual = testObject.IsMatch(It.IsAny<int>());

    Assert.IsFalse(actual);
  }

  [TestMethod]
  public void AppendWhenNotMatched()
  {
    PrepareMatchedAndNotMatchedHandlers(false, out var mockHandlerMatched, out var mockHandlerNotMatched);

    var testObject = new HandlerNotMatched(mockHandlerMatched.Object)
                        .AddNotMatched(mockHandlerNotMatched.Object);
    testObject.AddNotMatched(mockHandlerNotMatched.Object);

    testObject.Handle(null!, It.IsAny<int>());
    mockHandlerNotMatched.Verify
    (
      h => h.Handle(It.IsAny<IMatchedStorage>(), It.IsAny<int>()),
      Times.Exactly(1)
    );

    mockHandlerMatched.Verify
    (
      h => h.Handle(It.IsAny<IMatchedStorage>(), It.IsAny<int>()),
      Times.Exactly(0)
    );
  }

  [TestMethod]
  public void AppendWhenMatched()
  {
    PrepareMatchedAndNotMatchedHandlers(true, out var mockHandlerMatched, out var mockHandlerNotMatched);

    var testObject = new HandlerNotMatched(mockHandlerMatched.Object)
                        .AddNotMatched(mockHandlerNotMatched.Object);

    testObject.Handle(null!, It.IsAny<int>());
    mockHandlerNotMatched.Verify
    (
      h => h.Handle(It.IsAny<IMatchedStorage>(), It.IsAny<int>()),
      Times.Exactly(0)
    );

    mockHandlerMatched.Verify
    (
      h => h.Handle(It.IsAny<IMatchedStorage>(), It.IsAny<int>()),
      Times.Exactly(1)
    );
  }

  private static void PrepareMatchedAndNotMatchedHandlers
  (
    bool IsMatch,
    out Mock<Handler> mockHandlerMatched,
    out Mock<Handler> mockHandlerNotMatched
  )
  {
    mockHandlerMatched = new Mock<Handler>(null, null);
    mockHandlerMatched.Setup(h => h.IsMatch(It.IsAny<int>())).Returns(IsMatch);
    mockHandlerMatched.Setup(h => h.Handle(It.IsAny<IMatchedStorage>(), It.IsAny<int>()));
    mockHandlerNotMatched = new Mock<Handler>(null, null);
    mockHandlerNotMatched.Setup(h => h.Handle(It.IsAny<IMatchedStorage>(), It.IsAny<int>()));
  }
}