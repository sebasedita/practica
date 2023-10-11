Public Interface IBaseModel(Of Model As Class)

    Function Add(model As Model) As Integer
    Function Edit(model As Model) As Integer
    Function Remove(model As Model) As Integer
    Function GetSingle(value As String) As Model
    Function GetAll() As IEnumerable(Of Model)
    Function GetByValue(value As String) As IEnumerable(Of Model)

End Interface
