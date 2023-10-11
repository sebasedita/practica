Imports System.Drawing.Drawing2D

Public Class BaseMainForm
    Inherits Form
    ''' <summary>
    ''' Esta clase hereda de la clase Form de la librería de windows form.
    ''' Esta clase es responsable de implementar el método de redimencionamiento
    ''' (Cambiar de tamaño el formualario desde la esquina inferior derecha), Minimizar, 
    ''' Cerrar, Maximizar y restaurar.
    ''' </summary>

#Region "-> Campos"
    Private tolerance As Integer = 12 'Tolerancia para el redimencionamiento.
    Private Const WM_NCHITTEST As Integer = 132 'Win32, Notificación de entrada del mouse: determina qué parte de la ventana corresponde a un punto, permite cambiar el tamaño del formulario.        
    Private Const WS_MINIMIZEBOX As Integer = &H20000 'Métodos nativos: representa un estilo de ventana que tiene un botón de minimizar
    Private Const HTBOTTOMRIGHT As Integer = 17 'Esquina inferior derecha del borde de una ventana, permite cambiar el tamaño en diagonal hacia la derecha.
    Private sizeGripRectangle As Rectangle 'Control de tamaño en la esquina inferior derecha de una ventana.
    Protected PanelClientArea As Panel 'Area de cliente del formulario.
#End Region

#Region "-> Constructor"
    Public Sub New()
        Me.Padding = New Padding(1)
        PanelClientArea = New Panel With {
            .BackColor = Color.WhiteSmoke,
            .Dock = DockStyle.Fill
        }
        Me.Controls.Add(PanelClientArea)
    End Sub
#End Region

#Region "-> Métodos anulados"
    Protected Overrides Sub WndProc(ByRef m As Message)
        ''Función WindowProc: anulación del procesamiento de mensajes de Windows / nivel de sistema operativo
        Select Case (m.Msg)
            Case WM_NCHITTEST   'Si el mensaje de Windows es WM_NCHITTEST
                MyBase.WndProc(m)
                If (Me.WindowState = FormWindowState.Normal) Then 'Cambiar el tamaño del formulario si está en estado normal.
                    Dim pos As Point = New Point((m.LParam.ToInt32 And 65535), (m.LParam.ToInt32 + 16))
                    pos = Me.PointToClient(pos)

                    If ((pos.X >= (Me.ClientSize.Width - tolerance)) AndAlso (pos.Y >= (Me.ClientSize.Height - tolerance))) Then
                        m.Result = New IntPtr(HTBOTTOMRIGHT) 'Cambiar el tamaño en diagonal hacia la derecha.
                        Return
                    End If
                End If
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        'Este evento ocurre cuando el formualario cambia de tamaño.
        MyBase.OnSizeChanged(e)
        'Crear una region con el tamaño del formulario.
        Dim region = New Region(New Rectangle(0, 0, Me.ClientRectangle.Width, Me.ClientRectangle.Height))
        'Crear nuevo rectángulo para el control de tamaño con las dimensiones del formulario menos el valor de la tolerencia(Coordenada) y de tamaño de la tolerancia (12px).
        sizeGripRectangle = New Rectangle(Me.ClientRectangle.Width - tolerance, Me.ClientRectangle.Height - tolerance, tolerance, tolerance)
        region.Exclude(sizeGripRectangle) 'Excluir una porcion de la región para el control de tamaño.
        Me.PanelClientArea.Region = region 'Establecer la region creada.
        Me.Invalidate() 'Redibujar el formulario.
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        'Este evento ocurre cuando se dibuja o redibuja el formulario.
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim blueBrush As SolidBrush = New SolidBrush(Color.FromArgb(48, 63, 105))
        e.Graphics.FillRectangle(blueBrush, sizeGripRectangle) 'Dibujar un rectangulo relleno en las coordenadas del control de tamaño.
        ControlPaint.DrawSizeGrip(e.Graphics, Color.MediumSlateBlue, sizeGripRectangle) 'Dibujar el control de tamaño(lineas diagonales)
        e.Graphics.DrawRectangle(New Pen(Color.MediumSlateBlue), 0, 0, Me.Width - 1, Me.Height - 1) 'Dibujar el borde del formulario.
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        'Anular los parámetros de creación de formularios
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.Style = param.Style Or WS_MINIMIZEBOX 'Establece un cuadro de minimizar en el estilo de la ventana / Permitirá minimizar el formulario desde el icono de la barra de tareas.
            Return param
        End Get
    End Property
#End Region

#Region "-> Métodos"

    Protected Sub Minimize()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Protected Sub MaximizeRestore()
        If Me.WindowState = FormWindowState.Normal Then 'Maximizar el formulario
            'Al maximizar un formulario sin bordes, éste cubre toda la pantalla ocultando la barra de tareas,
            'para ello es necesario especificar un tamaño máximo:
            Me.MaximumSize = Screen.FromHandle(Me.Handle).WorkingArea.Size 'Establecer el tamaño del área del escritorio como el tamaño máximo del formulario.
            Me.WindowState = FormWindowState.Maximized
            Me.Padding = New Padding(0) 'Ocultar el borde.
        Else 'Restaurar el tamaño del formualario.
            Me.WindowState = FormWindowState.Normal
            Me.Padding = New Padding(1) 'Mostrar el borde.
        End If
    End Sub

    Protected Sub CloseApp()
        If MessageBox.Show("¿Está seguro de cerrar la aplicación?", "Mensaje",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Application.Exit() 'Cierra toda la aplicación finalizando todos los procesos.
        End If
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseMainForm))
        Me.SuspendLayout()
        '
        'BaseMainForm
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BaseMainForm"
        Me.ResumeLayout(False)

    End Sub
#End Region

End Class
