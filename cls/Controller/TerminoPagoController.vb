Imports Microsoft.VisualBasic
Imports System.Xml

Public Class TerminoPagoController

    Dim obj30 As New wsBrowse.Pws0030

    Public Function Ayuda() As ArrayList
        Dim arreglo As New ArrayList

        Dim resultado As String = obj30.Execute()
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Sucursal")
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objSede As New SedeObj

                objSede.Codigo = codigo
                objSede.Descripcion = descripcion

                arreglo.Add(objSede)

            Next


        End If


        Return arreglo
    End Function

End Class
