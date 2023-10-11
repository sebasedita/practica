Public Class Address
    Inherits BaseValueObject
    ''' <summary>
    ''' Los objetos de valor son objetos que no tienen identidad o no son entidades específicos del dominio.
    ''' Por ejemplo el objeto dirección.
    ''' Mas información:
    ''' https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    ''' </summary>

    Public Property Street As String
    Public Property City As String
    Public Property State As String
    Public Property Country As String
    Public Property ZipCode As String

    Public Sub New()
    End Sub

    Public Sub New(street As String, city As String, state As String, country As String, zipcode As String)
        street = street
        city = city
        state = state
        country = country
        zipcode = zipcode
    End Sub

    Protected Overrides Iterator Function GetEqualityComponents() As IEnumerable(Of Object)
        ' Using a yield return statement to return each element one at a time
        Yield Street
        Yield City
        Yield State
        Yield Country
        Yield ZipCode
    End Function

End Class
