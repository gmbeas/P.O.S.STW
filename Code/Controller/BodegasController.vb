Imports Microsoft.VisualBasic
Imports System.Xml
Public Class BodegasController

    ' servicio ayuda Bodegas


    Public Function Ayuda(ByVal codigoempresa As String) As ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
         "<Documento>" & _
         "<Documento_empresa>" + codigoempresa + "</Documento_empresa>" & _
         "</Documento>"

        Dim arreglo As New ArrayList
        Dim resultado As String = ""

        If standalone = True Then
            Dim ws29 As New _apws0029.Pws0029
            resultado = ws29.Execute(cadena)
        Else
            Dim ws29 As New apws0029.Pws0029
            resultado = ws29.Execute(cadena)
        End If



        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Bodega")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText.Trim
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText.Trim
                Dim objContactosCliente As New ContactosClienteObj

                objContactosCliente.Codigo = codigo
                objContactosCliente.Descripcion = descripcion
                arreglo.Add(objContactosCliente)

            Next


        End If

        Return arreglo
    End Function

End Class
