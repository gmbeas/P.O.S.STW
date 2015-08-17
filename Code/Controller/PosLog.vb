Imports System.IO



Public Class PosLog


    Public Sub GuardaMvto(ByVal tipo As String, ByVal Mvto_ As String)

        Dim texto As String = DateTime.Now + " " + tipo + " " + Mvto_
        Dim sw As New System.IO.StreamWriter(_RutaLog, True)
        sw.WriteLine(texto)
        sw.Close()

    End Sub


    Public Function ReportaError(ByVal ORIGEN As String, ByVal descripcion As String, ByVal ERROR_ As String) As Boolean

        Dim correo As New System.Net.Mail.MailMessage
        correo.From = New System.Net.Mail.MailAddress("cg@steward.cl")
        correo.To.Add("ehidalgo@steward.cl")
        'correo.To.Add("eduardohc@vtr.net")
        correo.Subject = "REPORTE DE ERROR EN APLICACIÓN POS : " + ORIGEN
        Dim mensajeCompleto As String = "ORIGEN:" & ORIGEN & vbCrLf & vbCrLf & "DESCRIPCION: " & descripcion & vbCrLf & "ERROR: " & ERROR_
        correo.Body = mensajeCompleto
        correo.IsBodyHtml = False
        correo.Priority = System.Net.Mail.MailPriority.Normal
        Dim smtp As New System.Net.Mail.SmtpClient
        smtp.Host = "pod51010.outlook.com"
        smtp.Port = 25
        smtp.Credentials = New System.Net.NetworkCredential("cg@steward.cl", "vespucio.2012")
        smtp.EnableSsl = True
        Dim sended As Boolean = False
        Dim intentos As Integer = 0

        Try
            smtp.Send(correo)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
