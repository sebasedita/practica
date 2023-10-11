Public Module ActiveUser
    '''<summary>
    ''' Responsable de almacenar el ID y Cargo del usuario que inició sesión, 
    ''' que te permite realizar los permisos de usuario en cualquier capa.
    ''' Esto es opcional , generalmente no es necesario realizar permisos
    ''' de usuario en la capa de acceso a datos y dominio.
    ''' </summary>
    ''' 
    Public Property Id As Integer
    Public Property Position As String
    'Esto es un ejemplo simple y básico, hay muchas maneras de hacerlo.
End Module
