namespace FizzBuzz.Tests;

[TestClass]
public class Test_ExtensionMethods
{
  [TestMethod]
  public void AnsSpecificationTestType()
  {
    var mock1 = new Mock<ISpecification>();
    var mock2 = new Mock<ISpecification>();
    var actual = mock1.Object.And(mock2.Object);
    Assert.IsInstanceOfType(actual, typeof(AndSpecification));
  }
}