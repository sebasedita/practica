Imports System.ComponentModel.DataAnnotations

Public Class DataValidation

    Private _instance As Object
    Private _errorMessage As String
    Private _isValid As Boolean

    Public Sub New(instance As Object)
        _instance = instance
        Validate()
    End Sub

    Public ReadOnly Property ErrorMessage As String
        Get
            Return _errorMessage
        End Get
    End Property

    Public ReadOnly Property Result As Boolean
        Get
            Return _isValid
        End Get
    End Property

    Private Sub Validate()
        Dim results As List(Of ValidationResult) = New List(Of ValidationResult)()
        Dim context As ValidationContext = New ValidationContext(_instance)
        _isValid = Validator.TryValidateObject(_instance, context, results, True)

        If _isValid = False Then
            _errorMessage = "Tiene algunos campos no válidos, realice las correcciones siguientes:" & vbLf & vbLf

            For Each item As ValidationResult In results
                _errorMessage += "     ■ " & item.ErrorMessage & vbLf
            Next
        End If
    End Sub
End Class
