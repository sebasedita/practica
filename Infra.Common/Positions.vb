Public Module Positions

    ''' <summary>
    ''' Esta estructura almacena los cargos del usuario, escencial para
    ''' realizar las condiciones de los permisos de usuario (Para el ejemplo del proyecto).
    ''' De igual manera esto es opcional, en su lugar puedes usar
    ''' una tabla de cargos en la base de datos, puedes hacerlo
    ''' mediante enumeraciones y el ID de los cargos.
    ''' </summary>

    Public Const GeneralManager As String = "General manager"
    Public Const Accountant As String = "Accountant"
    Public Const MarketingGuru As String = "Marketing guru"
    Public Const AdministrativeAssistant As String = "Administrative assistant"
    Public Const HMR As String = "Human resource manager"
    Public Const Receptionist As String = "Receptionist"
    Public Const SystemAdministrator As String = "System administrator"

    Public Function GetPositions() As IEnumerable(Of String)
        'Método para listar los cargos. Se usa para establece la fuente de datos
        'del ComboBox en el formulario usuario de la capa de interfaz de usuario.
        Dim positions = New List(Of String) From {
            GeneralManager,
            Accountant,
            MarketingGuru,
            AdministrativeAssistant,
            HMR,
            Receptionist,
            SystemAdministrator
        }
        positions.Sort()
        Return positions
    End Function
End Module
