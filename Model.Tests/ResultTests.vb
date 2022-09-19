<TestClass()> _
Public Class ResultTests

    <TestMethod()> _
    Public Sub AddSetResultTest()
        ' Arrange
        Dim result = New Result()
        Dim setResult = New SetResult With {.Home = 5, .Guest = 2}

        ' Act
        result.AddSetResult(setResult)

        ' Assert
        Assert.IsNotNull(result.SetResults, "SetResults is null")
        Assert.AreEqual(1, result.SetResults.Length, "Unexpected number of SetResults")
        Assert.AreEqual(5, result.SetResults(0).Home, "Unexpected SetResults[0].Home")
        Assert.AreEqual(2, result.SetResults(0).Guest, "Unexpected SetResults[0].Guest")
    End Sub

End Class