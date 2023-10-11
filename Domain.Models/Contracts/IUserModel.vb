Public Interface IUserModel
    Inherits IBaseModel(Of UserModel)

    Function AddRange(users As List(Of UserModel)) As Integer
    Function RemoveRange(users As List(Of UserModel)) As Integer
    Function Login(user As String, pass As String) As UserModel
    Function RecoverPassword(requestingUser As String) As UserModel

End Interface
