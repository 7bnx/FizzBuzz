namespace FizzBuzz.Tests;

[TestClass]
public class Test_Handler
{
  [TestMethod]
  public void IsMatchTrue()
  {
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(true);
    var testObject = new Handler(new Mock<ITag>().Object, mockSpec.Object);

    var actual = testObject.IsMatch(It.IsAny<int>());

    Assert.IsTrue(actual);
  }

  [TestMethod]
  public void IsMatchFalse()
  {
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(false);
    var testObject = new Handler(new Mock<ITag>().Object, mockSpec.Object);

    var actual = testObject.IsMatch(It.IsAny<int>());

    Assert.IsFalse(actual);
  }

  [TestMethod]
  public void AppendToMatchStorageIfSatisfied()
  {
    int invocationCount = 0;
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(true);
    var mockMatchedStorage = new Mock<IMatchedStorage>();
    mockMatchedStorage.Setup(s => s.Append(It.IsAny<ITag>())).Callback(() => invocationCount++);
    var testObject = new Handler(new Mock<ITag>().Object, mockSpec.Object);

    testObject.Handle(mockMatchedStorage.Object, It.IsAny<int>());
    mockMatchedStorage.Verify
    (
      s => s.Append(It.IsAny<ITag>()),
      Times.Exactly(1),
      $"Invocation times of IMatchedStorage should be exactly 1, but was {invocationCount}"
    );
  }

  [TestMethod]
  public void AppendToMatchStorageIfNotSatisfied()
  {
    int invocationCount = 0;
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(false);
    var mockMatchedStorage = new Mock<IMatchedStorage>();
    mockMatchedStorage.Setup(s => s.Append(It.IsAny<ITag>())).Callback(() => invocationCount++);
    var testObject = new Handler(new Mock<ITag>().Object, mockSpec.Object);

    testObject.Handle(mockMatchedStorage.Object, It.IsAny<int>());
    mockMatchedStorage.Verify
    (
      s => s.Append(It.IsAny<ITag>()),
      Times.Exactly(0),
      $"Invocation times of IMatchedStorage should be exactly 0, but was {invocationCount}"
    );
  }

  [TestMethod]
  public void EqualsTrue()
  {
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.Equals(It.IsAny<ISpecification>())).Returns(true);
    var testObject = new Handler(null!, mockSpec.Object);

    Assert.IsTrue(testObject.Equals(new Handler(null!, null!)));
  }

  [TestMethod]
  public void EqualsFalse()
  {
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.Equals(It.IsAny<ISpecification>())).Returns(false);
    var testObject = new Handler(null!, mockSpec.Object);

    Assert.IsFalse(testObject.Equals(new Handler(null!, null!)));
  }

  [TestMethod]
  public void EqualsDifferentType()
  {
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.Equals(It.IsAny<ISpecification>())).Returns(true);
    var testObject = new Handler(null!, mockSpec.Object);

    Assert.IsFalse(testObject.Equals(new object()));
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void AddHandlerWithEqualSpecificationException()
  {
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.Equals(It.IsAny<ISpecification>())).Returns(true);
    var testObject = new Handler(null!, mockSpec.Object);

    testObject.Add(new Handler(null!, null!));
  }

  [TestMethod]
  public void AddHandlerWithDifferentSpecification()
  {
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.Equals(It.IsAny<ISpecification>())).Returns(false);
    var testObject = new Handler(null!, mockSpec.Object);

    testObject.Add(new Handler(null!, null!));
  }

  [TestMethod]
  public void AppendTagsWithManyDifferentSpecifications()
  {
    int invocationCount = 0;
    var mockSpec = new Mock<ISpecification>();
    mockSpec.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(true);
    var mockMatchedStorage = new Mock<IMatchedStorage>();
    mockMatchedStorage.Setup(s => s.Append(It.IsAny<ITag>())).Callback(() => invocationCount++);

    var testObject = new Handler(new Mock<ITag>().Object, mockSpec.Object);

    for (int i = 0; i < 10; i++)
    {
      var mockSpecAdd = new Mock<ISpecification>();
      mockSpecAdd.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(true);
      testObject.Add(new Handler(new Mock<ITag>().Object, mockSpecAdd.Object));
    }

    testObject.Handle(mockMatchedStorage.Object, It.IsAny<int>());
    mockMatchedStorage.Verify
    (
      s => s.Append(It.IsAny<ITag>()),
      Times.Exactly(11),
      $"Invocation times of IMatchedStorage should be exactly 11, but was {invocationCount}"
    );
  }
}