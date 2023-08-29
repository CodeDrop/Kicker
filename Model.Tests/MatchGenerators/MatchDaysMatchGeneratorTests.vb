<TestClass>
Public Class MatchDaysMatchGeneratorTests

    Private sut As MatchDaysMatchGenerator

    <TestInitialize>
    Public Sub SetUp()
        sut = New MatchDaysMatchGenerator()
    End Sub

    <TestMethod>
    Public Sub Generate2Test()
        Dim result = sut.Generate(2)
        Assert.AreEqual(1, result.Count)
    End Sub

    <TestMethod>
    Public Sub Generate3Test()
        Dim result = sut.Generate(3)
        Assert.AreEqual(3, result.Count)
    End Sub

    <TestMethod>
    Public Sub Generate5Test()
        Dim result = sut.Generate(5)
        Assert.AreEqual(10, result.Count)
        Assert.AreNotEqual(New Tuple(Of Integer, Integer)(0, 2), result.ElementAt(1))
        For Each matchIndexPair In result
            Console.WriteLine(matchIndexPair)
        Next
    End Sub

    <TestMethod>
    Public Sub Generate6Test()
        Dim result = sut.Generate(6)
        Assert.AreEqual(15, result.Count)
        Assert.AreNotEqual(New Tuple(Of Integer, Integer)(0, 2), result.ElementAt(1))
        For Each matchIndexPair In result
            Console.WriteLine(matchIndexPair)
        Next
    End Sub

End Class
