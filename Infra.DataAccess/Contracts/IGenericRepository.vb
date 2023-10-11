Public Interface IGenericRepository(Of Entity As Class)
    'Esta interfaz define los comportamientos públicos comunes para todas las entidades.

    Function Add(entity As Entity) As Integer 'Agregar nueva entidad.
    Function Edit(entity As Entity) As Integer 'Editar una entidad.
    Function Remove(entity As Entity) As Integer 'Eliminar una entidad.

    Function GetSingle(value As String) As Entity  'Obtener una entidad por valor(Buscar).
    Function GetAll() As IEnumerable(Of Entity) 'Listar todas las entidades.
    Function GetByValue(value As String) As IEnumerable(Of Entity) 'Listar entidades por valor(Filtrar).

    'Nota: No es obligatorio usar interfaces, sin embargo, su uso tiene ciertas ventajas y utilidades.
    'Recomiendo investigar sobre las interfaces. 
    'Mas Información: https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/interfaces/
End Interface
