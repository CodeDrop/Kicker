<TestClass>
Public Class GeneticMatchGeneratorTests

    <TestMethod>
    Public Sub Generate2Test()
        Dim sut = New GeneticMatchGenerator(2)
        Dim result = sut.Generate()
        Assert.AreEqual(1, result.Count)
    End Sub

    <TestMethod>
    Public Sub Generate3Test()
        Dim sut = New GeneticMatchGenerator(3)
        Dim result = sut.Generate()
        Assert.AreEqual(3, result.Count)
    End Sub

    <TestMethod>
    Public Sub Generate5Test()
        Dim sut = New GeneticMatchGenerator(5)
        Dim result = sut.Generate()
        Assert.AreEqual(10, result.Count)
    End Sub

End Class
