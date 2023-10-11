Public Class WelcomeForm

    Public Sub New(username As String)
        InitializeComponent()
        lblUsername.Text = username
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    End Sub

    Private Sub WelcomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0.0
        circularProgressBar1.Value = 0
        circularProgressBar1.Minimum = 0
        circularProgressBar1.Maximum = 100
        timer1.Start()
    End Sub

    Private Sub timer1_Tick(sender As Object, e As EventArgs) Handles timer1.Tick
        If Me.Opacity < 1 Then Me.Opacity += 0.05
        circularProgressBar1.Value += 2
        circularProgressBar1.Text = circularProgressBar1.Value.ToString()

        If circularProgressBar1.Value = 100 Then
            timer1.Stop()
            timer2.Start()
        End If
    End Sub

    Private Sub timer2_Tick(sender As Object, e As EventArgs) Handles timer2.Tick
        Me.Opacity -= 0.1

        If Me.Opacity = 0 Then
            timer2.Stop()
            Me.Close()
        End If
    End Sub

    Private Sub WelcomeForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawRectangle(New Pen(Color.MediumSlateBlue), 0, 0, Me.Width - 1, Me.Height - 1)
    End Sub

    Private Sub lblUsername_Click(sender As Object, e As EventArgs) Handles lblUsername.Click

    End Sub
End Class