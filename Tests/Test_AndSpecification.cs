namespace FizzBuzz.Tests;

[TestClass]
public class Test_AndSpecification
{
  [TestMethod]
  public void IsSatisfiedByBothTrue()
  {
    var mock1 = new Mock<ISpecification>();
    var mock2 = new Mock<ISpecification>();
    mock1.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(true);
    mock2.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(true);

    var testObject = new AndSpecification(mock1.Object, mock2.Object);

    var actual = testObject.IsSatisfiedBy(It.IsAny<int>());

    Assert.IsTrue(actual);
  }

  [TestMethod]
  public void IsSatisfiedByBothFalse()
  {
    var mock1 = new Mock<ISpecification>();
    var mock2 = new Mock<ISpecification>();
    mock1.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(false);
    mock2.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(false);

    var testObject = new AndSpecification(mock1.Object, mock2.Object);

    var actual = testObject.IsSatisfiedBy(It.IsAny<int>());

    Assert.IsFalse(actual);
  }

  [TestMethod]
  public void IsSatisfiedByFirstTrueSecondFalseReturnFalse()
  {
    var mock1 = new Mock<ISpecification>();
    var mock2 = new Mock<ISpecification>();
    mock1.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(true);
    mock2.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(false);

    var testObject = new AndSpecification(mock1.Object, mock2.Object);

    var actual = testObject.IsSatisfiedBy(It.IsAny<int>());

    Assert.IsFalse(actual);
  }

  [TestMethod]
  public void IsSatisfiedByFirstFalseSecondTrueReturnFalse()
  {
    var mock1 = new Mock<ISpecification>();
    var mock2 = new Mock<ISpecification>();
    mock1.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(false);
    mock2.Setup(s => s.IsSatisfiedBy(It.IsAny<int>())).Returns(true);

    var testObject = new AndSpecification(mock1.Object, mock2.Object);

    var actual = testObject.IsSatisfiedBy(It.IsAny<int>());

    Assert.IsFalse(actual);
  }
}