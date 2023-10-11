Imports Infra.Common
Imports Domain.Models

Public Class FormUsers

#Region "-> Campos"
    Private domainModel As IUserModel = New UserModel() 'Modelo de dominio del Usuario.
    Private userViewModel As UserViewModel = New UserViewModel() 'Modelo de vista del Usuario.
    Private userViewList As List(Of UserViewModel) 'Lista de usuarios.
    Private maintenanceForm As FormUserMaintenance 'formulario de mantenimiento.
#End Region

#Region "-> Constructor"
    Public Sub New()
        InitializeComponent()
    End Sub
#End Region

#Region "-> Métodos"

    Private Sub LoadUserData()
        'LLenar la cuadricula de datos con la lista de usuarios.
        userViewList = userViewModel.MapUserViewModel(domainModel.GetAll()) 'Obtener todos los usuarios.
        dataGridView1.DataSource = userViewList 'Establecer la fuente de datos.
    End Sub

    Private Sub FindUser(value As String)
        'Buscar usuarios.
        userViewList = userViewModel.MapUserViewModel(domainModel.GetByValue(value)) 'Filtrar usuario por valor.
        dataGridView1.DataSource = userViewList 'Establecer la fuente de datos con los resultados.
    End Sub

    Private Function GetUser(id As Integer) As UserViewModel
        'Obtener usuario por ID.
        Dim userModel = domainModel.GetSingle(id.ToString()) 'Buscar un único usuario.
        If userModel IsNot Nothing Then 'Si hay resultado, retornar un objeto modelo de vista de usuario.
            Return userViewModel.MapUserViewModel(userModel)
        Else 'Caso contrario, retornar un valor nulo, y mostrar mensaje.
            MessageBox.Show("No se ha encontrado usuario con id: " & id.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End If
    End Function
#End Region

#Region "-> Métodos de Eventos"

    Private Sub FormUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserData() 'Cargar datos.
        dataGridView1.Columns(0).Width = 50 'Establecer un ancho fijo para la columna ID.
        dataGridView1.Columns(1).Width = 100 'Establecer un ancho fijo para la columna Username.
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FindUser(txtSearch.Text) 'Buscar usuario.
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        'Buscar usuario si se preciona tecla enter en cuadro de texto buscar.
        If e.KeyCode = Keys.Enter Then
            FindUser(txtSearch.Text)
        End If
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        'Mostrar detalles de usuario.
        If dataGridView1.RowCount <= 0 Then
            MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If dataGridView1.SelectedRows.Count > 0 Then
            Dim user = GetUser(dataGridView1.CurrentRow.Cells(0).Value) 'Obtener ID del usuario y buscar usando el método GetUser(id).
            If user Is Nothing Then Return
            Dim frm = New FormUserMaintenance(user, TransactionAction.View) 'Instanciar formulario, y enviar parámetros (modelo de vista y acción)
            frm.ShowDialog() 'Mostrar formulario.
        Else
            MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Agregar usuario o varios usuarios.
        maintenanceForm = New FormUserMaintenance(New UserViewModel(), TransactionAction.Add) 'Instanciar formulario, y enviar parámetros (modelo de vista y acción).
        AddHandler maintenanceForm.FormClosed, AddressOf MaintenanceFormClosed 'Asociar evento cerrado, para actualizar el datagrdiview despues que el formualario de mantenimiento se cierre.
        maintenanceForm.ShowDialog() 'Mostrar formulario de mantenimiento.
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'Editar usuario.
        If dataGridView1.RowCount <= 0 Then
            MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If dataGridView1.SelectedCells.Count > 1 Then
            Dim user = GetUser(dataGridView1.CurrentRow.Cells(0).Value) 'Obtener ID del usuario y buscar usando el método GetUser(id).
            If user Is Nothing Then Return
            maintenanceForm = New FormUserMaintenance(user, TransactionAction.Edit) 'Instanciar formulario, y enviar parámetros (modelo de vista y acción).
            AddHandler maintenanceForm.FormClosed, AddressOf MaintenanceFormClosed 'Asociar evento cerrado, para actualizar el datagrdiview despues que el formualario de mantenimiento se cierre.
            maintenanceForm.ShowDialog() 'Mostrar formulario de mantenimiento.     
        Else
            MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        'Eliminar usuario.
        If dataGridView1.RowCount <= 0 Then
            MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If dataGridView1.SelectedRows.Count > 0 Then
            Dim user = GetUser(dataGridView1.CurrentRow.Cells(0).Value) 'Obtener ID del usuario y buscar usando el método GetUser(id).
            If user Is Nothing Then Return
            maintenanceForm = New FormUserMaintenance(user, TransactionAction.Remove) 'Instanciar formulario, y enviar parámetros (modelo de vista y acción).
            AddHandler maintenanceForm.FormClosed, AddressOf MaintenanceFormClosed 'Asociar evento cerrado, para actualizar el datagrdiview despues que el formualario de mantenimiento se cierre.
            maintenanceForm.ShowDialog() 'Mostrar formulario de mantenimiento. 
        Else
            MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub MaintenanceFormClosed(sender As Object, e As FormClosedEventArgs)
        'Actualizar el datagridview despues que el formualario de mantenimiento se cierre.

        Dim lastData = maintenanceForm.LastRecord 'Obtener el último registro del formulario de mantenimiento.
        If lastData IsNot Nothing Then 'Si tiene un último registro.
            LoadUserData() 'Actualizar el datagridview.

            If lastData <> "" Then 'Si el campo último registro, es diferente a una cadena vacia, entonces debe resaltar y visualizar el usuario agregado o editado.
                Dim index = userViewList.FindIndex(Function(u) u.Username = lastData) 'Buscar el index del ultimo usuario registrado o modificado.
                dataGridView1.CurrentCell = dataGridView1.Rows(index).Cells(0) 'Enfocar la celda del ultimo registro.
                dataGridView1.Rows(index).Selected = True 'Seleccionar fila.
                'Nota, si agregó varios usuarios a la vez (Inserción masiva) se seleccionará el primer registro de la colección de usuarios.
            End If
        End If
    End Sub
#End Region

End Class