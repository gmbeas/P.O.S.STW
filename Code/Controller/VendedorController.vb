Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Xml


Public Class VendedorController



    Public Function Buscar(ByVal codvendedor As String) As VendedorObj

        Dim ds As New DataSet

        If standalone = True Then
            Dim objLisaMs As New _WS_LISA.WS_Lisa
            ds = objLisaMs.GetVenedores("STE", "1", codvendedor)
        Else
            Dim objLisaMs As New ws_lisa.WS_Lisa
            ds = objLisaMs.GetVenedores("STE", "1", codvendedor)

        End If

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
        "<Documento_Empresa>" + codigoEmpresa + "</Documento_Empresa>" & _
        "</Documento>"

        Dim arreglo As New ArrayList
        Dim resultado As String = ""
        If standalone = True Then
            Dim wsayudaVendedor As New _apws0034.Pws0034
            resultado = wsayudaVendedor.Execute(cadena)
        Else
            Dim wsayudaVendedor As New apws0034.Pws0034
            resultado = wsayudaVendedor.Execute(cadena)
        End If



        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/DefinicionRespuesta/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/DefinicionRespuesta/Respuesta/Vendedor")
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

        Dim objven As VendedorObj = Buscar(codigoVendedor)

        Return objven.Nombre
   
    End Function


End Class
