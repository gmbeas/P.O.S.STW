Imports System.Xml
Imports System.Data


Public Class ArticuloController











    Public Function GetArticuloCodigo(ByVal rutempresa As Integer, ByVal sku As String, ByVal listaprecio As String, ByVal espromo As String) As ArticuloObj

        'TOTALES

        Dim objArticulo As New ArticuloObj

        Dim ds As New DataSet

        If standalone = True Then
            Dim wsLisa As New _WS_LISA.WS_Lisa
            ds = wsLisa.ConsultaPos("PRE", "STE", _Sede, rutempresa, sku, 0, listaprecio)
        Else
            Dim wsLisa As New ws_lisa.WS_Lisa
            ds = wsLisa.ConsultaPos("PRE", "STE", _Sede, rutempresa, sku, 0, listaprecio, espromo)
        End If

        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            objArticulo.sku = dr("sku").ToString
            'objArticulo.descripcion = dr("NomCliente").ToString
            objArticulo.precio = Int32.Parse(dr("precio"))
            Dim iva As Double = Double.Parse(dr("Precio")) * 0.19
            iva = Math.Round(iva, 0)
            objArticulo.nombre = dr("nombre")
            objArticulo.unidadmedida = dr("um").ToString
            objArticulo.PrecioIva = dr("Bruto")'Math.Round(Double.Parse(dr("precio")) + iva, 0)
            objArticulo.Oferta = dr(0).ToString
            objArticulo.CBruto = Double.Parse(dr("Bruto"))
            objArticulo.CNeto = Double.Parse(dr("Neto"))
            objArticulo.CIva = Double.Parse(dr("Iva"))

        End If

        Return objArticulo
    End Function

    Public Function GetArticuloCodigoCantidad(ByVal rutempresa As Integer, ByVal sku As String, ByVal cantidad As Integer, ByVal lista As String, ByVal promocion As String) As ArticuloStringObj

        Dim objArticulo As New ArticuloStringObj

       
        Try
            Dim ds As New DataSet
            If standalone = True Then
                Dim wsLisa As New _WS_LISA.WS_Lisa
                ds = wsLisa.ConsultaPos("PRE", "STE", _Sede, rutempresa, sku, cantidad, lista)
            Else
                Dim wsLisa As New ws_lisa.WS_Lisa
                ds = wsLisa.ConsultaPos("PRE", "STE", _Sede, rutempresa, sku, cantidad, lista, promocion)
            End If

            If ds.Tables(0).Rows.Count <> 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                objArticulo.sku = dr("sku").ToString.Trim
                objArticulo.precio = Double.Parse(dr("precio")).ToString("N0")
                Dim iva As Integer = (Integer.Parse(dr("precio")) * 19) / 100
                objArticulo.PrecioIva = (Double.Parse(dr("PrecioBruto"))).ToString("N0")
                objArticulo.nombre = dr("nombre").ToString.Trim
                objArticulo.unidadmedida = dr("um").ToString.Trim
                objArticulo.cantidad = cantidad
                Dim totalneto As Double = cantidad * Int32.Parse(dr("Precio").ToString)
                Dim totaliva As Double = totalneto * 0.19
                objArticulo.valortotal = (Double.Parse(dr("Bruto"))).ToString("N0")'(totalneto + totaliva).ToString("N0")

                objArticulo.CBruto = Double.Parse(dr("Bruto"))
                objArticulo.CNeto = Double.Parse(dr("Neto"))
                objArticulo.CIva = Double.Parse(dr("Iva"))

                objArticulo.Envase = "C"
                If dr("Flag").ToString = "1" Then
                    objArticulo.Oferta = 1
                Else
                    objArticulo.Oferta = 0
                End If

                

                
            End If

            Return objArticulo
        Catch ex As Exception
            Dim objlog As New PosLog
            objlog.GuardaMvto("E", ex.ToString)
            objlog.ReportaError("ArticuloController", "GetArticuloCodigoCantidad", ex.ToString)

        End Try

    End Function


    Public Function ValidaUbicacionArticulo(ByVal codEmpresa As String, ByVal codArticulo As String, ByVal codBodega As String) As Boolean

        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + codEmpresa + "</Documento_empresa>" & _
       "<Documento_Articulo>" + codArticulo + "</Documento_Articulo>" & _
       "<Documento_Bodega>" + codBodega + "</Documento_Bodega>" & _
       "</Documento>"
        Dim resultado As String

        'modalidad standalone

        If standalone = True Then
            Dim ws08 As New _apws0008.Pws0008
            resultado = ws08.Execute(cadena)
        Else
            Dim ws08 As New apws0008.Pws0008
            resultado = ws08.Execute(cadena)
        End If

        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta")
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText

            Next


        End If


        Return True
    End Function


    Public Function AyudaArticulos(ByVal codigoEmpresa As String, ByVal ListaPrecio As String, ByVal articulo As String) As ArrayList

        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + codigoEmpresa + "</Documento_empresa>" & _
       "<Documento_lista_precios>" + ListaPrecio + "</Documento_lista_precios>" & _
       "<Documento_articulo>" + articulo + "</Documento_articulo>" & _
       "</Documento>"

        Dim resultado As String = ""

        If standalone = True Then
            Dim ws045 As New _apws0045.Pws0045
            resultado = ws045.Execute(cadena)
        Else
            Dim ws045 As New apws0045.Pws0045
            resultado = ws045.Execute(cadena)
        End If



        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta")
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText

            Next


        End If


        Return arreglo

    End Function


    ' valida codigo de barra
    Public Function ValidaArticulo(ByVal codigoempresa As String, ByVal articulo As String, ByVal barra As String) As ArrayList

        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + codigoempresa + "</Documento_empresa>" & _
       "<Documento_articulo>" + articulo + "</Documento_articulo>" & _
       "<Documento_barra>" + barra + "</Documento_barra>" & _
       "</Documento>"

        Dim resultado As String = ""

        If standalone = True Then
            Dim ws07 As New _apws0007.Pws0007
            resultado = ws07.Execute(cadena)
        Else
            Dim ws07 As New apws0007.Pws0007
            resultado = ws07.Execute(cadena)

        End If

        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta")
            'hay que terminarlo bien
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText

            Next


        End If

        Return arreglo

    End Function


    Public Function Filtro(ByVal tipo As String, ByVal patron As String, ByVal listaprecio As String) As DataSet
        Dim ds As New DataSet
        Try
            If standalone = True Then
                Dim wslisa As New _WS_LISA.WS_Lisa
                ds = wslisa.ConsultaProductosFiltrados(tipo.Trim, "STE", patron, listaprecio)
            Else
                Dim wslisa As New ws_lisa.WS_Lisa
                ds = wslisa.ConsultaProductosFiltrados(tipo.Trim, "STE", patron, listaprecio)

            End If


            Return ds
        Catch ex As Exception
            MsgBox("error:", ex.ToString)
            Dim objlog As New PosLog
            objlog.GuardaMvto("E", ex.ToString)
            objlog.ReportaError("ArticuloController.vb", "Filtro", ex.ToString)
            MsgBox("ERROR" + ex.ToString)

        End Try

    End Function


  

End Class
