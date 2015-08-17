Imports Microsoft.VisualBasic
Imports System.Xml

Public Class DocumentosPagoController

    Dim objws31 As New wsBrowse.Pws0031

    Public Function Get_todos() As ArrayList

        Dim arreglo As New ArrayList

        Dim resultado As String = objws31.Execute()
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Documento")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objDocumentosVenta As New DocumentosVentaObj
                objDocumentosVenta.Codigo = codigo
                objDocumentosVenta.Descripcion = descripcion
                arreglo.Add(objDocumentosVenta)

            Next


        End If

        Return arreglo
    End Function

End Class
