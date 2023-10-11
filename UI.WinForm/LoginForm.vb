Imports Infra.Common
Imports Oracle.ManagedDataAccess.Client
Imports System.Configuration


Public Class LoginForm
    Inherits BaseFixedForm
    ''' <summary>
    ''' Esta clase hereda de la clase BaseFixedForm.
    ''' </summary>
    ''' 

#Region "-> Campos"
    Private usernamePlaceholder As String 'Marca de agua(Placeholder) para el cuadro de texto usuario.
    Private passwordPlaceholder As String 'Marca de agua(Placeholder) para el cuadro de texto contraseña.
    Private placeholderColor As Color 'Color del marca de agua(Placeholder).
    Private textColor As Color 'Color para el texto del cuadro texto.
#End Region

#Region "-> Constructor"
    Public Sub New()
        InitializeComponent()

        Me.MinimizeButton = True 'Mostrar boton de minimizar
        usernamePlaceholder = txtUsername.Text 'Establecer placeholder del cuadro de texto usuario.
        passwordPlaceholder = txtPassword.Text 'Establecer placeholder del cuadro de texto contraseña.
        placeholderColor = txtUsername.ForeColor 'Establecer color de placeholder.
        textColor = Color.LightGray 'Establecer color del cuadro de texto usuario y contraseña.
        lblDescription.Select() 'Seleccionar un control diferente, para que los cuadros de texto no se inicien enfocados.
    End Sub
#End Region

#Region "-> Métodos"
    Private Sub SetPlaceholder()
        'Establecer la marca de agua (Placeholder) al cuadro de texto usuario y contraseña,
        'Siempre en cuando el valor sea nulo o tiene espacios en blanco.

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then 'Usuario
            txtUsername.Text = usernamePlaceholder
            txtUsername.ForeColor = placeholderColor
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then 'Contraseña
            txtPassword.Text = passwordPlaceholder
            txtPassword.ForeColor = placeholderColor
            txtPassword.UseSystemPasswordChar = False 'Quitar el enmascaramiento de caracteres.
        End If
    End Sub

    Private Sub RemovePlaceHolder(textBox As TextBox, placeholderText As String)
        'Quitar la marca de agua (Placeholder) de un cuadro de texto.
        If textBox.Text = placeholderText Then
            textBox.Text = "" 'Quitar placeholder
            textBox.ForeColor = textColor 'Establecer color normal de texto
            If textBox Is txtPassword Then textBox.UseSystemPasswordChar = True 'Si el cuadro de texto es contraseña, enmascarar los caracteres.
        End If
    End Sub

    Private Sub Login()
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse txtUsername.Text = usernamePlaceholder Then
            ShowMessage("Ingrese nombre de usuario o correo electrónico")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) OrElse txtPassword.Text = passwordPlaceholder Then
            ShowMessage("Ingrese contraseña")
            Return
        End If

        ' Construye la cadena de conexión en tiempo de ejecución
        Dim baseConnectionString As String = ConfigurationManager.ConnectionStrings("OracleDbContext").ConnectionString
        Dim connectionString As String = String.Format("{0}USER ID={1};Password={2}", baseConnectionString, txtUsername.Text, txtPassword.Text)

        Try
            Using connection As New OracleConnection(connectionString)
                connection.Open() ' Intenta abrir la conexión
                MainForm.Show()
                Me.Hide()
            End Using
        Catch ex As Exception
            ShowMessage("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Logout()
        'Limpiar campos cuando se cierre sesión, este metodo se invoca en el metodo de evento MainForm_SessionClosed(..).
        Me.Show() 'Volver a mostrar el formulario login.
        txtUsername.Clear()
        txtPassword.Clear()
        SetPlaceholder()
        ActiveUser.Id = 0
        ActiveUser.Position = ""
        lblDescription.[Select]()
        lblErrorMessage.Visible = False
    End Sub

    Private Sub ShowMessage(message As String)
        lblErrorMessage.Text = "    " & message
        lblErrorMessage.Visible = True
    End Sub
#End Region

#Region "-> Métodos de Evento"
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login() 'Invocar el método Iniciar sesión.
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        'Invocar el método Iniciar sesión, si preciona enter en el cuadro de texto contraseña.
        If e.KeyCode = Keys.Enter Then Login()
    End Sub

    Private Sub MainForm_SessionClosed(sender As Object, e As FormClosedEventArgs)
        Logout() 'Invocar el método Cerrar sesión cuando en el formulario principal se haya cerrado sesión.
    End Sub

    Private Sub LoginForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'Dibujar la linea/subrayado del cuadro de texto contraseña.
        e.Graphics.DrawLine(New Pen(Color.Gray, 1), txtPassword.Location.X, txtPassword.Bottom + 5, txtPassword.Right, txtPassword.Bottom + 5)
        'Dibujar la linea/subrayado del cuadro de texto usuario.
        e.Graphics.DrawLine(New Pen(Color.Gray, 1), txtUsername.Location.X, txtUsername.Bottom + 5, txtUsername.Right, txtUsername.Bottom + 5)
        e.Graphics.DrawLine(New Pen(lblDescription.ForeColor, 1), lblDescription.Location.X, lblDescription.Top - 5, lblDescription.Right - 5, lblDescription.Top - 5)

    End Sub

    Private Sub txtUsername_Enter(sender As Object, e As EventArgs) Handles txtUsername.Enter
        'Quitar la marca de agua cuando el cursor ingrese en el cuadro de texto usuario.
        RemovePlaceHolder(txtUsername, usernamePlaceholder)
    End Sub

    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        'Establecer la marca de agua cuando el cursor deje el cuadro de texto usuario.
        SetPlaceholder()
    End Sub

    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        'Quitar la marca de agua cuando el cursor ingrese en el cuadro de texto contraseña.
        RemovePlaceHolder(txtPassword, passwordPlaceholder)
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        'Establecer la marca de agua cuando el cursor deje el cuadro de texto contraseña.
        SetPlaceholder()
    End Sub


    Private Sub lblForgotPass_Click(sender As Object, e As EventArgs) Handles lblForgotPass.Click
        'Recuperar contraseña.
        Dim frm = New FormRecoverPassword()
        frm.ShowDialog()
    End Sub
#End Region

#Region "-> Anulaciones"
    Protected Overrides Sub CloseForm()
        Application.Exit() 'Anular el metodo cerrar formulario y cerrar la aplicación.
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        'Anular los parámetros de creación de formularios
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.Style = param.Style Or &H20000  'Establece un cuadro de minimizar en el estilo de la ventana / Permitirá minimizar el formulario desde el icono de la barra de tareas.
            Return param
        End Get
    End Property

#End Region

    Private Sub btnLogin_Paint(sender As Object, e As PaintEventArgs) Handles btnLogin.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnLogin.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnLogin.Region = New Region(buttonPath)
    End Sub

    Private Sub pictureBox1_Click(sender As Object, e As EventArgs) Handles pictureBox1.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub label1_Click(sender As Object, e As EventArgs) Handles label1.Click

    End Sub

    Private Sub lblDescription_Click(sender As Object, e As EventArgs) Handles lblDescription.Click

    End Sub
End Class