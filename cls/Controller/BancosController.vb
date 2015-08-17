Imports Microsoft.VisualBasic
Imports System.Xml


Public Class BancosController
    Dim objws32 As New wsBrowse.Pws0032

    Public Function Ayuda() As ArrayList

        Dim arreglo As New ArrayList
        Dim resultado As String = objws32.Execute()
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode

        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Banco")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objDirecciones As New ListaObj

                objDirecciones.Codigo = codigo
                objDirecciones.Descripcion = descripcion
                arreglo.Add(objDirecciones)

            Next


        End If

        Return arreglo
    End Function



End Class
