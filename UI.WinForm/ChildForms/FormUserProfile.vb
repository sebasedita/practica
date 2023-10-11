Imports Infra.Common

Public Class FormUserProfile

    Private connectedUser As UserViewModel
    Private mainForm As MainForm

    Public Sub New(_connectedUser As UserViewModel, parentForm As MainForm)
        InitializeComponent()
        mainForm = parentForm
        connectedUser = _connectedUser

        If connectedUser IsNot Nothing Then
            LoadUserData()
        Else
            btnEdit.Visible = False
        End If
    End Sub

    Private Sub FormUserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub LoadUserData()
        lblFullname.Text = connectedUser.FullName
        lblUsername.Text = connectedUser.Username
        lblName.Text = connectedUser.FirstName
        lblLastName.Text = connectedUser.LastName
        lblMail.Text = connectedUser.Email
        lblPosition.Text = connectedUser.Position

        If connectedUser.Photo IsNot Nothing Then
            pictureBoxPhoto.Image = ItemConverter.BinaryToImage(connectedUser.Photo)
        Else
            pictureBoxPhoto.Image = My.Resources.DefaultUserProfile
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim userForm = New FormUserMaintenance(connectedUser, TransactionAction.Special)
        userForm.ShowDialog()
        RefreshUserData()
    End Sub

    Public Sub RefreshUserData()
        Dim userModel = New Domain.Models.UserModel().GetSingle(connectedUser.Id.ToString())
        connectedUser.FirstName = userModel.FirstName
        connectedUser.LastName = userModel.LastName
        connectedUser.Email = userModel.Email
        connectedUser.Position = userModel.Position
        connectedUser.Username = userModel.Username
        connectedUser.Password = userModel.Password
        connectedUser.Photo = userModel.Photo
        LoadUserData()
        mainForm.LoadUserData()
    End Sub
End Class