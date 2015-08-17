Imports System.Net
Imports System.Net.Mail
Imports Microsoft.VisualBasic.CompilerServices

Module Module1

    Public _Ubicacion As String = ""

    Public standalone As Boolean = False

    Public _CentrodeGestion As String = ""

    Public _esVentaRecuperada As Boolean = False

    Public _cab_Id As Integer = 0

    Public _CreditoPendienteAutorizar As Boolean = False

    Public _DocumentosParaImpresion As New ArrayList

    Public _DocumentosAplicarPago As ArrayList

    Public _Modalidad As String = ""

    Public valoresParametrosCredito As ValoresCredito
    Public valoresParametrosDebito As ValoresDebito

    Public _NotasDeCredito As New ArrayList


    Public busquedaAlumno As Boolean = False
    Public teclacontrol As Boolean = False
    Public id_Cajero As Integer = 0
    Public _tipoDocumentoVenta As String = ""
    Public _listaPrecio As String
    Public cambiolistaPrecio As Boolean = False
    Public concepto As String = ""

    Public _CuentaCorriente As New CuentaCorrienteObj

    Public aprobacionchequesautorizacion As Boolean = False
    Public AprobacionExcesoCreditoSteward As Boolean = False
    Public AprobacionDeposito As Boolean = False

    Public _ArregloCheques As New ArrayList

    Public _cantidaditemsdetalle As Integer

    Public _usuario As String

    Public ArregloItems As New ArrayList

    Public copiaVenta As New VentaObj

    Public Function _GetDatoFtp(tipo As String) As String
        Dim ds As New DataSet
        Dim ws As New ws_pos.Pos
        ds = ws.POS_Parametros(tipo, "", "")

        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString
        Else
            Return ""

        End If
    End Function

    Public Function _GetNumeroLineas(caja As String) As Int32
        Dim aa = New ws_pos.Pos
        Dim aaa = aa.WPL_LeeParametrosAdminWeb("POS", "POS_MAXIMO_LINEAS", caja, "", "", 0)
        Dim au = aaa.Tables(0).Rows.Count
        If (au > 0) Then
            Dim dr = aaa.Tables(0).Rows(0)
            Return Int32.Parse(dr("Valor").ToString())
        Else
            Return 0
        End If
    End Function

    Public Function cadenaSql() As String
        If standalone = False Then
            Return "Server=10.81.13.11;Database=STEWARD_WEB ;User ID=sa;Password=web2010; Trusted_Connection=False;"
        Else
            Return "Server=DELTA;Database=pow ;User ID=sa;Password=; Trusted_Connection=False;"
        End If


    End Function


    'ACA IRAN LAS VARIABLES DEL ARCHIVO DE CONFIGURACION

    'VALOR CASA MATRIZ




    Public _AbonoCambio As String = "1"

    Public ventaInstanciada As New VentaObj

    Public _cargo_cambio As String = "1"

    Public rutaini As String = "c:\windows\Pos_Steward.ini"

    Public _banco As String

    Public _direccionFacturacion As New DireccionObj
    Public _direccionDespacho As New DireccionObj
    Public _perfilCliente As New PerfilClienteObj

    Public Function _FechaSistema() As String

        Dim fecha As DateTime = _Fecha()
        Return fecha.ToString("yyyyMMdd")
        ' Dim x As String = "20120101"
        'Return x

    End Function

    Public Function _FechaSistema_ImpresionRecupera(fecha As DateTime) As String

        'Dim fecha As DateTime = _Fecha()
        Dim dia As String = fecha.Day
        Dim mes As String = fecha.Month
        Dim ano As String = fecha.Year

        If mes = "01" Or mes = "1" Then
            mes = "ENERO"
        End If

        If mes = "02" Or mes = "2" Then
            mes = "FEBRERO"
        End If

        If mes = "03" Or mes = "3" Then
            mes = "MARZO"
        End If

        If mes = "04" Or mes = "4" Then
            mes = "ABRIL"
        End If

        If mes = "05" Or mes = "5" Then
            mes = "MAYO"
        End If

        If mes = "06" Or mes = "6" Then
            mes = "JUNIO"
        End If

        If mes = "07" Or mes = "7" Then
            mes = "JULIO"
        End If

        If mes = "08" Or mes = "8" Then
            mes = "AGOSTO"
        End If


        If mes = "09" Or mes = "9" Then
            mes = "SEPTIEMBRE"
        End If


        If mes = "10" Or mes = "10" Then
            mes = "OCTUBRE"
        End If

        If mes = "11" Or mes = "11" Then
            mes = "NOVIEMBRE"
        End If

        If mes = "12" Or mes = "12" Then
            mes = "DICIEMBRE"
        End If


        ' Dim x As String = "20120101"

        If dia.Length = 1 Then
            dia = dia.Insert(0, "0")
        End If

        Return dia + " " + mes + " " + ano

    End Function

    Public Function _FechaSistema_Impresion() As String

        Dim fecha As DateTime = _Fecha()
        Dim dia As String = fecha.Day
        Dim mes As String = fecha.Month
        Dim ano As String = fecha.Year

        If mes = "01" Or mes = "1" Then
            mes = "ENERO"
        End If

        If mes = "02" Or mes = "2" Then
            mes = "FEBRERO"
        End If

        If mes = "03" Or mes = "3" Then
            mes = "MARZO"
        End If

        If mes = "04" Or mes = "4" Then
            mes = "ABRIL"
        End If

        If mes = "05" Or mes = "5" Then
            mes = "MAYO"
        End If

        If mes = "06" Or mes = "6" Then
            mes = "JUNIO"
        End If

        If mes = "07" Or mes = "7" Then
            mes = "JULIO"
        End If

        If mes = "08" Or mes = "8" Then
            mes = "AGOSTO"
        End If


        If mes = "09" Or mes = "9" Then
            mes = "SEPTIEMBRE"
        End If


        If mes = "10" Or mes = "10" Then
            mes = "OCTUBRE"
        End If

        If mes = "11" Or mes = "11" Then
            mes = "NOVIEMBRE"
        End If

        If mes = "12" Or mes = "12" Then
            mes = "DICIEMBRE"
        End If


        ' Dim x As String = "20120101"

        If dia.Length = 1 Then
            dia = dia.Insert(0, "0")
        End If

        Return dia + " " + mes + " " + ano

    End Function

    Public Function _FechaSistemaWin()
        Dim fecha As DateTime = _Fecha()
        Return fecha
    End Function



    Public _ValorFlete As Double = 0




    Public Function _FechaComun() As String
        Dim fechacomun As String = ""

        Dim fecha As DateTime = _Fecha()
        'Dim dia As String = fecha.Day
        'Dim mes As String = fecha.Month()
        'Dim ano As String = fecha.Year

        'fechacomun = dia + "/" + mes + "/" + ano

        ' Return fechacomun
        Return fecha.ToString("dd/MM/yyyy")

    End Function


    Public _PuntoFacturacion As String

    Public Function _GetPuntoFacturacion() As String
        Dim Ini As New CIniClass
        ' Ini.Archivo = "c:\windows\Pos_Steward.ini"

        Return Ini.Readini(rutaini, "PUNTO", "pto")


    End Function

    Public _Pos As String


    Public _Bodega As String
    ' Dim Ini As New CIniClass
    ' Ini.Archivo = "c:\windows\Pos_Steward.ini"
    '  Return Ini.Readini(rutaini, "PUNTO", "bodega")
    ' End Function

    Public Function _GetPos() As String
        Dim Ini As New CIniClass
        ' Ini.Archivo = "c:\windows\Pos_Steward.ini"
        Return Ini.Readini(rutaini, "PUNTO", "pos")


    End Function

    Public _RutaLog As String = "pos_log.log"

    Public Function _GetRutaLog() As String
        Dim Ini As New CIniClass
        ' Ini.Archivo = "c:\windows\Pos_Steward.ini"
        Return Ini.Readini(rutaini, "RUTAS", "log")
    End Function


    Public Function _GetRutaMvto() As String
        Dim Ini As New CIniClass
        ' Ini.Archivo = "c:\windows\Pos_Steward.ini"
        Return Ini.Readini(rutaini, "RUTAS", "logM")


    End Function

    Public _CajaRecaudacion As String

    Public Function _GetCajaRecaudacion() As String
        ' Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "PUNTO", "caja")

        Dim ds As New DataSet

        If standalone = True Then
            ' Dim ws As New _ws_pos.POS
            'ds = ws.POS_Parametros("POS_CAJA", "", "")
        Else
            Try
                Dim ws As New ws_pos.Pos
                ds = ws.POS_Parametros("POS_CAJA", "", "")
            Catch ex As Exception
                MsgBox("cueck" + ex.ToString)
            End Try

        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If

    End Function



    Private _CajaPos As String
    Public Property CajaPos() As String
        Get
            Return _CajaPos
        End Get
        Set(ByVal value As String)
            _CajaPos = value
        End Set
    End Property


    Public _TerminosCheque As String

    Public Function _GetTerminosCheque() As String
        'Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "TERMINOSPAGO", "cheque")


        Dim ds As New DataSet

        If standalone = True Then
            '  Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_TERMINO_PAGO", "CHEQUE", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_TERMINO_PAGO", "CHEQUE", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If
    End Function


    Public _TerminosTarjetaCredito As String


    Public Function _GetTerminosTarjetaCredito() As String
        'Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "TERMINOSPAGO", "tdeb")

        Dim ds As New DataSet

        If standalone = True Then
            ' Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_TERMINO_PAGO", "CREDITO", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_TERMINO_PAGO", "CREDITO", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If

    End Function

    Public _Concepto As String

    Public Function _GetConcepto() As String

        ' Dim Ini As New CIniClass
        'concepto = Ini.Readini(rutaini, "PUNTO", "concepto")
        'Return concepto
        Dim ds As New DataSet

        If standalone = True Then
            ' Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_CONCEPTO", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_CONCEPTO", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If

    End Function


    Public _Moneda As String
    Public Function _GetMoneda() As String
        ' Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "COMERCIAL", "moneda")

        Dim ds As New DataSet

        If standalone = True Then
            'Dim ws As New _ws_pos.POS
            'ds = ws.POS_Parametros("POS_MONEDA", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_MONEDA", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If


    End Function


    Public _Empresa As String

    Public Function _GetEmpresa() As String
        'Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "GENERAL", "empresa")
        Dim ds As DataSet


        If standalone = True Then
            '  Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_EMPRESA", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_EMPRESA", "", "")
        End If

        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If

    End Function


    Public _CodigoBoleta As String
    Public Function _GetCodigoBoleta() As String
        '  Dim Ini As New CIniClass

        ' Return Ini.Readini(rutaini, "GENERAL", "codigoboleta")

        Dim ds As New DataSet

        If standalone = True Then
            ' Dim ws As New _ws_pos.POS
            '  ds = ws.POS_Parametros("POS_TIPO_DOCUMENTO", "BOLETA", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_TIPO_DOCUMENTO", "BOLETA", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If

    End Function


    Public _CodigoFactura As String
    Public Function _GetCodigoFactura() As String
        ' Dim Ini As New CIniClass
        ' Return Ini.Readini(rutaini, "GENERAL", "codigofactura")


        Dim ds As New DataSet

        If standalone = True Then
            ' Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_TIPO_DOCUMENTO", "FACTURA", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_TIPO_DOCUMENTO", "FACTURA", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If


    End Function


    Public _iva As Integer

    Public Function _Getiva() As Integer
        ' Dim Ini As New CIniClass
        ' Return Int32.Parse(Ini.Readini(rutaini, "GENERAL", "iva"))



        Dim ds As New DataSet

        If standalone = True Then
            '   Dim ws As New _ws_pos.POS
            '   ds = ws.POS_Parametros("POS_IVA", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_IVA", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If
    End Function

    Public _ListaPrecioDefecto As Integer

    Public Function _GetListaPrecioDefecto() As Integer
        'Dim Ini As New CIniClass
        'Return Int32.Parse(Ini.Readini(rutaini, "GENERAL", "listapreciodefectoventa"))

        Dim ds As New DataSet

        If standalone = True Then
            '  Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_LISTA_PRECIO_DEFECTO", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_LISTA_PRECIO_DEFECTO", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If
    End Function


    Public _Sede As String

    Public Function _GetSede() As String

        ' Dim Ini As New CIniClass
        ' Return Ini.Readini(rutaini, "PUNTO", "sede")


        Dim ds As New DataSet

        If standalone = True Then
            ' Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_SEDE", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_SEDE", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If

    End Function

    Public _VendedorDefecto As String

    Public Function _GetVendedorDefecto() As String
        Dim Ini As New CIniClass
        Return Ini.Readini(rutaini, "PUNTO", "Vendedor")
    End Function


    Public _VendedorDefectoNombre As String

    Public Function _GetVendedorDefectoNombre() As String
        Dim Ini As New CIniClass
        Return Ini.Readini(rutaini, "PUNTO", "nvendedor")
    End Function


    Public _RutaRespaldoXml As String
    Public Function _GetRutaRespaldoXml() As String
        'Dim Ini As New CIniClass
        ' Return Ini.Readini(rutaini, "RUTAS", "xml")


        Dim ds As New DataSet

        If standalone = True Then
            ' Dim ws As New _ws_pos.POS
            'ds = ws.POS_Parametros("POS_RUTAXML", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_RUTAXML2", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If
    End Function

    Public _RutaDocumentosImpresos As String
    Public Function _GetRutaDocumentosImpresos() As String
        '  Dim Ini As New CIniClass
        ' Return Ini.Readini(rutaini, "RUTAS", "documentosimpresos")

        Dim ds As New DataSet

        If standalone = True Then
            ' Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_RUTA_IMPRESION", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_RUTA_IMPRESION", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If

    End Function


    Public _RutaComprobantes As String

    Public Function _GetRutaComprobantes() As String
        Dim Ini As New CIniClass
        Return Ini.Readini(rutaini, "RUTAS", "comprobantes")
    End Function


    Public _RutaDocumentosPendientes As String
    Public Function _GetRutaDocumentosPendientes() As String
        Dim Ini As New CIniClass
        Return Ini.Readini(rutaini, "RUTAS", "pendientes")
    End Function

    Public _ImpresoraBoleta As String
    Public Function _GetImpresoraBoleta() As String
        Dim Ini As New CIniClass
        Return Ini.Readini(rutaini, "IMPRESORAS", "boleta")
    End Function


    Public _ImpresoraFactura As String
    Public Function _GetImpresoraFactura() As String
        Dim Ini As New CIniClass
        Return Ini.Readini(rutaini, "IMPRESORAS", "factura")
    End Function


    Public _TerminoPagoContadoEfectivo As Integer
    Public Function _GetTerminoPagoContadoEfectivo() As Integer
        ' Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "TERMINOSPAGO", "contadoefectivo")


        Dim ds As New DataSet

        If standalone = True Then
            'Dim ws As New _ws_pos.POS
            ' ds = ws.POS_Parametros("POS_TERMINO_PAGO", "EFECTIVO", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_TERMINO_PAGO", "EFECTIVO", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If

    End Function


    Public _TerminoPagoDebito As Integer
    Public Function _GetTerminoPagoDebito() As Integer
        'Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "TERMINOSPAGO", "debito")

        Dim ds As New DataSet

        If standalone = True Then
            'Dim ws As New _ws_pos.POS
            'ds = ws.POS_Parametros("POS_TERMINO_PAGO", "DEBITO", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_TERMINO_PAGO", "DEBITO", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If


    End Function


    Public _MontoCreditoSteward As Double
    Public Function _GetMontoCreditoSteward() As Double
        'Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "POLITICA", "montocreditosteward")



        Dim ds As New DataSet

        If standalone = True Then
            'Dim ws As New _ws_pos.POS
            'ds = ws.POS_Parametros("POS_CREDITO_STEWARD_MONTO", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_CREDITO_STEWARD_MONTO", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return dr("Valor").ToString

        Else
            Return ""

        End If
    End Function


    Public Function _MaximoLineasDetalle() As Integer
        ' Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "GENERAL", "maximolineasdetalle")

        Dim ds As New DataSet

        If standalone = True Then
            'Dim ws As New _ws_pos.POS
            'ds = ws.POS_Parametros("POS_MAXIMO_LINEAS", "", "")
        Else
            Dim ws As New ws_pos.Pos
            ds = ws.POS_Parametros("POS_MAXIMO_LINEAS", "", "")
        End If
        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Dim ax = dr("VALOR").ToString
            Dim pp = ax
            Return Convert.ToInt32(dr("VALOR").ToString)

        Else
            Return 0

        End If
    End Function


    Public Function _ROLSUPERVISOR() As Integer
        'Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "ROLES", "supervisor")


        Try
            Dim ds As New DataSet

            If standalone = True Then
                'Dim ws As New _ws_pos.POS
                'ds = ws.POS_Parametros("POS_ROLES", "SUPERVISOR", "")
            Else
                Dim ws As New ws_pos.Pos
                ds = ws.POS_Parametros("POS_ROLES", "SUPERVISOR", "")
            End If
            If ds.Tables.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Return Int32.Parse(dr("Valor").ToString)

            Else
                Return 0

            End If
        Catch ex As Exception

            Dim objLog As New PosLog
            objLog.GuardaMvto("E", ex.ToString)
            objLog.ReportaError("Module1", "_ROLSUPERVISOR", ex.ToString)
            MsgBox("ERROR" + ex.ToString, MsgBoxStyle.Exclamation, "ERROR")

        End Try





    End Function


    Public Function _ROLCAJERO() As Integer
        Dim Ini As New CIniClass
        Return Ini.Readini(rutaini, "ROLES", "cajero")
    End Function


    Public Function _DESCUENTOMAXIMO() As Integer
        'Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "DESC", "maximo")

        Try
            Dim ds As New DataSet

            If standalone = True Then
                ' Dim ws As New _ws_pos.POS
                'ds = ws.POS_Parametros("POS_DESCUENTO", "MAXIMO", "")
            Else
                Dim ws As New ws_pos.Pos
                ds = ws.POS_Parametros("POS_DESCUENTO", "MAXIMO", "")
            End If
            If ds.Tables.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Return Int32.Parse(dr("Valor").ToString)

            Else
                Return 0

            End If
        Catch ex As Exception
            Dim objLog As New PosLog
            objLog.GuardaMvto("E", ex.ToString)
            objLog.ReportaError("Module1", "_DESCUENTOMAXIMO", ex.ToString)
            MsgBox("ERROR" + ex.ToString, MsgBoxStyle.Exclamation, "ERROR")
        End Try


    End Function


    Public Function _DESCUENTOMINIMO() As Integer
        'Dim Ini As New CIniClass
        'Return Ini.Readini(rutaini, "DESC", "minimo")

        Try
            Dim ds As New DataSet

            If standalone = True Then
                '  Dim ws As New _ws_pos.POS
                ' ds = ws.POS_Parametros("POS_DESCUENTO", "MINIMO", "")
            Else
                Dim ws As New ws_pos.Pos
                ds = ws.POS_Parametros("POS_DESCUENTO", "MINIMO", "")
            End If
            If ds.Tables.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Return Int32.Parse(dr("Valor").ToString)

            Else
                Return 0

            End If
        Catch ex As Exception

            Dim objLog As New PosLog
            objLog.GuardaMvto("E", ex.ToString)
            objLog.ReportaError("Module1", "_DESCUENTOMINIMO", ex.ToString)
            MsgBox("ERROR" + ex.ToString, MsgBoxStyle.Exclamation, "ERROR")

        End Try

    End Function


    Public Function _MENSAJE_CONFIRMACION(ByVal msg As String, ByVal titulo As String) As Boolean

        Dim retorno As Boolean = False

        If MessageBox.Show(msg, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            retorno = True
        End If

        Return retorno

    End Function

    Structure Cheque

        Public nro As Integer
        Public nroCheque As String
        Public fecha As String
        Public monto As Double
        Public CtaCte As String
        Public banco As String
        Public rut As String


    End Structure

    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Function SoloNumerosComodin(ByVal Keyascii As Short) As Short
        If InStr("1234567890*", Chr(Keyascii)) = 0 Then
            SoloNumerosComodin = 0
        Else
            SoloNumerosComodin = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosComodin = Keyascii
            Case 13
                SoloNumerosComodin = Keyascii
        End Select
    End Function


    Function SoloNumerosSincero(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumerosSincero = 0
        Else
            SoloNumerosSincero = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosSincero = Keyascii
            Case 13
                SoloNumerosSincero = Keyascii
        End Select
    End Function


    Public Function _digitoverificador(ByVal rut As Integer) As String

        Dim rutdigito As String
        Dim Digito As Integer
        Dim Contador As Integer
        Dim Multiplo As Integer
        Dim Acumulador As Integer

        Contador = 2
        Acumulador = 0
        While rut <> 0
            Multiplo = (rut Mod 10) * Contador
            Acumulador = Acumulador + Multiplo
            rut = rut \ 10
            Contador = Contador + 1
            If Contador = 8 Then
                Contador = 2
            End If
        End While
        Digito = 11 - (Acumulador Mod 11)
        rutdigito = CStr(Digito)
        If Digito = 10 Then rutdigito = "K"
        If Digito = 11 Then rutdigito = "0"
        Return rutdigito

    End Function

    Public Structure ValoresCredito
        Dim termino As ListaObj
        Dim banco As ListaObj
        Dim tipoTarjeta As ListaObj
    End Structure

    Public Structure ValoresDebito
        Dim Banco As ListaObj
    End Structure

    Public esVentaRecuperada As Boolean = False


    Public Function _FechaBrowse(ByVal fecha As String) As String

        If fecha <> "" Then
            Dim largo As Integer = fecha.Length

            Dim año As String = fecha.Substring(largo - 4, 4)
            Dim mes As String = fecha.Substring(largo - 7, 2)
            Dim dia As String = fecha.Substring(largo - 10, 2)

            Return año + mes + dia

        Else
            Return ""

        End If


    End Function


    Public ExistenciaErroresFolios As Boolean = False


    Public Sub soloNumeros(ByVal e)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosComodin(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub


    Public Function _Fecha() As DateTime

        Dim obws As New ws_lisa.WS_Lisa
        Dim dr As DataRow = obws.ConsultaPos("FEC", "", "", "", "", 0, "500", "").Tables(0).Rows(0)
        Return DateTime.Parse(dr(0).ToString)


    End Function


    Private _conceptoVenta As String

    Public Property ConceptoVenta() As String
        Get
            Return _conceptoVenta
        End Get
        Set(ByVal value As String)
            _conceptoVenta = value
        End Set
    End Property



    Private CodigoVendedorDefecto_ As String
    Public Property _CodigoVendedorDefecto() As String
        Get
            Return CodigoVendedorDefecto_
        End Get
        Set(ByVal value As String)
            CodigoVendedorDefecto_ = value
        End Set
    End Property

    Private NumeroLineas_ As Int32
    Public Property _NumeroLineas() As Int32
        Get
            Return NumeroLineas_
        End Get
        Set(ByVal value As Int32)
            NumeroLineas_ = value
        End Set
    End Property


    Public Function _ValidaEstadoWebService(ByVal webservice As String) As Boolean

        Try

            Dim oHttpWebRequest As System.Net.HttpWebRequest
            Dim strURL As String = webservice

            oHttpWebRequest = Net.WebRequest.Create(strURL)

            oHttpWebRequest.GetResponse()


            If Not oHttpWebRequest.HaveResponse Then

                Return False
            End If


            Return True
        Catch ex As Exception

            Return False

        End Try



    End Function


    Public Function _EnviaMail(ByVal mensaje As String, ByVal emails As ArrayList) As Object
        Dim obj As Object
        Dim enumerator As IEnumerator = Nothing
        Dim correo As MailMessage = New MailMessage() With
        {
            .From = New MailAddress("cg@steward.cl")
        }
        Try
            enumerator = emails.GetEnumerator()
            While enumerator.MoveNext()
                Dim email As String = Conversions.ToString(enumerator.Current)
                correo.[To].Add(email)
            End While
        Finally
            '       If (TypeOf enumerator Is IDisposable) Then
            '(TryCast(enumerator, IDisposable)).Dispose()
            '       End If
        End Try
        correo.Subject = "ALERTA STOCK POS"
        correo.Body = mensaje
        correo.IsBodyHtml = False
        correo.Priority = MailPriority.Normal
        Dim smtp As SmtpClient = New SmtpClient() With
        {
            .Host = "pod51010.outlook.com",
            .Port = 25,
            .Credentials = New NetworkCredential("cg@steward.cl", "vespucio.2012"),
            .EnableSsl = True
        }
        Try
            smtp.Send(correo)
            obj = True
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            obj = False
            ProjectData.ClearProjectError()
        End Try
        Return obj
    End Function


End Module
