Imports System.Data.Common
Imports Oracle.ManagedDataAccess.Client

Public Interface IMasterRepository
    ' Métodos para ejecutar comandos de Insertar, Actualizar y Eliminar.
    Function ExecuteNonQuery(commandText As String, parameter As DbParameter, commandType As CommandType) As Integer
    Function ExecuteNonQuery(commandText As String, parameters As List(Of DbParameter), commandType As CommandType) As Integer
    Function BulkExecuteNonQuery(transactions As List(Of BulkTransaction), commandType As CommandType) As Integer

    ' Métodos para ejecutar comandos de consulta (Seleccionar)
    Function ExecuteReader(commandText As String, commandType As CommandType) As DataTable
    Function ExecuteReader(commandText As String, parameter As DbParameter, commandType As CommandType) As DataTable
    Function ExecuteReader(commandText As String, parameters As List(Of DbParameter), commandType As CommandType) As DataTable
    Function ExecuteNonQuery(commandText As String, parameter As OracleParameter, commandType As CommandType) As Integer
    Function ExecuteNonQuery(commandText As String, parameters As List(Of OracleParameter), commandType As CommandType) As Integer
    Function ExecuteReader(commandText As String, parameter As OracleParameter, commandType As CommandType) As DataTable
    Function ExecuteReader(commandText As String, parameters As List(Of OracleParameter), commandType As CommandType) As DataTable
    Function ExecuteNonQuery(commandText As String, parameter As OracleParameter, commandType As CommandType, connection As OracleConnection) As Integer
End Interface

