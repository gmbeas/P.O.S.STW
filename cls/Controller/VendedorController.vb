Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Xml


Public Class VendedorController
    Dim objLisaMs As New wsLisa.WS_Lisa
    Dim wsayudaVendedor As New wsBrowse.Pws0034



    Public Function Buscar(ByVal codvendedor As String) As VendedorObj

        Dim ds As DataSet = objLisaMs.GetVenedores("STE", "1", codvendedor)
        Dim objVendedor As New VendedorObj
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            objVendedor.codigo = codvendedor
            objVendedor.Nombre = dr("Nombre").ToString

        End If
        Return objVendedor
    End Function


    Public Function Ayuda(ByVal codigoEmpresa As String) As ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_empresa>" + codigoEmpresa + "</Documento_empresa>" & _
        "</Documento>"

        Dim arreglo As New ArrayList

        Dim resultado As String = wsayudaVendedor.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Vendedor")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objVendedores As New ListaObj
                objVendedores.Codigo = codigo
                objVendedores.Descripcion = descripcion
                objVendedores.Codigo_Padre = codigoEmpresa
                arreglo.Add(objVendedores)

            Next


        End If
        Return arreglo

    End Function


    Public Function GetNombreVendedor(ByVal codigoVendedor As String) As String
        Dim valor As String = ""
        Dim arr As ArrayList = Ayuda("Ste")

        For Each item As ListaObj In arr

            If item.Codigo = codigoVendedor Then
                valor = item.Descripcion
            End If


        Next
        Return valor

    End Function


End Class
