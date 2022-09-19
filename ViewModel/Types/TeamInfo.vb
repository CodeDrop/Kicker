Imports POFF.Kicker.Model
Imports System.ComponentModel

Namespace Types

    Public Class TeamInfo
        Inherits NotificationObject
        Implements IChangeTracking

        Public Sub New()
            MyClass.New(New Team() With {.Name = "New Team"})
        End Sub

        Public Sub New(team As Team)
            ' Check parameters
            If team Is Nothing Then Throw New ArgumentNullException("team")

            ' Initialize members
            TeamValue = team
            Current.Name = team.Name
            Current.Player1 = team.Player1
            Current.Player2 = team.Player2
        End Sub

        Private Current As Data

        Private Structure Data
            Public Name As String
            Public Player1 As String
            Public Player2 As String
        End Structure

        Private ReadOnly TeamValue As Team
        Friend ReadOnly Property Team() As Team
            Get
                Return TeamValue
            End Get
        End Property

        Public Property Name() As String
            Get
                Return Current.Name
            End Get
            Set(value As String)
                If value = Current.Name Then Return
                Current.Name = value
                OnPropertyChanged()
            End Set
        End Property

        Public Property Player1() As String
            Get
                Return Current.Player1
            End Get
            Set(value As String)
                If value = Current.Player1 Then Return
                Current.Player1 = value
                OnPropertyChanged()
            End Set
        End Property

        Private Player2Value As String
        Public Property Player2() As String
            Get
                Return Current.Player2
            End Get
            Set(value As String)
                If value = Current.Player2 Then Return
                Current.Player2 = value
                OnPropertyChanged()
            End Set
        End Property

        Protected Overrides Sub OnPropertyChanged(Optional propertyName As String = "")
            IsChangedValue = True
            MyBase.OnPropertyChanged(propertyName)
        End Sub

        Public Sub AcceptChanges() Implements IChangeTracking.AcceptChanges
            Team.Name = Current.Name
            Team.Player1 = Current.Player1
            Team.Player2 = Current.Player2
        End Sub

        Private IsChangedValue As Boolean
        Public ReadOnly Property IsChanged As Boolean Implements IChangeTracking.IsChanged
            Get
                Return IsChangedValue
            End Get
        End Property

    End Class

End Namespace