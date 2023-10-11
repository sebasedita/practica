Interface IEmailService
    'Define métodos públicos de la clase EmailService
    Sub Send(recipient As String, subject As String, body As String)
    Sub Send(recipients As List(Of String), subject As String, body As String)
End Interface
