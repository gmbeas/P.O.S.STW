

Public Class DocumentoController


    Public Sub GuardarDocumento(ByVal nro As Integer, ByVal tipodoc As String, ByVal xml As String)
        Try


            If standalone = True Then
                '  Dim objpos As New _ws_pos.POS
                '  objpos.POS_Documentos("INSERTA", nro, tipodoc, Date.Now, xml)
            Else
                Dim objpos As New ws_pos.POS
                objpos.POS_Documentos("INSERTA", nro, tipodoc, Date.Now, xml)
            End If


        Catch ex As Exception
            MsgBox("Ha ocurrido un error, el Sistema a generado de forma automatica el reporte con el area de soporte", MsgBoxStyle.Exclamation, "ERROR 9000")
            Dim objlog As New PosLog
            objlog.GuardaMvto("E", ex.ToString)
            objlog.ReportaError("DocumentoController.Vb", "GuardarDocumento", ex.ToString)
            objlog.ReportaError(_Pos + "" + _usuario, "Error al intentar guardar el xml en base de datos", ex.ToString())
        End Try


    End Sub


    Public Function GetDocumento(ByVal nro As String) As String
        Dim doc As String = ""

        Dim DS As New DataSet

        If standalone = True Then
            ' Dim objpos As New _ws_pos.POS
            ' DS = objpos.POS_Documentos("CONSULTA", nro, "", Date.Now, "")
        Else
            Dim objpos As New ws_pos.POS
            DS = objpos.POS_Documentos("CONSULTA", nro, "", Date.Now, "")
        End If



        If DS.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = DS.Tables(0).Rows(0)
            doc = dr("xml").ToString
        End If

        Return doc

    End Function

    Public Function GetDoc(ByVal nro As String) As VentaObj

        Dim objDocument As New VentaObj
        Dim ds As New DataSet


        If standalone = True Then
            Dim ws As New _WS_LISA.WS_Lisa
            ds = ws.ConsultaPos("TD1", "STE", "", nro, _tipoDocumentoVenta, 0, "")
        Else
            Dim ws As New ws_lisa.WS_Lisa
            ds = ws.ConsultaPos("TD1", "STE", "", nro, _tipoDocumentoVenta, 0, "", "")
        End If

        If ds.Tables(0).Rows.Count <> 0 Then

            Dim dr As DataRow = ds.Tables(0).Rows(0)
            objDocument.Correlativo = dr("FolioTI").ToString
            objDocument.Cod_Cliente = dr("Cliente").ToString
            objDocument.FechaEmision = dr("FechaEmision").ToString
            objDocument.CodigoVendedor = dr("Vendedor").ToString
            objDocument.Lista = dr("ListaPrecio").ToString
            objDocument.CodigoVendedor = dr("Vendedor").ToString
            objDocument.Cod_Cliente = dr("Cliente").ToString

            objDocument.CodigoDireccion = dr("coddirfacturacion").ToString
            objDocument.DireccionFacturacion = dr("direccionCalle").ToString
            objDocument.Region = dr("region").ToString
            objDocument.Ciudad = dr("ciudad").ToString
            objDocument.Comuna = dr("comuna").ToString

            objDocument.CodigoDireccionDespa = dr("coddirfacturaciondespa").ToString
            objDocument.DireccionDespacho = dr("direccionCalledespa").ToString
            objDocument.RegionDespa = dr("regiondespa").ToString
            objDocument.CiudadDespa = dr("ciudaddespa").ToString
            objDocument.ComunaDespa = dr("comunadespa").ToString


            Dim X As String = dr("DctoDocVo".ToString)
            Dim valordecimal As Decimal = Decimal.Parse(X)
            objDocument.Descuento = Convert.ToDouble(dr("DctoDocVo".ToString)) 'Convert.ToInt32(valordecimal)
        End If

        Dim arregloArticulos As New ArrayList
        For i As Integer = 1 To ds.Tables(0).Rows.Count - 1
            Dim drDetalle As DataRow = ds.Tables(0).Rows(i)
            Dim objArticulo As New ArticuloStringObj
            objArticulo.sku = drDetalle("SKU").ToString
            objArticulo.precio = Double.Parse(drDetalle("PrecioPromedio")).ToString("N0")
            objArticulo.PrecioIva = Double.Parse(drDetalle("PrecioBruto")).ToString("N0")
            objArticulo.nombre = drDetalle("nombresku").ToString
            objArticulo.cantidad = drDetalle("CantDesp").ToString
            objArticulo.valortotal = Double.Parse(drDetalle("ValorBruto")).ToString("N0")
            objArticulo.unidadmedida = "CU"

          

            objArticulo.CBruto = Double.Parse(drDetalle("PrecioBruto"))
            objArticulo.CNeto = Double.Parse(drDetalle("PrecioNeto"))
            objArticulo.CIva =  Double.Parse(drDetalle("PrecioBruto"))  - Double.Parse(drDetalle("PrecioNeto"))

            arregloArticulos.Add(objArticulo)
        Next

        objDocument.ListaArticulos = arregloArticulos

        Return objDocument
    End Function


    Public Function verificaexistenciafolio(ByVal tipodocumento As String, ByVal FOLIO As String) As Boolean

        Dim valor As Boolean = False
        Dim ds As DataSet

        If standalone = True Then
            Dim ws_lisa As New _WS_LISA.WS_Lisa
            ds = ws_lisa.ConsultaPos("VFL", tipodocumento, FOLIO, "", "", 0, "")
        Else
            Dim ws_lisa As New ws_lisa.WS_Lisa
            ds = ws_lisa.ConsultaPos("VFL", tipodocumento, FOLIO, "", "", 0, "", "")

        End If


        If ds.Tables(0).Rows.Count <> 0 Then
            valor = True
        End If

        Return valor

    End Function


    Public Function VerificaExistenciaenWop(ByVal folio As String, ByVal tipodoc As String) As Boolean

        Dim DS As New DataSet
        If standalone = True Then
            ' Dim wswop As New _ws_pos.POS
            ' DS = wswop.POS_Documento("EXISTE", Now, folio, 0, "", tipodoc, "", 0, 0, 0)
        Else
            Dim wswop As New ws_pos.POS
            DS = wswop.POS_Documento("EXISTE", Now, folio, 0, "", tipodoc, "", 0, 0, 0)
        End If

        If DS.Tables(0).Rows.Count <> 0 Then
            Return True
        End If

        Return False
    End Function


    Public Function VerificaEstadoImpresion(ByVal folio As String, ByVal tipodoc As String) As Boolean


        Dim DS As New DataSet

        If standalone = True Then
            ' Dim wswop As New _ws_pos.POS
            ' DS = wswop.POS_Documento("EXISTE", Now, folio, 0, "", tipodoc, "", 0, 0, 0)
        Else
            Dim wswop As New ws_pos.POS
            DS = wswop.POS_Documento("EXISTE", Now, folio, 0, "", tipodoc, "", 0, 0, 0)
        End If


        Dim dr As DataRow

        If DS.Tables(0).Rows.Count <> 0 Then
            dr = DS.Tables(0).Rows(0)
            If dr("generada") = Nothing Then
                Return False
            End If

            If dr("generada").ToString = "0" Then
                Return False
            End If

        End If

        Return True
    End Function


    Public Sub CambiaEstadoImpresion(ByVal documento As String, ByVal tipodoc As String, ByVal estado As Integer)

        Try

            If standalone = True Then
                '  Dim objWs As New _ws_pos.POS
                ' objWs.POS_Documento("IMPRESION", Now, documento, 0, "", tipodoc, "", estado, 0, 0)
            Else
                Dim objWs As New ws_pos.POS
                objWs.POS_Documento("IMPRESION", Now, documento, 0, "", tipodoc, "", estado, 0, 0)
            End If

        Catch ex As Exception
            Throw New Exception(ex.ToString)
        End Try


    End Sub
 

End Class