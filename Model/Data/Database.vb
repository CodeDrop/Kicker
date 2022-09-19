Imports System.Xml.Serialization

Friend Class Database

    Public Shared Function Load(type As Type) As Object
        If Not IO.File.Exists(GetDataFileName(type)) Then Return Nothing

        Dim reader = New IO.StreamReader(GetDataFileName(type))

        Try
            Dim objectGenerator = New XmlSerializer(type)
            Return objectGenerator.Deserialize(reader)
        Finally
            reader.Close()
        End Try
    End Function

    Public Shared Sub Save(type As Type, data As Object)
        Dim writer = New IO.StreamWriter(GetDataFileName(type), False)

        Try
            Dim xmlGenerator = New XmlSerializer(type)
            xmlGenerator.Serialize(writer, data)
        Finally
            writer.Close()
        End Try
    End Sub

    Private Shared Function GetDataFileName(type As Type) As String
        Return String.Format(".\{0}.xml", type.Name)
    End Function

End Class
