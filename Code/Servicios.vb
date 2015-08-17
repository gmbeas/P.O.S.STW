Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Xml


Public Class Servicios
    Public Sub Stream2XML(ByRef sr As StreamReader, ByVal file As String)
        Dim objWriter As StreamWriter = New IO.StreamWriter(file)

        Dim buffer(1024 * 1024) As Char

        Dim position As Integer = 0
        Dim charsRead As Integer = 0

        charsRead = sr.Read(buffer, 0, buffer.Length)
        Do While charsRead > 0
            Dim contentToProcess As String = New String(buffer, 0, charsRead)
            objWriter.Write(contentToProcess)
            position += charsRead
            charsRead = sr.Read(buffer, 0, buffer.Length)
        Loop
        objWriter.Close()
        objWriter.Dispose()

    End Sub


    Function Ejecuta(ByVal xml As String, ByVal soapaccion As String, ByVal posurl As String) As String

        '  Dim objXMLHttp As New MSXML2.ServerXMLHTTP40

        Dim strSoapEnvelope As String = ""
        strSoapEnvelope = "<?xml version='1.0' encoding='utf-8'?>"
        strSoapEnvelope += "<soap:Envelope "
        strSoapEnvelope += " xmlns:xsi = 'http://www.w3.org/2001/XMLSchema-instance'"
        strSoapEnvelope += " xmlns:xsd = 'http://www.w3.org/2001/XMLSchema'"
        strSoapEnvelope += " xmlns:soap= 'http://schemas.xmlsoap.org/soap/envelope/'>"
        strSoapEnvelope += "<soap:Body>"
        strSoapEnvelope += xml
        strSoapEnvelope += "</soap:Body>"
        strSoapEnvelope += "</soap:Envelope>"

        '  objXMLHttp.open("POST", posurl, "", "")
        '  objXMLHttp.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
        ' objXMLHttp.setRequestHeader("SOAPAction", soapaccion)
        'envia a soap
        ' objXMLHttp.send(strSoapEnvelope.ToString())
        'objXMLHttp.waitForResponse(500)
        'Dim outXMl As String = objXMLHttp.responseText.ToString()

        ' Return outXMl


    End Function

End Class
