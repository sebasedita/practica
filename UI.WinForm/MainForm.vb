Imports Infra.Common
Imports System.Drawing.Drawing2D

Public Class MainForm
    Inherits BaseMainForm
    ''' <summary>
    ''' Esta clase hereda de clase BaseMainForm.
    ''' </summary>
    ''' 
#Region "-> Campos"
    Private dragControl As DragControl 'Permite arrastrar el formulario.
    Private connectedUser As UserViewModel 'Obtiene o establece el usuario conectado.
    Private listChildForms As List(Of Form) 'Obtiene o establece los formularios secundarios abiertos en el panel escritorio del formualario.
    Private activeChildForm As Form 'Obtiene o establece el formulario secundario mostrado actualmente.
#End Region

#Region "-> Constructores"
    Public Sub New()
        'Utilice este contructor si no deseas mostrar los datos del usuario conectado.
        InitializeComponent()
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

        dragControl = New DragControl(panelTitleBar, Me)
        listChildForms = New List(Of Form)()
        connectedUser = New UserViewModel()
        linkProfile.Visible = False
    End Sub

    Public Sub New(_connectedUser As UserViewModel)
        'Utilice este constructor en el inicio de sesión y envié un modelo de vista del usuario
        'para mostrar los datos del usuario en el menú lateral.
        InitializeComponent()
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

        dragControl = New DragControl(panelTitleBar, Me)
        listChildForms = New List(Of Form)()
        connectedUser = _connectedUser
    End Sub
#End Region

