Imports Domain.Models
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class UserViewModel

#Region "-> Atributos"
    Private _id As Integer
    Private _username As String
    Private _password As String
    Private _firstName As String
    Private _lastName As String
    Private _position As String
    Private _email As String
    Private _photo As Byte()
#End Region

#Region "-> Constructores"
    Public Sub New()
    End Sub

    Public Sub New(id As Integer, userName As String, password As String, firstName As String, lastName As String, position As String, email As String, photo As Byte())
        id = id
        userName = userName
        password = password
        firstName = firstName
        lastName = lastName
        position = position
        email = email
        photo = photo
    End Sub
#End Region

#Region "-> Propiedades + Validacíon y Visualización de Datos"

    'Posición 0 
    'Nombre a visualizar (Por ejemplo en la columna del datagridview se mostrará como Num).
    <DisplayName("Num")>
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    'Posición 1
    'Nombre a visualizar y validaciones.
    <DisplayName("Usuario")>
    <Required(ErrorMessage:="El nombre de usuario es requerido.")>
    <StringLength(100, MinimumLength:=5, ErrorMessage:="El nombre de usuario debe contener un mínimo de 5 caracteres.")>
    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    'Posición 2
    'Nombre a visualizar - Ocultar campo(Ejem. No mostrar en el datagridview) - validaciones.
    <DisplayName("Contraseña")>
    <Browsable(False)>
    <Required(ErrorMessage:="Por favor ingrese una contraseña.")>
    <StringLength(100, MinimumLength:=5, ErrorMessage:="La contraseña debe contener un mínimo de 5 caracteres.")>
    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    'Posición 3
    <DisplayName("Nombre")>
    <Browsable(False)>
    <Required(ErrorMessage:="Por favor ingrese nombre")>
    <RegularExpression("^[a-zA-Z ]+$", ErrorMessage:="El nombre debe ser solo letras")>
    <StringLength(100, MinimumLength:=3, ErrorMessage:="El nombre debe contener un mínimo de 3 caracteres.")>
    Public Property FirstName As String
        Get
            Return _firstName
        End Get
        Set(value As String)
            _firstName = value
        End Set
    End Property

    'Posición 4
    <DisplayName("Apellido")>
    <Browsable(False)>
    <Required(ErrorMessage:="Por favor ingrese apellido.")>
    <RegularExpression("^[a-zA-Z ]+$", ErrorMessage:="El apellido debe ser solo letras")>
    <StringLength(100, MinimumLength:=3, ErrorMessage:="El apellido debe contener un mínimo de 3 caracteres.")>
    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Set(value As String)
            _lastName = value
        End Set
    End Property

    'Posición 5
    <[ReadOnly](True)>
    <DisplayName("Nombre completo")>
    Public ReadOnly Property FullName As String
        Get
            Return _firstName & ", " & _lastName
        End Get
    End Property

    'Posición 6
    <DisplayName("Cargo")>
    <Required(ErrorMessage:="Por favor ingrese un cargo.")>
    <StringLength(100, MinimumLength:=8, ErrorMessage:="Last name must contain a minimum of 8 characters.")>
    Public Property Position As String
        Get
            Return _position
        End Get
        Set(value As String)
            _position = value
        End Set
    End Property

    'Posición 7
    <DisplayName("Correo electronico")>
    <Required(ErrorMessage:="Por favor ingrese correo electrónico.")>
    <EmailAddress(ErrorMessage:="Ingrese un correo electrónico válido: Ejemplo@gmail.com")>
    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    'Posición 8
    <DisplayName("Foto")>
    <Browsable(False)>
    Public Property Photo As Byte()
        Get
            Return _photo
        End Get
        Set(value As Byte())
            _photo = value
        End Set
    End Property
#End Region

#Region "-> Métodos (Mapear datos)"

    'Mapear modelo de dominio a modelo de vista
    Public Function MapUserViewModel(userModel As UserModel) As UserViewModel
        Dim userViewModel = New UserViewModel With {
            .Id = userModel.Id,
            .Username = userModel.Username,
            .Password = userModel.Password,
            .FirstName = userModel.FirstName,
            .LastName = userModel.LastName,
            .Position = userModel.Position,
            .Email = userModel.Email,
            .Photo = userModel.Photo
        }
        Return userViewModel
    End Function

    Public Function MapUserViewModel(userModelList As IEnumerable(Of UserModel)) As List(Of UserViewModel)
        Dim userViewModelList = New List(Of UserViewModel)()

        For Each userModel In userModelList
            userViewModelList.Add(MapUserViewModel(userModel))
        Next

        Return userViewModelList
    End Function

    'Mapear modelo de vista a modelo de dominio
    Public Function MapUserModel(userViewModel As UserViewModel) As UserModel
        Dim userModel = New UserModel With {
            .Id = userViewModel.Id,
            .Username = userViewModel.Username,
            .Password = userViewModel.Password,
            .FirstName = userViewModel.FirstName,
            .LastName = userViewModel.LastName,
            .Position = userViewModel.Position,
            .Email = userViewModel.Email,
            .Photo = userViewModel.Photo
        }
        Return userModel
    End Function

    Public Function MapUserModel(userViewModelList As List(Of UserViewModel)) As List(Of UserModel)
        Dim userModelList = New List(Of UserModel)()

        For Each userViewModel In userViewModelList
            userModelList.Add(MapUserModel(userViewModel))
        Next

        Return userModelList
    End Function
#End Region

End Class
