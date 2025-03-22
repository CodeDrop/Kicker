﻿Imports System.IO
Imports Fluid

Public Class Tournament

    Public Sub New()
        TeamManager = New TeamManager()
        MatchManager = New MatchManager()
        StandingManager = New StandingManager()
    End Sub

    Private ReadOnly StandingManager As StandingManager

    Public ReadOnly Property TeamManager() As TeamManager

    Public ReadOnly Property MatchManager() As MatchManager

    Public Sub Start(type As TournamentType)
        MatchManager.Generate(GetTeams(), type)
    End Sub

    Public Function TotalMatchCount() As Integer
        Return MatchManager.GetMatches().Count(Function(m) Not ContainsWithdrawnTeam(m))
    End Function

    Public Function PlayedMatchCount() As Integer
        Return MatchManager.GetMatches(MatchStatus.Finished).Length
    End Function

    Public ReadOnly Property GetTeams() As Team()
        Get
            Return TeamManager.GetTeams()
        End Get
    End Property

    Public Sub AddTeam(team As Team)
        TeamManager.AddTeam(team)
        MatchManager.Clear()
    End Sub

    Public Sub RemoveTeam(team As Team)
        If team Is Nothing Then Throw New ArgumentNullException("team")

        TeamManager.RemoveTeam(team)
        MatchManager.Clear()
    End Sub

    Public Sub Save()
        Database.Save(GetType(Team()), TeamManager.GetTeams())
        MatchManager.Save()
    End Sub

    Public Function GetStandings() As IEnumerable(Of Standing)
        Return StandingManager.GetStandings(MatchManager.GetMatches(MatchStatus.Finished))
    End Function

    Public Sub CopyStandingsHtmlToClipboard()
        Dim export = New HtmlExport(Me)
        My.Computer.Clipboard.SetText(export.ToString())
    End Sub

    Private Function ContainsWithdrawnTeam(match As Match) As Boolean
        Dim team1 = GetTeams().Single(Function(t) t.Equals(match.Team1))
        Dim team2 = GetTeams().Single(Function(t) t.Equals(match.Team2))
        Return team1.Withdrawn Or team2.Withdrawn
    End Function

    Public Sub Export()
        Dim exporter = New FluidTemplateExport(Me)
        My.Computer.Clipboard.SetText(If(exporter.ToString(), ""))
    End Sub

End Class
