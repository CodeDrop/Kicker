Imports POFF.Kicker.Model

Public Class MatchInfo

    Public Sub New(match As Match)
        ' Check parameters
        If match Is Nothing Then Throw New ArgumentNullException("match")

        ' Initializes members
        MatchValue = match
        Team1NameValue = match.Team1.Name
        Team2NameValue = match.Team2.Name
        ResultSummaryValue = match.Result.ToString()
    End Sub

    Private ReadOnly MatchValue As Match
    Friend ReadOnly Property Match() As Match
        Get
            Return MatchValue
        End Get
    End Property

    Private ReadOnly Team1NameValue As String
    Public ReadOnly Property Team1Name() As String
        Get
            Return Team1NameValue
        End Get
    End Property

    Private ReadOnly Team2NameValue As String
    Public ReadOnly Property Team2Name() As String
        Get
            Return Team2NameValue
        End Get
    End Property

    Private ReadOnly ResultSummaryValue As String
    Public ReadOnly Property ResultSummary() As String
        Get
            Return ResultSummaryValue
        End Get
    End Property

End Class