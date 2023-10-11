Imports Infra.Common
Imports Domain.Models
Imports System.ComponentModel

Public Class FormUserMaintenance
    Inherits BaseFixedForm
    ''' <summary>
    ''' Esta clase hereda de la clase BaseFixedForm.
    ''' </summary>

#Region "-> Campos"

    Private domainModel As IUserModel 'Interfaz del modelo de dominio Usuario.
    Private userCollection As BindingList(Of UserViewModel) 'Colección de usuarios para la inserción masiva.
    Private userViewModel As UserViewModel 'Modelo de vista del usuario.
    Private transaction As TransactionAction 'Acción de transacción para la persistencia.
    Private listOperation As TransactionAction = TransactionAction.Add 'Acción de transacción para la colección de usuarios.
    Private defaultPhoto As Image = My.Resources.DefaultUserProfile 'Foto predeterminada para usuarios que no tienen una foto agregada.
    Private _lastRecord As String = "" 'Campo para almacenar el ultimo dato insertado o editado. Esto permitirá seleccionar y visualizar los cambios en el datagridview del formulario Users.
#End Region

#Region "-> Propiedades"

    Public Property LastRecord As String
        'Propiedad para almacenar el ultimo dato insertado o editado.
        'Esto permitirá seleccionar y visualizar los cambios en el datagridview del formulario Users.
        Get
            Return _lastRecord
        End Get
        Set(value As String)
            _lastRecord = value
        End Set
    End Property
#End Region

#Region "-> Constructor"

    Public Sub New(_userViewModel As UserViewModel, _transaction As TransactionAction)
        InitializeComponent()

        'Inicializar campos
        domainModel = New UserModel()
        userCollection = New BindingList(Of UserViewModel)()
        userViewModel = _userViewModel
        transaction = _transaction

        'Inicializar propiedades de control
        rbSingleInsert.Checked = True
        cmbPosition.DataSource = Positions.GetPositions()
        dataGridView1.DataSource = userCollection
        FillFields(_userViewModel)
        InitializeTransactionUI()
        InitializeDataGridView()
    End Sub
#End Region

#Region "-> Métodos"

    Private Sub InitializeTransactionUI()
        'Este método es responsable de establecer las propiedades de apariencia según la acción de la transacción.
        Select Case transaction
            Case TransactionAction.View
                _lastRecord = Nothing
                Me.TitleBarColor = Color.PaleVioletRed
                lblMaintenanceTitle.Text = "Detalles de usuario"
                lblMaintenanceTitle.ForeColor = Color.PaleVioletRed
                btnSave.Visible = False
                panelAddedControl.Visible = False
                lblCurrentPass.Visible = False
                txtCurrentPass.Visible = False
                lblConfirmPass.Visible = False
                txtConfirmPass.Visible = False
                btnCancel.Text = "X  Cerrar"
                btnCancel.Location = New Point(300, 310)
                btnCancel.BackColor = Color.PaleVioletRed
                ReadOnlyFields()

            Case TransactionAction.Add
                Me.TitleBarColor = Color.FromArgb(33, 169, 128)
                lblMaintenanceTitle.Text = "Agregar usuario"
                lblMaintenanceTitle.ForeColor = Color.FromArgb(33, 169, 128)
                btnSave.BackColor = Color.FromArgb(33, 169, 128)
                cmbPosition.SelectedIndex = -1
                lblCurrentPass.Visible = False
                txtCurrentPass.Visible = False

            Case TransactionAction.Edit
                Me.TitleBarColor = Color.CornflowerBlue
                lblMaintenanceTitle.Text = "Editar usuario"
                lblMaintenanceTitle.ForeColor = Color.CornflowerBlue
                btnSave.BackColor = Color.CornflowerBlue
                panelAddedControl.Visible = False
                lblCurrentPass.Visible = False
                txtCurrentPass.Visible = False

            Case TransactionAction.Remove
                Me.TitleBarColor = Color.FromArgb(236, 83, 104)
                lblMaintenanceTitle.Text = "Eliminar usuario"
                lblMaintenanceTitle.ForeColor = Color.FromArgb(236, 83, 104)
                btnSave.Text = "Eliminar"
                btnSave.BackColor = Color.FromArgb(236, 83, 104)
                panelAddedControl.Visible = False
                lblCurrentPass.Visible = False
                txtCurrentPass.Visible = False
                ReadOnlyFields()

            Case TransactionAction.Special
                Me.TitleBarColor = Color.CornflowerBlue
                lblMaintenanceTitle.Text = "Actualizar mi perfil de usuario"
                lblMaintenanceTitle.ForeColor = Color.CornflowerBlue
                btnSave.BackColor = Color.CornflowerBlue
                panelAddedControl.Visible = False
                lblPassword.Text = "Contraseña nueva"
                Label6.Visible = False
                cmbPosition.Visible = False
        End Select
    End Sub

    Private Sub InitializeDataGridView()
        'Este método es responsable de agregar columnas de editar y eliminar usuarios
        'de la colección de usuarios de la opción inserción masiva.
        Dim EditColumn As DataGridViewImageColumn = New DataGridViewImageColumn()
        Dim DeleteColumn As DataGridViewImageColumn = New DataGridViewImageColumn()

        EditColumn.Image = My.Resources.editIcon
        EditColumn.Name = "EditColumn"
        EditColumn.HeaderText = " "

        DeleteColumn.Image = My.Resources.deleteIcon
        DeleteColumn.Name = "DeleteColumn"
        DeleteColumn.HeaderText = " "

        Me.dataGridView1.Columns.Add(EditColumn)
        Me.dataGridView1.Columns.Add(DeleteColumn)

        dataGridView1.Columns("EditColumn").Width = 25
        dataGridView1.Columns("DeleteColumn").Width = 25
        dataGridView1.Columns(0).Width = 40
        dataGridView1.Columns(1).Width = 100
    End Sub

    Private Sub PersistSingleRow()
        'Método para persistir una sola fila en la base de datos.
        Try
            Dim userObject = FillViewModel() 'Obtener modelo de vista.
            Dim validateData = New DataValidation(userObject) 'Validar campos del objeto.
            Dim validatePassword = txtPassword.Text = txtConfirmPass.Text 'Validar contraseña.

            If validateData.Result = True AndAlso validatePassword = True Then 'Si el objeto es válido.
                Dim userModel = userViewModel.MapUserModel(userObject) 'Mapear el modelo de vista a modelo de dominio.

                Select Case transaction
                    Case TransactionAction.Add 'Agregar usuario.
                        AddUser(userModel)
                    Case TransactionAction.Edit 'Editar usuario.
                        EditUser(userModel)
                    Case TransactionAction.Remove 'Eliminar usuario.
                        RemoveUser(userModel)
                    Case TransactionAction.Special 'Actualizar perfil de usuario.

                        If String.IsNullOrWhiteSpace(txtCurrentPass.Text) = False Then

                            If txtCurrentPass.Text = userViewModel.Password Then
                                EditUser(userModel)
                            Else
                                MessageBox.Show("Tu contraseña actual es incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Else
                            MessageBox.Show("Por favor ingrese su contraseña actual", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                End Select

            Else 'Si los campos no son válidos
                If validateData.Result = False Then
                    MessageBox.Show(validateData.ErrorMessage, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("Las contraseñas no coinciden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

        Catch ex As Exception
            _lastRecord = Nothing 'Establecer nulo como ultimo registro.
            Dim message = ExceptionManager.GetMessage(ex) 'Obtener mensaje de excepción.
            MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Mostrar mensaje.
        End Try
    End Sub

    Private Sub PersistMultipleRows()
        'Método para persistir varias filas en la base de datos (Inserción masiva).
        Try
            If userCollection.Count > 0 Then 'Validar si hay datos a insertar.
                Dim userModelList = userViewModel.MapUserModel(userCollection.ToList()) 'Mapear la colección de usuarios a colección de modelos de dominio.
                Select Case transaction
                    Case TransactionAction.Add
                        AddUserRange(userModelList) 'Agregar colección de usuarios.
                End Select
            Else
                MessageBox.Show("No hay datos, por favor agregue datos en la tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            _lastRecord = Nothing
            Dim message = ExceptionManager.GetMessage(ex)
            MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddUser(userModel As UserModel)

        Dim result = domainModel.Add(userModel)
        If result > 0 Then
            _lastRecord = userModel.Username 'Establecer el ultimo registro.
            MessageBox.Show("Usuario agregado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            _lastRecord = Nothing
            MessageBox.Show("No se realizó la operación, intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub AddUserRange(userModelList As List(Of UserModel))
        Dim result = domainModel.AddRange(userModelList)

        If result > 0 Then
            _lastRecord = userModelList(0).Username 'Establecer el ultimo registro.
            MessageBox.Show("se agregaron " & result.ToString() & " usuarios con éxito")
            Me.Close()
        Else
            _lastRecord = Nothing
            MessageBox.Show("No se realizó la operación, intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub EditUser(userModel As UserModel)
        Dim result = domainModel.Edit(userModel)

        If result > 0 Then
            _lastRecord = userModel.Username 'Establecer el ultimo registro.
            MessageBox.Show("Usuario actualizado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            _lastRecord = Nothing
            MessageBox.Show("No se realizó la operación, intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub RemoveUser(userModel As UserModel)
        Dim result = domainModel.Remove(userModel)

        If result > 0 Then
            _lastRecord = "" 'Establecer una cadena vacía como ultimo registro, ya que el usuario ya no existe, por lo tanto no es posible seleccionar y visualizar los cambios (Ver formulario Users).
            MessageBox.Show("Usuario eliminado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            _lastRecord = Nothing
            MessageBox.Show("No se realizó la operación, intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ModifyUserCollection()
        'Este método es responsable de agregar o modificar un usuario de la colección de usuarios para la insercion masiva.

        Dim userObject = FillViewModel()
        Dim validateData = New DataValidation(userObject) 'Validar objeto.
        Dim validatePassword = txtPassword.Text = txtConfirmPass.Text

        If validateData.Result = True AndAlso validatePassword = True Then

            Select Case listOperation
                Case TransactionAction.Add
                    Dim findUser = userCollection.FirstOrDefault(Function(user) user.Email = userObject.Email OrElse user.Username = userObject.Username)

                    If findUser Is Nothing Then
                        Dim lastUser = userCollection.LastOrDefault()

                        If lastUser Is Nothing Then
                            userObject.Id = 1
                        Else
                            userObject.Id = lastUser.Id + 1
                        End If

                        userCollection.Add(userObject)
                        ClearFields()
                    Else
                        MessageBox.Show("Dato duplicado." & vbLf & "Email o nombre de usuario ya se ha añadido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Case TransactionAction.Edit
                    Dim findObject = userCollection.SingleOrDefault(Function(user) user.Id = userViewModel.Id)
                    Dim index = userCollection.IndexOf(findObject)
                    userCollection(index) = userObject
                    userCollection.ResetBindings()
                    ClearFields()
            End Select
        Else

            If validateData.Result = False Then
                MessageBox.Show(validateData.ErrorMessage, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Las contraseñas no coinciden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub FillFields(userView As UserViewModel)
        'Cargar los datos del modelo de vista en los campos del formulario.
        txtUsername.Text = userView.Username
        txtPassword.Text = userView.Password
        txtConfirmPass.Text = userView.Password
        txtFirstName.Text = userView.FirstName
        txtLastName.Text = userView.LastName
        cmbPosition.Text = userView.Position
        txtEmail.Text = userView.Email
        If userView.Photo IsNot Nothing Then
            PictureBoxPhoto.Image = ItemConverter.BinaryToImage(userView.Photo)
        Else : PictureBoxPhoto.Image = defaultPhoto
        End If
    End Sub

    Private Function FillViewModel() As UserViewModel
        'LLenar y retornar los datos de los campos del formulario en un nuevo objeto.
        Dim userView = New UserViewModel With {
            .Id = userViewModel.Id,
            .Username = txtUsername.Text,
            .Password = txtPassword.Text,
            .FirstName = txtFirstName.Text,
            .LastName = txtLastName.Text,
            .Position = cmbPosition.Text,
            .Email = txtEmail.Text
        }

        If PictureBoxPhoto.Image Is defaultPhoto Then
            userView.Photo = Nothing
        Else
            userView.Photo = ItemConverter.ImageToBinary(PictureBoxPhoto.Image)
        End If

        Return userView
    End Function

    Private Sub ClearFields()
        'Limpiar los campos del formulario.
        txtUsername.Clear()
        txtPassword.Clear()
        txtConfirmPass.Clear()
        txtCurrentPass.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtEmail.Clear()
        PictureBoxPhoto.Image = defaultPhoto
        cmbPosition.SelectedIndex = -1
        listOperation = TransactionAction.Add
        btnAddUser.Text = "Agregar"
        btnAddUser.BackColor = Color.CornflowerBlue
    End Sub

    Private Sub ReadOnlyFields()
        'Convertir los campos del formulario en solo lectura.
        txtUsername.ReadOnly = True
        txtPassword.ReadOnly = True
        txtConfirmPass.ReadOnly = True
        txtCurrentPass.ReadOnly = True
        txtFirstName.ReadOnly = True
        txtLastName.ReadOnly = True
        txtEmail.ReadOnly = True
        btnAddPhoto.Enabled = False
        btnDeletePhoto.Enabled = False
        'cmbPosition.Enabled = False
    End Sub
#End Region

#Region "-> Métodos de evento"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Boton guardar cambios
        If rbSingleInsert.Checked Then 'Si el botón de radio está activado.
            PersistSingleRow() 'Ejecutar el método de persistir una sola fila.
        Else 'Caso contrario, ejecutar el método de persistir varias filas(Insercción masiva)
            PersistMultipleRows()
        End If
    End Sub

    Private Sub btnAddUserList_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        'Botón de agregar usuario a la colección de usuarios para la insercción masiva.
        ModifyUserCollection()
    End Sub

    Private Sub FormUserMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub rbSingleInsert_CheckedChanged(sender As Object, e As EventArgs) Handles rbSingleInsert.CheckedChanged

        If rbSingleInsert.Checked Then 'Cambiar la apariencia para la inserción única.
            panelMultiInsert.Visible = False
            btnCancel.Location = New Point(210, 310)
            btnSave.Location = New Point(386, 310)
            Me.Size = New Size(754, 370)
        Else 'Cambiar la apariencia para insercción masiva.
            panelMultiInsert.Visible = True
            btnCancel.Location = New Point(212, 654)
            btnSave.Location = New Point(388, 654)
            Me.Size = New Size(754, 715)
        End If
    End Sub

    Private Sub btnAddPhoto_Click(sender As Object, e As EventArgs) Handles btnAddPhoto.Click
        'Agregar una imagen al cuadro de imagen para la foto del usuario.
        Dim openFile As OpenFileDialog = New OpenFileDialog With {
            .Filter = "Images(.jpg,.png)|*.png;*.jpg"
        }

        If openFile.ShowDialog() = DialogResult.OK Then
            PictureBoxPhoto.Image = New Bitmap(openFile.FileName)
        End If
    End Sub

    Private Sub btnDeletePhoto_Click(sender As Object, e As EventArgs) Handles btnDeletePhoto.Click
        'Borrar foto del usuario
        PictureBoxPhoto.Image = defaultPhoto
    End Sub

    Private Sub dataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellMouseEnter
        'Cambiar el cursor si puntero del mouse entra en la columna de editar o eliminar.
        If e.ColumnIndex = dataGridView1.Columns("EditColumn").Index OrElse e.ColumnIndex = dataGridView1.Columns("DeleteColumn").Index Then
            dataGridView1.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub dataGridView1_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellMouseLeave
        'Cambiar el cursor si puntero del mouse sale de la columna de editar o eliminar.
        If e.ColumnIndex = dataGridView1.Columns("EditColumn").Index OrElse e.ColumnIndex = dataGridView1.Columns("DeleteColumn").Index Then
            dataGridView1.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub dataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellClick
        'Eliminar o editar un usuario de la colección de usuarios.

        If e.RowIndex = dataGridView1.NewRowIndex OrElse e.RowIndex < 0 Then Return

        If e.ColumnIndex = dataGridView1.Columns("DeleteColumn").Index Then
            If listOperation <> TransactionAction.Edit Then
                userCollection.RemoveAt(e.RowIndex)
            Else
                MessageBox.Show("Se está editando datos, por favor termine la operación.")
            End If
        End If

        If e.ColumnIndex = dataGridView1.Columns("EditColumn").Index Then
            userViewModel = userCollection(e.RowIndex)
            FillFields(userViewModel)
            listOperation = TransactionAction.Edit
            btnAddUser.Text = "Actualizar"
            btnAddUser.BackColor = Color.MediumSlateBlue
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Si se cancela la acción establecer nulo como último registro.
        _lastRecord = Nothing
        Me.Close()
    End Sub

    Protected Overrides Sub CloseForm()
        'Si se cierra el formulario, establecer nulo como último registro.
        MyBase.CloseForm()
        _lastRecord = Nothing
    End Sub

    Private Sub lbl2_Click(sender As Object, e As EventArgs) Handles lbl2.Click

    End Sub
#End Region

End Class