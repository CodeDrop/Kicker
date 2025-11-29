using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POFF.Kicker.Data;

[TestClass()]
public class SetResultTests
{

    [TestMethod()]
    public void ToStringTest()
    {
        // Arrange
        var setResult = new SetResult() { Home = 5, Guest = 3 };

        // Act
        string result = setResult.ToString();

        // Assert
        Assert.AreEqual("5:3", result, "Unexpected result");
    }

}