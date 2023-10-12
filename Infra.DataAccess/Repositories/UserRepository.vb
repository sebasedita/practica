Imports System.Configuration
Imports System.Windows.Forms
Imports Oracle.ManagedDataAccess.Client

Public Class UserRepository
    Inherits MasterRepository
    Implements IUserRepository

    Public Function IGenericRepository_GetAll() As IEnumerable(Of User) Implements IGenericRepository(Of User).GetAll
        Dim users As New List(Of User)()

        Using connection As New OracleConnection(baseConnectionString)
            connection.Open()

            Using command As New OracleCommand("SELECT * FROM TIPO_ACCION", connection)
                Using reader As OracleDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim user As New User With {
                        .ID_TIPO_ACCION = reader.GetInt32(reader.GetOrdinal("ID_TIPO_ACCION")),
                        .TIPO_ACCION = reader.GetString(reader.GetOrdinal("TIPO_ACCION")),
                        .FECHA_CREACION_TIPO_ACCION = reader.GetDateTime(reader.GetOrdinal("FECHA_CREACION")),
                        .ACTIVO_TIPO_ACCION = reader.GetBoolean(reader.GetOrdinal("ACTIVO"))
                    }

                        users.Add(user)
                    End While
                End Using
            End Using
        End Using

        Return users
    End Function

    Public Function Login(username As String, password As String) As User Implements IUserRepository.Login
        Throw New NotImplementedException()
    End Function

    Public Function AddRange(users As List(Of User)) As Integer Implements IUserRepository.AddRange
        Throw New NotImplementedException()
    End Function

    Public Function RemoveRange(users As List(Of User)) As Integer Implements IUserRepository.RemoveRange
        Throw New NotImplementedException()
    End Function

    Public Function Add(entity As User) As Integer Implements IGenericRepository(Of User).Add
        Throw New NotImplementedException()
    End Function

    Public Function Edit(entity As User) As Integer Implements IGenericRepository(Of User).Edit
        Throw New NotImplementedException()
    End Function

    Public Function Remove(entity As User) As Integer Implements IGenericRepository(Of User).Remove
        Throw New NotImplementedException()
    End Function

    Public Function GetSingle(value As String) As User Implements IGenericRepository(Of User).GetSingle
        Throw New NotImplementedException()
    End Function

    Public Function GetByValue(value As String) As IEnumerable(Of User) Implements IGenericRepository(Of User).GetByValue
        Throw New NotImplementedException()
    End Function

    Private ReadOnly Property baseConnectionString As String
        Get
            Return ConfigurationManager.ConnectionStrings("OracleDbContext").ConnectionString
        End Get
    End Property
End Class






