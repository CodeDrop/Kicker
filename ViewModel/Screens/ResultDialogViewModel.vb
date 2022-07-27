Imports System.ComponentModel
Imports POFF.Kicker.ViewModel.Types
Imports POFF.Kicker.Model

Namespace Screens

    Public Class ResultDialogViewModel

        Public Sub New(ByVal match As Match)
            If match Is Nothing Then Throw New ArgumentNullException("match")

            Team1Value = match.Team1.Name
            Team2Value = match.Team2.Name

            SetResultInputsValue = New BindingList(Of SetResultInput)

            For Each setResult In match.Result.SetResults
                SetResultInputsValue.Add(New SetResultInput(setResult))
            Next setResult

            ResultValue = New Result
        End Sub

        Private ReadOnly Team1Value As String
        Public ReadOnly Property Team1 As String
            Get
                Return Team1Value
            End Get
        End Property

        Private ReadOnly Team2Value As String
        Public ReadOnly Property Team2 As String
            Get
                Return Team2Value
            End Get
        End Property

        Private ReadOnly SetResultInputsValue As BindingList(Of SetResultInput)
        Public ReadOnly Property SetResultInputs() As BindingList(Of SetResultInput)
            Get
                Return SetResultInputsValue
            End Get
        End Property

        Private ReadOnly ResultValue As Result
        Public ReadOnly Property Result As Result
            Get
                Return ResultValue
            End Get
        End Property

        Public Sub FillResult()
            Result.Clear()
            For Each setResultInput In SetResultInputs
                If setResultInput.Home.HasValue And setResultInput.Guest.HasValue Then
                    Result.AddSetResult(New SetResult() With {.Home = setResultInput.Home, .Guest = setResultInput.Guest})
                End If
            Next setResultInput
        End Sub

    End Class

End Namespace