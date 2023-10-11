Public Class FormRecoverPassword
    Inherits BaseFixedForm

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        lblMessage.Text = ""
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
      If String.IsNullOrWhiteSpace(txtUser.Text) = False Then
            Dim result = New Domain.Models.UserModel().RecoverPassword(txtUser.Text)

            If result IsNot Nothing Then
                lblMessage.Text = "Hola, " & result.FirstName & "," & vbLf &
                    "Se envió la recuperación de contraseña a su correo electrónico: " + result.Email & vbLf &
                    "Sin embargo, le pedimos que cambie su contraseña inmediatamente una vez ingrese a la aplicacíon."
                lblMessage.ForeColor = Color.DimGray
            Else
                lblMessage.Text = "Lo sentimos, no tiene una cuenta asociada con el correo electrónico o el nombre de usuario proporcionado."
                lblMessage.ForeColor = Color.IndianRed
            End If
        Else
            lblMessage.Text = "Por favor ingrese su nombre de usuario o email"
            lblMessage.ForeColor = Color.IndianRed
        End If
    End Sub
End Class