#Region "-> Métodos"
    Public Sub LoadUserData()
        'Cargar los datos del usuario conectado en el menú lateral.
        lblName.Text = connectedUser.FirstName
        lblLastName.Text = connectedUser.LastName
        lblPosition.Text = connectedUser.Position

        If connectedUser.Photo IsNot Nothing Then
            pictureBoxPhoto.Image = ItemConverter.BinaryToImage(connectedUser.Photo)
        Else
            pictureBoxPhoto.Image = My.Resources.DefaultUserProfile
        End If
    End Sub

    Private Sub ManagePermissions()
        'Administrar los permisos de usuario, esto es simplemente una demostración,
        'Puedes eliminarlo si no lo necesitas.
        Select Case ActiveUser.Position
            Case Positions.GeneralManager
            Case Positions.Accountant
                btnUsers.Enabled = False
                btnPacients.Enabled = False
                btnHistory.Enabled = False
                btnCalendar.Enabled = False
            Case Positions.AdministrativeAssistant
                btnReports.Enabled = False
            Case Positions.Receptionist
                btnReports.Enabled = False
                btnUsers.Enabled = False
            Case Positions.HMR
            Case Positions.MarketingGuru
            Case Positions.SystemAdministrator
        End Select
    End Sub

    'Este metodo es responsable de mostrar un formulario secundario en el panel escritorio del formulario principal.
    Private Sub OpenChildForm(Of childForm As Form)(_delegate As Func(Of childForm), senderMenuButton As Object)
        ' Método genérico con un parámetro de delegado genérico (Func <TResult>) donde el tipo de datos es Form.
        ' Este método PERMITE abrir formularios CON o SIN parámetros dentro del panel escritorio. En muchas ocasiones,
        ' en los tutoriales de youtube se utilizaron métodos similares a este. Sin embargo, simplemente permitía abrir formularios
        ' SIN parámetros (por ejemplo, <ver cref = "new MyForm ()" />)
        ' y fue imposible abrir un formulario CON parámetros( por ejemplo, <see cref="new MyForm (user:'John', mail:'john@gmail.com')"/>
        ' por lo que este método soluciona este defecto gracias al delegado genérico(Func <TResult>)  

        Dim menuButton As Button = CType(senderMenuButton, Button) 'Boton de donde se abre el formulario, puedes enviar un valor nulo, si no estas tratando de abrir un formulario desde un control diferente de los botones del menu lateral.
        Dim form As Form = listChildForms.OfType(Of childForm)().FirstOrDefault() 'Buscar si el formulario ya está instanciado o se ha mostrado anteriormente.
        If activeChildForm IsNot Nothing AndAlso form Is activeChildForm Then Return 'Si el formulario es igual al formulario  actual activo, retornar y no hacer nada.

        If form Is Nothing Then 'Si el formulario no existe, entonces crear la instancia y mostrarla en el panel escritorio.
            form = _delegate() 'Ejecutar al delegado 
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None 'Quitar el borde.
            form.TopLevel = False 'Indicar que el formulario no es de nivel superior
            form.Dock = DockStyle.Fill 'Establecer el estilo de muelle en lleno (Rellenar el panel escritorio)  
            listChildForms.Add(form) 'Agregar formulario secundario a la lista de formularios.

            If menuButton IsNot Nothing Then 'Si el boton de menu es diferente a nulo:
                ActivateButton(menuButton) 'Activar/Resaltar el boton.
                AddHandler form.FormClosed, Sub(s, e) DeactivateButton(menuButton) 'Cuando del formulario se cierre, desactivar el boton.
            End If

            btnChildFormClose.Visible = True 'Mostrar el boton de cerrar formulario secundario.
        End If

        CleanDesktop() 'Eliminar el formulario secundario actual del panel escritorio
        panelDesktop.Controls.Add(form) 'agregar formulario secundario al panel del escritorio
        panelDesktop.Tag = form 'Almacenar el formulario
        form.Show() 'Mostrar el formulario 
        form.BringToFront() 'Traer al frente
        form.Focus() 'Enfocar el formulario
        lblCaption.Text = form.Text 'Establecer el titulo del formulario.
        activeChildForm = form 'Establecer como formulario activo.

        '<Nota>
        ' Puede usar el delegado Func <TResult> con métodos anónimos o expresión lambda,
        ' por ejemplo, podemos llamar a este método de la siguiente manera: Supongamos que estamos en el método de evento clic de algún botón.
        ' Con método anónimo:
        '     <see cref="OpenChildForm( delegate () { return new MyForm('MyParameter'); });"/>    
        ' Con expresión lambda (Mi favorito)
        '     <see cref="OpenChildForm( () => new MyForm('id', 'username'));"/>
        '</Nota>
    End Sub

    Private Sub CloseChildForm()
        'Cerrar formulario secundario activo.
        If activeChildForm IsNot Nothing Then
            listChildForms.Remove(activeChildForm) 'Eliminar de la lista de formularios.
            panelDesktop.Controls.Remove(activeChildForm) 'Eliminar del panel escritorio.
            activeChildForm.Close() 'Cerrar el formulario.
            RefreshDesktop() 'Actualizar el escritorio (Mostrar el formulario anterior si es el caso, caso contrario restablecer el formulario principal)
        End If
    End Sub

    Private Sub CleanDesktop()
        'Limpiar el escritorio.
        If activeChildForm IsNot Nothing Then
            activeChildForm.Hide()
            panelDesktop.Controls.Remove(activeChildForm)
        End If
        ' Este método oculta y elimina el formulario secundario activo del panel escritorio,
        ' por lo que solo habrá un formulario secundario abierto dentro del panel del escritorio,
        ' ya que agregar un formulario nuevo elimina el formulario anterior y agrega el nuevo
        ' formulario (Revise el método OpenChildForm).
        ' Los formularios secundarios inactivos se almacenan en una lista genérica.
        '
        ' Creé estos métodos para deshacerme de las dudas ya que muchos piensan (incluido yo mismo) que
        ' tener 20 o 50 formularios agregados dentro del panel escritorio afecta el rendimiento,
        ' bueno, no me di cuenta de eso. De hecho, es posible agregar 10 mil controles dinámicamente
        ' en una formulario mostrada y no hay límite si se agrega desde el constructor del formulario, 
        ' para experimentar, agregué 100 mil etiquetas y 10 mil paneles con color aunque tardó más
        ' de 10 minutos en mostrar (pc : 8 ram, cpu SixCore 3,50 GHz)
        'y no hay ningún problema de rendimiento (consumió 20mb ram) y desplazarse por el formulario funciona bien.
        '
        ' Por lo tanto, si estos métodos parecen muy tediosos o difíciles de entender, puede utilizar 
        ' los métodos para abrir un formulario secundario dentro del panel de Proyectos 
        ' anteriores (tutoriales) que se muestran en YouTube, donde los formularios secundarios
        ' se almacenan dentro del Panel escritorio, se superponen uno tras otro y se muestra uno (form.bringtofront ();).
        '
        ' Sin embargo, todavía no me parece apropiado agregar tantos formularios dentro de un panel 
        ' considerando que un formulario predeterminado es de nivel superior y no me gusta la idea
        ' de tener tantos controles en un panel (controles de formulario secundario ).
        '
        ' Como resultado, preferí almacenar los formularios secundarios en una lista genérica y 
        ' agregar y mostrar solo un formulario en el panel escritorio :) */
    End Sub

    Private Sub RefreshDesktop()
        'Este método es responsable  de actualizar el formulario principal con los parametros adecuados,
        'ya sea restablecer los valores pretederminados o mostrar un formulario secundario anterior si es el caso.
        Dim childForm = listChildForms.LastOrDefault() 'Verificar y obtener el último formulario secundario (anterior) en la lista de formularios

        If childForm IsNot Nothing Then 'si hay un formulario secundario instanciado en la lista, agregarlo de nuevo al panel escritorio.
            activeChildForm = childForm
            panelDesktop.Controls.Add(childForm)
            panelDesktop.Tag = childForm
            childForm.Show()
            childForm.BringToFront()
            lblCaption.Text = childForm.Text
        Else 'Si no hay ningún resultado, no hay ninguna instancia en la lista de formularios secundarios.
            ResetDefaults() 'Restablecer el formulario principal a los valores predeterminados
        End If
    End Sub

    Private Sub ResetDefaults()
        activeChildForm = Nothing
        lblCaption.Text = "   Home"
        btnChildFormClose.Visible = False
    End Sub

    Private Sub ActivateButton(menuButton As Button)
        menuButton.ForeColor = Color.MediumSlateBlue
        'menuButton.BackColor = panelMenuHeader.BackColor;
    End Sub

    Private Sub DeactivateButton(menuButton As Button)
        menuButton.ForeColor = Color.SlateGray
        'menuButton.BackColor = panelSideMenu.BackColor;
    End Sub
