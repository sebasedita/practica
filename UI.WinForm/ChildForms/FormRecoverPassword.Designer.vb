<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRecoverPassword
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
        Me.label1 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.label1.Location = New System.Drawing.Point(20, 53)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(312, 16)
        Me.label1.TabIndex = 8
        Me.label1.Text = "Ingrese su nombre de usuario o correo electrónico: "
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblMessage.Location = New System.Drawing.Point(20, 102)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(389, 70)
        Me.lblMessage.TabIndex = 7
        Me.lblMessage.Text = "Mensaje"
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.btnSend.FlatAppearance.BorderSize = 0
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSend.Location = New System.Drawing.Point(326, 72)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 6
        Me.btnSend.Text = "Enviar"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.ForeColor = System.Drawing.Color.Silver
        Me.txtUser.Location = New System.Drawing.Point(23, 72)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(305, 23)
        Me.txtUser.TabIndex = 5
        '
        'FormRecoverPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(433, 188)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtUser)
        Me.Name = "FormRecoverPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recuperar contraseña"
        Me.Controls.SetChildIndex(Me.txtUser, 0)
        Me.Controls.SetChildIndex(Me.btnSend, 0)
        Me.Controls.SetChildIndex(Me.lblMessage, 0)
        Me.Controls.SetChildIndex(Me.label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Private WithEvents btnSend As System.Windows.Forms.Button
    Private WithEvents txtUser As System.Windows.Forms.TextBox
End Class
