<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUserMaintenance
    Inherits UI.WinForm.BaseFixedForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelAddedControl = New System.Windows.Forms.Panel()
        Me.rbMultiInsert = New System.Windows.Forms.RadioButton()
        Me.rbSingleInsert = New System.Windows.Forms.RadioButton()
        Me.txtCurrentPass = New System.Windows.Forms.TextBox()
        Me.lblCurrentPass = New System.Windows.Forms.Label()
        Me.txtConfirmPass = New System.Windows.Forms.TextBox()
        Me.lblConfirmPass = New System.Windows.Forms.Label()
        Me.cmbPosition = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDeletePhoto = New System.Windows.Forms.Button()
        Me.btnAddPhoto = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.PictureBoxPhoto = New System.Windows.Forms.PictureBox()
        Me.lblMaintenanceTitle = New System.Windows.Forms.Label()
        Me.panelMultiInsert = New System.Windows.Forms.Panel()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.panelAddedControl.SuspendLayout()
        CType(Me.PictureBoxPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelMultiInsert.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelAddedControl
        '
        Me.panelAddedControl.Controls.Add(Me.rbMultiInsert)
        Me.panelAddedControl.Controls.Add(Me.rbSingleInsert)
        Me.panelAddedControl.Location = New System.Drawing.Point(474, 45)
        Me.panelAddedControl.Name = "panelAddedControl"
        Me.panelAddedControl.Size = New System.Drawing.Size(276, 30)
        Me.panelAddedControl.TabIndex = 123
        '
        'rbMultiInsert
        '
        Me.rbMultiInsert.AutoSize = True
        Me.rbMultiInsert.Checked = True
        Me.rbMultiInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMultiInsert.ForeColor = System.Drawing.Color.Gainsboro
        Me.rbMultiInsert.Location = New System.Drawing.Point(119, 3)
        Me.rbMultiInsert.Name = "rbMultiInsert"
        Me.rbMultiInsert.Size = New System.Drawing.Size(135, 21)
        Me.rbMultiInsert.TabIndex = 1
        Me.rbMultiInsert.TabStop = True
        Me.rbMultiInsert.Text = "Inserción múltiple"
        Me.rbMultiInsert.UseVisualStyleBackColor = True
        '
        'rbSingleInsert
        '
        Me.rbSingleInsert.AutoSize = True
        Me.rbSingleInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSingleInsert.ForeColor = System.Drawing.Color.Gainsboro
        Me.rbSingleInsert.Location = New System.Drawing.Point(8, 3)
        Me.rbSingleInsert.Name = "rbSingleInsert"
        Me.rbSingleInsert.Size = New System.Drawing.Size(107, 21)
        Me.rbSingleInsert.TabIndex = 0
        Me.rbSingleInsert.Text = "Inserto único"
        Me.rbSingleInsert.UseVisualStyleBackColor = True
        '
        'txtCurrentPass
        '
        Me.txtCurrentPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtCurrentPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentPass.ForeColor = System.Drawing.Color.LightGray
        Me.txtCurrentPass.Location = New System.Drawing.Point(474, 265)
        Me.txtCurrentPass.Name = "txtCurrentPass"
        Me.txtCurrentPass.Size = New System.Drawing.Size(230, 22)
        Me.txtCurrentPass.TabIndex = 114
        Me.txtCurrentPass.UseSystemPasswordChar = True
        '
        'lblCurrentPass
        '
        Me.lblCurrentPass.AutoSize = True
        Me.lblCurrentPass.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPass.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblCurrentPass.Location = New System.Drawing.Point(471, 246)
        Me.lblCurrentPass.Name = "lblCurrentPass"
        Me.lblCurrentPass.Size = New System.Drawing.Size(118, 16)
        Me.lblCurrentPass.TabIndex = 122
        Me.lblCurrentPass.Text = "Contraseña actual:"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirmPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPass.ForeColor = System.Drawing.Color.LightGray
        Me.txtConfirmPass.Location = New System.Drawing.Point(474, 215)
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.Size = New System.Drawing.Size(230, 22)
        Me.txtConfirmPass.TabIndex = 113
        Me.txtConfirmPass.UseSystemPasswordChar = True
        '
        'lblConfirmPass
        '
        Me.lblConfirmPass.AutoSize = True
        Me.lblConfirmPass.BackColor = System.Drawing.Color.Transparent
        Me.lblConfirmPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmPass.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblConfirmPass.Location = New System.Drawing.Point(471, 196)
        Me.lblConfirmPass.Name = "lblConfirmPass"
        Me.lblConfirmPass.Size = New System.Drawing.Size(137, 16)
        Me.lblConfirmPass.TabIndex = 121
        Me.lblConfirmPass.Text = "Confirmar contraseña:"
        '
        'cmbPosition
        '
        Me.cmbPosition.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPosition.ForeColor = System.Drawing.Color.Silver
        Me.cmbPosition.FormattingEnabled = True
        Me.cmbPosition.Location = New System.Drawing.Point(216, 266)
        Me.cmbPosition.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPosition.Name = "cmbPosition"
        Me.cmbPosition.Size = New System.Drawing.Size(230, 24)
        Me.cmbPosition.TabIndex = 110
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(213, 246)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Cargo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(471, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 16)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Nombre de usuario:"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.LightGray
        Me.txtUsername.Location = New System.Drawing.Point(474, 115)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(230, 22)
        Me.txtUsername.TabIndex = 111
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.LightGray
        Me.txtPassword.Location = New System.Drawing.Point(474, 165)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(230, 22)
        Me.txtPassword.TabIndex = 112
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.BackColor = System.Drawing.Color.Transparent
        Me.lbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl2.Location = New System.Drawing.Point(213, 196)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(44, 16)
        Me.lbl2.TabIndex = 119
        Me.lbl2.Text = "Email:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblPassword.Location = New System.Drawing.Point(471, 146)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(79, 16)
        Me.lblPassword.TabIndex = 116
        Me.lblPassword.Text = "Contraseña:"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.Color.LightGray
        Me.txtEmail.Location = New System.Drawing.Point(216, 215)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(230, 22)
        Me.txtEmail.TabIndex = 109
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(213, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "Apellido:"
        '
        'txtLastName
        '
        Me.txtLastName.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.ForeColor = System.Drawing.Color.LightGray
        Me.txtLastName.Location = New System.Drawing.Point(216, 165)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(230, 22)
        Me.txtLastName.TabIndex = 108
        '
        'txtFirstName
        '
        Me.txtFirstName.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.ForeColor = System.Drawing.Color.LightGray
        Me.txtFirstName.Location = New System.Drawing.Point(216, 115)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(230, 22)
        Me.txtFirstName.TabIndex = 107
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(213, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Nombre:"
        '
        'btnDeletePhoto
        '
        Me.btnDeletePhoto.BackColor = System.Drawing.Color.IndianRed
        Me.btnDeletePhoto.FlatAppearance.BorderSize = 0
        Me.btnDeletePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeletePhoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeletePhoto.ForeColor = System.Drawing.Color.White
        Me.btnDeletePhoto.Location = New System.Drawing.Point(161, 255)
        Me.btnDeletePhoto.Name = "btnDeletePhoto"
        Me.btnDeletePhoto.Size = New System.Drawing.Size(25, 25)
        Me.btnDeletePhoto.TabIndex = 125
        Me.btnDeletePhoto.Text = "-"
        Me.btnDeletePhoto.UseVisualStyleBackColor = False
        '
        'btnAddPhoto
        '
        Me.btnAddPhoto.BackColor = System.Drawing.Color.SeaGreen
        Me.btnAddPhoto.FlatAppearance.BorderSize = 0
        Me.btnAddPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddPhoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddPhoto.ForeColor = System.Drawing.Color.White
        Me.btnAddPhoto.Location = New System.Drawing.Point(130, 255)
        Me.btnAddPhoto.Name = "btnAddPhoto"
        Me.btnAddPhoto.Size = New System.Drawing.Size(25, 25)
        Me.btnAddPhoto.TabIndex = 124
        Me.btnAddPhoto.Text = "+"
        Me.btnAddPhoto.UseVisualStyleBackColor = False
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.DarkGray
        Me.label3.Location = New System.Drawing.Point(39, 259)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(86, 16)
        Me.label3.TabIndex = 127
        Me.label3.Text = "Cambiar foto:"
        '
        'PictureBoxPhoto
        '
        Me.PictureBoxPhoto.Image = Global.UI.WinForm.My.Resources.Resources.DefaultUserProfile
        Me.PictureBoxPhoto.Location = New System.Drawing.Point(36, 101)
        Me.PictureBoxPhoto.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBoxPhoto.Name = "PictureBoxPhoto"
        Me.PictureBoxPhoto.Size = New System.Drawing.Size(150, 150)
        Me.PictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxPhoto.TabIndex = 126
        Me.PictureBoxPhoto.TabStop = False
        '
        'lblMaintenanceTitle
        '
        Me.lblMaintenanceTitle.AutoSize = True
        Me.lblMaintenanceTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblMaintenanceTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaintenanceTitle.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblMaintenanceTitle.Location = New System.Drawing.Point(31, 59)
        Me.lblMaintenanceTitle.Name = "lblMaintenanceTitle"
        Me.lblMaintenanceTitle.Size = New System.Drawing.Size(155, 26)
        Me.lblMaintenanceTitle.TabIndex = 128
        Me.lblMaintenanceTitle.Text = "Mantenimiento"
        '
        'panelMultiInsert
        '
        Me.panelMultiInsert.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.panelMultiInsert.Controls.Add(Me.dataGridView1)
        Me.panelMultiInsert.Controls.Add(Me.btnAddUser)
        Me.panelMultiInsert.Location = New System.Drawing.Point(2, 308)
        Me.panelMultiInsert.Name = "panelMultiInsert"
        Me.panelMultiInsert.Size = New System.Drawing.Size(750, 330)
        Me.panelMultiInsert.TabIndex = 129
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.AllowUserToResizeRows = False
        Me.dataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridView1.ColumnHeadersHeight = 40
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(114, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dataGridView1.EnableHeadersVisualStyles = False
        Me.dataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.dataGridView1.Location = New System.Drawing.Point(4, 49)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.ReadOnly = True
        Me.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(95, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(114, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dataGridView1.RowHeadersWidth = 40
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.dataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dataGridView1.RowTemplate.Height = 40
        Me.dataGridView1.Size = New System.Drawing.Size(743, 278)
        Me.dataGridView1.TabIndex = 69
        '
        'btnAddUser
        '
        Me.btnAddUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnAddUser.FlatAppearance.BorderSize = 0
        Me.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddUser.ForeColor = System.Drawing.Color.White
        Me.btnAddUser.Location = New System.Drawing.Point(296, 3)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(150, 40)
        Me.btnAddUser.TabIndex = 0
        Me.btnAddUser.Text = "Agregar"
        Me.btnAddUser.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(388, 654)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 40)
        Me.btnSave.TabIndex = 130
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(212, 654)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 40)
        Me.btnCancel.TabIndex = 131
        Me.btnCancel.Text = "X  Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'FormUserMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(754, 715)
        Me.Controls.Add(Me.panelMultiInsert)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblMaintenanceTitle)
        Me.Controls.Add(Me.btnDeletePhoto)
        Me.Controls.Add(Me.btnAddPhoto)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.PictureBoxPhoto)
        Me.Controls.Add(Me.panelAddedControl)
        Me.Controls.Add(Me.txtCurrentPass)
        Me.Controls.Add(Me.lblCurrentPass)
        Me.Controls.Add(Me.txtConfirmPass)
        Me.Controls.Add(Me.lblConfirmPass)
        Me.Controls.Add(Me.cmbPosition)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FormUserMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mantenimiento de usuario"
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtFirstName, 0)
        Me.Controls.SetChildIndex(Me.txtLastName, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtEmail, 0)
        Me.Controls.SetChildIndex(Me.lblPassword, 0)
        Me.Controls.SetChildIndex(Me.lbl2, 0)
        Me.Controls.SetChildIndex(Me.txtPassword, 0)
        Me.Controls.SetChildIndex(Me.txtUsername, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.cmbPosition, 0)
        Me.Controls.SetChildIndex(Me.lblConfirmPass, 0)
        Me.Controls.SetChildIndex(Me.txtConfirmPass, 0)
        Me.Controls.SetChildIndex(Me.lblCurrentPass, 0)
        Me.Controls.SetChildIndex(Me.txtCurrentPass, 0)
        Me.Controls.SetChildIndex(Me.panelAddedControl, 0)
        Me.Controls.SetChildIndex(Me.PictureBoxPhoto, 0)
        Me.Controls.SetChildIndex(Me.label3, 0)
        Me.Controls.SetChildIndex(Me.btnAddPhoto, 0)
        Me.Controls.SetChildIndex(Me.btnDeletePhoto, 0)
        Me.Controls.SetChildIndex(Me.lblMaintenanceTitle, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.panelMultiInsert, 0)
        Me.panelAddedControl.ResumeLayout(False)
        Me.panelAddedControl.PerformLayout()
        CType(Me.PictureBoxPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelMultiInsert.ResumeLayout(False)
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panelAddedControl As System.Windows.Forms.Panel
    Private WithEvents rbMultiInsert As System.Windows.Forms.RadioButton
    Private WithEvents rbSingleInsert As System.Windows.Forms.RadioButton
    Friend WithEvents txtCurrentPass As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentPass As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPass As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmPass As System.Windows.Forms.Label
    Friend WithEvents cmbPosition As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnDeletePhoto As System.Windows.Forms.Button
    Friend WithEvents btnAddPhoto As System.Windows.Forms.Button
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents lblMaintenanceTitle As System.Windows.Forms.Label
    Private WithEvents panelMultiInsert As System.Windows.Forms.Panel
    Friend WithEvents btnAddUser As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
End Class
