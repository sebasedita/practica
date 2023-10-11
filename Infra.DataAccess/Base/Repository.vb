Imports System.Configuration
Imports Oracle.ManagedDataAccess.Client

Public Class Repository
    Implements IDisposable

    Private connectionString As String
    Private MessageBox As Object

    Public Sub New(Optional user As String = Nothing, Optional pass As String = Nothing)
        If String.IsNullOrEmpty(user) Or String.IsNullOrEmpty(pass) Then
            connectionString = ConfigurationManager.ConnectionStrings("OracleDbContext").ConnectionString
        Else
            connectionString = "DATA SOURCE=10.1.0.98:1521/cliepuc;PERSIST SECURITY INFO=True;USER ID=" & user & ";PASSWORD=" & pass & ";"
        End If
    End Sub

    Public Function GetConnection() As OracleConnection
        MessageBox.Show(connectionString) ' Esto mostrará la cadena de conexión.
        Return New OracleConnection(connectionString)
    End Function


    Public Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub
End Class
