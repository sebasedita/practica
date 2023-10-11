Imports System.Net.Mail
Imports System.Net

Public Class EmailService
    Implements IEmailService

    ''' <summary>
    ''' Esta clase implementa la interfaz IEmailService junto a sus métodos para enviar 
    ''' mensajes de correo electrónico, para ello se inicializa el objeto SmtpClient.
    ''' No olvides de configurar la conexión al servidor de correo remitente (MailServer), 
    ''' con tus datos de correo electrónico (El que se encargará de enviar los mensajes de correo).
    ''' En caso que uses Gmail como email remitente, debes de activar la opcion Permitir el acceso de aplicaciones
    ''' poco seguras para que tu aplicación pueda enviar correos electrónicos.
    ''' Leer la guía rápida para mas información.
    ''' </summary>
    ''' 

#Region "-> Campos"

    Private smtpClient As SmtpClient 'Obtiene o establece el cliente SMTP.
    Private Structure MailServer 'Obtiene o establece  el correo servidor quien se encarga de enviar los mensajes.
        Public Const Address As String = "VitalClinicSystem@gmail.com"
        Public Const Password As String = "@admin123"
        Public Const DisplayName As String = "Vital Clinic"
        Public Const Host As String = "smtp.gmail.com"
        Public Const Port As Integer = 587
        Public Const SSL As Boolean = True
    End Structure
#End Region

#Region "-> Constructor"

    Public Sub New()
        smtpClient = New SmtpClient With {
            .Credentials = New NetworkCredential(MailServer.Address, MailServer.Password),
            .Host = MailServer.Host,
            .Port = MailServer.Port,
            .EnableSsl = MailServer.SSL
        }
    End Sub
#End Region

#Region "-> Métodos"

    Public Sub Send(recipient As String, subject As String, body As String) Implements IEmailService.Send
        'Este método es responsable de enviar un mensaje de correo a un solo destinatario.

        Dim mailMessage = New MailMessage() 'Inicializar el objeto mensaje de correo.
        Dim mailSender = New MailAddress(MailServer.Address, MailServer.DisplayName) 'Inicializar el objeto dirección de correo electrónico remitente.
        Try
            mailMessage.From = mailSender 'Establecer la dirección de correo remitente.
            mailMessage.To.Add(recipient) 'Establecer y agregar la dirección de correo destinatario.
            mailMessage.Subject = subject 'Establecer el asunto del mensaje de correo.
            mailMessage.Body = body 'Establecer el contenido del mensaje de correo.
            mailMessage.Priority = MailPriority.Normal 'Establecer la prioridad del mensaje de correo.
            smtpClient.Send(mailMessage) 'Enviar el mensaje de correo mediante el cliente SMTP(Protocolo simple de transferencia de correo)
        Catch ex As SmtpException
            Throw New ArgumentException(ex.Message)
        Finally
            mailMessage.Dispose()
        End Try
    End Sub

    Public Sub Send(recipients As List(Of String), subject As String, body As String) Implements IEmailService.Send
        'Este método es responsable de enviar un mensaje de correo a varios destinatarios.

        Dim mailMessage = New MailMessage() 'Inicializar el objeto mensaje de correo.
        Dim mailSender = New MailAddress(MailServer.Address, MailServer.DisplayName) 'Inicializar el objeto dirección de correo electrónico remitente.
        Try
            mailMessage.From = mailSender 'Establecer la dirección de correo remitente.
            For Each recipientMail In recipients 'Recorrer la lista de destinatarios para obtener cada dirección de correo.
                mailMessage.To.Add(recipientMail) 'Agregar la dirección de correo destinatario a la colección de direcciones de correo.
            Next
            mailMessage.Subject = subject 'Establecer el asunto del mensaje de correo.
            mailMessage.Body = body 'Establecer el contenido del mensaje de correo.
            mailMessage.Priority = MailPriority.Normal 'Establecer la prioridad del mensaje de correo.
            smtpClient.Send(mailMessage) 'Enviar el mensaje de correo mediante el cliente SMTP(Protocolo simple de transferencia de correo)
        Catch ex As SmtpException
            Throw New ArgumentException(ex.Message)
        Finally
            mailMessage.Dispose()
        End Try
    End Sub

#End Region

End Class
