Module ExceptionManager

    Public Function GetMessage(exception As Exception) As String
        Dim sqlEx As System.Data.SqlClient.SqlException = TryCast(exception, System.Data.SqlClient.SqlException)

        If sqlEx IsNot Nothing AndAlso sqlEx.Number = 2627 Then
            Dim value As String = sqlEx.Message.Split("("c, ")"c)(1)
            Return "Registro duplicado, pruebe con otro." & vbLf & "El valor duplicado es:" & vbLf & "    ■ " & value
        Else
            Return "Se ha producido un error." & vbLf & "Detalles:" & vbLf & exception.Message
        End If
    End Function

End Module
