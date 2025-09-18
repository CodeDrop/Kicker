<TestClass>
Public Class MatchDaysMatchGeneratorTests

    <TestMethod>
    Public Sub Generate2Test()
        Dim sut = New MatchdaysMatchGenerator(2)
        Dim result = sut.Generate()
        Assert.AreEqual(1, result.Count)
    End Sub

    <TestMethod>
    Public Sub Generate3Test()
        Dim sut = New MatchdaysMatchGenerator(3)
        Dim result = sut.Generate()
        Assert.AreEqual(3, result.Count)
    End Sub

    <TestMethod>
    Public Sub Generate5Test()
        Dim sut = New MatchdaysMatchGenerator(5)
        Dim result = sut.Generate()
        Assert.AreEqual(10, result.Count)
        Assert.AreNotEqual(New Tuple(Of Integer, Integer)(0, 2), result.ElementAt(1))
    End Sub

    <TestMethod>
    Public Sub GenerateXTest()
        Dim sut = New MatchdaysMatchGenerator(14)
        Dim result = sut.Generate()
        For Each matchIndexPair In result
            Console.WriteLine(matchIndexPair)
        Next
    End Sub

End Class
