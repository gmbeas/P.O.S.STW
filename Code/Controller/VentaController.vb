Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic
Imports System.Xml
Imports StewardLib
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Printing


Public Class VentaController

    Dim objclienteC As New ClientesController
    Dim objEmpresaC As New EmpresaController
    Dim objDocumentoVenta As New DocumentosVentaController
    Dim wsRecibeVenta As New apws0049.Pws0049
    Dim objtrans As New Trans


    

    Public Function GetCorrelativo()

        Dim valor As Integer = 0

        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter("POS_INSERTA", cadenaSql)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            ' da.SelectCommand.Parameters.Add("@FechaAlta", SqlDbType.DateTime)

            da.Fill(ds)


            If ds.Tables(0).Rows.Count <> 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)

                valor = Int32.Parse(dr(0).ToString)

            End If

            Return valor
        Catch ex As Exception
            MsgBox("error:" + ex.ToString)
        End Try


    End Function





    Public Function GeneraDocumentoImpresionBoleta(ByVal obj As VentaObj)

        Dim arrDetalle As ArrayList = obj.ListaArticulos
        Dim strDetalle As String = ""
        Dim numeroLinea As Integer = 0
        Dim nombre As String = ""
        Dim linea_ As String = "                                                                                                                                                  "

        For Each objeto As ArticuloStringObj In arrDetalle

            linea_ = "                                                                                                                                                             "
            nombre = objeto.nombre


            If nombre.TrimEnd.Length >= 59 Then
                nombre = nombre.Substring(0, 56)
            End If

            numeroLinea = numeroLinea + 1

            linea_ = linea_.Insert(0, numeroLinea.ToString)
            linea_ = linea_.Insert(5, objeto.sku)
            linea_ = linea_.Insert(20, nombre)
            linea_ = linea_.Insert(82 - objeto.cantidad.ToString.Length, objeto.cantidad)
            linea_ = linea_.Insert(91, objeto.DescuentoLinea)
            linea_ = linea_.Insert(99, objeto.DescuentoLinea)
            linea_ = linea_.Insert(107 - objeto.PrecioIva.Replace(".", "").Trim.Length, objeto.PrecioIva.Replace(".", "").Trim)
            linea_ = linea_.Insert(116 - (objeto.PrecioIva * objeto.cantidad).ToString.Replace(".", "").Trim.Length, (objeto.PrecioIva * objeto.cantidad).ToString.Replace(".", "").Trim)

            strDetalle = strDetalle + vbNewLine + linea_
        Next

        Dim fuecorrecto As Boolean = False

        Dim oSW As New StreamWriter(_RutaDocumentosImpresos + obj.nro_Documento + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")

        Dim Linea As String = "HEADER: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TDocu: " & obj.DocumentoVenta
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Folio: " & obj.nro_Documento
        Linea = Linea & vbNewLine & ""

        If esVentaRecuperada = True Then
            Linea = Linea & "Femis: " & obj.FechaEmision
        Else
            Linea = Linea & "Femis: " & obj.FechaSistemaSlash
        End If



        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Fvcto: " & obj.FechaSistemaSlash
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RutCl: " & obj.rutCliente
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RSoci: " & obj.nombreCliente
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Direc: " & "AMERICO VESPUCIO NORTE 0655" ' _direccionFacturacion.Direccion
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Comun: " & "HUECHURABA" '_direccionFacturacion.Comuna 
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Ciuda: " & "SANTIAGO" '_direccionFacturacion.Ciudad
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "GiroC: " & "VENTA Y ARRIENDO DE PRODUCTOS GASTRONOMICOS"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FonoC: " & "7566000"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Vende: " & obj.nombreVendedor
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Sucur: " & "VESPUCIO NORTE"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TipTR: Venta"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "cajer: " & _usuario
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Caja : " & _Pos
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FPAGO: " & obj.FormaPago
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "           "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TADct: " & obj.subtotal
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Dscto: " & obj.Descuento
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "NetoT: " & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "IvaDo: " & obj.iva
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TotBr: " & obj.total
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "OComp: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FecOC: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FPago: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse1: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse2: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse3: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "DETALLE :"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Li     Codigo                       Pro Descripcion                         Cantidad   Dcto  Dctop  Precio  TotItem"
        Linea = Linea & strDetalle
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "REFERENCIA :"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TdoRe          FecRef:                    TipRe:  RazRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Nota"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TDoRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TipRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FolRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FecRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RazRe:"

        Dim printProfactura = New PrinterSettings
        printProfactura.PrinterName = "PROFACTURA"
        'printProfactura.PrinterName = "PROFACTURA_PHURTADO"
        RawPrinterHelper.SendStringToPrinter(printProfactura.PrinterName, Linea.TrimEnd())

        oSW.WriteLine(Linea)
        oSW.Flush()
        oSW.Close()

    End Function



#Region "RawPrinterHelper"
    Public Class RawPrinterHelper

        ' Structure and API declarions:
        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
        Public Class DOCINFOA

            <MarshalAs(UnmanagedType.LPStr)> _
            Public pDocName As String

            <MarshalAs(UnmanagedType.LPStr)> _
            Public pOutputFile As String

            <MarshalAs(UnmanagedType.LPStr)> _
            Public pDataType As String
        End Class

        Public Declare Function OpenPrinter Lib "winspool.Drv" Alias "OpenPrinterA" (ByVal szPrinter As String, ByRef hPrinter As IntPtr, ByVal pd As IntPtr) As Boolean

        Public Declare Function ClosePrinter Lib "winspool.Drv" Alias "ClosePrinter" (ByVal hPrinter As IntPtr) As Boolean

        Public Declare Function StartDocPrinter Lib "winspool.Drv" Alias "StartDocPrinterA" (ByVal hPrinter As IntPtr, ByVal level As Int32, ByVal di As DOCINFOA) As Boolean

        Public Declare Function EndDocPrinter Lib "winspool.Drv" Alias "EndDocPrinter" (ByVal hPrinter As IntPtr) As Boolean

        Public Declare Function StartPagePrinter Lib "winspool.Drv" Alias "StartPagePrinter" (ByVal hPrinter As IntPtr) As Boolean

        Public Declare Function EndPagePrinter Lib "winspool.Drv" Alias "EndPagePrinter" (ByVal hPrinter As IntPtr) As Boolean

        Public Declare Function WritePrinter Lib "winspool.Drv" Alias "WritePrinter" (ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean

        ' SendBytesToPrinter()
        ' When the function is given a printer name and an unmanaged array
        ' of bytes, the function sends those bytes to the print queue.
        ' Returns true on success, false on failure.
        Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
            Dim dwWritten As Int32 = 0
            Dim dwError As Int32 = 0
            Dim hPrinter As IntPtr = New IntPtr(0)
            Dim di As DOCINFOA = New DOCINFOA
            Dim bSuccess As Boolean = False
            ' Assume failure unless you specifically succeed.
            di.pDocName = "My C#.NET RAW Document"
            di.pDataType = "RAW"
            ' Open the printer.
            If OpenPrinter(szPrinterName.Normalize, hPrinter, IntPtr.Zero) Then
                ' Start a document.
                If StartDocPrinter(hPrinter, 1, di) Then
                    ' Start a page.
                    If StartPagePrinter(hPrinter) Then
                        ' Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                        EndPagePrinter(hPrinter)
                    End If
                    EndDocPrinter(hPrinter)
                End If
                ClosePrinter(hPrinter)
            End If
            ' If you did not succeed, GetLastError may give more information
            ' about why not.
            If (bSuccess = False) Then
                dwError = Marshal.GetLastWin32Error
            End If
            Return bSuccess
        End Function

        Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
            ' Open the file.
            Dim fs As FileStream = New FileStream(szFileName, FileMode.Open)
            ' Create a BinaryReader on the file.
            Dim br As BinaryReader = New BinaryReader(fs)
            ' Dim an array of bytes big enough to hold the file's contents.
            Dim bytes() As Byte = New Byte((fs.Length) - 1) {}
            Dim bSuccess As Boolean = False
            ' Your unmanaged pointer.
            Dim pUnmanagedBytes As IntPtr = New IntPtr(0)
            Dim nLength As Integer
            nLength = Convert.ToInt32(fs.Length)
            ' Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength)
            ' Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength)
            ' Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength)
            ' Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength)
            ' Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes)
            Return bSuccess
        End Function

        Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String) As Boolean
            Dim pBytes As IntPtr
            Dim dwCount As Int32
            ' How many characters are in the string?
            dwCount = szString.Length
            ' Assume that the printer is expecting ANSI text, and then convert
            ' the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString)
            ' Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount)
            Marshal.FreeCoTaskMem(pBytes)
            Return True
        End Function
    End Class
#End Region

    Public Function GeneraCombrobantePagoDocumento(ByVal documentos As ArrayList, ByVal totalpago As Double) As String

        Dim strDetalle As String = ""
        Dim numeroLinea As Integer = 0
        Dim nombre As String = ""
        Dim linea_ As String = " "

        strDetalle = "Nro Doc.    Saldo"
        For Each doc As DocumentoObj In documentos
            Dim saldo As String = doc.SaldoXPagar.ToString("N0")
            linea_ = doc.Folio + "        " + saldo
            strDetalle = strDetalle + vbNewLine + linea_
        Next

        Dim oSW As New StreamWriter(_RutaComprobantes + "comprobante.log")

        Dim Linea As String = "           Steward S.A"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "            96644100-3"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "COMPROBANTE DE PAGO"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Sede: " & _Sede + "    Caja:" + _Pos
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Cajero:" & id_Cajero
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Total Pago:" & totalpago.ToString
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Detalle:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & strDetalle & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "GRACIAS POR PREFERIRNOS!:"
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "      www.steward.cl  "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""

        oSW.WriteLine(Linea)

        oSW.Flush()
        oSW.Close()

        Return _RutaComprobantes + "comprobante.log"
    End Function




    Public Function GeneraDocumentoImpresionBoleta_old(ByVal obj As VentaObj)

        Dim arrDetalle As ArrayList = obj.ListaArticulos
        Dim strDetalle As String = ""
        Dim numeroLinea As Integer = 0
        Dim nombre As String = ""
        Dim linea_ As String = "                                                                                                                                                  "

        For Each objeto As ArticuloStringObj In arrDetalle
            linea_ = "                                                                                                                                                             "
            nombre = objeto.nombre
            numeroLinea = numeroLinea + 1
            linea_ = linea_.Insert(0, numeroLinea.ToString)
            linea_ = linea_.Insert(5, objeto.sku)
            linea_ = linea_.Insert(17, objeto.nombre)
            linea_ = linea_.Insert(objeto.cantidad.ToString.Length, objeto.cantidad)
            linea_ = linea_.Insert(90, objeto.Descuento)
            linea_ = linea_.Insert(98, objeto.Descuento)
            linea_ = linea_.Insert(102, objeto.precio)
            linea_ = linea_.Insert(110, (objeto.precio * objeto.cantidad).ToString)

            strDetalle = strDetalle + vbNewLine + linea_
        Next

        Dim fuecorrecto As Boolean = False

        Dim oSW As New StreamWriter(_RutaDocumentosImpresos + obj.nro_Documento + ".txt")

        Dim Linea As String = "HEADER: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TDocu: " & obj.DocumentoVenta
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Folio: " & obj.nro_Documento
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Femis: " & obj.FechaSistemaSlash
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Fvcto: " & obj.FechaSistemaSlash
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RutCl: " & obj.rutCliente
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RSoci: " & obj.nombreCliente
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Direc: " & "AMERICO VESPUCIO NORTE 0655" ' _direccionFacturacion.Direccion
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Comun: " & "HUECHURABA" '_direccionFacturacion.Comuna 
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Ciuda: " & "SANTIAGO" '_direccionFacturacion.Ciudad
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "GiroC: " & "VENTA Y ARRIENDO DE PRODUCTOS GASTRONOMICOS"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FonoC: " & "7566000"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Vende: " & obj.nombreVendedor
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Sucur: " & "VESPUCIO NORTE"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TipTR: Venta"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "cajer: " & _usuario
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Caja : " & _Pos
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FPAGO: " & obj.FormaPago
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "           "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TADct: " & obj.subtotal
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Dscto: " & obj.Descuento
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "NetoT: " & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "IvaDo: " & obj.iva
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TotBr: " & obj.total
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "OComp: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FecOC: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FPago: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse1: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse2: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse3: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "DETALLE :"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Li     Codigo                       Pro Descripcion                         Cantidad   Dcto  Dctop  Precio  TotItem"
        Linea = Linea & strDetalle
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "REFERENCIA :"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TdoRe          FecRef:                    TipRe:  RazRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Nota"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TDoRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TipRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FolRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FecRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RazRe:"

        oSW.WriteLine(Linea)
        oSW.Flush()
        oSW.Close()



    End Function

    Public Function GeneraDocumentoImpresionFactura_old(ByVal obj As VentaObj, ByVal descuento As Boolean)

        Dim arrDetalle As ArrayList = obj.ListaArticulos
        Dim strDetalle As String = ""
        Dim numeroLinea As Integer = 0
        Dim nombre As String = ""
        Dim linea_ As String = "                                                                                                                                                  "

        For Each objeto As ArticuloStringObj In arrDetalle

            Dim nombre_ As String = objeto.nombre

            If nombre_.Length > 39 Then
                nombre_ = nombre_.Substring(0, 38)
            End If

            Dim precio_ As Double = objeto.precio
            Dim descuento_ As Double = objeto.Descuento

            If descuento = True Then

                precio_ = precio_ - ((objeto.precio * objeto.PorcentajeDescuento) / 100)
            End If


            linea_ = "                                                                                                                                                             "
            nombre = objeto.nombre
            numeroLinea = numeroLinea + 1
            linea_ = linea_.Insert(0, numeroLinea.ToString)
            linea_ = linea_.Insert(5, objeto.sku)
            linea_ = linea_.Insert(17, nombre_)
            linea_ = linea_.Insert(66, objeto.cantidad)
            linea_ = linea_.Insert(70, objeto.Descuento)
            linea_ = linea_.Insert(80, objeto.Descuento)
            linea_ = linea_.Insert(85, precio_.ToString.Replace(".", ""))
            linea_ = linea_.Insert(95, (precio_ * objeto.cantidad).ToString)

            strDetalle = strDetalle + vbNewLine + linea_
        Next

        Dim fuecorrecto As Boolean = False

        Dim oSW As New StreamWriter(_RutaDocumentosImpresos + obj.nro_Documento + ".txt")

        Dim subtotal As Double = 0
        Dim desc As Double = 0

        If descuento = False Then
            subtotal = obj.Bruto
            desc = 0
        Else
            subtotal = obj.subtotal
            desc = obj.Descuento
        End If

        Dim Linea As String = "HEADER: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TDocu: " & obj.DocumentoVenta
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Folio: " & obj.nro_Documento
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Femis: " & obj.FechaSistemaSlash
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Fvcto: " & obj.FechaSistemaSlash
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RutCl: " & obj.rutCliente
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RSoci: " & obj.nombreCliente
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Direc: " & _direccionFacturacion.Direccion
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Comun: " & _direccionFacturacion.DescripcionComuna
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Ciuda: " & _direccionFacturacion.DescripcionCiudad
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "GiroC: " & obj.PerfilCliente.Giro
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FonoC: " & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Vende: " & obj.nombreVendedor
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Sucur: " & "V"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TipTR: Venta"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "cajer: " & _usuario
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Caja : " & _Pos
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FPAGO: " & obj.FormaPago
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "           "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TADct: " & subtotal
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Dscto: " & desc
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "NetoT: " & obj.Bruto
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "IvaDo: " & obj.iva
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TotBr: " & obj.total
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "OComp: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FecOC: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FPago: " & obj.FormaPago
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse1: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse2: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Obse3: "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "DETALLE :"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Li     Codigo                       Pro Descripcion                         Cantidad   Dcto  Dctop  Precio  TotItem"
        Linea = Linea & strDetalle
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "REFERENCIA :"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TdoRe          FecRef:                    TipRe:  RazRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "Nota"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TDoRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "TipRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FolRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "FecRe:"
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "RazRe:"

        oSW.WriteLine(Linea)
        oSW.Flush()
        oSW.Close()



    End Function




    Public Function GeneraDocumentoImpresionFactura(ByVal obj As VentaObj, ByVal descuento As Boolean)

        Dim arrDetalle As ArrayList = obj.ListaArticulos
        Dim strDetalle As String = ""
        Dim numeroLinea As Integer = 0
        Dim nombre As String = ""
        Dim linea_ As String = "                                                                                                                                                                            "

        Dim contadorArticulos As Integer = 0
        For Each objeto As ArticuloStringObj In arrDetalle
            contadorArticulos = contadorArticulos + 1

            Dim nombre_ As String = objeto.nombre

            If nombre_.Length > 39 Then
                nombre_ = nombre_.Substring(0, 38)
            End If

            If nombre_.Contains("º") Then
                nombre_ = nombre_.Replace("º", "")
            End If

            If nombre_.Contains("°") Then
                nombre_ = nombre_.Replace("°", "")
            End If

            Dim precio_ As Double = objeto.precio
            Dim descuento_ As Double = objeto.Descuento

            If descuento = True Then

                precio_ = precio_ - ((objeto.precio * objeto.PorcentajeDescuento) / 100)
            End If


            linea_ = "                                                                                                                                                                                   "
            nombre = nombre_
            numeroLinea = numeroLinea + 1

            If nombre.Length > 39 Then
                nombre = nombre.Substring(0, 38)
            End If
            linea_ = linea_.Insert(7, objeto.sku)
            linea_ = linea_.Insert(31 - objeto.cantidad.ToString.Length, objeto.cantidad)
            linea_ = linea_.Insert(35, nombre)
            linea_ = linea_.Insert(82 - objeto.unidadmedida.ToString.Length, objeto.unidadmedida)
            linea_ = linea_.Insert(93 - obj.Descuento.ToString.Length, objeto.DescuentoLinea)
            linea_ = linea_.Insert(112 - objeto.precio.Trim.Length, objeto.precio.Replace(".", ""))
            linea_ = linea_.Insert(132 - (objeto.precio * objeto.cantidad).ToString.Replace(".", "").ToString.Length, (objeto.precio * objeto.cantidad).ToString.Replace(".", ""))
            strDetalle = strDetalle + vbNewLine + linea_

        Next

        If contadorArticulos < 24 Then

            For i As Integer = 1 To 24 - contadorArticulos

                strDetalle = strDetalle + vbNewLine + "         "
            Next

        End If



        Dim fuecorrecto As Boolean = False

        Dim pp = _RutaDocumentosImpresos + obj.nro_Documento + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"

        Dim oSW As New StreamWriter(_RutaDocumentosImpresos + obj.nro_Documento + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt")


        Dim lineaCorrelativo As String = "                                                                                                                                                          "
        lineaCorrelativo = lineaCorrelativo.Insert(116, obj.Correlativo)


        Dim aa = _FechaSistema_ImpresionRecupera(Convert.ToDateTime(obj.FechaEmision))


        Dim lineaFecha As String = "                                                                                                                "
        Try

            If esVentaRecuperada = True Then
                lineaFecha = lineaFecha.Insert(27, _FechaSistema_ImpresionRecupera(Convert.ToDateTime(obj.FechaEmision)))
            Else
                lineaFecha = lineaFecha.Insert(27, _FechaSistema_Impresion)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

       


        lineaFecha = lineaFecha.Insert(84, "Contrato")
        lineaFecha = lineaFecha.Insert(101, "0")
        lineaFecha = lineaFecha.Insert(113, "VENTAS POS ")

        Dim LineaFechaVencimiento As String = "                                                                       "
        LineaFechaVencimiento = LineaFechaVencimiento.Insert(29, obj.FechaVencimiento)

        Dim lineaSubTotal As String = "                                                                                                                                           "
        lineaSubTotal = lineaSubTotal.Insert(59, "Subtotal: " + String.Format("{0:000,000,000}", Int32.Parse(obj.subtotal)))
        'lineaSubTotal = lineaSubTotal.Insert(132 - obj.subtotal.Length, "Subtotal:" + String.Format("{0:000000000}", Int32.Parse(obj.subtotal)))
        Dim lineaDescuento As String = "                                                                                                                                                             "

        If obj.Descuento <> 0 Then
            'lineaDescuento = lineaDescuento.Insert(100 - obj.PorcentajeDescuento.ToString.Length, obj.PorcentajeDescuento)
            'lineaDescuento = lineaDescuento.Insert(101, "%")
            'lineaDescuento = lineaDescuento.Insert(104, "Desc")
            lineaDescuento = lineaDescuento.Insert(59, "Desc:     " + String.Format("{0:000,000,000}", Int32.Parse(obj.Descuento.ToString)))
        Else
            lineaDescuento = lineaDescuento.Insert(59, "Desc:     000.000.000")
        End If

        Dim lineaFlete As String = "                                                                                                                                              "

        If obj.Flete <> 0 Then
            lineaFlete = lineaFlete.Insert(59, "Flete:    " + String.Format("{0:000,000,000}", Int32.Parse(obj.Flete)))
        Else
            lineaFlete = lineaFlete.Insert(59, "Flete:    000.000.000")
        End If

        Dim lineaNeto As String = "                                                                                                                                  "
        lineaNeto = lineaNeto.Insert(59, "Neto:     " + String.Format("{0:000,000,000}", Int32.Parse(obj.Neto)))
        Dim LineaIva As String = "                                                                                                                                   "
        LineaIva = LineaIva.Insert(59, "Iva:      " + String.Format("{0:000,000,000}", Int32.Parse(obj.iva)))
        Dim LineaTotal As String = "                                                                                                                                  "
        LineaTotal = LineaTotal.Insert(59, "Total:    " + String.Format("{0:000,000,000}", Int32.Parse(obj.total)))

        Dim Linea As String = ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaCorrelativo
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & lineaFecha
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                    " + obj.RazonSocial
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                      " + obj.rutCliente
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                    " + _direccionFacturacion.Direccion.Trim + "," + _direccionFacturacion.DescripcionCiudad.Trim + "," + _direccionFacturacion.DescripcionComuna.Trim
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                             " + obj.FormaPago
        Linea = Linea & vbNewLine & ""
        Linea = Linea & LineaFechaVencimiento
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                    " + obj.PerfilCliente.Giro
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & strDetalle
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaSubTotal
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaDescuento
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaFlete
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaNeto & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & LineaIva & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & LineaTotal

        Dim printProFactura = New PrinterSettings()
        printProFactura.PrinterName = "PROFACTURA"
        'printProFactura.PrinterName = "PROFACTURA_PHURTADO"

        RawPrinterHelper.SendStringToPrinter(printProFactura.PrinterName, Linea.TrimEnd())

        oSW.WriteLine(Linea)
        oSW.Flush()
        oSW.Close()



    End Function


    Public Function GeneraStringFactura(ByVal obj As VentaObj, ByVal descuento As Boolean) As String

        Dim arrDetalle As ArrayList = obj.ListaArticulos
        Dim strDetalle As String = ""
        Dim numeroLinea As Integer = 0
        Dim nombre As String = ""
        Dim linea_ As String = "                                                                                                                                                  "

        Dim contadorArticulos As Integer = 0
        For Each objeto As ArticuloStringObj In arrDetalle
            contadorArticulos = contadorArticulos + 1

            Dim nombre_ As String = objeto.nombre

            If nombre_.Length > 39 Then
                nombre_ = nombre_.Substring(0, 38)
            End If

            If nombre_.Contains("º") Then
                nombre_ = nombre_.Replace("º", "")
            End If

            If nombre_.Contains("°") Then
                nombre_ = nombre_.Replace("°", "")
            End If

            Dim precio_ As Double = objeto.precio
            Dim descuento_ As Double = objeto.Descuento

            If descuento = True Then

                precio_ = precio_ - ((objeto.precio * objeto.PorcentajeDescuento) / 100)
            End If


            linea_ = "                                                                                                                                                             "
            nombre = nombre_
            numeroLinea = numeroLinea + 1

            If nombre.Length > 39 Then
                nombre = nombre.Substring(0, 38)
            End If
            linea_ = linea_.Insert(7, objeto.sku)
            linea_ = linea_.Insert(31 - objeto.cantidad.ToString.Length, objeto.cantidad)
            linea_ = linea_.Insert(35, nombre)
            linea_ = linea_.Insert(82 - objeto.unidadmedida.ToString.Length, objeto.unidadmedida)
            linea_ = linea_.Insert(93 - obj.Descuento.ToString.Length, objeto.Descuento)
            linea_ = linea_.Insert(112 - objeto.precio.Trim.Length, objeto.precio.Replace(".", ""))
            linea_ = linea_.Insert(132 - (objeto.precio * objeto.cantidad).ToString.Replace(".", "").ToString.Length, (objeto.precio * objeto.cantidad).ToString.Replace(".", ""))
            strDetalle = strDetalle + vbNewLine + linea_

        Next

        If contadorArticulos < 24 Then

            For i As Integer = 1 To 24 - contadorArticulos

                strDetalle = strDetalle + vbNewLine + "         "
            Next

        End If



        Dim fuecorrecto As Boolean = False




        Dim lineaCorrelativo As String = "                                                                                                                                                          "
        lineaCorrelativo = lineaCorrelativo.Insert(116, obj.Correlativo)


        Dim lineaFecha As String = "                                                                                                                   "
        lineaFecha = lineaFecha.Insert(27, _FechaSistema_Impresion)
        lineaFecha = lineaFecha.Insert(84, "Contrato")
        lineaFecha = lineaFecha.Insert(101, "0")
        lineaFecha = lineaFecha.Insert(113, "VENTAS POS ")

        Dim LineaFechaVencimiento As String = "                                                                       "
        LineaFechaVencimiento = LineaFechaVencimiento.Insert(29, obj.FechaVencimiento)

        Dim lineaSubTotal As String = "                                                                                                                                           "
        lineaSubTotal = lineaSubTotal.Insert(132 - obj.subtotal.Length, obj.subtotal)
        Dim lineaDescuento As String = "                                                                                                                                                             "

        If obj.Descuento <> 0 Then
            lineaDescuento = lineaDescuento.Insert(100 - obj.PorcentajeDescuento.ToString.Length, obj.PorcentajeDescuento)
            lineaDescuento = lineaDescuento.Insert(101, "%")
            lineaDescuento = lineaDescuento.Insert(104, "DESCUENTO")
            lineaDescuento = lineaDescuento.Insert(132 - obj.Descuento.ToString.Length - 1, "-" + obj.Descuento.ToString)


        End If

        Dim lineaFlete As String = "                                                                                                                                              "

        If obj.Flete <> 0 Then
            lineaFlete = lineaFlete.Insert(132 - obj.Flete.ToString.Length, obj.Flete)
        Else
            lineaFlete = lineaFlete.Insert(132 - 1, "0")
        End If
        Dim lineaNeto As String = "                                                                                                                                  "
        lineaNeto = lineaNeto.Insert(132 - obj.Neto.ToString.Length, obj.Neto)
        Dim LineaIva As String = "                                                                                                                                   "
        LineaIva = LineaIva.Insert(132 - obj.iva.Length, obj.iva)
        Dim LineaTotal As String = "                                                                                                                                  "
        LineaTotal = LineaTotal.Insert(132 - obj.total.Length, obj.total)

        Dim Linea As String = ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaCorrelativo
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & lineaFecha
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                    " + obj.RazonSocial
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                      " + obj.rutCliente
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                    " + _direccionFacturacion.Direccion.Trim + "," + _direccionFacturacion.DescripcionCiudad.Trim + "," + _direccionFacturacion.DescripcionComuna.Trim
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                             " + obj.FormaPago
        Linea = Linea & vbNewLine & ""
        Linea = Linea & LineaFechaVencimiento
        Linea = Linea & vbNewLine & ""
        Linea = Linea & "                    " + obj.PerfilCliente.Giro
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & " "
        Linea = Linea & vbNewLine & ""
        Linea = Linea & strDetalle
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaSubTotal
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaDescuento
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaFlete
        Linea = Linea & vbNewLine & ""
        Linea = Linea & lineaNeto & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & LineaIva & ""
        Linea = Linea & vbNewLine & ""
        Linea = Linea & LineaTotal



        Return Linea



    End Function


End Class
