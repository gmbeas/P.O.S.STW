Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Xml



Public Class SucursalClienteController
   
    Public Function Ayuda(ByVal CodigoEmpresa As String, ByVal CodigoCliente As String) As ArrayList
        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + CodigoEmpresa + "</Documento_empresa>" & _
       "<Documento_cliente>" + CodigoCliente + "</Documento_cliente>" & _
       "</Documento>"
        Dim resultado As String = ""

        If standalone = True Then
            Dim objws As New _apws0043.Pws0043
            resultado = objws.Execute(cadena)
        Else
            Dim objws As New apws0043.Pws0043
            resultado = objws.Execute(cadena)

        End If



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
