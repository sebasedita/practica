Public Class BaseFixedForm
    Inherits Form
    ''' <summary>
    ''' Formulario prediseñado con barra de titulo, herede esta clase si desea 
    ''' crear formularios fijos (Sin cambio de tamaño).
    ''' </summary>
    ''' 

#Region "-> Campos"
    Private dragControl As DragControl 'Responsable de arrastrar el formualario.
    Private titleBar As Panel 'Barra de título del formulario.
    Private btnClose As Button 'Botón de cerrar del formulario.
    Private btnMinimize As Button 'Botón de minimizar el formulario.
    Private lblTitle As Label 'Título del formulario.
#End Region

#Region "-> Constructor"
    Public Sub New()
        titleBar = New Panel()
        dragControl = New DragControl(titleBar, Me)
        btnClose = New Button()
        btnMinimize = New Button()
        lblTitle = New Label()

        titleBar.Size = New System.Drawing.Size(300, 40)
        titleBar.BackColor = Color.FromArgb(113, 189, 68)
        titleBar.Dock = DockStyle.Top
        titleBar.Controls.Add(btnMinimize)
        titleBar.Controls.Add(btnClose)
        titleBar.Controls.Add(lblTitle)

        btnClose.Image = My.Resources.btnClose
        btnClose.Size = New System.Drawing.Size(40, 40)
        btnClose.Dock = DockStyle.Right
        btnClose.Text = ""
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        AddHandler btnClose.Click, AddressOf btnClose_Click

        btnMinimize.Image = My.Resources.btnMinimize
        btnMinimize.Size = New System.Drawing.Size(40, 40)
        btnMinimize.Dock = DockStyle.Right
        btnMinimize.Text = ""
        btnMinimize.FlatStyle = FlatStyle.Flat
        btnMinimize.FlatAppearance.BorderSize = 0
        btnMinimize.Visible = False
        AddHandler btnMinimize.Click, AddressOf btnMinimize_Click

        lblTitle.Text = "Fixed Form"
        lblTitle.ForeColor = Color.WhiteSmoke
        lblTitle.Font = New Font("Verdana", 11.0F, FontStyle.Regular)
        lblTitle.Location = New Point(10, 10)
        lblTitle.AutoSize = True

        Me.Controls.Add(titleBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ResizeRedraw = True
        Me.Padding = New Padding(1)
        Me.BackColor = Color.FromArgb(48, 63, 105)
    End Sub
#End Region

#Region "-> Propiedades"

    Protected Property TitleBarColor As Color
        Get
            Return titleBar.BackColor
        End Get
        Set(value As Color)
            titleBar.BackColor = value
        End Set
    End Property

    Protected Property MinimizeButton As Boolean
        Get
            Return btnMinimize.Visible
        End Get
        Set(value As Boolean)
            btnMinimize.Visible = value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            lblTitle.Text = value
        End Set
    End Property
#End Region

#Region "-> Métodos"
    Protected Overridable Sub CloseForm()
        Me.Close()
    End Sub
#End Region

#Region "-> Métodos de evento"
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        CloseForm()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.DrawRectangle(New Pen(Color.FromArgb(61, 81, 135), 1), 0, 0, Me.Width - 1, Me.Height - 1)
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseFixedForm))
        Me.SuspendLayout()
        '
        'BaseFixedForm
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BaseFixedForm"
        Me.ResumeLayout(False)

    End Sub
#End Region

End Class