#End Region

#Region "->  Métodos de Evento"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserData()
        ManagePermissions()
        ResetDefaults()
    End Sub

#Region "- Cerrar sesión, Cerrar aplicación, minimizar y maximizar."

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("¿Está seguro de cerrar sesión?", "Mensaje",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close() 'Cierra el formulario
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.CloseApp() 'Cierra la aplicación.
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        Me.MaximizeRestore()

        If Me.WindowState = FormWindowState.Maximized Then
            btnMaximize.Image = My.Resources.btnRestore
        Else
            btnMaximize.Image = My.Resources.btnMaximize
        End If
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.Minimize()
    End Sub

    Private Sub btnChildFormClose_Click(sender As Object, e As EventArgs) Handles btnChildFormClose.Click
        CloseChildForm()
    End Sub
#End Region

#Region "- Convertir foto de perfil a circular"

    Private Sub pictureBoxPhoto_Paint(sender As Object, e As PaintEventArgs) Handles pictureBoxPhoto.Paint
        Using graphicsPath As GraphicsPath = New GraphicsPath()
            Dim rectangle = New Rectangle(0, 0, pictureBoxPhoto.Width - 1, pictureBoxPhoto.Height - 1)
            graphicsPath.AddEllipse(rectangle)
            pictureBoxPhoto.Region = New Region(graphicsPath)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            Dim pen = New Pen(New SolidBrush(pictureBoxPhoto.BackColor), 1)
            e.Graphics.DrawEllipse(pen, rectangle)
        End Using
    End Sub
#End Region

#Region "- Contraer o Expandir menú lateral"

    Private Sub btnSideMenu_Click(sender As Object, e As EventArgs) Handles btnSideMenu.Click
        If panelSideMenu.Width > 100 Then
            panelSideMenu.Width = 52

            For Each control As Control In panelMenuHeader.Controls
                If control IsNot btnSideMenu Then control.Visible = False
            Next
        Else
            panelSideMenu.Width = 230

            For Each control As Control In panelMenuHeader.Controls
                control.Visible = True
            Next
        End If
    End Sub
#End Region

#Region "- Abrir formularios secundarios"

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        OpenChildForm(Function() New FormUsers(), sender)
        '()=> :Llamar el delegado genérico - instanciar un formulario sin parametros.
        'sender: Botón users.
    End Sub

    Private Sub btnPacients_Click(sender As Object, e As EventArgs) Handles btnPacients.Click
        OpenChildForm(Function() New FormPacients(), sender)
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        OpenChildForm(Function() New FormHistory(), sender)
    End Sub

    Private Sub btnCalendar_Click(sender As Object, e As EventArgs) Handles btnCalendar.Click
        OpenChildForm(Function() New FormCalendar(), sender)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        OpenChildForm(Function() New FormReports(), sender)
    End Sub

    Private Sub linkProfile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkProfile.LinkClicked
        'Si el control no es boton del menu lateral enviar NULL como parámetro.
        OpenChildForm(Function() New FormUserProfile(connectedUser, Me), Nothing)
        '()=> :Llamar el delegado genérico - instanciar un formulario con parametro modelo de vista del usuario.
        'sender: NULL, porque no es un boton.
    End Sub

    Private Sub panelDesktop_Paint(sender As Object, e As PaintEventArgs) Handles panelDesktop.Paint

    End Sub

    Private Sub panelSideMenu_Paint(sender As Object, e As PaintEventArgs) Handles panelSideMenu.Paint

    End Sub

    Private Sub label1_Click(sender As Object, e As EventArgs) Handles label1.Click

    End Sub

    Private Sub label2_Click(sender As Object, e As EventArgs) Handles label2.Click

    End Sub

    Private Sub label3_Click(sender As Object, e As EventArgs) Handles label3.Click

    End Sub
#End Region

#End Region

End Class