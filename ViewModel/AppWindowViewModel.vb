Imports System.ComponentModel
Imports POFF.Kicker.Model
Imports POFF.Kicker.ViewModel.Screens
Imports POFF.Kicker.ViewModel.Types

Public Class AppWindowViewModel
    Inherits ViewModelBase

    Public Shared Instance As AppWindowViewModel = New AppWindowViewModel()

    Private Sub New()
        TournamentValue = New Tournament()
        TeamsScreenValue = New TeamsScreenViewModel(TournamentValue)
    End Sub

    Public Shared Function DI(Of T As ViewModelBase)() As T
        If GetType(T) Is GetType(TeamsScreenViewModel) Then
            Return CType(Instance.TeamsScreen, ViewModelBase)
        End If

        Throw New ArgumentOutOfRangeException("type", "Unexpected type")
    End Function

    Public ReadOnly Property Teams() As BindingList(Of Team)
        Get
            Return TeamsScreen.Teams
        End Get
    End Property

    Private TournamentValue As Tournament
    Public ReadOnly Property Tournament As Tournament
        Get
            Return TournamentValue
        End Get
    End Property

    Private TabIndexValue As Integer
    Public Property TabIndex() As Integer
        Get
            Return TabIndexValue
        End Get
        Set(value As Integer)
            If value = TabIndexValue Then Return
            TabIndexValue = value
            OnPropertyChanged()
        End Set
    End Property

    Private ReadOnly TeamsScreenValue As TeamsScreenViewModel
    Public ReadOnly Property TeamsScreen As TeamsScreenViewModel
        Get
            Return TeamsScreenValue
        End Get
    End Property

    Public Sub AddTeam(team As TeamInfo)
        TeamsScreen.AddTeam(team.Team)
    End Sub

    Public Sub RemoveTeam(team As Team)
        TeamsScreen.RemoveTeam(team)
    End Sub

    Public Sub Save()
        Tournament.Save()
    End Sub

    Public Sub CopyToClipboard()
        Tournament.CopyStandingsHtmlToClipboard()
    End Sub

End Class
