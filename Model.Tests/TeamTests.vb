<TestClass()> _
Public Class TeamTests

    <TestMethod()> _
    Public Sub TeamTest()
        ' Arrange
        Dim number As Integer = 3

        ' Act
        Dim result = New Team(number)

        ' Assert
        Assert.AreEqual("Team N°3", result.Name, "Unexpected Name")
    End Sub

End Class