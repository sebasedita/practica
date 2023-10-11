<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WelcomeForm
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WelcomeForm))
        Me.label2 = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.circularProgressBar1 = New CircularProgressBar.CircularProgressBar()
        Me.label1 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.pictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panel1.SuspendLayout()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.label2.Location = New System.Drawing.Point(303, 58)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(147, 32)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Bienvenido"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblUsername.Location = New System.Drawing.Point(320, 90)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(184, 29)
        Me.lblUsername.TabIndex = 13
        Me.lblUsername.Text = "NombreUsuario"
        '
        'timer1
        '
        Me.timer1.Interval = 50
        '
        'timer2
        '
        Me.timer2.Interval = 30
        '
        'circularProgressBar1
        '
        Me.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.circularProgressBar1.AnimationSpeed = 500
        Me.circularProgressBar1.BackColor = System.Drawing.Color.Transparent
        Me.circularProgressBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold)
        Me.circularProgressBar1.ForeColor = System.Drawing.Color.Gainsboro
        Me.circularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.circularProgressBar1.InnerMargin = 2
        Me.circularProgressBar1.InnerWidth = -1
        Me.circularProgressBar1.Location = New System.Drawing.Point(368, 157)
        Me.circularProgressBar1.MarqueeAnimationSpeed = 2000
        Me.circularProgressBar1.Name = "circularProgressBar1"
        Me.circularProgressBar1.OuterColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.circularProgressBar1.OuterMargin = -25
        Me.circularProgressBar1.OuterWidth = 26
        Me.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.circularProgressBar1.ProgressWidth = 15
        Me.circularProgressBar1.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.circularProgressBar1.Size = New System.Drawing.Size(150, 150)
        Me.circularProgressBar1.StartAngle = 270
        Me.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.circularProgressBar1.SubscriptColor = System.Drawing.Color.Gainsboro
        Me.circularProgressBar1.SubscriptMargin = New System.Windows.Forms.Padding(-2, -1, -1, -1)
        Me.circularProgressBar1.SubscriptText = ""
        Me.circularProgressBar1.SuperscriptColor = System.Drawing.Color.Gainsboro
        Me.circularProgressBar1.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.circularProgressBar1.SuperscriptText = "%"
        Me.circularProgressBar1.TabIndex = 15
        Me.circularProgressBar1.Text = "0"
        Me.circularProgressBar1.TextMargin = New System.Windows.Forms.Padding(8, 8, 0, 0)
        Me.circularProgressBar1.Value = 68
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.label1.Location = New System.Drawing.Point(322, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(184, 17)
        Me.label1.TabIndex = 2
        Me.label1.Text = "CREAMOS VALOR PARA TI"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(113, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.panel1.Controls.Add(Me.pictureBox2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(804, 40)
        Me.panel1.TabIndex = 11
        '
        'pictureBox2
        '
        Me.pictureBox2.Image = CType(resources.GetObject("pictureBox2.Image"), System.Drawing.Image)
        Me.pictureBox2.Location = New System.Drawing.Point(-48, 5)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(364, 32)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox2.TabIndex = 5
        Me.pictureBox2.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(-6, 39)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(294, 324)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox1.TabIndex = 12
        Me.pictureBox1.TabStop = False
        '
        'WelcomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(804, 364)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.circularProgressBar1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WelcomeForm"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WelcomeForm"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents lblUsername As System.Windows.Forms.Label
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents timer2 As System.Windows.Forms.Timer
    Private WithEvents circularProgressBar1 As CircularProgressBar.CircularProgressBar
    Private WithEvents pictureBox2 As System.Windows.Forms.PictureBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
End Class
