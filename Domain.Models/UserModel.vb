Imports Infra.DataAccess
Imports Infra.EmailServices

Public Class UserModel
    Implements IUserModel
    ''' <summary>
    ''' Esta clase implementa la interfaz IUserModel junto a sus métodos definidos.
    ''' </summary>

#Region "-> Atributos"
    Private _id As Integer
    Private _username As String
    Private _password As String
    Private _firstName As String
    Private _lastName As String
    Private _position As String
    Private _email As String
    Private _photo As Byte()
    Private _userRepository As IUserRepository
#End Region

#Region "-> Constructores"
    Public Sub New()
        _userRepository = New UserRepository()
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
        _userRepository = New UserRepository()
    End Sub
#End Region

#Region "-> Propiedades"
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _firstName
        End Get
        Set(value As String)
            _firstName = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Set(value As String)
            _lastName = value
        End Set
    End Property

    Public Property Position As String
        Get
            Return _position
        End Get
        Set(value As String)
            _position = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property Photo As Byte()
        Get
            Return _photo
        End Get
        Set(value As Byte())
            _photo = value
        End Set
    End Property
#End Region

#Region "-> Métodos Públicos"

    Public Function Add(userModel As UserModel) As Integer Implements IBaseModel(Of UserModel).Add
        Dim userEntity = MapUserEntity(userModel)
        Return _userRepository.Add(userEntity)
    End Function

    Public Function Edit(userModel As UserModel) As Integer Implements IBaseModel(Of UserModel).Edit
        Dim userEntity = MapUserEntity(userModel)
        Return _userRepository.Edit(userEntity)
    End Function

    Public Function Remove(userModel As UserModel) As Integer Implements IBaseModel(Of UserModel).Remove
        Dim userEntity = MapUserEntity(userModel)
        Return _userRepository.Remove(userEntity)
    End Function

    Public Function AddRange(userModels As List(Of UserModel)) As Integer Implements IUserModel.AddRange
        Dim userEntityList = MapUserEntity(userModels)
        Return _userRepository.AddRange(userEntityList)
    End Function

    Public Function RemoveRange(userModels As List(Of UserModel)) As Integer Implements IUserModel.RemoveRange
        Dim userEntityList = MapUserEntity(userModels)
        Return _userRepository.RemoveRange(userEntityList)
    End Function

    Public Function GetSingle(value As String) As UserModel Implements IBaseModel(Of UserModel).GetSingle
        Dim userEntity = _userRepository.GetSingle(value)
        If userEntity IsNot Nothing Then
            Return MapUserModel(userEntity)
        Else
            Return Nothing
        End If
    End Function

    Public Function GetAll() As IEnumerable(Of UserModel) Implements IBaseModel(Of UserModel).GetAll
        Dim userEntityList = _userRepository.GetAll()
        Return MapUserModel(userEntityList)
    End Function

    Public Function GetByValue(value As String) As IEnumerable(Of UserModel) Implements IBaseModel(Of UserModel).GetByValue
        Dim userEntityList = _userRepository.GetByValue(value)
        Return MapUserModel(userEntityList)
    End Function

    Public Function Login(username As String, password As String) As UserModel Implements IUserModel.Login

        Dim userEntity = _userRepository.Login(username, password)
        If userEntity IsNot Nothing Then
            Return MapUserModel(userEntity)
        Else
            Return Nothing
        End If
    End Function

    Public Function RecoverPassword(requestingUser As String) As UserModel Implements IUserModel.RecoverPassword
        'Método para recupear la contraseña del usuario y enviarlo a su dirección de correo.

        Dim userModel = GetSingle(requestingUser)
        If userModel IsNot Nothing Then
            Dim mailService = New EmailService()
            mailService.Send(
                recipient:=userModel.Email,
                subject:="Solicitud de recuperación de contraseña",
                body:="Hola " & userModel.FirstName & "," & vbLf & "Solicitó recuperar su contraseña." & vbLf &
                      "Tu contraseña actual es: " + userModel.Password & vbLf & "Sin embargo, le pedimos que cambie" &
                      "su contraseña inmediatamente una vez ingrese a la aplicacíon")
        End If
        Return userModel
        ' Nota: Eso es simplemente un ejemplo para enviar correos electrónicos,
        ' no es buena idea enviar directamente la contraseña del usuario,
        ' en su lugar, es mejor enviar una contraseña temporal.
    End Function
#End Region

#Region "-> Métodos Privados (Mapear datos)"

    'Mapear modelo entidad a modelo de dominio.
    Private Function MapUserModel(userEntity As User) As UserModel
        'Mapear un solo objeto.
        Dim userModel = New UserModel With {
            .Id = userEntity.Id,
            .Username = userEntity.Username,
            .Password = userEntity.Password,
            .FirstName = userEntity.FirstName,
            .LastName = userEntity.LastName,
            .Position = userEntity.Position,
            .Email = userEntity.Email,
            .Photo = userEntity.Photo
        }
        Return userModel
    End Function

    Private Function MapUserModel(userEntityList As IEnumerable(Of User)) As List(Of UserModel)
        'Mapear colección de objetos.
        Dim userModelList = New List(Of UserModel)()
        For Each userEntity In userEntityList
            userModelList.Add(MapUserModel(userEntity))
        Next
        Return userModelList
    End Function

    'Mapear modelo de dominio a modelo de entidad.
    Private Function MapUserEntity(userModel As UserModel) As User
        'Mapear un solo objeto.
        Dim userEntity = New User With {
            .Id = userModel.Id,
            .Username = userModel.Username,
            .Password = userModel.Password,
            .FirstName = userModel.FirstName,
            .LastName = userModel.LastName,
            .Position = userModel.Position,
            .Email = userModel.Email,
            .Photo = userModel.Photo
        }
        Return userEntity
    End Function

    Private Function MapUserEntity(userModelList As List(Of UserModel)) As List(Of User)
        'Mapear una colección de usuarios.
        Dim userEntityList = New List(Of User)()
        For Each userModel In userModelList
            userEntityList.Add(MapUserEntity(userModel))
        Next
        Return userEntityList
    End Function
#End Region

End Class
