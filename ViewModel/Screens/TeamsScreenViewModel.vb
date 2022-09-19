Imports System.ComponentModel
Imports POFF.Kicker.Model
Imports POFF.Kicker.ViewModel.Interfaces
Imports POFF.Kicker.ViewModel.Types

Namespace Screens

    Public Class TeamsScreenViewModel
        Inherits ViewModelBase

        Public Sub New(tournament As Tournament)
            ' Check parameters
            If tournament Is Nothing Then Throw New ArgumentNullException("tournament")

            ' Initialize members
            TournamentValue = tournament
            TeamsValue = New BindingList(Of Team)(New List(Of Team)(tournament.GetTeams())) With {.RaiseListChangedEvents = True}
            ConfirmationMessageHandlerValue = DefaultConfirmationMessageHandler.Empty
        End Sub

        Private ReadOnly TournamentValue As Tournament
        Public ReadOnly Property Tournament() As Tournament
            Get
                Return TournamentValue
            End Get
        End Property

        Private TeamsValue As BindingList(Of Team)
        Public ReadOnly Property Teams() As BindingList(Of Team)
            Get
                Return TeamsValue
            End Get
        End Property

        Private ConfirmationMessageHandlerValue As IConfirmationMessage
        Public Property ConfirmationMessageHandler() As IConfirmationMessage
            Get
                Return ConfirmationMessageHandlerValue
            End Get
            Set(value As IConfirmationMessage)
                If value Is Nothing Then Throw New ArgumentException("ConfirmationMessageHandler must not be null")
                ConfirmationMessageHandlerValue = value
            End Set
        End Property

        Public Sub AddTeam(team As Team)
            Tournament.AddTeam(team)
            Teams.Add(team)
        End Sub

        Public Sub RemoveTeam(team As Team)
            Dim message = String.Format("Der Spielplan und Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie die Mannschaft ""{1}"" entfernen.{0}{0}Wollen Sie die Manschaft entfernen?", vbCrLf, team.Name)
            If ConfirmationMessageHandler.Confirm(message) Then
                Tournament.RemoveTeam(team)
                Teams.Remove(team)
            End If
        End Sub


    End Class

End Namespace