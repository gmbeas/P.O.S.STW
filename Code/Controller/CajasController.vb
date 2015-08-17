Imports System.Xml

Public Class CajasController

    Public Function ayuda() As ArrayList


        Dim cadena As String = "<Documento>" & _
        "<Documento_empresa>" + _Empresa + "</Documento_empresa>" & _
        "</Documento>"
        Dim resultado As String = ""
        If standalone = True Then

            Dim obj As New _apws0046.Pws0046
            resultado = obj.Execute(cadena)
        Else
            Dim obj As New apws0046.Pws0046
            resultado = obj.Execute(cadena)

        End If



        Dim arreglo As New ArrayList


        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then
            listanodoSedes = docXML.SelectNodes("/Respuesta/Caja")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes
                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText.TrimEnd
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText.TrimEnd
                Dim objlista As New ListaObj
                objlista.Codigo = codigo
                objlista.Descripcion = codigo + " " + descripcion
                arreglo.Add(objlista)
            Next


        End If
        Return arreglo

    End Function

End Class
