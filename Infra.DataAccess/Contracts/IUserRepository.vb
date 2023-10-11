Public Interface IUserRepository
    Inherits IGenericRepository(Of User)

    Function Login(username As String, password As String) As User
    Function AddRange(users As List(Of User)) As Integer
    Function RemoveRange(users As List(Of User)) As Integer
End Interface
