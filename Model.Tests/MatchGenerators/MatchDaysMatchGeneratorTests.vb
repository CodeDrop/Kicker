<TestClass>
Public Class MatchDaysMatchGeneratorTests

    <TestMethod>
    Public Sub Generate2Test()
        Dim sut = New MatchdaysMatchGenerator(2)
        Dim result = sut.Generate()
        Assert.AreEqual(1, result.Count)
    End Sub

    <TestMethod>
    Public Sub Generate4Test()
        Dim sut = New MatchdaysMatchGenerator(4)
        Dim result = sut.Generate()
        Assert.AreEqual(6, result.Count)
    End Sub

    <TestMethod>
    Public Sub Generate10Test()
        Dim sut = New MatchdaysMatchGenerator(10)
        Dim result = sut.Generate()
        Assert.AreEqual(45, result.Count)
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
