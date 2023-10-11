Imports Oracle.ManagedDataAccess.Client

Public Class BulkTransaction
    ''' <summary>
    ''' Esta clase simplemente es responsable de almacenar un comando de texto y una lista de parámetros
    ''' para el comando de texto (Transact-SQL o Procedimiento almacenado) para realizar transacciones masivas.
    ''' Para mas detalles ver el método BulkExecuteNonQuery() de la clase MasterRepository.
    ''' </summary>

    Public Property CommandText As String ' Obtiene o establece un comando de texto.
    Public Property Parameters As List(Of OracleParameter) ' Obtiene o establece una colección de parámetros.

    Public Sub New()
        Parameters = New List(Of OracleParameter)() ' Inicializar la lista de parámetros.
    End Sub
End Class
