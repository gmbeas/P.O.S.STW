Imports System.Data
Imports System.Xml



Public Class ClientesController

    Dim objLisaMs As New wsLisa.WS_Lisa
    Dim objWsbrowse As New wsBrowse.Pws0006
    Dim objws39 As New wsBrowse.Pws0039
    Dim wsayudaContactoCLiente As New wsBrowse.Pws0042
    Dim objws0047 As New wsBrowse.Pws0047



    Public Sub New()

    End Sub

    Public Function BuscaCliente(ByVal rut As String) As ClienteObj

        Dim objCliente As New ClienteObj

        Dim ds As DataSet = objLisaMs.ConsultaPos("CLR", "STE", rut, "", 0)
        Dim totalregistros As Integer = ds.Tables(0).Rows.Count

        If totalregistros > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            objCliente.id = Int32.Parse(dr("codcliente"))
            objCliente.nombre = dr("NomCliente").ToString
            objCliente.Vendedor = dr("vendedor").ToString
            objCliente.codigovendedor = dr("vendedorarr").ToString
            objCliente.Lista = dr("listaPrecio").ToString
        End If

        Return objCliente
    End Function


    Public Function BuscaClienteCLC(ByVal rut As Integer) As ArrayList

        Dim ARREGLO As New ArrayList
        Dim objCliente As New ClienteObj

        Dim ds As DataSet = objLisaMs.ConsultaPos("CLC", "STE", rut, "", 0)
        Dim totalregistros As Integer = ds.Tables(0).Rows.Count

        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows
            objCliente.id = Int32.Parse(dr("codcliente"))
            objCliente.nombre = dr("NomCliente").ToString
            objCliente.Vendedor = dr("vendedor").ToString
            objCliente.codigovendedor = dr("vendedorarr").ToString

        Next

        ARREGLO.Add(objCliente)
        Return ARREGLO
    End Function


    Public Function totalRegistrosCLR(ByVal rut As String) As Integer

        Dim ds As DataSet = objLisaMs.ConsultaPos("CLR", "STE", rut, "", 0)
        Dim totalregistros As Integer = ds.Tables(0).Rows.Count

        Return totalregistros

    End Function


    Public Function GetContacto(ByVal codigoempresa As String, ByVal codigocliente As String) As ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
         "<Documento>" & _
         "<Documento_empresa>" + codigoempresa + "</Documento_empresa>" & _
         "<Documento_cliente>" + codigocliente + "</Documento_cliente>" & _
         "</Documento>"

        Dim arreglo As New ArrayList

        Dim resultado As String = wsayudaContactoCLiente.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Contactos")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objContactosCliente As New ContactosClienteObj

                objContactosCliente.Codigo = codigo
                objContactosCliente.Descripcion = descripcion
                objContactosCliente.Codigo_Cliente = codigocliente
                arreglo.Add(objContactosCliente)

            Next


        End If

        Return arreglo
    End Function


    Public Function GetDireccionesTodas(ByVal codigoEmpresa As String, ByVal codigoCliente As String) As ArrayList

        'Facturacion
        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_empresa>" + codigoEmpresa + "</Documento_empresa>" & _
        "<Documento_cliente>" + codigoCliente + "</Documento_cliente>" & _
        "</Documento>"

        Dim arreglo As New ArrayList

        Dim resultado As String = objws39.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode

        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Direcciones")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objDirecciones As New ListaObj

                objDirecciones.Codigo = codigo
                objDirecciones.Descripcion = descripcion
                objDirecciones.Codigo_Padre = codigoCliente
                arreglo.Add(objDirecciones)

            Next


        End If

        Return arreglo
    End Function


    Public Function GetDireccionesSucursal(ByVal codigoEmpresa As String, ByVal codigoCliente As String) As ArrayList

        'Facturacion
        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_empresa>" + codigoEmpresa + "</Documento_empresa>" & _
        "<Documento_cliente>" + codigoCliente + "</Documento_cliente>" & _
        "</Documento>"

        Dim arreglo As New ArrayList

        Dim resultado As String = objws39.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode

        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Direcciones")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objDirecciones As New ListaObj

                objDirecciones.Codigo = codigo
                objDirecciones.Descripcion = descripcion
                objDirecciones.Codigo_Padre = codigoCliente
                arreglo.Add(objDirecciones)

            Next


        End If

        Return arreglo
    End Function


    Public Function GetPerfil(ByVal codigoEmpresa As String, ByVal codigoCliente As String) As PerfilClienteObj

        Dim rut2 As String = Replace(Mid(codigoCliente, 1, codigoCliente.IndexOf("-")), ".", "")

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_empresa>" + codigoEmpresa + "</Documento_empresa>" & _
        "<Documento_cliente>" + rut2 + "</Documento_cliente>" & _
        "</Documento>"

        Dim arreglo As New ArrayList
        Dim objPerfilCliente As New PerfilClienteObj
        Dim resultado As String = objws0047.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then
            listanodoSedes = docXML.SelectNodes("/Respuesta/Perfil")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText


                objPerfilCliente.rut = nodo.ChildNodes.Item(0).InnerText
                objPerfilCliente.dv = nodo.ChildNodes(1).InnerText
                objPerfilCliente.Nombre = nodo.ChildNodes(2).InnerText
                objPerfilCliente.Lista_Precios = nodo.ChildNodes(3).InnerText
                objPerfilCliente.vendedor = nodo.ChildNodes(4).InnerText
                objPerfilCliente.termino = nodo.ChildNodes(5).InnerText
                objPerfilCliente.tipo_transporte = nodo.ChildNodes(6).InnerText
                objPerfilCliente.tipo_despacho = nodo.ChildNodes(7).InnerText
                objPerfilCliente.bodega = nodo.ChildNodes(8).InnerText
                objPerfilCliente.dcto1 = nodo.ChildNodes(9).InnerText
                objPerfilCliente.dcto2 = nodo.ChildNodes(10).InnerText
                objPerfilCliente.dcto3 = nodo.ChildNodes(11).InnerText
                objPerfilCliente.tipo = nodo.ChildNodes(12).InnerText
                arreglo.Add(objPerfilCliente)
            Next



        End If

        Return objPerfilCliente

    End Function



    Public Function GetDireccionPorCodigo(ByVal codigoEmpresa As String, ByVal codigoCliente As String, ByVal codigo As Integer) As ListaObj

        Dim arreglo As ArrayList = GetDireccionesTodas(codigoEmpresa, codigoCliente)

        Dim objLista As New ListaObj

        For Each item As ListaObj In arreglo

            If item.Codigo = codigo Then
                objLista.Codigo = item.Codigo
                objLista.Descripcion = item.Descripcion
                objLista.Codigo_Padre = codigoEmpresa
            End If

        Next


        Return objLista
    End Function


    






End Class
