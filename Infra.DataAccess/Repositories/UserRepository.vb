Imports System.Windows.Forms
Imports Oracle.ManagedDataAccess.Client

Public Class UserRepository
    Inherits MasterRepository
    Implements IUserRepository

    Public Function Login(username As String, password As String) As User Implements IUserRepository.Login
        ' Intentamos establecer una conexión con las credenciales proporcionadas
        Try
            Using connection As New OracleConnection($"DATA SOURCE=10.1.0.98:1521/cliepuc;PERSIST SECURITY INFO=True;USER ID={username};PASSWORD={password};")
                connection.Open()
                ' Si la conexión es exitosa, retornamos un objeto User con la información básica
                Return New User() With {.Id = 0, .TipoUsuario = username}
            End Using
        Catch ex As OracleException
            ' Si hay un error al intentar conectar, mostramos un mensaje y retornamos Nothing
            MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
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

    Public Function GetAll() As IEnumerable(Of User) Implements IGenericRepository(Of User).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetByValue(value As String) As IEnumerable(Of User) Implements IGenericRepository(Of User).GetByValue
        Throw New NotImplementedException()
    End Function
End Class





