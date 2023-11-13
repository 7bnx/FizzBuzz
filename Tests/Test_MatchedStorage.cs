namespace FizzBuzz.Tests;

[TestClass]
public class Test_MatchedStorage
{
  [TestMethod]
  public void AppendAndGetSameQuantityOfTags()
  {
    var testObject = new MatchedStorage();
    int expectedQty = 12;
    for (int i = 0; i < expectedQty; i++)
      testObject.Append(new Mock<ITag>().Object);

    var actualQty = testObject.GetTags().Count();

    Assert.AreEqual(expectedQty, actualQty);
  }

  [TestMethod]
  public void CheckSameOrderOfMatchedTags()
  {
    var testObject = new MatchedStorage();
    var tagsStrings = new string[] { "fizz", "buzz", "guzz", "muzz" };
    foreach (var s in tagsStrings)
    {
      var mockTag = new Mock<ITag>();
      mockTag.SetupGet(t => t.Get).Returns(s);
      testObject.Append(mockTag.Object);
    }

    var actualTags = testObject.GetTags();

    Assert.IsTrue(tagsStrings.SequenceEqual(actualTags.Select(t => t.Get)));
  }
}