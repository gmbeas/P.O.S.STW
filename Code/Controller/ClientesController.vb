Imports System.Data
Imports System.Xml
Imports System.IO


Public Class ClientesController


    Dim objWsbrowse As New apws0006.Pws0006


    Public Sub New()

    End Sub

    Public Function BuscaCliente(ByVal rut As String) As ClienteObj

        Dim objCliente As New ClienteObj
        Dim ds As New DataSet

        If standalone = True Then
            Dim objLisaMs As New _WS_LISA.WS_Lisa
            ds = objLisaMs.ConsultaPos("CLR", "STE", _Sede, rut, "", 0, 500)
        Else
            Dim objLisaMs As New ws_lisa.WS_Lisa
            ds = objLisaMs.ConsultaPos("CLR", "STE", _Sede, rut, "", 0, 500, "")
        End If

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
        Dim ds As New DataSet

        If standalone = True Then
            Dim objLisaMs As New _WS_LISA.WS_Lisa
            ds = objLisaMs.ConsultaPos("CLC", "STE", _Sede, rut, "", 0, 500)
        Else
            Dim objLisaMs As New ws_lisa.WS_Lisa
            ds = objLisaMs.ConsultaPos("CLC", "STE", _Sede, rut, "", 0, 500, "")
        End If



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

    Public Function filtrar(ByVal campo As String) As ArrayList

        Try
            Dim ARREGLO As New ArrayList
            Dim ds As New DataSet
            If standalone = True Then
                Dim objLisaMs As New _WS_LISA.WS_Lisa
                ds = objLisaMs.FiltroClientes(campo)
            Else
                Dim objLisaMs As New ws_lisa.WS_Lisa
                ds = objLisaMs.FiltroClientes(campo)
            End If



            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                Dim obj As New ListaObj
                obj.Codigo = dr("mbauxcod").ToString + "-" + dr("mbauxdv").ToString
                obj.Descripcion = dr("mbauxcod").ToString + "-" + dr("mbauxdv").ToString + "  " + dr("mbauxraz").ToString
                ARREGLO.Add(obj)

            Next


            Return ARREGLO
        Catch ex As Exception
            Dim objlog As New PosLog
            objlog.GuardaMvto("E", ex.ToString)
            objlog.ReportaError("ClientesController.vb", "Funcion Filtrar", ex.ToString)

        End Try



    End Function

    Public Function totalRegistrosCLR(ByVal rut As String) As Integer
        Dim ds As New DataSet

        If standalone = True Then
            Dim objLisaMs As New _WS_LISA.WS_Lisa
            ds = objLisaMs.ConsultaPos("CLR", "STE", _Sede, rut, "", 0, 500)
        Else
            Dim objLisaMs As New ws_lisa.WS_Lisa
            ds = objLisaMs.ConsultaPos("CLR", "STE", _Sede, rut, "", 0, 500, "")

        End If



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
        Dim resultado As String = ""



        Try
            If standalone = True Then
                Dim wsayudaContactoCLiente As New _apws0042.Pws0042
                resultado = wsayudaContactoCLiente.Execute(cadena)
            Else
                Dim wsayudaContactoCLiente As New apws0042.Pws0042
                resultado = wsayudaContactoCLiente.Execute(cadena)
            End If



        Catch ex As Exception

        End Try

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
        "<Documento_Empresa>" + codigoEmpresa + "</Documento_Empresa>" & _
        "<Documento_Cliente>" + codigoCliente + "</Documento_Cliente>" & _
        "</Documento>"

        Dim arreglo As New ArrayList
        Dim resultado As String = ""


        If standalone = True Then
            Dim objws39 As New _apws0039.Pws0039
            resultado = objws39.Execute(cadena)
        Else
            Dim objws39 As New apws0039.Pws0039
            resultado = objws39.Execute(cadena)
        End If


        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode

        docXML.SelectNodes("/DefinicionRespuesta/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/DefinicionRespuesta/Respuesta/Direcciones")
            Dim x As Integer = listanodoSedes.Count

            Dim objDir As New ListaObj
            objDir.Codigo = "-"
            objDir.Descripcion = "[SELECCIONAR]"
            arreglo.Add(objDir)

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

    Public Function GetDirecciones(ByVal codigoEmpresa As String, ByVal codigoCliente As String) As ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_Empresa>" + codigoEmpresa + "</Documento_Empresa>" & _
        "<Documento_Cliente>" + codigoCliente.Split("-")(0) + "</Documento_Cliente>" & _
        "</Documento>"

        Dim arreglo As New ArrayList
        Dim resultado As String = ""

        Try

            If standalone = True Then
                Dim objws39 As New _apws0039.Pws0039
                resultado = objws39.Execute(cadena)
            Else
                Dim objws39 As New apws0039.Pws0039
                resultado = objws39.Execute(cadena)
            End If


        Catch ex As Exception
            MsgBox("Error al Intentar Conectar el Servicio Web, verfique su conexion de Red ", MsgBoxStyle.Exclamation, "Error")
            Exit Function

        End Try


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


    Public Function GetDireccionComercial(ByVal arreglo As ArrayList, idcodigo As String) As DireccionObj

        For Each obj As DireccionObj In arreglo

            If obj.Codigo = idcodigo Then
                Return obj
            End If

        Next

        'For Each obj As DireccionObj In arreglo

        '    If obj.Codigo <> "888" Then
        '        Return obj
        '    End If

        'Next


    End Function


    Public Function GetGiroComercial(ByVal CodigoCliente As Integer) As String
        Dim giro As String = ""
        Dim ds As DataSet

        If standalone = True Then
            Dim objLisaMs As New _WS_LISA.WS_Lisa
            ds = objLisaMs.PerfilCliente("perfil", CodigoCliente)
        Else
            Dim objLisaMs As New ws_lisa.WS_Lisa
            ds = objLisaMs.PerfilCliente("perfil", CodigoCliente)
        End If


        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            giro = dr("descripciongiro").ToString
            
        End If
        Return giro

    End Function

    Public Function GetDireccionesSucursal(ByVal codigoEmpresa As String, ByVal codigoCliente As String) As ArrayList

        'Facturacion
        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_empresa>" + codigoEmpresa + "</Documento_empresa>" & _
        "<Documento_cliente>" + codigoCliente + "</Documento_cliente>" & _
        "</Documento>"

        Dim arreglo As New ArrayList

        Dim resultado As String = ""
        Try

            If standalone = True Then
                Dim objws39 As New _apws0039.Pws0039
                resultado = objws39.Execute(cadena)
            Else
                Dim objws39 As New apws0039.Pws0039
                resultado = objws39.Execute(cadena)
            End If



        Catch ex As Exception
            MsgBox("Error al Intentar Conectar el Servicio Web, verfique su conexion de Red ", MsgBoxStyle.Exclamation, "Error")
            Exit Function
        End Try

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

        codigoCliente = codigoCliente.Remove(codigoCliente.Length - 2, 2)

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_Empresa>" + codigoEmpresa + "</Documento_Empresa>" & _
        "<Documento_Cliente>" + codigoCliente + "</Documento_Cliente>" & _
        "</Documento>"

     
        Dim arreglo As New ArrayList
        Dim objPerfilCliente As New PerfilClienteObj
        Dim resultado As String = ""


        Try

            If standalone = True Then
                Dim objws0047 As New _apws0047.Pws0047
                resultado = objws0047.Execute(cadena)
            Else
                Dim objws0047 As New apws0047.Pws0047
                resultado = objws0047.Execute(cadena)
            End If



        Catch ex As Exception
            MsgBox("Error al Intentar Conectar el Servicio Web, verfique su conexion de Red ", MsgBoxStyle.Exclamation, "Error")
            Exit Function
        End Try


        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/DefinicionRespuesta/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then
            listanodoSedes = docXML.SelectNodes("/DefinicionRespuesta/Respuesta/Perfil")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                objPerfilCliente.rut = nodo.ChildNodes.Item(0).InnerText
                objPerfilCliente.dv = nodo.ChildNodes(1).InnerText
                objPerfilCliente.Nombre = nodo.ChildNodes(2).InnerText
                If nodo.ChildNodes(3).InnerText = "" Or nodo.ChildNodes(3).InnerText = "0" Then
                    objPerfilCliente.Lista_Precios = _ListaPrecioDefecto
                Else
                    objPerfilCliente.Lista_Precios = nodo.ChildNodes(3).InnerText
                End If

                If codigoCliente.ToString.Trim = "10" Then

                    objPerfilCliente.vendedor = _CodigoVendedorDefecto
                Else

                    objPerfilCliente.vendedor = nodo.ChildNodes(4).InnerText
                End If

                'objPerfilCliente.vendedor = nodo.ChildNodes(4).InnerText
                objPerfilCliente.termino = nodo.ChildNodes(5).InnerText
                objPerfilCliente.tipo_transporte = nodo.ChildNodes(6).InnerText
                objPerfilCliente.tipo_despacho = nodo.ChildNodes(7).InnerText
                objPerfilCliente.bodega = nodo.ChildNodes(8).InnerText
                objPerfilCliente.dcto1 = nodo.ChildNodes(9).InnerText
                objPerfilCliente.dcto2 = nodo.ChildNodes(10).InnerText
                objPerfilCliente.dcto3 = nodo.ChildNodes(11).InnerText
                objPerfilCliente.tipo = nodo.ChildNodes(12).InnerText
                'guardamos la dirección de facturación por defecto

                objPerfilCliente.Giro = GetGiroComercial(Int32.Parse(nodo.ChildNodes.Item(0).InnerText))


                Dim objdir As New DireccionesController
                objPerfilCliente.Direcciones = objdir.GetDirecciones(objPerfilCliente.rut)
                _direccionFacturacion = GetDireccionComercial(objPerfilCliente.Direcciones, "999")
                _direccionDespacho = GetDireccionComercial(objPerfilCliente.Direcciones, "888")

            Next
        End If

        Return objPerfilCliente

    End Function

    Public Function GetPerfil_(ByVal codigoEmpresa As String, ByVal codigoCliente As String) As PerfilClienteObj


        Dim rut2 As String = Replace(Mid(codigoCliente, 1, codigoCliente.IndexOf("-")), ".", "")

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_empresa>" + codigoEmpresa + "</Documento_empresa>" & _
        "<Documento_cliente>" + rut2 + "</Documento_cliente>" & _
        "</Documento>"

        Dim arreglo As New ArrayList
        Dim objPerfilCliente As New PerfilClienteObj
        Dim resultado As String = ""

        Try

            If standalone = True Then
                Dim objws0047 As New _apws0047.Pws0047
                resultado = objws0047.Execute(cadena)

            Else

                Dim objws0047 As New apws0047.Pws0047
                resultado = objws0047.Execute(cadena)

            End If


        Catch ex As Exception
            MsgBox("Error al Intentar Conectar el Servicio Web, verfique su conexion de Red ", MsgBoxStyle.Exclamation, "Error")
            Exit Function
        End Try

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

    Public Function TieneCredito(ByVal rut As Integer) As Integer

        Dim xml As New XmlDocument

        Dim INDCREDITO As String
        Dim resultado As System.Xml.XmlNode

        Try
            If standalone = True Then
                Dim Ws As New _WS_LISA.WS_Lisa
                resultado = Ws.ConsultaEstadoCliente("STE", rut)
                Ws.Dispose()
            Else
                Dim Ws As New ws_lisa.WS_Lisa
                resultado = Ws.ConsultaEstadoCliente("STE", rut)
                Ws.Dispose()
            End If


        Catch ex As Exception
            MsgBox("Error al Intentar Conectar el Servicio Web, verfique su conexion de Red ", MsgBoxStyle.Exclamation, "Error")
            Exit Function
        End Try


        xml.LoadXml(resultado.OuterXml)
        xml.SelectNodes("/ESTADOCLIENTE")
        If xml.GetElementsByTagName("INDCREDITO").Count > 0 Then
            INDCREDITO = xml.GetElementsByTagName("INDCREDITO").Item(0).InnerText().Trim
            Return INDCREDITO
        Else
            Throw New Exception("No existe registro cliente")
        End If
    End Function

    Function Giros() As ArrayList
        Dim arreglo As New ArrayList

        Dim ds As New DataSet

        If standalone = True Then
            Dim objLisaMs As New _WS_LISA.WS_Lisa
            ds = objLisaMs.Giros()
        Else
            Dim objLisaMs As New ws_lisa.WS_Lisa
            ds = objLisaMs.Giros()
        End If


        If ds.Tables(0).Rows.Count <> 0 Then

            For Each dr As DataRow In ds.Tables(0).Rows

                Dim obj As New ListaObj
                obj.Codigo = dr(0).ToString
                obj.Descripcion = dr(1).ToString
                arreglo.Add(obj)


            Next

        End If

        Return arreglo
    End Function

    Public Sub RegistroCliente(ByVal rut As String, ByVal dv As String, ByVal Nombre As String, ByVal giro As Integer, ByVal tipo As String)

        Try
            If standalone = True Then

                Dim objLisaMs As New _WS_LISA.WS_Lisa
                objLisaMs.AgregaCliente("STE", rut, dv, Nombre, Nombre, giro, "500", "10", "50", _VendedorDefecto, tipo)
            Else
                Dim objLisaMs As New ws_lisa.WS_Lisa
                objLisaMs.AgregaCliente("STE", rut, dv, Nombre, Nombre, giro, "500", "10", "50", _VendedorDefecto, tipo)

            End If


        Catch ex As Exception
            Dim objlog As New PosLog
            objlog.GuardaMvto("E", ex.ToString)
            objlog.ReportaError("ClientesController.vb", "Procedimiento RegistroCliente", ex.ToString)
            MsgBox("Error", MsgBoxStyle.Exclamation, "STEWARD")
        End Try



    End Sub

    Public Sub RegistraDireccionCliente(ByVal rut As String, ByVal detalle As String, ByVal region As Integer, ByVal ciudad As Integer, ByVal comuna As Integer)
        Try

            If standalone = True Then
                Dim objLisaMs As New _WS_LISA.WS_Lisa
                objLisaMs.AgregaDireccion(_Empresa, rut, detalle, region, ciudad, comuna, 1)
            Else
                Dim objLisaMs As New ws_lisa.WS_Lisa
                objLisaMs.AgregaDireccion(_Empresa, rut, detalle, region, ciudad, comuna, 1)
            End If

        Catch ex As Exception
            Dim objlog As New PosLog
            objlog.GuardaMvto("E", ex.ToString)
            objlog.ReportaError("ClientesController.vb", "RegistraDireccionCliente", ex.ToString)
            MsgBox("ERROR" + ex.ToString, MsgBoxStyle.Exclamation, "STEWARD")
        End Try


    End Sub

    Public Sub RegistraDireccion888(ByVal rut As Integer)
        Try
            If standalone = True Then
                Dim objLisaMs As New _WS_LISA.WS_Lisa
                objLisaMs.AgregaDireccion888(_Empresa, rut)
            Else
                Dim objLisaMs As New ws_lisa.WS_Lisa
                objLisaMs.AgregaDireccion888(_Empresa, rut)
            End If



        Catch ex As Exception
            Dim objlog As New PosLog
            objlog.GuardaMvto("E", ex.ToString)
            objlog.ReportaError("ClientesController.Vb", "RegistraDireccion888", ex.ToString)
            MsgBox("ERROR" + ex.ToString, MsgBoxStyle.Exclamation, "STEWARD")
        End Try
    End Sub

    Public Function ConsultaCobrador(cobrador As String) As String
        Dim ds As New DataSet
        Dim nombre As String
        If standalone = True Then
            Dim objLisaMs As New _WS_LISA.WS_Lisa
            ds = objLisaMs.ConsultaPos("COB", cobrador, "", "", "", 0, "")
        Else
            Dim objLisaMs As New ws_lisa.WS_Lisa

            ds = objLisaMs.ConsultaPos("COB", cobrador, "", "", "", 0, "", "")
        End If
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim drCabecera As DataRow = ds.Tables(0).Rows(0)
            nombre = drCabecera("GcVenNom").ToString()
        End If
        Return nombre
    End Function

    Public Function EstadoFinanciero(ByVal rut As String) As FichaCobranzaObj
        Dim objFichaCob As New FichaCobranzaObj

        Dim ds As New DataSet

        If standalone = True Then
            Dim objLisaMs As New _WS_LISA.WS_Lisa
            ds = objLisaMs.Cobranza(rut)
        Else
            Dim objLisaMs As New ws_lisa.WS_Lisa

            ds = objLisaMs.Cobranza(rut)
        End If

        If ds.Tables(0).Rows.Count <> 0 Then

            Dim drCabesera As DataRow = ds.Tables(0).Rows(0)
            objFichaCob.rut = Int32.Parse(drCabesera("CodigoCliente").ToString)
            objFichaCob.Nombre = drCabesera("NombreCliente").ToString
            objFichaCob.SaldoxPagar = Double.Parse(drCabesera("SaldoXPagar"))
            objFichaCob.Abonos = Double.Parse(drCabesera("abonos").ToString)
            objFichaCob.Cargos = Double.Parse(drCabesera("Cargos").ToString)

            Dim contador As Integer = 0
            Dim arreglo As New ArrayList

            For Each dr As DataRow In ds.Tables(0).Rows
                If contador <> 0 Then
                    If dr("CodigoDoc").ToString = "FAAF" Then
                        Dim objdoc As New DocumentoCobranzaObj
                        objdoc.TipoDocumento = dr("CodigoDoc").ToString
                        objdoc.numerodocumento = Int32.Parse(dr("NumeroDoc").ToString)
                        objdoc.Abono = Double.Parse(dr("Abonos").ToString)
                        objdoc.Cargo = Double.Parse(dr("Cargos").ToString)
                        objdoc.SaldoXPagar = Double.Parse(dr("SaldoXPagar").ToString)
                        objdoc.FechaEmision = dr("FechaEmiteDoc").ToString
                        objdoc.FechaVencimiento = dr("FechaVenceDoc").ToString
                        objdoc.Cobrador = dr("Cobrador").ToString()
                        arreglo.Add(objdoc)
                    End If


                End If

                contador = contador + 1
            Next

            objFichaCob.Documentos = arreglo

        End If

        Return objFichaCob

    End Function






End Class
