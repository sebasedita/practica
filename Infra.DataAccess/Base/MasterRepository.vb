Imports System.Data.Common
Imports Oracle.ManagedDataAccess.Client

Public Class MasterRepository
    Inherits Repository
    Implements IMasterRepository

    Private dataTable As DataTable ' Obtiene o establece la tabla de datos para las consultas.

    Public Sub New()
    End Sub

    Public Function GetOracleConnection() As OracleConnection
        Return GetConnection()
    End Function

    Public Function ExecuteNonQuery(commandText As String, parameter As OracleParameter, commandType As CommandType, connection As OracleConnection) As Integer Implements IMasterRepository.ExecuteNonQuery
        Using cmd As New OracleCommand(commandText, connection)
            cmd.CommandType = commandType
            cmd.Parameters.Add(parameter)
            connection.Open()
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    Public Function ExecuteNonQuery(commandText As String, parameter As DbParameter, commandType As CommandType) As Integer Implements IMasterRepository.ExecuteNonQuery
        Throw New NotImplementedException()
    End Function

    Public Function ExecuteNonQuery(commandText As String, parameters As List(Of DbParameter), commandType As CommandType) As Integer Implements IMasterRepository.ExecuteNonQuery
        Throw New NotImplementedException()
    End Function

    Public Function ExecuteNonQuery(commandText As String, parameter As OracleParameter, commandType As CommandType) As Integer Implements IMasterRepository.ExecuteNonQuery
        Throw New NotImplementedException()
    End Function

    Public Function ExecuteNonQuery(commandText As String, parameters As List(Of OracleParameter), commandType As CommandType) As Integer Implements IMasterRepository.ExecuteNonQuery
        Throw New NotImplementedException()
    End Function

    Public Function BulkExecuteNonQuery(transactions As List(Of BulkTransaction), commandType As CommandType) As Integer Implements IMasterRepository.BulkExecuteNonQuery
        Dim result As Integer = 0
        Using connection = GetConnection()
            connection.Open()
            Using OracleTransaction As OracleTransaction = connection.BeginTransaction()
                Using command = New OracleCommand()
                    command.Connection = connection
                    command.Transaction = OracleTransaction
                    command.CommandType = commandType
                    Try
                        For Each trans In transactions
                            command.CommandText = trans.CommandText
                            command.Parameters.AddRange(trans.Parameters.ToArray())
                            result += command.ExecuteNonQuery()
                            command.Parameters.Clear()
                        Next
                        OracleTransaction.Commit()
                    Catch ex As Exception
                        OracleTransaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Using
        Return result
    End Function

    Public Function ExecuteReader(commandText As String, commandType As CommandType) As DataTable Implements IMasterRepository.ExecuteReader
        dataTable = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New OracleCommand()
                command.Connection = connection
                command.CommandText = commandText
                command.CommandType = commandType
                Using reader = command.ExecuteReader()
                    dataTable.Load(reader)
                End Using
            End Using
        End Using
        Return dataTable
    End Function

    Public Function ExecuteReader(commandText As String, parameter As OracleParameter, commandType As CommandType) As DataTable Implements IMasterRepository.ExecuteReader
        dataTable = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New OracleCommand()
                command.Connection = connection
                command.CommandText = commandText
                command.CommandType = commandType
                command.Parameters.Add(parameter)
                Using reader = command.ExecuteReader()
                    dataTable.Load(reader)
                End Using
            End Using
        End Using
        Return dataTable
    End Function

    Public Function ExecuteReader(commandText As String, parameter As DbParameter, commandType As CommandType) As DataTable Implements IMasterRepository.ExecuteReader
        Throw New NotImplementedException()
    End Function

    Public Function ExecuteReader(commandText As String, parameters As List(Of DbParameter), commandType As CommandType) As DataTable Implements IMasterRepository.ExecuteReader
        Throw New NotImplementedException()
    End Function

    Public Function ExecuteReader(commandText As String, parameters As List(Of OracleParameter), commandType As CommandType) As DataTable Implements IMasterRepository.ExecuteReader
        Throw New NotImplementedException()
    End Function

    ' Implementa otros métodos aquí con la lógica real
End Class


