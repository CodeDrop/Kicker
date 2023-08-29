<TestClass>
Public Class MatchIndexPairTests


    <TestMethod>
    Public Sub ContainsTeam1OfTest()
        Dim m1 = New MatchIndexPair(1, 2)
        Dim m2 = New MatchIndexPair(1, 3)
        Assert.IsTrue(m1.ContainsTeamOf(m2))
    End Sub

    <TestMethod>
    Public Sub ContainsTeam2OfTest()
        Dim m1 = New MatchIndexPair(1, 2)
        Dim m2 = New MatchIndexPair(5, 2)
        Assert.IsTrue(m1.ContainsTeamOf(m2))
    End Sub

    <TestMethod>
    Public Sub ContainsNoTeamOfTest()
        Dim m1 = New MatchIndexPair(1, 2)
        Dim m2 = New MatchIndexPair(3, 4)
        Assert.IsFalse(m1.ContainsTeamOf(m2))
    End Sub

    <TestMethod>
    Public Sub EqualsSameTest()
        Dim m1 = New MatchIndexPair(1, 2)
        Assert.AreEqual(m1, m1)
    End Sub

    <TestMethod>
    Public Sub EqualsDuplicateTest()
        Dim m1 = New MatchIndexPair(1, 2)
        Dim m2 = New MatchIndexPair(1, 2)
        Assert.AreEqual(m1, m2)
    End Sub

    <TestMethod>
    Public Sub EqualsReverseTest()
        Dim m1 = New MatchIndexPair(1, 2)
        Dim m2 = New MatchIndexPair(2, 1)
        Assert.AreEqual(m1, m2)
    End Sub


End Class
