using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POFF.Kicker.Domain;

[TestClass()]
public class ResultTests
{

    [TestMethod()]
    public void AddSetResultTest()
    {
        // Arrange
        var result = new Result();
        var setResult = new SetResult() { Home = 5, Guest = 2 };

        // Act
        result.AddSetResult(setResult);

        // Assert
        Assert.IsNotNull(result.SetResults, "SetResults is null");
        Assert.AreEqual(1, result.SetResults.Length, "Unexpected number of SetResults");
        Assert.AreEqual(5, result.SetResults[0].Home, "Unexpected SetResults[0].Home");
        Assert.AreEqual(2, result.SetResults[0].Guest, "Unexpected SetResults[0].Guest");
    }

}