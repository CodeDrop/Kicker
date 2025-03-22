Imports System.IO
Imports System.Runtime.Remoting.Contexts
Imports System.Text
Imports Fluid

Public Class FluidTemplateExport
    Private ReadOnly Tournament As Tournament

    Public Sub New(tournament As Tournament)
        Me.Tournament = tournament
    End Sub

    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder(My.Resources.HtmlExportTemplate)

        Dim parser = New FluidParser()
        Dim source As String = File.ReadAllText("FluidTemplate.html")
        Dim model = New Object()

        Dim template As IFluidTemplate = Nothing
        Dim fluidError As String = Nothing

        If parser.TryParse(source, template, fluidError) Then
            Dim context = New TemplateContext(model)
            Return template.Render(context)
        Else
            Throw New ApplicationException(fluidError)
        End If

        Return String.Empty
    End Function

End Class
