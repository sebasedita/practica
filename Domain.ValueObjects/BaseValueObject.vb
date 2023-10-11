Public MustInherit Class BaseValueObject
    ''' <summary>
    ''' Clase abstracta base que implementa métodos básicos para otros objetos de valor.
    ''' Ejemplo basado en la documentación de Microsoft:
    ''' https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    ''' </summary>
    ''' 

    Protected Shared Function EqualOperator(left As BaseValueObject, right As BaseValueObject) As Boolean
        If ReferenceEquals(left, Nothing) Xor ReferenceEquals(right, Nothing) Then
            Return False
        End If
        Return ReferenceEquals(left, Nothing) OrElse left.Equals(right)
    End Function

    Protected Shared Function NotEqualOperator(left As BaseValueObject, right As BaseValueObject) As Boolean
        Return Not (EqualOperator(left, right))
    End Function

    Protected MustOverride Function GetEqualityComponents() As IEnumerable(Of Object)

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse obj.GetType() <> Me.GetType() Then
            Return False
        End If

        Dim other = CType(obj, BaseValueObject)
        Return Me.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents())
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return GetEqualityComponents().Select(Function(x) If(x IsNot Nothing, x.GetHashCode(), 0)).Aggregate(Function(x, y) x Xor y)
    End Function
    'Puedes continuar agregando otros métodos de utilidad.

End Class
