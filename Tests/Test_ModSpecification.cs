namespace FizzBuzz.Tests;

[TestClass]
public class Test_ModSpecification
{
  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void ZeroDividerException()
  {
    _ = new ModSpecification(0);
  }

  [TestMethod]
  [DataRow(int.MinValue, int.MinValue, true)]
  [DataRow(int.MaxValue, int.MaxValue, true)]
  [DataRow(int.MaxValue, int.MinValue, false)]
  [DataRow(int.MinValue, int.MaxValue, false)]
  [DataRow(34, 0, true)]
  [DataRow(7, 14, true)]
  [DataRow(7, 13, false)]
  public void IsSatisfiedByValidInput(int divider, int num, bool expected)
  {
    var testObject = new ModSpecification(divider);
    var actual = testObject.IsSatisfiedBy(num);
    Assert.AreEqual(expected, actual);
  }

  [TestMethod]
  public void EqualsDifferentObjectsWithSameDividerTrue()
  {
    var testObject1 = new ModSpecification(1);
    var testObject2 = new ModSpecification(1);
    Assert.IsTrue(testObject1.Equals(testObject2));
  }

  [TestMethod]
  public void EqualsDifferentObjectsWithDifferentDividerFalse()
  {
    var testObject1 = new ModSpecification(1);
    var testObject2 = new ModSpecification(2);
    Assert.IsFalse(testObject1.Equals(testObject2));
  }

  [TestMethod]
  public void EqualsSameObjectTrue()
  {
    var testObject = new ModSpecification(1);
    Assert.IsTrue(testObject.Equals(testObject));
  }

  [TestMethod]
  public void EqualsDifferentTypeFalse()
  {
    var testObject = new ModSpecification(1);
    Assert.IsFalse(testObject.Equals(new object()));
  }
}