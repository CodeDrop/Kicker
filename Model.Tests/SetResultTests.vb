<TestClass()> _
Public Class SetResultTests

    <TestMethod()> _
    Public Sub ToStringTest()
        ' Arrange
        Dim setResult = New SetResult() With {.Home = 5, .Guest = 3}

        ' Act
        Dim result = setResult.ToString()

        ' Assert
        Assert.AreEqual("5:3", result, "Unexpected result")
    End Sub

End Class