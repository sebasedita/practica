Imports System.Runtime.InteropServices

Public Class DragControl

#Region "-> Campos"
    Private dragControl As Control
    Private targetForm As Form
#End Region

#Region "-> Constructor"
    Public Sub New(_dragControl As Control, _targetForm As Form)
        targetForm = _targetForm
        dragControl = _dragControl
        AddHandler dragControl.MouseDown, AddressOf Control_MouseDown
    End Sub
#End Region

#Region "-> Importar métodos externos"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
#End Region

#Region "-> Métodos de evento"
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        ReleaseCapture()
        SendMessage(targetForm.Handle, &H112, &HF012, 0)
    End Sub
#End Region

End Class
