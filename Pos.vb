Imports StewardLib
Imports System.Xml
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports GeneraTXT.GeneraDocumento
Imports TbkLibSTW
Imports TbkLibSTW.Models


Public Class Pos

    Dim objCLiente As New ClientesController
    Dim objVendedorController As New VendedorController
    Dim objArticuloController As New ArticuloController
    Dim objBancoController As New BancosController
    Dim objVentaController As New VentaController
    Dim objMonedaController As New MonedasController
    Dim objDocumentoVenta As New DocumentosVentaController
    Dim objTerminoPagoController As New TerminoPagoController
    Dim objEmpresa As New EmpresaController
    Dim objStw As New Trans
    Dim wsRecibeVenta As New apws0049.Pws0049
    Dim objVal As New STWVal
    Dim objTrans As New Trans
    Dim ventarecuperada = "N"
    Dim PromoNombre as String
   

    Private WithEvents xDialogo As New Productos
    Private WithEvents xVendedor As New VendedoresDialog
    Private WithEvents xDescuento As New form_Descuento
    Private WithEvents xBanco As New BancoDialogoCheque
    Private WithEvents xPendiente As New PendientesDialog
    Private WithEvents xRazon As New FormRazonDialog
    Private WithEvents xLogin As New LoginForm
    Private WithEvents xBusquedaCliente As New FormBusquedaClientes
    Private WithEvents Xautorizacion As New FormAutorizacion
    Private WithEvents XDirecciones As New FormDirecciones

    Private WithEvents xPromocionTercera As New Promocion
    ' Private WithEvents XDireccionesPorPagar As New FormDireccionesPorPagar

    Private WithEvents XDocumentosCliente As New CLientesCuenta
    Private WithEvents XDocumentosPendientes As New frmDocumentos

    Private WithEvents XListaDisplay As New ListaDisplay
    Private WithEvents XFormularioPagos As New CLientesCuenta
    Private WithEvents XFormularioPagosAplicar As New CLientesCuenta
    Private WithEvents XFormCantidad As New FormCantidadItems

    Private WithEvents xTBK As New frmTrans

    Private WithEvents XCopiaXml As New frmCopiaXml

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer

    'Private WithEvents xCheque As New ChequeDialog

    Dim WS_POS As New ws_pos.Pos



    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click

        BuscarCliente()

    End Sub


    Protected Sub BuscarCliente()

        Dim rut As String = txtRut.Text
        If objVal.ValidaRut(rut) = True Then

            Dim objPerfilCliente As PerfilClienteObj = objCLiente.GetPerfil("STE", txtRut.Text)

            If objPerfilCliente.rut <> Nothing Then

                If TipoDocumentoVenta() = "FAAF" Then
                    Dim objCuentaController As New CuentaCorriente
                    _CuentaCorriente = objCuentaController.GetCuenta("STE", txtRut.Text, _FechaSistema, _FechaSistema, _FechaSistema, _FechaSistema)
                End If

                _perfilCliente = objPerfilCliente

                txtNombreCliente.Text = objPerfilCliente.Nombre
                'txtCodigoVendedor.Text = "POS"
                ' txtNombreVendedor.Text = "POS 1"

                txtCodigoVendedor.Text = objPerfilCliente.vendedor
                txtCodigoVendedorAsignado.Text = objPerfilCliente.vendedor
                txtNombreVendedor.Text = objVendedorController.GetNombreVendedor(objPerfilCliente.vendedor)
                txtDescripcionVendedorAsignado.Text = objVendedorController.GetNombreVendedor(objPerfilCliente.vendedor)
                txtCodigoDirección.Text = _direccionFacturacion.Codigo
                txtCodigoDirecciónDespacho.Text = _direccionDespacho.Codigo
                txtNombreDireccion.Text = _direccionFacturacion.Direccion.Trim + " " + _direccionFacturacion.DescripcionComuna.Trim + " " + _direccionFacturacion.DescripcionCiudad.Trim
                txtNombreDireccionDespacho.Text = _direccionDespacho.Direccion.Trim + " " + _direccionDespacho.DescripcionComuna.Trim + " " + _direccionDespacho.DescripcionCiudad.Trim

                Me.txtCodigoVendedor.Text = objPerfilCliente.vendedor.ToString
                Me.txtNombreVendedor.Text = objVendedorController.GetNombreVendedor(objPerfilCliente.vendedor)

                'If _VendedorDefecto <> "" Then
                'Me.txtCodigoVendedor.Text = _VendedorDefecto
                'Me.txtNombreVendedor.Text = _VendedorDefectoNombre
                'End If

                txtListaPrecio.Text = objPerfilCliente.Lista_Precios
                _listaPrecio = objPerfilCliente.Lista_Precios
                Me.txtCodigoProducto.Enabled = True
                Me.txtCodigoProducto.Focus()
                'lblCodCLiente.Text = rut
                Me.txtCodigoProducto.ReadOnly = False
                txtCodigoProducto.Focus()
                Me.btnBuscarVendedor.Enabled = True
                Me.btnDireccionesFacturacion.Enabled = True
                Me.btnDireccionesDespacho.Enabled = True
                Me.txtDescripcionProducto.ReadOnly = False
                Me.txtListaPrecio.ReadOnly = False

                'Me.txtCodigo.Focus()
                'Me.txtCodigo.Enabled = True
                'txtCodigo.TabIndex = 0

                Dim objLisa = New ws_lisa.WS_Lisa

                If txtRut.Text <> "" And txtRut.Text <> "10-8" Then
                    Dim rutx As Integer = txtRut.Text.Remove(txtRut.Text.Length - 2, 2)
                    If _Deudores = 1 Then

                        Dim deudro As Boolean = False
                        Dim nCobrador As String = ""
                        Dim objcliente As New ClientesController
                        Dim obj As FichaCobranzaObj = objcliente.EstadoFinanciero(rutx.ToString)
                        For Each o As DocumentoCobranzaObj In obj.Documentos
                            Dim fechavencimiento = Convert.ToDateTime(o.FechaVencimiento)
                            Dim fechahoy As DateTime
                            Dim fechamenos90 = fechahoy.Now.AddDays(-90)
                            If fechavencimiento < fechamenos90 Then
                                If o.SaldoXPagar > 0 Then
                                    deudro = True
                                    nCobrador = o.Cobrador.Trim()
                                End If

                            End If

                        Next

                        If deudro = True Then
                            Dim xx = objcliente.ConsultaCobrador(nCobrador)
                            Dim mensaje = "El cliente: " + vbCrLf +
                                        objPerfilCliente.Nombre + vbCrLf +
                                        "TIENE DEUDA(S) VENCIDAD POR MAS DE 90 DIAS" + vbCrLf +
                                        "Favor contactar al cobrador asigando: " + vbCrLf +
                                        xx.Trim() + vbCrLf + "para obtener mas información, contactar al jefe de local."
                            MessageBox.Show(mensaje, "Información de deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If

                    End If

                    Dim dsCredito = objLisa.ConsultaPos("CRE", "STE", "", rutx, "", 0, "", "")
                    Dim drCredito = dsCredito.Tables(0).Rows(0)
                    Dim retornoCredito = Convert.ToInt32(drCredito("Autoriza").ToString())
                    If retornoCredito = 1 Then
                        PictureBox5.Visible = True
                        btn_Credito_Steward.Visible = True
                        txtResumenCreditoSteward.Visible = True
                    ElseIf retornoCredito = 0 Then
                        _DeudorCheque = True
                    End If


                End If



            Else
                If _MENSAJE_CONFIRMACION("El Cliente no Existe Desea Registrarlo", "Steward") = True Then
                    Dim form As New frmRegistraUsuario
                    form.txtRut.Text = txtRut.Text
                    form.ShowDialog()
                End If

            End If

            Exit Sub

            If objCLiente.totalRegistrosCLR(txtRut.Text) > 1 Then

                Dim arrayclc As ArrayList = objCLiente.BuscaClienteCLC(Int32.Parse(txtRut.Text))

            Else


                Dim cliente As ClienteObj = objCLiente.BuscaCliente(txtRut.Text)

                If cliente.nombre <> Nothing Then

                    ' txtNombreCliente.Text = cliente.nombre
                    'txtCodigoVendedor.Text = cliente.codigovendedor
                    'txtDescripcionVendedor.Text = cliente.Vendedor
                    'txtListaPrecio.Text = cliente.Lista
                    'lblCodCLiente.Text = cliente.id

                Else
                    Dim var As String = "El cliente Consultado no Existe"

                    MsgBox("El Cliente no Existe", MsgBoxStyle.Information, "Información no Encontrada")

                End If
            End If




        Else

            MsgBox("Rut Invalido", MsgBoxStyle.Exclamation, "Información no Encontrada")


        End If
    End Sub


    Public Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        If UCase(txtDescripcionProducto.Text) = "INVALIDO" Then
            MsgBox("Articulo Invalido", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If

        If Int32.Parse(txtCantidad.Text) = 0 Then
            MsgBox("La cifra no es valida", MsgBoxStyle.Exclamation, "STEWARD")
            Exit Sub
        End If

        Dim rut As Integer = Int32.Parse(Me.objTrans.LimpiaRut(txtRut.Text))
        Dim codigo As String = txtCodigoProducto.Text
        Dim cantidad As Integer = Int32.Parse(txtCantidad.Text)

        IngresaArticuloGrid(rut, codigo, cantidad)

    End Sub

    Protected Sub CreaCabeserasGrid()

        Me.gridDetalle.Columns.Add("Codigo", "Codigo")
        Me.gridDetalle.Columns("Codigo").DataPropertyName = "SKU"
        Me.gridDetalle.Columns("Codigo").Width = 60
        Me.gridDetalle.Columns("Codigo").ReadOnly = True

        Me.gridDetalle.Columns.Add("Descripcion", "Descripcion")
        Me.gridDetalle.Columns("Descripcion").DataPropertyName = "NOMBRE"
        Me.gridDetalle.Columns("Descripcion").Width = 360
        Me.gridDetalle.Columns("Descripcion").ReadOnly = True

        Me.gridDetalle.Columns.Add("UnidadMedida", "U.M.")
        Me.gridDetalle.Columns("UnidadMedida").DataPropertyName = "unidadmedida"
        Me.gridDetalle.Columns("UnidadMedida").Width = 35
        Me.gridDetalle.Columns("UnidadMedida").ReadOnly = True

        Me.gridDetalle.Columns.Add("Precio", "Precio")
        Me.gridDetalle.Columns("Precio").DataPropertyName = "Precio"
        Me.gridDetalle.Columns("Precio").ReadOnly = True

        Me.gridDetalle.Columns.Add("PrecioIva", "Precio Iva")
        Me.gridDetalle.Columns("PrecioIva").DataPropertyName = "PrecioIva"
        Me.gridDetalle.Columns("PrecioIva").ReadOnly = True

        Me.gridDetalle.Columns.Add("Cant", "Cantidad")
        Me.gridDetalle.Columns("Cant").DataPropertyName = "Cantidad"
        Me.gridDetalle.Columns("Cant").Width = 50

        Me.gridDetalle.Columns.Add("Valor", "Valor")
        Me.gridDetalle.Columns("Valor").DataPropertyName = "ValorTotal"
        Me.gridDetalle.Columns("Valor").ReadOnly = True

        Me.gridDetalle.Columns.Add("Envase", "Envase")
        Me.gridDetalle.Columns("Envase").DataPropertyName = "Envase"

        Me.gridDetalle.Columns.Add("Descuento", "Descuento")
        Me.gridDetalle.Columns("Descuento").DataPropertyName = "Descuento"

        Me.gridDetalle.Columns.Add("DescuentoLinea", "DescuentoLinea")
        Me.gridDetalle.Columns("DescuentoLinea").DataPropertyName = "DescuentoLinea"


        Me.gridDetalle.Columns.Add("Oferta", "Oferta")
        Me.gridDetalle.Columns("Oferta").DataPropertyName = "Oferta"

        Me.gridDetalle.Columns.Add("Porcentaje", "%")
        Me.gridDetalle.Columns("Porcentaje").DataPropertyName = "PorcentajeDescuento"


        Me.gridDetalle.Columns.Add("CBruto", "CBruto")
        Me.gridDetalle.Columns("CBruto").DataPropertyName = "CBruto"
       

        Me.gridDetalle.Columns("Porcentaje").Width = 30



        Dim columaimagen As New DataGridViewImageColumn


    End Sub


    Protected Sub CreaCabeseraCheques()

        Me.cheque_grid_cheque.Columns.Add("Nro", "Nro")
        Me.cheque_grid_cheque.Columns("Nro").DataPropertyName = "Nro"
        Me.cheque_grid_cheque.Columns("Nro").Width = 12
        Me.cheque_grid_cheque.Columns("Nro").ReadOnly = True

        Me.cheque_grid_cheque.Columns.Add("Nro_Cheque", "Serie")
        Me.cheque_grid_cheque.Columns("Nro_Cheque").DataPropertyName = "Nro_Cheque"
        Me.cheque_grid_cheque.Columns("Nro_Cheque").Width = 50
        Me.cheque_grid_cheque.Columns("Nro_Cheque").ReadOnly = False

        Me.cheque_grid_cheque.Columns.Add("Cod_Autorizacion", "Cod. Auto")
        Me.cheque_grid_cheque.Columns("Cod_Autorizacion").DataPropertyName = "CodigoAutorizacion"
        Me.cheque_grid_cheque.Columns("Cod_Autorizacion").Width = 50
        Me.cheque_grid_cheque.Columns("Cod_Autorizacion").ReadOnly = False

        Me.cheque_grid_cheque.Columns.Add("Fecha", "Fecha")
        Me.cheque_grid_cheque.Columns("Fecha").DataPropertyName = "Fecha"
        Me.cheque_grid_cheque.Columns("Fecha").Width = 80
        Me.cheque_grid_cheque.Columns("Fecha").ReadOnly = False

        Me.cheque_grid_cheque.Columns.Add("Monto", "Monto")
        Me.cheque_grid_cheque.Columns("Monto").DataPropertyName = "Monto"
        Me.cheque_grid_cheque.Columns("Monto").ReadOnly = False

        Me.cheque_grid_cheque.Columns.Add("Cuenta", "Cuenta Cte.")
        Me.cheque_grid_cheque.Columns("Cuenta").DataPropertyName = "Cta_Cte"
        Me.cheque_grid_cheque.Columns("Cuenta").Width = 60

        Me.cheque_grid_cheque.Columns.Add("Banco", "Banco")
        Me.cheque_grid_cheque.Columns("Banco").DataPropertyName = "Banco"
        Me.cheque_grid_cheque.Columns("Banco").ReadOnly = True

        Me.cheque_grid_cheque.Columns.Add("CodigoBanco", "CodigoBanco")
        Me.cheque_grid_cheque.Columns("CodigoBanco").DataPropertyName = "CodigoBanco"
        Me.cheque_grid_cheque.Columns("CodigoBanco").Visible = False

        Me.cheque_grid_cheque.Columns.Add("Rut_Titular", "Rut Titular")
        Me.cheque_grid_cheque.Columns("Rut_Titular").DataPropertyName = "Rut_Titular"


    End Sub

    Private Sub Pos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub Pos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub Pos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

    End Sub


    Protected Sub CargaParametrosEntrada()

        _Empresa = _GetEmpresa()
        '_Sede = _GetSede()
        ' _PuntoFacturacion = _GetPuntoFacturacion()
        ' _Pos = _GetPos()
        '_RutaLog = _GetRutaLog()
        '_RutaMvto = _GetRutaMvto()
        _CajaRecaudacion = _GetCajaRecaudacion()
        _TerminosCheque = _GetTerminosCheque()
        _TerminosTarjetaCredito = _GetTerminosTarjetaCredito()
        _Concepto = _GetConcepto()
        _Moneda = _GetMoneda()
        _CodigoBoleta = _GetCodigoBoleta()
        _CodigoFactura = _GetCodigoFactura()
        _iva = _Getiva()
        _ListaPrecioDefecto = _GetListaPrecioDefecto()
        ' _VendedorDefecto = _GetVendedorDefecto()
        '_VendedorDefectoNombre = _GetVendedorDefectoNombre()
        _RutaRespaldoXml = _GetRutaRespaldoXml()
        _RutaDocumentosImpresos = _GetRutaDocumentosImpresos()
        _RutaDocumentosPendientes = _GetRutaDocumentosPendientes()
        _RutaComprobantes = _GetRutaComprobantes()
        ' _ImpresoraBoleta = _GetImpresoraBoleta()
        '_ImpresoraFactura = _GetImpresoraFactura()
        _TerminoPagoContadoEfectivo = _GetTerminoPagoContadoEfectivo()
        _TerminoPagoDebito = _GetTerminoPagoDebito()
        _MontoCreditoSteward = _GetMontoCreditoSteward()
        _cab_Id = 0
        TransbankCheck(true)




    End Sub

    Public Sub TransbankCheck(_estadoTBK As Boolean)
           if _estadoTBK = True Then
            PictureBox4.Visible = False
            btn_Compra_credito.Visible = False
            btnCompraDebito.Visible = False
            txtResumenCredito.Visible = False
            txtResumenDebito.Visible = False
            txtResumenDebitoCredito.Visible = True
            btnDebitoCredito.Visible = True
            else
             PictureBox4.Visible = True
            btn_Compra_credito.Visible = True
            btnCompraDebito.Visible = True
            txtResumenCredito.Visible = True
            txtResumenDebito.Visible = True
            txtResumenDebitoCredito.Visible = False
            btnDebitoCredito.Visible = False
           End If
    End Sub


    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CargaParametrosEntrada()


        If ValidaConexiones() = True Then

            Dim formlogin As New LoginForm
            formlogin.ShowDialog()
            concepto = _Concepto

            Dim arr As ArrayList = objCLiente.GetDirecciones("STE", "10-8")
            CreaCabeserasGrid()
            OrdenarGrilla()

            Me.TabControl.TabPages.Remove(Me.txt_Debito_Banco)

            RemoverPanelesCabecera()
            Me.TabControlCabecera.TabPages.Add(TabCabeceraPrincipal)
            Me.btnDetalle.Enabled = False
            Me.txtNroCaja.Text = CajaPos

        Else
            MsgBox("Error de Conexion Internet, Verifique su Conexion a Internet antes de continuar ")
            Exit Sub

        End If












    End Sub

    Public Function ValidaConexiones() As Boolean



        'If _ValidaEstadoWebService("http://192.168.1.230/wslisa/WSLISAERP.asmx") = False Then

        '    Return False

        'End If


        'If _ValidaEstadoWebService("http://192.168.1.230/wspos/pos.asmx") = False Then

        '    Return False

        'End If

        'If _ValidaEstadoWebService("http://192.168.1.230:8090/lisainterfazsqln/servlet/apws0049?wsdl") = False Then

        '    Return False

        'End If


        Return True


    End Function

    Public Function BuscarArticulo() As Boolean

        Dim espromo As String = "N"
        If Me.chkOferta.Checked = True Then
            espromo = "S"
        End If


        Dim rut As String = objTrans.LimpiaRut(txtRut.Text)
        Dim lista As Integer = Int32.Parse(txtListaPrecio.Text)
        Dim articulo As ArticuloObj = objArticuloController.GetArticuloCodigo(Int32.Parse(rut), Me.txtCodigoProducto.Text, txtListaPrecio.Text, espromo)
        Dim x As New ArticuloController

        If articulo.nombre <> Nothing Then
            Me.txtDescripcionProducto.Text = articulo.nombre.ToString
            txtUm.Text = articulo.unidadmedida
            txtPrecioProducto.Text = articulo.precio.ToString("N0")
            txtPrecioIva.Text = articulo.PrecioIva.ToString("N0")
            Me.txtCantidad.Enabled = True
            Me.txtCantidad.Focus()
            txtCantidad.Text = 1
        Else


            Dim posicion As Integer = 0
            posicion = txtCodigoProducto.Text.IndexOf("*")
            If posicion <> -1 Then

                xDialogo.txtBusqueda.Text = txtCodigoProducto.Text
                xDialogo.tipo = "C"
                xDialogo.listaPrecio = txtListaPrecio.Text
                xDialogo.CargarDatos()
                xDialogo.Show()

            Else
                Dim msg As String = "NO SE ENCUENTRA PRODUCTO!"
                MsgBox(msg, MsgBoxStyle.Exclamation, " STEWARD INFORMACION")
                Me.txtCodigoProducto.Text = ""
                Me.txtCodigoProducto.Focus()
                Return False
            End If


        End If
        Return True
    End Function

    Private Sub txtCodigoProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoProducto.KeyDown
        'Teclado(e)
        If e.KeyValue = Keys.Enter Then
            If BuscarArticulo() = True Then
                IngresaCantidadArticulo(1)
            End If

        End If

    End Sub

    Private Sub txtCodigoProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoProducto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosComodin(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Public Sub ingresarutdesdedialogo(ByVal rut As String) Handles xBusquedaCliente.IngresaRut

        Me.txtRut.Text = rut
        Me.BuscarCliente()

    End Sub

    Private Sub txtCodigoProducto_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCodigoProducto.MouseMove

    End Sub


    Private Sub txtCodigoProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoProducto.TextChanged




    End Sub


    Protected Sub IngresaArticuloGrid(ByVal rut As String, ByVal codigo As String, ByVal cantidad As Integer)

        Dim espromocion As String = "N"
        If chkOferta.Checked = True Then
            espromocion = "S"
        End If

        Dim lista As String = Me.txtListaPrecio.Text
        Dim arreglo As New ArrayList

        codigo = objArticuloController.GetArticuloCodigoCantidad(rut, codigo, cantidad, lista, espromocion).sku




        If Me.gridDetalle.Rows.Count = 0 Then
            Dim x As String = ""
            Dim articulo As ArticuloStringObj = objArticuloController.GetArticuloCodigoCantidad(rut, codigo, cantidad, lista, espromocion)


            'articulo.Descuento = descuento

            ArregloItems.Add(articulo)
            llenarGrilla(gridDetalle, ArregloItems)
            Me.btn_Descuento_Cabesera.Enabled = True
            DestacaProductoEnOferta()
            APlicaColoresGrillaDetalle()
        Else
            If ValidaExistencia(codigo) = False Then


                Dim objarticulo3 As ArticuloStringObj = objArticuloController.GetArticuloCodigoCantidad(rut, codigo, cantidad, lista, espromocion)

                ArregloItems.Add(objarticulo3)
                llenarGrilla(gridDetalle, ArregloItems)
                DestacaProductoEnOferta()
                APlicaColoresGrillaDetalle()
            Else

                If Not IsNothing(Me.traefila(codigo)) Then

                    'Dim txt As TextBox = traefila(codigo).Cells(4).FindControl("txtCantidad")
                    'Dim txt As TextBox = traefila(codigo).Cells("sku").Value
                    Dim sumacantidad As Integer = traefila(codigo).Cells("cant").Value + cantidad
                    traefila(codigo).Cells("cant").Value = sumacantidad
                    ' txt.Text = Int32.Parse(txt.Text) + Int32.Parse(cantidad)

                    Dim precio As Integer = Double.Parse(traefila(codigo).Cells("precio").Value)
                    ' Dim precio As Integer = Int32.Parse(traefila(codigo).Cells(2).Text)
                    traefila(codigo).Cells("valor").Value = (precio * sumacantidad).ToString("N0")

                End If

            End If

        End If

        'Session.Add("itemscompra", arreglo)

        LimpiaFormularioIngreso()




        CalculaSubTotal()


        gridDetalle.CurrentCell = gridDetalle.Item(0, gridDetalle.Rows.Count - 1)
        gridDetalle.FirstDisplayedCell = gridDetalle.CurrentCell
        gridDetalle.Rows(Me.gridDetalle.Rows.Count - 1).Selected = True
        Me.gridDetalle.Rows.GetLastRow(DataGridViewElementStates.Displayed)



        OrdenarGrilla()




        txtCodigoProducto.Focus()


        Me.ActualizaValoresDescuentos()
        Me.AplicaSeparadoresdeMil()
        AplicaDestacadoProducto()
        Exit Sub

    End Sub

    Public Sub AplicaDestacadoProducto()

        Dim contador As Integer = 0
        For Each obj As ArticuloStringObj In ArregloItems

            If obj.Oferta = 1 Then
                Me.gridDetalle.Rows(contador).DefaultCellStyle.BackColor = Color.GreenYellow
                Me.gridDetalle.Rows(contador).DefaultCellStyle.ForeColor = Color.Black
            End If

            contador = contador + 1
        Next

    End Sub


    Protected Sub LimpiaFormularioIngreso()
        txtCodigoProducto.Text = ""
        txtDescripcionProducto.Text = ""
        txtPrecioProducto.Text = ""
        txtPrecioIva.Text = ""
        txtUm.Text = ""
        txtCantidad.Text = ""
    End Sub

    Protected Function ValidaExistencia(ByVal codigo As String) As Boolean
        Dim valor As Boolean = False

        For Each gr As DataGridViewRow In gridDetalle.Rows


            Dim x As String = gr.Cells("codigo").Value.ToString.Trim
            If x = codigo Then
                valor = True
            End If



        Next


        Return valor

    End Function


    Protected Function traefila(ByVal codigo As String) As DataGridViewRow


        Dim fila As DataGridViewRow = Nothing

        For Each gr As DataGridViewRow In gridDetalle.Rows

            Dim valor As String = gr.Cells("Codigo").Value.Trim

            If valor = codigo Then
                fila = gr
            End If


        Next

        Return fila

    End Function

    Protected Sub CalculaSubTotal()
        Dim contador As Integer = 0
        Dim subtotal As Double
        Dim subbruto As Double
        Dim subiva As Double

        Dim var As Integer = 0

        If gridDetalle.RowCount > 0 Then


            For Each gr As DataGridViewRow In gridDetalle.Rows
                Dim xxx = gr.Cells("Cant").Value.ToString
                contador = contador + 1
                Dim cantidad As Integer = 0
                If Not IsNothing(gr.Cells("Cant").Value.ToString()) Then
                    cantidad = Int32.Parse(gr.Cells("Cant").Value.ToString())
                End If

                Dim au = Integer.Parse(gr.Cells("CBruto").Value.ToString.Replace(".", ""))
                Dim au1 = Integer.Parse(gr.Cells("CNeto").Value.ToString.Replace(".", ""))
                Dim au2 = Integer.Parse(gr.Cells("CIva").Value.ToString.Replace(".", ""))

                Dim precio As Integer = Integer.Parse(gr.Cells("Precioiva").Value.ToString.Replace(".", ""))
                Dim precioneto As Integer = Integer.Parse(gr.Cells("precio").Value.ToString.Replace(".", ""))


                subtotal = subtotal + (au1 * cantidad) '(cantidad * precioneto) + subtotal
                subbruto = subbruto + (au * cantidad)
                subiva = subiva + (au2 * cantidad)
            Next

            'Dim neto As Double
            'dim netoAplicado as Double

            'neto =  (subbruto / 1.19)

            'Me.txtSubTotal.Text = neto.ToString("N0")

            'AplicaDescuentos()

            'If txtDescuento.Text <> "" Then
            '     netoAplicado = neto - Double.Parse(txtDescuento.Text)
            '     txtBruto.Text = netoAplicado.ToString("N0")
            '     Me.btnDetalleDescuento.Enabled = True
            '    else
            '      netoAplicado = neto
            '      txtBruto.Text = netoAplicado.ToString("N0")
            'End If

           
            ''If txtDescuento.Text <> "" Then
            ''    bruto = subtotal - Double.Parse(txtDescuento.Text)
            ''    txtBruto.Text = bruto.ToString("N0")
            ''    Me.btnDetalleDescuento.Enabled = True
            ''Else
            ''    bruto = (subbruto / 1.19).ToString("N0")
            ''    txtBruto.Text = bruto.ToString("N0")
            ''End If

            ''verificaOpcionPagar()
            'CalculaIvaYTotalfinal(netoAplicado)

            'verificaOpcionPagar()

            Me.txtSubTotal.Text = subtotal.ToString("N0")
            AplicaDescuentos()

            Dim bruto As Double
            If txtDescuento.Text <> "" Then
                bruto = subtotal - Double.Parse(txtDescuento.Text)
                txtBruto.Text = bruto.ToString("N0")
                Me.btnDetalleDescuento.Enabled = True
            Else
                bruto = subtotal
                txtBruto.Text = bruto.ToString("N0")
            End If

            CalculaIvaYTotalfinal(subbruto)
        Else
            txtIva.Text = ""
            txtBruto.Text = ""
            txtFinal.Text = ""
            txtSubTotal.Text = ""

        End If


    End Sub


    Protected Sub CalculaIvaYTotalfinal(ByVal bruto As Integer)

        Dim wsLisa As New ws_lisa.WS_Lisa
            
            Dim flete As Double = 0
            If txtResumenDespacho.Text <> ""
                    flete = Double.Parse(Me.txtResumenDespacho.Text)
            End If
            Dim subtotal As Double = Double.Parse(Me.txtSubTotal.Text)
            Dim descuento As Double = 0
            If txtPorcentajeDescuento.Text <> ""
                descuento = Double.Parse(Me.txtPorcentajeDescuento.Text)
            End If


            Dim ds = wsLisa.ConsultaPos("RECALFD", "", "", bruto, subtotal, descuento, flete, "")
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                Dim pp = dr("Descuento").ToString
               txtBruto.Text = Convert.ToDouble(dr("Neto")).ToString("N0")
                Me.txtIva.Text =Convert.ToDouble(dr("Iva")).ToString("N0")
                Me.txtFinal.Text = Convert.ToDouble(dr("Bruto")).ToString("N0")
            End If


            'If txtDescuento.Text <> "" Then
            '    descuento = Double.Parse(txtDescuento.Text)
            'End If
            'txtBruto.Text = ((subtotal - descuento) + flete).ToString("N0")
            'bruto = Double.Parse(txtBruto.Text)
           


        'Dim iva As Integer = bruto * 19
        'iva = iva / 100

        'Me.txtIva.Text = subiva.ToString("N0")
        'Me.txtFinal.Text = subbruto.ToString("N0") ''(bruto + iva).ToString("N0")
        verificaOpcionPagar()



    End Sub



    Protected Sub verificaOpcionPagar()

        Dim total As Integer = gridDetalle.Rows.Count

        If total > 0 Then

            Me.btnCerrarCompra.Enabled = True
        End If

    End Sub

    Private Sub txtCantidad_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles txtCantidad.Invalidated

    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown

        If txtCodigoProducto.Text = "" Then
            Exit Sub
        End If



        If txtCantidad.Text = "" Then
            MsgBox("Ingrese ", MsgBoxStyle.Information)
            Exit Sub
        End If

        If e.KeyValue = Keys.Enter Then
            Dim cantidad As Integer = Int32.Parse(txtCantidad.Text)
            IngresaCantidadArticulo(cantidad)
        Else
            MsgBox("Se ha completado el maximo de items de detalle")
        End If



    End Sub

    Public Sub IngresaCantidadArticulo(ByVal cantidad As Integer)

        If Helper.Multifactura = False Then
            If gridDetalle.Rows.Count >= _NumeroLineas And TipoDocumentoVenta() = "FAAF" Then
                If MessageBox.Show("Se ha superado el máximo de items para este documento, desea continuar o cancelar factura", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'continua ingresando
                    Helper.Multifactura = True
                Else
                    'cancela ingreso y hay que cerrar documento
                    Helper.Multifactura = False
                    Exit Sub
                End If
            End If
        End If


        If UCase(txtDescripcionProducto.Text) = "INVALIDO" Then
            MsgBox("Articulo Invalido", MsgBoxStyle.Information, "Error")
            Me.LimpiaFormularioIngreso()
            Me.txtCodigoProducto.Focus()
            Exit Sub
        End If
        If txtPrecioIva.Text = "0" Or txtPrecioIva.Text = "0" Then
            MsgBox("NO Puede ingresar un articulo sin precio", MsgBoxStyle.Information, "Error")
            Me.LimpiaFormularioIngreso()
            Me.txtCodigoProducto.Focus()
            Exit Sub
        End If


        Dim rut As Integer = Int32.Parse(Me.objTrans.LimpiaRut(txtRut.Text))
        Dim codigo As String = txtCodigoProducto.Text

        IngresaArticuloGrid(rut, codigo, cantidad)
        CalculaItemsTotalesLineasdeDetalle()
        Me.btnGuardar.Enabled = True
        ' AplicaSeparadoresdeMil()




    End Sub

    Public Sub llenarGrilla(ByVal grilla As DataGridView, ByVal objeto As Object)
        Dim bs As BindingSource = New BindingSource()
        bs.DataSource = objeto
        grilla.DataSource = bs
        bs.ResetBindings(False)
        OrdenarGrilla()
    End Sub


    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub btnCerrarCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabArticulos.Click

    End Sub


    Private Sub gridDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)


    End Sub

    Private Sub txtResumenDebito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenDebito.KeyDown



        If e.KeyValue = Keys.Enter Then
            DesactivarMediosPagosVacios()
            If txtResumenDebito.Text <> "" Then
                Dim debito As Integer = Int32.Parse(Me.txtResumenDebito.Text.Replace(".", ""))
                Me.txtResumenDebito.Text = debito.ToString("N0")
            End If
            'txtPagado.Text = efectivo.ToString("N0")
            ValidaTotaldePagos()
        End If


    End Sub

    Private Sub txtResumenDebito_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenDebito.KeyUp

    End Sub

    Private Sub txtResumenDebito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenDebito.LostFocus
        If txtResumenDebito.Text = "" Then
            txtResumenDebito.ReadOnly = True
            TabMedioPago.TabPages.Clear()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenDebito.TextChanged
        ValidaTotaldePagos()
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub


    Protected Sub BuscaVendedor()
        Dim objVendedor As VendedorObj = objVendedorController.Buscar(Me.txtCodigoVendedor.Text)


        If Not IsNothing(objVendedor.Nombre) Then
            Me.txtNombreVendedor.Text = objVendedor.Nombre.ToString
        Else
            Dim var As String = "Este vendedor no existe"
            MsgBox(var, MsgBoxStyle.Exclamation, "No se Encuentra")


        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarVendedor.Click
        Me.xVendedor.CargarDatos()
        Me.xVendedor.ShowDialog()

    End Sub



    Public Sub AccionFinalizaVenta()

        If validaDetallePagos() = False Then
            Exit Sub
        End If

        If txtPagado.Text = "" Then
            MsgBox("DEBE INGRESAR EL PAGO", MsgBoxStyle.Exclamation, "STEWARD")
            Exit Sub
        End If

        If Int32.Parse(txtPagado.Text.Replace(".", "")) < Int32.Parse(txtFinal.Text.Replace(".", "")) Then
            MsgBox("EL MONTO DEL PAGO DEBE SER MAYOR AL TOTAL ", MsgBoxStyle.Exclamation, "STEWARD")
            Exit Sub
        End If

        Dim dir As String = _direccionFacturacion.Direccion.TrimEnd

        If dir.Length > 47 Then

            Dim form As New direccionFacturacion
            form.ShowDialog()

            Exit Sub
        End If





        'validar el detalle de los pagos
        Try

            Dim DOC As String = ""
            If _tipoDocumentoVenta = "BOVT" Then
                DOC = "BOLETA"
            End If

            If _tipoDocumentoVenta = "FAAF" Then
                DOC = "FACTURA"
            End If
          


            Dim Mensaje = String.Empty
            If Helper.Multifactura = True Then   'SI ES MULTIFACTURA
                Dim ppax = gridDetalle.Rows.Count

                Dim clineasarr3 = Convert.ToDouble(ppax)
                Dim ai = Convert.ToInt32(Math.Ceiling(clineasarr3 / _NumeroLineas))

                Helper.MultiFacturaCantidad = ai


                Dim arrayFolios(ai - 1) As String
                arrayFolios(0) = txtCorrelativo.Text

                For i As Integer = 1 To (ai - 1)
                    arrayFolios(i) = (Convert.ToInt32(txtCorrelativo.Text) + i).ToString()
                Next
                Helper.MultifacturaArray = arrayFolios
                Mensaje = "¿DESEA CERRAR LA VENTA CON LOS DOCUMENTOS: " + DOC + " NUMEROS: " + String.Join(",", arrayFolios)
            Else 'NO ES MULTIFACTURA
                Mensaje = "¿DESEA CERRAR LA VENTA CON EL DOCUMENTO: " + DOC + "  NUMERO: " + txtCorrelativo.Text
            End If



            If _MENSAJE_CONFIRMACION(Mensaje, "STEWARD") = True Then

                Dim objVenta As VentaObj = VentaSetParametros()
                objVenta.PerfilCliente = _perfilCliente


                Dim esdescuento As Boolean = False

                If txtDescuento.Text <> "" Then
                    esdescuento = True
                End If

                Dim resultadoEjecutaVenta As Boolean
                If Helper.Multifactura = True Then
                    resultadoEjecutaVenta = EjecutaventaMulti(objVenta)
                Else
                    resultadoEjecutaVenta = Ejecutaventa(objVenta)

                End If


                If resultadoEjecutaVenta = True Then




                    'Actualiza correlativo
                    If txtCorrelativo.Text <> "" Then

                        If Helper.Multifactura = True Then
                            For i As Integer = 0 To Helper.MultifacturaArray.Length - 1
                                Dim Folio = Int32.Parse(Helper.MultifacturaArray(i))
                                objDocumentoVenta.ActualizaCorrelativo(_Sede, _PuntoFacturacion, _tipoDocumentoVenta, Folio)
                            Next
                        Else
                            Dim Folio As Integer = Int32.Parse(Me.txtCorrelativo.Text)
                            objDocumentoVenta.ActualizaCorrelativo(_Sede, _PuntoFacturacion, _tipoDocumentoVenta, Folio)
                        End If




                    End If


                    'si es venta_recuperada

                    Dim bodega As Integer = Int32.Parse(_Bodega)

                    If esVentaRecuperada = True Then
                        WS_POS.POS_Documentos_Wop("M", _cab_Id, 0, bodega, _Pos, _tipoDocumentoVenta, Int32.Parse(Me.txtCorrelativo.Text))
                    End If

                    CambiaEstadoCabecera(_cab_Id, 4)

                    'MODALIDAD DE DOCUMENTO APLICANDO ABONO

                    esVentaRecuperada = False

                    If DetectaModalidad() = "V1" Then
                        Dim objDoc As New DocumentoController

                        If TipoDocumentoVenta() = "FAAF" Then




                            If Helper.Multifactura = True Then
                                objVentaController.GeneraDocumentoImpresionFacturaMultiple(objVenta, esdescuento)
                                objDoc.CambiaEstadoImpresion(objVenta.Correlativo, "FAAF", 1)
                            Else
                                objVentaController.GeneraDocumentoImpresionFactura(objVenta, esdescuento)
                                objDoc.CambiaEstadoImpresion(objVenta.Correlativo, "FAAF", 1)

                            End If

                        Else
                            objVentaController.GeneraDocumentoImpresionBoleta(objVenta)
                            objDoc.CambiaEstadoImpresion(objVenta.Correlativo, "BOVT", 1)
                        End If


                        
                        MsgBox("VENTA FINALIZADA", MsgBoxStyle.Information, "VENTA")
                        Me.btnPagar.Enabled = False
                        Helper.Multifactura = False
                        Me.chkOferta.Checked = False
                        ArregloItems.Clear()
                        objVenta.ListaArticulos.Clear()
                        objVenta = Nothing
                        ResetFormulario()
                    End If

                    'Modalidad para Generar Documento sin Aplicar Pago

                    If DetectaModalidad() = "V2" Then

                        'If DetectaModalidad() = "V2" And _Modalidad = "NC" Then
                        'objVentaController.GeneraDocumentoImpresionFactura(objVenta, esdescuento)
                        'MsgBox("IMPRIMIENDO DOCUMENTO", MsgBoxStyle.Information)
                        'Exit Sub
                        'End If

                        MsgBox("PORFAVOR APLIQUE LOS PAGOS PARA REALIZAR FINALIZAR VENTA", MsgBoxStyle.Information, "VENTA")
                        ArregloItems.Clear()
                        objVenta.ListaArticulos.Clear()
                        objVenta = Nothing
                        ResetFormulario()
                    End If


                    Dim DocumentosParaComprobante As New ArrayList
                    'Modalidad para Aplicar pago  a Documentos Existentes
                    If DetectaModalidad() = "V3" Then



                        Dim ObjDocumento As New DocumentoController
                        For Each doc_a As DocumentoObj In _DocumentosAplicarPago

                            If ObjDocumento.VerificaExistenciaenWop(doc_a.Folio, doc_a.TipoDocumento) = True Then

                                If ObjDocumento.VerificaEstadoImpresion(doc_a.Folio, doc_a.TipoDocumento) = False Then
                                    ResetFormulario()

                                    recuperaVentaLisa(doc_a.Folio, True)
                                    'codigo de impresion nuevo

                                    Me.txtCorrelativo.Text = doc_a.Folio
                                    objVenta.Correlativo = doc_a.Folio
                                    objVenta.Lista = txtListaPrecio.Text
                                    objVenta.subtotal = txtSubTotal.Text
                                    objVenta.total = txtFinal.Text
                                    objVenta.Neto = Me.txtBruto.Text
                                    objVenta.iva = Me.txtIva.Text
                                    objVenta.nro_Documento = doc_a.Folio

                                    If txtPorcentajeDescuento.Text <> "" Then
                                        objVenta.PorcentajeDescuento = Int32.Parse(Me.txtPorcentajeDescuento.Text.Replace(".", ""))
                                        objVenta.Descuento = Int32.Parse(Me.txtDescuento.Text.Replace(".", ""))
                                    End If


                                    Dim esdescuento_ As Boolean = False
                                    If objVenta.Descuento <> 0 Then
                                        esdescuento_ = True
                                    End If

                                    objVentaController.GeneraDocumentoImpresionFactura(objVenta, esdescuento_)

                                    'MsgBox("DOCUMENTO ENVIADO A IMPRESIÓN", MsgBoxStyle.Information, "VENTA")
                                Else

                                    DocumentosParaComprobante.Add(doc_a)
                                End If

                            Else
                                DocumentosParaComprobante.Add(doc_a)
                            End If

                            ' si existen documentos para emitir comprobantes los Enviamos a la funcion de Generar Comprobante
                            If DocumentosParaComprobante.Count > 0 Then

                                Dim imprimir As New PrintDocument
                                imprimir = New PrintDocument
                                Dim imagen As New System.Drawing.StringFormat
                                If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    PrintDocument1.Print()
                                End If

                                objVentaController.GeneraCombrobantePagoDocumento(DocumentosParaComprobante, Me.txtFinal.Text)

                            End If

                        Next

                        Me.TabControl.TabPages.Clear()
                        ArregloItems.Clear()
                        objVenta.ListaArticulos.Clear()
                        objVenta = Nothing
                        ResetFormulario()
                    End If


                Else
                    MsgBox("ERROR: NO SE PUDO GENERAR DOCUMENTO, REINTENTE")
                End If




            End If

        Catch ex As Exception
            MsgBox("ERROR:" + ex.ToString, MsgBoxStyle.Exclamation, "STEWARD")
        End Try

    End Sub



    Public Sub CambiaEstadoCabecera(ByVal CabId As String, ByVal estado As Integer)
        Dim wswop As New ws_pos.Pos

        Try
            Dim ds As DataSet = wswop.POS_Documentos_Wop("S", Int32.Parse(CabId), estado, "", "", "", 0)

        Catch ex As Exception
            MsgBox("Error" + ex.ToString)
        End Try



    End Sub



    Private Sub btnPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagar.Click
        AccionFinalizaVenta()
    End Sub


    Public Function VentaSetParametros() As VentaObj

        Dim DocumentoVenta As String = _tipoDocumentoVenta
        Dim objventa As New VentaObj
        objventa.FormaPago = FormadePago(DocumentoVenta)

        If txtCorrelativo.Text = "" Then
            objventa.Correlativo = 777
        Else
            objventa.Correlativo = Int32.Parse(txtCorrelativo.Text)
        End If

        objventa.DireccionFacturacion = _GetDireccionFacturacion()
        objventa.DireccionDespacho = _GetDireccionDespacho()
        objventa.codigo_Post = _Pos
        objventa.Moneda = _Moneda
        objventa.Codigo_Empresa = _Empresa
        objventa.ListaArticulos = ArregloItems
        objventa.Abono = txtPagado.Text
        objventa.FonoCliente = ""
        objventa.Banco = _GetBanco()
        objventa.nro_Documento = txtCorrelativo.Text
        objventa.Sede = _Sede
        objventa.Lista = Me.txtListaPrecio.Text
        objventa.DocumentoVenta = DocumentoVenta
        objventa.PuntoFacturacion = _PuntoFacturacion
        objventa.CajaRecepcion = _CajaRecaudacion
        objventa.nombreCliente = txtNombreCliente.Text
        objventa.CodigoVendedor = txtCodigoVendedor.Text
        objventa.nombreVendedor = txtNombreVendedor.Text
        objventa.Lista = txtListaPrecio.Text
        objventa.subtotal = txtSubTotal.Text
        objventa.total = txtFinal.Text
        objventa.Cod_Cliente = _GetRut()
        objventa.CentrodeGestion = _CentrodeGestion
        objventa.iva = txtIva.Text
        objventa.Cargo_Termino_Pago = Me.ObtieneTerminoPago()
        objventa.rutCliente = txtRut.Text
        objventa.Cajero = id_Cajero
        objventa.RazonSocial = Me.txtNombreCliente.Text
        objventa.Bruto = Me.txtBruto.Text
        objventa.FechaVencimiento = GetFechaVencimiento()

        If esVentaRecuperada = True Then
            objventa.FechaEmision = lblFechaDocumento.Text
        End If
        objventa.Flete = 0

        If txtDirección_Flete.Text <> "" Then
            objventa.Flete = Double.Parse(txtDirección_Flete.Text)
        End If

        objventa.PorcentajeDescuento = 0
        If txtPorcentajeDescuento.Text <> "" Then
            objventa.PorcentajeDescuento = Convert.ToDouble(txtPorcentajeDescuento.Text.Replace(".", ","))
        End If

        If txtDescuento.Text.Length <> 0 Then
            objventa.Descuento = Int32.Parse(txtDescuento.Text.Replace(".", ""))
        End If

        'ingreso el valor neto
        Dim neto As Integer = 0
        If txtBruto.Text <> "" Then
            neto = Int32.Parse(txtBruto.Text.Replace(".", ""))
        End If
        objventa.Neto = neto

        'ingreso el subtotal antes del descuento

        Dim totalAntesDescuento As Integer = 0

        If txtSubTotal.Text <> "" Then
            Dim tad As String = Me.txtSubTotal.Text
            tad = tad.Replace(".", "")
            totalAntesDescuento = Int32.Parse(tad)
        End If
        objventa.TotalAntesDescuento = totalAntesDescuento

        Return objventa


    End Function


    Public Function _GetBanco() As String
        Return "0"
    End Function

    Public Function EjecutaVentaRespaldo(ByVal objventa As VentaObj, ByVal EstadoCabesera As Integer)


        Dim idcabesera As Integer = 0
        Dim ds As New DataSet
        Dim dr As DataRow

        If DetectaModalidad() = "V1" Then
            'Actualiza Cabecera
            Dim porcentajecabesera As Double = 0

            If Me.txtPorcentajeDescuento.Text <> "" Then
                porcentajecabesera = Convert.ToDouble(txtPorcentajeDescuento.Text.Replace(".", ","))
            End If




            ds = Me.WS_POS.POS_ActualizaCabecera("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, objventa.Correlativo, _FechaSistema, txtCodigoVendedor.Text, objventa.Cod_Cliente, txtListaPrecio.Text, EstadoCabesera, id_Cajero, porcentajecabesera, 0, 0, 0, 0, 0, "", 2, 0, 0, "", 0, 0, 0, "", 0, 0, PromoNombre)
            dr = ds.Tables(0).Rows(0)
            _cab_Id = Int32.Parse(dr(0).ToString)




            ' Actualiza Detalle
            For Each fila As DataGridViewRow In gridDetalle.Rows
                Dim Dato = ""
               
                Dim dsDetalle As DataSet = Me.WS_POS.POS_ActualizaDetalle("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, objventa.Correlativo, fila.Cells("codigo").Value, fila.Cells("unidadmedida").Value, fila.Cells("cant").Value, 0, 0, 0, fila.Cells("precio").Value, Dato)
                Dim drDetalle As DataRow = dsDetalle.Tables(0).Rows(0)
            Next

            'Actualiza Pagos
            EjecutaRespaldoMediosdePago()

        End If


        If DetectaModalidad() = "V2" Then
            'Actualiza Cabesera
            ds = Me.WS_POS.POS_ActualizaCabecera("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, objventa.Correlativo, _FechaSistema, txtCodigoVendedor.Text, objventa.Cod_Cliente, txtListaPrecio.Text, EstadoCabesera, id_Cajero, 0, 0, 0, 0, 0, 0, "", 2, 0, 0, "", 0, 0, 0, "", 0, 0, "")
            dr = ds.Tables(0).Rows(0)

            'Actualiza Detalle
            For Each fila As DataGridViewRow In gridDetalle.Rows

                Dim dsDetalle As DataSet = Me.WS_POS.POS_ActualizaDetalle("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, objventa.Correlativo, fila.Cells("codigo").Value, fila.Cells("unidadmedida").Value, fila.Cells("cant").Value, 0, 0, 0, fila.Cells("precio").Value, "")
                Dim drDetalle As DataRow = dsDetalle.Tables(0).Rows(0)
            Next


            'If _Modalidad = "NC" Then
            'EjecutaRespaldoMediosdePago()
            ' End If
        End If



        If DetectaModalidad() = "V3" Then

            ' si el documento no estaba creado en wop lo crea para permitir ingresar y asociar los abonos etc etc

            For Each doc_a As DocumentoObj In _DocumentosAplicarPago

                Dim ObjDocumento As New DocumentoController
                If ObjDocumento.VerificaExistenciaenWop(doc_a.Folio, doc_a.TipoDocumento) = False Then
                    ds = Me.WS_POS.POS_ActualizaCabecera("N", _Empresa, _Bodega, _Pos, doc_a.TipoDocumento, doc_a.Folio, _FechaSistema, txtCodigoVendedor.Text, objventa.Cod_Cliente, txtListaPrecio.Text, EstadoCabesera, id_Cajero, 0, 0, 0, 0, 0, 0, "", 2, 0, 0, "", 0, 0, 0, "", 0, 0, "")
                    dr = ds.Tables(0).Rows(0)
                End If

                _tipoDocumentoVenta = doc_a.TipoDocumento
                Me.txtCorrelativo.Text = doc_a.Folio

                EjecutaRespaldoMediosdePago()
            Next
            txtCorrelativo.Text = ""
        End If






    End Function


    Function TipoDocumentoVenta() As String


        Return _tipoDocumentoVenta

    End Function




    Function ItemsCompra() As ArrayList

        Dim articulos As New ArrayList

        For Each fila As DataGridViewRow In gridDetalle.Rows

            Dim objArticulo As New ArticuloObj

            objArticulo.sku = fila.Cells("CODIGO").Value
            objArticulo.nombre = fila.Cells("DESCRIPCION").Value
            objArticulo.Envase = "C"

            articulos.Add(objArticulo)
        Next

        Return articulos

    End Function








    Private Sub btnCompraDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompraDebito.Click
        VuelveModalidadN()
        accionBotonCompraDebito()
    End Sub


    Private Sub accionBotonCompraDebito_()


        Try

            If validaDetallePagos() = False Then
                Exit Sub
            End If
            Dim codigoBanco As String = "-"




            If PagoRestante() <> 0 Or codigoBanco <> "-" Then

                If txtResumenDebito.Text = "" Then
                    RemoverPaneles()
                    Me.TabMedioPago.TabPages.Add(Me.TabDebito)
                    If PagoRestante() <> 0 Then
                        txtResumenDebito.Text = PagoRestante.ToString("N0")
                        txtResumenDebito.ReadOnly = False
                    End If
                    DesactivarMediosPagosVacios()
                    ValidaTotaldePagos()

                    If txtResumenDebito.Text = "" Then

                    End If

                Else
                    If PagoRestante() <> 0 Or codigoBanco <> "-" Then
                        Me.txtResumenDebito.ReadOnly = False
                        Me.txtResumenDebito.Focus()
                        Me.TabMedioPago.TabPages.Clear()
                        Me.TabMedioPago.TabPages.Add(Me.TabDebito)
                        If txtResumenDebito.Text = "" Then

                        End If
                        ValidaTotaldePagos()
                    End If
                End If
            Else
                MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")
            End If

        Catch ex As Exception

            MsgBox("error:" + ex.ToString)

        End Try



    End Sub

     Private Sub accionBotonCompraDebitoCredito()


        If validaDetallePagos() = False Then
            Exit Sub
        End If



        If PagoRestante() <> 0 Or debito_Banco.Text <> "" Then

            If TabMedioPago.TabPages.Count <> 0 Then
                If TabMedioPago.TabPages(0).Name <> "TabDebito" Then
                    Me.RemoverPaneles()
                    Me.TabMedioPago.TabPages.Add(TabTransbank)
                End If
            Else
                Me.RemoverPaneles()
                Me.TabMedioPago.TabPages.Add(TabTransbank)
            End If

            If txtResumenDebitoCredito.Text = "" Then
                txtResumenDebitoCredito.Text = PagoRestante.ToString("N0")
            End If
            txtResumenDebitoCredito.ReadOnly = False
            txtResumenDebitoCredito.Focus()

            ValidaTotaldePagos()
        Else
            MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")

        End If




    End Sub

    Private Sub accionBotonCompraDebito()


        If validaDetallePagos() = False Then
            Exit Sub
        End If



        If PagoRestante() <> 0 Or debito_Banco.Text <> "" Then

            If TabMedioPago.TabPages.Count <> 0 Then
                If TabMedioPago.TabPages(0).Name <> "TabDebito" Then
                    Me.RemoverPaneles()
                    Me.TabMedioPago.TabPages.Add(TabDebito)
                End If
            Else
                Me.RemoverPaneles()
                Me.TabMedioPago.TabPages.Add(TabDebito)
            End If

            If txtResumenDebito.Text = "" Then
                txtResumenDebito.Text = PagoRestante.ToString("N0")
            End If
            txtResumenDebito.ReadOnly = False
            txtResumenDebito.Focus()

            ValidaTotaldePagos()
        Else
            MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")

        End If




    End Sub


    Public Sub RemoverPaneles()
        Me.TabMedioPago.TabPages.Clear()
    End Sub

    Public Sub RemoverPanelesCabecera()
        Me.TabControlCabecera.TabPages.Clear()
    End Sub




    Private Sub btnCompraEfectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompraEfectivo.Click
        VuelveModalidadN()
        AccionBotonEfectivo()

    End Sub

    Public Sub AccionBotonEfectivo()

        If validaDetallePagos() = False Then
            Exit Sub
        End If



        RemoverPaneles()
        Me.TabMedioPago.TabPages.Add(TabEfectivo)

        If PagoRestante() <> 0 Then
            If txtResumenEfectivo.Text = "" Then

                txtResumenEfectivo.ReadOnly = False
                txtResumenEfectivo.Focus()
                txtResumenEfectivo.Text = PagoRestante().ToString("N0")

            End If

            ValidaTotaldePagos()
        Else
            MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")
        End If

    End Sub









    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Debito_Banco.Click
        'RemoverPaneles()
        'Me.TabMedioPago.TabPages.Add(TabEfectivo)
    End Sub

    Function SobrepasaCreditoSteward(ByVal monto As Double) As Boolean

        Dim valor As Boolean = False

        'If monto >= _MontoCreditoSteward Then
        '    valor = True
        'End If

        'Return valor


        Dim objLisa = New ws_lisa.WS_Lisa
        Dim ds = objLisa.ConsultaPos("CRE", "STE", "", "15747893", "", monto, "", "")
        Dim dr = ds.Tables(0).Rows(0)
        If dr("Autoriza").ToString() <> "1" Then
            valor = True
        End If
        Return valor

    End Function



    Protected Sub ValidaTotaldePagos()

        txtVuelto.Text = ""
        txtSaldo.Text = ""
        Dim total As Double = 0

        If Me.txtResumenEfectivo.Text.Trim <> "" Then
            total = total + Double.Parse(txtResumenEfectivo.Text)
        End If
        If Me.txtResumenDebito.Text <> "" Then
            total = total + Double.Parse(txtResumenDebito.Text)
        End If

         If Me.txtResumenDebitoCredito.Text <> "" Then
            total = total + Double.Parse(txtResumenDebitoCredito.Text)
        End If


        If Me.txtResumenCredito.Text <> "" Then
            total = total + Double.Parse(txtResumenCredito.Text)
        End If

        If Me.txtResumenCheque.Text <> "" Then
            total = total + Double.Parse(txtResumenCheque.Text)
        End If

        If Me.txtResumenCreditoSteward.Text <> "" Then
            total = total + Double.Parse(txtResumenCreditoSteward.Text)
        End If

        If Me.txtResumenTransferencia.Text <> "" Then
            total = total + Double.Parse(txtResumenTransferencia.Text)
        End If

        If Me.txtResumenSinPago.Text <> "" Then
            total = total + Double.Parse(txtResumenSinPago.Text)
        End If

        If Me.txtResumenNotaCredito.Text <> "" Then
            total = total + Double.Parse(txtResumenNotaCredito.Text)
        End If


        If total >= Double.Parse(Me.txtFinal.Text) Then
            Dim vuelto As Double = total - Double.Parse(txtFinal.Text)
            Me.txtPagado.Text = total.ToString("N0")
            If vuelto <> 0 Then
                Me.txtVuelto.Text = vuelto.ToString("N0")
            End If

            ' rutina en caso que se utilize nota de credito



        Else

            Dim vuelto_ As Double = total - Double.Parse(txtFinal.Text)

            If vuelto_ <= 0 Then
                vuelto_ = 0
            End If
            If vuelto_ <> 0 Then
                txtVuelto.Text = vuelto_
            End If

            If total <> 0 Then
                txtPagado.Text = total.ToString("N0")
            Else
                txtPagado.Text = ""
            End If

            Dim saldo As Double = Double.Parse(txtFinal.Text) - total

            If (saldo > 0 And saldo < Double.Parse(txtFinal.Text)) Then
                txtSaldo.Text = (Double.Parse(txtFinal.Text) - total).ToString("N0")
            End If




        End If

        If txtPagado.Text <> "" And txtFinal.Text <> "" Then

            If Int32.Parse(txtPagado.Text.Replace(".", "")) >= Int32.Parse(Me.txtFinal.Text.Replace(".", "")) Then
                ' Me.btnDespacho.Enabled = True
                Me.btnPagar.Enabled = True
            Else

                Me.btnPagar.Enabled = False
            End If

        End If



    End Sub

    Private Sub txtEfectivo_monto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub




    Protected Sub OrdenarGrilla()
        Me.gridDetalle.Columns("Codigo").DisplayIndex = 0
        Me.gridDetalle.Columns("Descripcion").DisplayIndex = 1
        Me.gridDetalle.Columns("UnidadMedida").DisplayIndex = 2
        '  Me.gridDetalle.Columns("Precio").DisplayIndex = 3
        Me.gridDetalle.Columns("PrecioIva").DisplayIndex = 4
        Me.gridDetalle.Columns("Cant").DisplayIndex = 5
        Me.gridDetalle.Columns("Valor").DisplayIndex = 6
        Me.gridDetalle.Columns("Descuento").DisplayIndex = 7
        Me.gridDetalle.Columns("Porcentaje").DisplayIndex = 8
        Me.gridDetalle.Columns("Descuento_").DisplayIndex = 9
        Me.gridDetalle.Columns("Eliminar").DisplayIndex = 10
        Me.gridDetalle.Columns("Envase").Visible = False
        Me.gridDetalle.Columns("Oferta").Visible = False
        Me.gridDetalle.Columns("Precio").Visible = False
        Me.gridDetalle.Columns("Porcentaje").Visible = False
        Me.gridDetalle.Columns("Descuento").Visible = False
        Me.gridDetalle.Columns("DescuentoLinea").DisplayIndex = 7

        'me.gridDetalle.Columns("Iva").DisplayIndex = 10
        'me.gridDetalle.Columns("Neto").DisplayIndex = 10
        'me.gridDetalle.Columns("Iva").Visible = False
        'me.gridDetalle.Columns("Neto").Visible = False



        ' Me.gridDetalle.Columns("valorReal").Visible = True
    End Sub

    Private Sub gridDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)


        Dim cantidad As Double = Me.gridDetalle.Rows(e.RowIndex).Cells("Cant").Value
        Dim valor As Double = Me.gridDetalle.Rows(e.RowIndex).Cells("Precio").Value
        Me.gridDetalle.Rows(e.RowIndex).Cells("Valor").Value = valor * cantidad

        CalculaSubTotal()


    End Sub

    Private Sub gridDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If gridDetalle.Rows.Count <> 0 Then

            If sender.CurrentCell.ColumnIndex = 0 Then

                Dim gwr As DataGridViewRow = Me.gridDetalle.Rows(sender.currentcell.rowindex)

                If MsgBox("Desea Eliminar: " + gwr.Cells("Descripcion").Value &
                    " ??", vbQuestion + vbYesNo) = vbYes Then

                    EliminaArticulo(gwr.Cells("Codigo").Value)

                End If


            End If
        End If

    End Sub




    Protected Sub EliminaArticulo(ByVal codigo As String)

        Dim ar As ArrayList = ArregloItems

        If Me.gridDetalle.Rows.Count = 1 Then

            Me.gridDetalle.Rows.RemoveAt(0)

        Else

            For Each ObjArticulo As ArticuloStringObj In ar
                If ObjArticulo.sku = codigo Then
                    ar.Remove(ObjArticulo)
                    Exit For
                End If
            Next

            llenarGrilla(gridDetalle, ar)
            APlicaColoresGrillaDetalle()
        End If
        CalculaSubTotal()
    End Sub

    Private Sub RadFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub


    Protected Sub LimpiaDatosCliente()

        Me.txtNombreCliente.Text = ""
        Me.txtRut.Text = ""
        Me.txtRut.ReadOnly = False
        Me.txtRut.Focus()
        Me.txtNombreVendedor.Text = ""
        Me.txtCodigoVendedor.Text = ""
        Me.btnBuscarCliente.Enabled = True

    End Sub

    Protected Sub CargarDireccionesDespacho(ByVal CodEmpresa As String, ByVal codCliente As String)

        Dim arreglo As ArrayList = objCLiente.GetDireccionesTodas(CodEmpresa, codCliente)

        If arreglo.Count <> 0 Then
            Direcciones_Combo_Despacho.DataSource = arreglo
            Direcciones_Combo_Despacho.DisplayMember = "descripcion"
            Direcciones_Combo_Despacho.ValueMember = "codigo"
        End If

    End Sub

    Private Sub txtDescripcionProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcionProducto.KeyDown

        If e.KeyCode = Keys.Enter Then

            xDialogo.txtBusqueda.Text = txtDescripcionProducto.Text
            xDialogo.listaPrecio = Me.txtListaPrecio.Text
            xDialogo.tipo = "D"
            xDialogo.CargarDatos()
            xDialogo.ShowDialog()

        End If

    End Sub

    Private Sub Pos_BuscarArt(ByVal codigo As String) Handles xDialogo.BuscarArt


        Me.txtCodigoProducto.Text = codigo
        Me.txtCodigoProducto.Focus()

        If BuscarArticulo() = True Then
            IngresaCantidadArticulo(1)
        End If


    End Sub

    Private Sub Pos_BuscaVendedor(ByVal codigo As String, ByVal nombre As String) Handles xVendedor.traeVendedor

        Me.txtCodigoVendedor.Text = codigo
        Me.txtNombreVendedor.Text = nombre

    End Sub

    Private Sub pos_Descuento(ByVal tipo As Integer, ByVal porcentaje As Double, ByVal codigo As String) Handles xDescuento.IngresaDescuento

        If tipo = 1 Then
            If porcentaje <> 0 Then
                txtPorcentajeDescuento.Text = porcentaje
            Else
                txtPorcentajeDescuento.Text = ""
            End If

            For Each x As DataGridViewRow In gridDetalle.Rows

                Dim total As Double = Double.Parse(x.Cells("Valor").Value)
                total = (total * porcentaje) / 100
                x.Cells("Porcentaje").Value = porcentaje.ToString("N0")
                x.Cells("Descuento").Value = total.ToString("N0")

            Next

            ' AplicarDescuento(1, porcentaje)
            CalculaSubTotal()
        End If

        If tipo = 2 Then

            'aca selecciono la fila y escribo la glosa del porcentaje de descuento
            Dim gr As DataGridViewRow = traefila(codigo)

            Dim total As Double = Double.Parse(gr.Cells("Valor").Value)
            total = (total * porcentaje) / 100

            gr.Cells("Porcentaje").Value = porcentaje.ToString("N0")
            gr.Cells("Descuento").Value = total.ToString("N0")


            CalculaSubTotal()
        End If


    End Sub


    Public Sub AplicaDescuentos()

        If Me.gridDetalle.Rows.Count = 0 Then
            Me.txtDescuento.Text = ""
        End If

        If txtPorcentajeDescuento.Text = "" Or txtPorcentajeDescuento.Text = "0" Then
            If obtenerSumaTotalDescuentosDetalle() <> 0 Then
                txtDescuento.Text = obtenerSumaTotalDescuentosDetalle().ToString("N0")
            Else
                txtDescuento.Text = ""
            End If

        Else

            Dim descuentoactual As Integer = 0
            If txtDescuento.Text <> "" Then
                descuentoactual = Convert.ToDouble(txtDescuento.Text.Replace(".", ""))
            End If

            Dim porcentajeCabesera = Double.Parse(txtPorcentajeDescuento.Text)
            Dim descuento As Double = Double.Parse(txtSubTotal.Text) * porcentajeCabesera
            descuento = descuento / 100

            If descuento <> 0 Then
                txtDescuento.Text = (obtenerSumaTotalDescuentosDetalle() + descuento).ToString("N0")
            Else
                txtDescuento.Text = ""
            End If
        End If

    End Sub

    Public Function obtenerSumaTotalDescuentosDetalle() As Double

        Dim totalDescuentos As Double = 0

        For Each gvrow As DataGridViewRow In gridDetalle.Rows
            Dim valor As Double = 0

            If Not IsNothing(gvrow.Cells("DescuentoLinea").Value) Then
                If gvrow.Cells("DescuentoLinea").Value <> 0 Then
                    valor = gvrow.Cells("DescuentoLinea").Value
                End If
            End If

            totalDescuentos = totalDescuentos + valor
        Next
        Return totalDescuentos

    End Function


    Public Function ObtenerDescuentoCabeseraDocumento() As Double

        Dim descuento As Double = 0

        Dim Subtotal As Double = Double.Parse(Me.txtSubTotal.Text)
        Dim cabecera As Double = 0
        If txtPorcentajeDescuento.Text <> "" Then
            cabecera = Double.Parse(Me.txtPorcentajeDescuento.Text)
        End If
        Dim porcentaje As Double = cabecera
        descuento = (Subtotal * porcentaje) / 100
        Return descuento

    End Function

    Private Sub txtRut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRut.KeyDown


        If e.KeyCode = Keys.Enter Then
            If txtRut.Text = "" Then
                xBusquedaCliente.txtBusqueda.Text = ""
                xBusquedaCliente.txtBusqueda.Focus()
                xBusquedaCliente.ShowDialog()
            End If

            If txtRut.Text.Length = 7 Or txtRut.Text.Length = 8 Then

                Dim dv As String = _digitoverificador(Int32.Parse(txtRut.Text))
                Dim rut As String = txtRut.Text + "-" + dv
                If objVal.ValidaRut(rut) = True Then
                    Me.txtRut.Text = rut
                End If

            End If

            BuscarCliente()
        End If




    End Sub

    Private Sub txtDescripcionProducto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcionProducto.TextChanged

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub TabCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Condicion_Pago.Click

    End Sub

    Private Sub Label32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label32.Click

    End Sub

    Function CondiciondePagoencheque(ByVal dias As Integer)


        Dim ultimafecha As DateTime = Nothing

        If cheque_grid_cheque.Rows.Count = 1 Then
            ultimafecha = cheque_grid_cheque.Rows(0).Cells("Fecha").Value
            ultimafecha = ultimafecha.AddDays(dias)
            Me.cheque_grid_cheque.Rows(0).Cells("Fecha").Value = ultimafecha.ToString("dd/MM/yyyy")
            Exit Function
        End If

        For Each gr As DataGridViewRow In Me.cheque_grid_cheque.Rows

            If ultimafecha = Nothing Then
                ultimafecha = gr.Cells("Fecha").Value
            Else
                ultimafecha = ultimafecha.AddDays(dias)
            End If

            gr.Cells("Fecha").Value = ultimafecha.ToString("dd/MM/yyyy")

        Next


    End Function

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)





    End Sub

    Private Sub btnAgregarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Cheque_txt_Cantidad.Text = "" Then
            MsgBox("Ingrese Cantidad", MsgBoxStyle.Information, "Dato Requerido")
            Cheque_txt_Cantidad.Focus()
            Exit Sub
        End If

        If verificaPagoCompleto() = True Then

            MsgBox("Ya se encuentra Pagado el total de la venta", MsgBoxStyle.Information, " Información")
            Exit Sub

        End If
        If cheque_txt_rut.Text <> "" Then

            If Me.objVal.ValidaRut(txtRut.Text) = False Then
                MsgBox("Rut Invalido", MsgBoxStyle.Exclamation, "Error de Validación")
                Exit Sub
            End If

        End If

        GrillaCheques_AgregarCheques()

        For Each gr As DataGridViewRow In Me.cheque_grid_cheque.Rows

            If cheque_txt_rut.Text <> "" Then
                gr.Cells("rut_titular").Value = cheque_txt_rut.Text
            End If
            If cheque_Banco_Codigo.Text <> "" Then
                gr.Cells("codigobanco").Value = cheque_Banco_Codigo.Text

                gr.Cells("Banco").Value = cheque_Banco.Text
            End If
            If cheque_txt_nroCuenta.Text <> "" Then
                gr.Cells("Cta_cte").Value = cheque_txt_nroCuenta.Text
            End If

        Next

        ' ChequeDialog.Show()
    End Sub


    Function verificaPagoCompleto() As Boolean

        Dim yapagado As Boolean = False

        Dim total As Double = 0
        Dim pagado As Double = 0

        If txtFinal.Text <> "" Then
            total = Double.Parse(txtFinal.Text)
        End If

        If txtPagado.Text <> "" Then
            pagado = Double.Parse(txtPagado.Text)
        End If

        If pagado >= total Then
            yapagado = True
        End If

        Return yapagado
    End Function



    Private Sub btnCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompraCheque.Click
        VuelveModalidadN()

        'If txtRut.Text = "10-8" Or txtNombreCliente.Text.TrimEnd = "CLIENTE FINAL" Then
        '    MsgBox("Ingrese el Rut del Cliente", MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If
        AccionBotonCheque()

    End Sub



    Public Sub AccionBotonCheque()
        If validaDetallePagos() = False Then
            Exit Sub
        End If

        If PagoRestante() <> 0 Or txtResumenCheque.Text <> "" Then

            If TabMedioPago.TabPages.Count <> 0 Then
                If TabMedioPago.TabPages(0).Name <> "TabDebito" Then
                    Me.RemoverPaneles()
                    Me.TabMedioPago.TabPages.Add(btn_Condicion_Pago)
                End If
            Else
                Me.RemoverPaneles()
                Me.TabMedioPago.TabPages.Add(btn_Condicion_Pago)
            End If

            If txtResumenCheque.Text = "" Then
                txtResumenCheque.Text = PagoRestante.ToString("N0")
            End If
            accionBotonCheque2()
            txtResumenCheque.ReadOnly = False
            txtResumenCheque.Focus()
            txtResumenCheque.Enabled = True
            If _DeudorCheque = True Then

                Cheque_txt_Cantidad.Text = "1"

                Call Cheque_txt_Cantidad_KeyDown(Cheque_txt_Cantidad, New KeyEventArgs(Keys.Enter))
                Cheque_txt_Cantidad.Enabled = False


            End If


            ValidaTotaldePagos()
        Else
            MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")

        End If



    End Sub


    Private Sub accionBotonCheque2()
        If Me.cheque_grid_cheque.Columns.Count = 0 Then
            CreaCabeseraCheques()
        End If

        If validaDetallePagos() = False Then
            Exit Sub
        End If

        If PagoRestante() <> 0 Then
            txtResumenCheque.Text = PagoRestante.ToString("N0")
        End If
        txtResumenCheque.ReadOnly = False
        txtResumenCheque.Focus()

    End Sub




    Public Sub AccionBotonFactura(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If gridDetalle.Rows.Count <> 0 Then

            If _MENSAJE_CONFIRMACION("Desea Realizar una Nueva Venta", "STEWARD") = True Then
                _tipoDocumentoVenta = "FAAF"

                If _MENSAJE_CONFIRMACION("¿ Desea Conservar los Items de la Compra ?", "STEWARD") = False Then

                    ResetFormulario()
                Else

                    Dim asa = _NumeroLineas
                    If Me.gridDetalle.Rows.Count > _NumeroLineas Then
                        MsgBox("EL Item Maximo de Items es " + _NumeroLineas, MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If

                End If


                Me.txtCorrelativo.Text = ""
                Try
                    Dim objdocumentoventa As New DocumentosVentaController
                    txtCorrelativo.ForeColor = Color.Blue

                    txtCorrelativo.Text = objdocumentoventa.GetFolio(_Sede, _PuntoFacturacion, "FAAF")

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                LimpiaDatosCliente()
                Me.txtRut.ReadOnly = False
                Me.txtRut.Enabled = True
                Me.txtRut.Focus()

            End If
        Else
            Try
                ResetFormulario()
                _tipoDocumentoVenta = "FAAF"
                Dim objdocumentoventa As New DocumentosVentaController
                txtCorrelativo.ForeColor = Color.Blue
                'txtCorrelativo.Text = WS_POS.POS_Correlativo(TipoDocumentoVenta)
                txtCorrelativo.Text = objdocumentoventa.GetFolio(_Sede, _PuntoFacturacion, "FAAF")


            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            LimpiaDatosCliente()
            Me.btnNuevaVenta.BackColor = Color.Aqua
            btnNuevaBoleta.BackColor = Color.Gainsboro
            Me.txtRut.ReadOnly = False
            Me.txtRut.Enabled = True
            Me.txtRut.Focus()

        End If


        Dim objdoc As New DocumentoController
        If objdoc.verificaexistenciafolio("FAAF", Me.txtCorrelativo.Text) = True Then
            Dim objdocven As New DocumentosVentaController
            Me.btnNuevaBoleta_Click(sender, e)
        End If

        Me.txtDocumento.Text = "FACTURA"
    End Sub


    Private Sub btnNuevaVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaVenta.Click
        Me.chkOferta.Checked = False
        esVentaRecuperada = False
        _cab_Id = 0

        AccionBotonFactura(sender, e)

        ' AccionBotonNuevaVenta()
    End Sub

    Public Sub AccionBotonNuevaVenta()


        If _MENSAJE_CONFIRMACION("Desea Realizar una Nueva Venta", "STEWARD") = True Then
            ResetFormulario()
            Me.txtCorrelativo.Text = ""
            btnPagar.Enabled = True
        End If



    End Sub

    Private Sub ResetFormulario()

        Me.grillaNotasCredito.Rows.Clear()
        _CreditoPendienteAutorizar = False
        Me.txtNota_nro_nota_Credito.Text = ""
        'Me.txtNotaMonto.Text = ""
        Me.txtTransferenciaRut.Text = ""
        Me.txtTransferenciaNro.Text = ""
        Me.txtTransferenciaNombre.Text = ""
        Me.txtTransferenciaObservaciones.Text = ""
        Me.txtResumenNotaCredito.Text = ""
        txt_Transferencia_Banco.Text = ""
        txt_transferencia_codigobanco.Text = ""
        Me.lblItemsDetalle.Text = ""
        Me.lblLineasDetalle.Text = ""
        Me.btnDetalle.Enabled = False
        txtResumenSinPago.Text = ""
        cheque_Banco.Text = ""
        Me.btn_sin_Pago.Enabled = False
        Me.ErrorProvider1.Clear()
        credito_txt_banco.Text = ""
        creditotxtCodigoBanco.Text = ""
        credito_txt_tipotarjeta.Text = ""
        credito_txt_codigo_tipoTarjeta.Text = ""
        Me.credito_txt_nro_operacion.Enabled = False
        Me.credito_txt_CodAutorizacion.Enabled = False
        Me.txtCuotasCredito.Enabled = False
        Me.credito_txt_banco.Text = ""

        txtCuotasCredito.Text = ""
        txtCreditoTerminoPago.Text = ""
        valoresParametrosCredito.termino = Nothing
        valoresParametrosCredito.banco = Nothing
        valoresParametrosCredito.tipoTarjeta = Nothing

        txtResumenTransferencia.ReadOnly = True
        Me.txtDocumento.Text = ""
        Me.btn_Credito_Steward.Enabled = False
        esVentaRecuperada = False
        txtDirección_Flete.Text = ""
        txtResumenDespacho.Text = ""
        txtResumenTransferencia.Text = ""
        Me.btnGuardar.Enabled = False
        txtPorcentajeDescuento.Text = ""
        txtCorrelativo.Text = ""
        ArregloItems.Clear()
        btnPagar.Enabled = False
        Me.txtRut.Enabled = False
        Me.txtRut.Text = ""
        Me.txtNombreCliente.Text = ""
        Me.txtCodigoCliente.Text = ""
        Me.txtNombreVendedor.Text = ""
        txtCodigoVendedorAsignado.Text = ""
        txtDescripcionVendedorAsignado.Text = ""
        Me.txtCodigoVendedor.Text = ""
        Me.txtCodigoProducto.Text = ""
        Me.txtDescripcionProducto.Text = ""
        Me.txtCantidad.Text = ""
        txtCodigoProducto.Enabled = False
        txtDescripcionProducto.ReadOnly = True
        txtCantidad.Enabled = False
        Me.txtSubTotal.Text = ""
        Me.txtBruto.Text = ""
        Me.txtIva.Text = ""
        'Dim arr As New ArrayList
        'Dim objarticulo As New ArticuloObj

        'Me.btn_Anular.Enabled = False
        Me.TabControl.TabPages.Remove(txt_Debito_Banco)
        Me.TabControl.TabPages.Remove(TabArticulos)
        Me.TabControl.TabPages.Add(TabArticulos)
        Me.txtResumenEfectivo.Text = ""
        txtResumenEfectivo.ReadOnly = True
        Me.txtResumenCredito.Text = ""
        txtResumenCredito.ReadOnly = True
        Me.txtResumenDebito.Text = ""
        txtResumenDebito.ReadOnly = True
        Me.txtResumenCreditoSteward.Text = ""
        txtResumenCreditoSteward.ReadOnly = True
        Me.txtResumenCheque.Text = ""
        txtResumenCheque.ReadOnly = True
        ' Me.txtEfectivo_monto.Text = ""
        txtFinal.Text = ""
        txtListaPrecio.Text = ""
        txtPagado.Text = ""
        txtVuelto.Text = ""
        txtCodigoDirección.Text = ""
        txtNombreDireccion.Text = ""

        txtCodigoDirecciónDespacho.Text = ""
        txtNombreDireccionDespacho.Text = ""


        txtDescuento.Text = ""
        txtPorcentajeDescuento.Text = ""

        Try
            Dim x As New ArrayList
            Me.gridDetalle.DataSource = x
            If Me.gridDetalle.ColumnCount < 12 Then
                Me.CreaCabeserasGrid()
            End If


        Catch ex As Exception
            MsgBox("Error:" + ex.ToString)
        End Try


        ' efectivo
        txtResumenEfectivo.Text = ""
        'txtEfectivo_monto.Text = ""
        ' credito
        credito_txt_CodAutorizacion.Text = ""
        credito_txt_nro_operacion.Text = ""

        'credito_txt_monto.Text = ""
        credito_txt_codigo_tipoTarjeta.Text = ""


        'debito

        Debito_txt_Codigo_Autorizacion.Text = ""
        'debito_txt_Monto.Text = ""
        debito_txtNroOperacion.Text = ""
        debito_codigo_banco.Text = ""
        debito_Banco.Text = ""


        'cheque

        cheque_txt_nroCuenta.Text = ""
        cheque_txt_rut.Text = ""
        Cheque_txt_Cantidad.Text = ""

        chequetxtCondicionPago.Text = ""
        cheque_txt_condicionPago_Codigo.Text = ""

        If Me.cheque_grid_cheque.Rows.Count <> 0 Then
            Me.cheque_grid_cheque.Rows.Clear()

        End If


        ' credito Steward
        txtResumenCreditoSteward.Text = ""
        txtResumenSinPago.ReadOnly = True




    End Sub

    Private Sub efectivo_btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Efectivo_err_Monto.Clear()
        '  If Me.txtEfectivo_monto.Text <> "" Then


        If Me.TXTMEDIOPAGO.Text = 1 Then
            ' Dim monto As Double = Double.Parse(Me.txtEfectivo_monto.Text.ToString)
            ' txtResumenEfectivo.Text = monto.ToString("N0")

            ValidaTotaldePagos()
        End If
        '  Else
        '  Efectivo_err_Monto.SetError(txtEfectivo_monto, "Ingrese  Valor")
        '  End If


    End Sub




    Private Sub TabBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabTransferencia.Click

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ErrorProvider1.Clear()



        If Me.credito_txt_nro_operacion.Text = "" Then

            ErrorProvider1.SetError(credito_txt_nro_operacion, "Ingrese Valor")
            Exit Sub

        End If


        If Me.credito_txt_CodAutorizacion.Text = "" Then

            ErrorProvider1.SetError(credito_txt_CodAutorizacion, "Ingrese Valor")
            Exit Sub

        End If


        'If Me.credito_txt_monto.Text = "" Then
        '
        ' ErrorProvider1.SetError(credito_txt_monto, "Ingrese Valor")
        ' Exit Sub

        '  End If







        'Dim monto As Double = credito_txt_monto.Text
        'txtResumenCredito.Text = monto.ToString("N0")
        ValidaTotaldePagos()


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Compra_credito.Click
        VuelveModalidadN()

        AccionBotonCredito()


    End Sub

    Public Sub ListaDIsplayBanco(ByVal tipo As String, ByVal codigo As String, ByVal descripcion As String) Handles XListaDisplay.ListaDisplay

        ListaDisplay(tipo, codigo, descripcion)


    End Sub

    Public Sub ListaDisplay(ByVal tipo As String, ByVal codigo As String, ByVal descripcion As String)

        If tipo = "CreditoBanco" Then
            Me.credito_txt_banco.Text = descripcion
            Me.creditotxtCodigoBanco.Text = codigo

        End If


        If tipo = "CreditoTipoTarjeta" Then
            Me.credito_txt_tipotarjeta.Text = descripcion
            Me.credito_txt_codigo_tipoTarjeta.Text = codigo
            Me.credito_txt_nro_operacion.Enabled = True

        End If


        If tipo = "DebitoBanco" Then
            Me.debito_Banco.Text = descripcion
            Me.debito_codigo_banco.Text = codigo
            Me.debito_txtNroOperacion.Focus()

        End If

        If tipo = "ChequeTermino" Then
            Me.chequetxtCondicionPago.Text = descripcion
            cheque_txt_condicionPago_Codigo.Text = codigo

            Dim dias As Integer = 0


            If descripcion.Contains("7") Then
                dias = 7
            End If


            If descripcion.Contains("15") Then
                dias = 15
            End If


            If descripcion.Contains("30") Then
                dias = 30
            End If

            If descripcion.Contains("60") Then
                dias = 60
            End If

            CondiciondePagoencheque(dias)


        End If
        If tipo = "ChequeBanco" Then

            cheque_Banco.Text = descripcion
            cheque_Banco_Codigo.Text = codigo
            ActualizaBancoCheque()

        End If

        If tipo = "TransferenciaBanco" Then

            txt_Transferencia_Banco.Text = descripcion
            txt_transferencia_codigobanco.Text = codigo
            TransferenciaFecha.Enabled = True
            Me.txtTransferenciaObservaciones.Enabled = True
            TransferenciaFecha.Focus()


        End If

    End Sub


    Protected Sub AccionBotonCredito()

        If validaDetallePagos() = False Then
            Exit Sub
        End If




        If PagoRestante() <> 0 Or Not IsNothing(valoresParametrosCredito.banco) Then

            If TabMedioPago.TabPages.Count <> 0 Then
                If TabMedioPago.TabPages(0).Name <> "TabCredito" Then
                    Me.RemoverPaneles()
                    Me.TabMedioPago.TabPages.Add(TabCredito)
                End If
            Else
                Me.RemoverPaneles()
                Me.TabMedioPago.TabPages.Add(TabCredito)
            End If

            If txtResumenCredito.Text = "" Then
                txtResumenCredito.Text = PagoRestante.ToString("N0")
            End If
            txtResumenCredito.ReadOnly = False
            txtResumenCredito.Focus()
            'Me.Credito_Combo_Banco.Enabled = True

            ValidaTotaldePagos()
        Else
            If txtResumenCredito.Text <> "" Then
                Me.RemoverPaneles()
                Me.TabMedioPago.TabPages.Add(TabCredito)
            Else
                MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")
            End If


        End If



    End Sub

    Protected Sub CargaComboTerminoPagoCredito()



    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If _MENSAJE_CONFIRMACION("¿Desea Cerrar?, se cancelara la venta que Esta en Proceso!!", "Cerrar") = True Then
            Me.Close()
            Dim objLog As New PosLog
            objLog.GuardaMvto("M", "Cierre de Sesion")
        End If

    End Sub

    Private Sub debito_txt_Monto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Me.TXTMEDIOPAGO.Text = 1 Then
                ' Dim monto As Double = Double.Parse(Me.debito_txt_Monto.Text.ToString)
                ' txtResumenDebito.Text = monto.ToString("N0")
                ValidaTotaldePagos()

            End If
        End If
    End Sub

    Private Sub debito_txt_Monto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Credito_Steward.Click

        If _CreditoPendienteAutorizar = True Then

            Xautorizacion.Tipo.Text = "SinCredito"
            Xautorizacion.ShowDialog()


            Exit Sub
        End If

        VuelveModalidadN()
        AccionBotonCreditoSteward()


        'Me.TabMedioPago.TabPages.Add(TabNotaCredito)

    End Sub

    Private Sub VuelveModalidadN()

        If _Modalidad = "SP" Then
            _Modalidad = "N"
        End If

        If _Modalidad = "NC" Then
            _Modalidad = "N"
        End If



    End Sub

    Private Sub AccionBotonCreditoSteward()
        If validaDetallePagos() = False Then
            Exit Sub
        End If

        Me.RemoverPaneles()

        Me.TabMedioPago.TabPages.Add(TabCreditoSteward)

        txtResumenCreditoSteward.ReadOnly = False
        Me.txtResumenCreditoSteward.Focus()


        If PagoRestante() <> 0 Then
            txtResumenCreditoSteward.Text = PagoRestante().ToString("N0")
            ValidaTotaldePagos()

            If SobrepasaCreditoSteward(Double.Parse(txtResumenCreditoSteward.Text)) = True Then

                MessageBox.Show("Cifra sobre Limite de Credito, contacte al jefe de tienda", "Credito")

                'If _MENSAJE_CONFIRMACION("Cifra sobre Limite de Credito, desea Ingresar Credito con Aprobación de Supervisor", "Credito") = True Then

                '    'Xautorizacion.Tipo.Text = "Credito"
                '    'Xautorizacion.ShowDialog()
                '    ValidaTotaldePagos()


                'Else
                If AprobacionExcesoCreditoSteward = False Then
                    Me.txtResumenCreditoSteward.Text = ""
                    Me.TabMedioPago.TabPages.Remove(TabCreditoSteward)
                    ValidaTotaldePagos()
                    Exit Sub
                End If
                'End If

            Else
                txtCreditoRut.Text = txtRut.Text
                txtCredito_OrdendeCompra.Focus()


            End If

        End If
    End Sub

    Private Sub gridDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDetalle.CellClick

        If e.RowIndex > 0 Then
            _cantidaditemsdetalle = Me.gridDetalle.Rows(e.RowIndex).Cells("Cant").Value
        End If



    End Sub

    Private Sub gridDetalle_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDetalle.CellContentClick

        If e.ColumnIndex = 1 Then
            If _MENSAJE_CONFIRMACION("DESEA ELIMINAR: " + Me.gridDetalle.Rows(e.RowIndex).Cells("Descripcion").Value, "Eliminar Item") = True Then
                EliminaArticulo(Me.gridDetalle.Rows(e.RowIndex).Cells("CODIGO").Value)
                CalculaSubTotal()
                CalculaItemsTotalesLineasdeDetalle()
            End If
        End If

        If e.ColumnIndex = 0 Then
            xDescuento.txtCodigoArticulo.Text = Me.gridDetalle.Rows(e.RowIndex).Cells("Codigo").Value
            xDescuento.txtTipo.Text = 2
            xDescuento.ShowDialog()
        End If

    End Sub


    Protected Sub EliminarItem()

        If Me.gridDetalle.Rows.Count <> 0 Then
            Dim fila As Integer = gridDetalle.CurrentRow.Index
            Dim cantidad As Integer = 0
            Dim gr As DataGridViewRow = gridDetalle.Rows(fila)

            If _MENSAJE_CONFIRMACION("DESEA ELIMINAR: " + Me.gridDetalle.Rows(fila).Cells("Descripcion").Value, "Eliminar Item") = True Then
                EliminaArticulo(Me.gridDetalle.Rows(fila).Cells("CODIGO").Value)
                CalculaSubTotal()
            End If
        End If



    End Sub

    Private Sub gridDetalle_CellEndEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDetalle.CellEndEdit




        If e.ColumnIndex = 8 Then

            If Me.gridDetalle.Rows.Count <> 0 Then
                Dim fila As Integer = gridDetalle.CurrentRow.Index
                Dim cantidad As Integer = 0
                Dim gr As DataGridViewRow = gridDetalle.Rows(fila)
                cantidad = Int32.Parse(gr.Cells("Cant").Value)
                XFormCantidad.cantidad = cantidad
                XFormCantidad.fila = fila
                XFormCantidad.ShowDialog()
            End If

        End If
        'Else

        ' Me.gridDetalle.Rows(e.RowIndex).Cells("Cant").Value = _cantidaditemsdetalle





    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalle.Click


        Me.TabControl.TabPages.Clear()
        Me.TabControl.TabPages.Add(TabArticulos)
        Me.OrdenarGrilla()
        Me.txtCodigoProducto.Focus()
    End Sub


    Public Function GetFechaVencimiento() As String

        Dim fechas As New ArrayList
        Dim FechaVencimiento As String = ""

        If txtResumenEfectivo.Text <> "" Then
            fechas.Add(_FechaComun)
        End If

        If txtResumenDebito.Text <> "" Then
            fechas.Add(_FechaComun)
        End If

        If txtResumenCredito.Text <> "" Then
            fechas.Add(_FechaComun)
        End If

        If txtResumenCheque.Text <> "" Then
            For Each gr As DataGridViewRow In Me.cheque_grid_cheque.Rows
                fechas.Add(gr.Cells("Fecha").Value.ToString)
            Next
        End If

        If txtResumenCreditoSteward.Text <> "" Then
            Dim fecha As DateTime = Now
            fecha = fecha.AddDays(30)
            fechas.Add(fecha.ToString("dd/MM/yyyy"))
        End If

        If txtResumenTransferencia.Text <> "" Then
            fechas.Add(_FechaComun)
        End If

        If txtResumenNotaCredito.Text <> "" Then
            fechas.Add(_FechaComun)
        End If


        If txtResumenTransferencia.Text <> "" Then
            fechas.Add(_FechaComun)
        End If

        If Me.txtResumenSinPago.Text <> "" Then
            fechas.Add(_FechaComun)
        End If


        Dim final As String = ""

        For i As Integer = 0 To fechas.Count - 1

            Dim fecha As Date = fechas(i)
            final = fechas(i)
            For i2 As Integer = 0 To fechas.Count - 1

                If fecha < Date.Parse(fechas(i2)) Then
                    fecha = Date.Parse(fechas(i2))
                    final = fechas(i2)
                End If

            Next

        Next

        Return final

    End Function


    Public Function EjecutaRespaldoMediosdePago()

        Dim arr As New ArrayList

        If txtResumenEfectivo.Text <> "" Then
            EjecutaRespaldoPagoEfectivo()
        End If

        If txtResumenDebito.Text <> "" Then
            EjecutaRespaldoPagoDebito()
        End If

        If txtResumenCredito.Text <> "" Then
            EjecutaRespaldoPagoCredito()
        End If

        If txtResumenCheque.Text <> "" Then

            EjecutaRespaldoPagoCheque()
        End If
        If txtResumenCreditoSteward.Text <> "" Then
            EjecutaRespaldoCreditoSteward()
        End If

        If txtResumenTransferencia.Text <> "" Then
            EjecutaRespaldoTransferencia()
        End If

        If txtResumenNotaCredito.Text <> "" Then
            EjecutaRespaldoNotaCredito()
        End If

        Return arr

    End Function
    Public Sub EjecutaRespaldoTransferencia()
        Dim correlativo As Integer = Int32.Parse(Me.txtCorrelativo.Text)

        Dim dsMedioPago As DataSet = Me.WS_POS.POS_ActualizaPagos("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, correlativo, "", "DEPO", 1, 0, 1, Me.txtTransferenciaRut.Text, "  ", Me.txtTransferenciaNro.Text, txtCredito_OrdendeCompra.Text, 1, 1, "", txtResumenTransferencia.Text.Replace(".", ""), 1, Me.txtTransferenciaNombre.Text)
        Dim drMedioPago As DataRow = dsMedioPago.Tables(0).Rows(0)
        If drMedioPago(0).ToString = "-1" Then
            MsgBox("ERROR en el Procedimiento vb: EjecutaRespaldoTransferencia() -  Detalle:" + drMedioPago(1).ToString, MsgBoxStyle.Exclamation, "ERROR DE RESPALDO DE PAGO EN WOP")
        End If

    End Sub


    Public Sub EjecutaRespaldoNotaCredito()

        Dim contador As Integer = 1

        For Each x As ListaObj In _NotasDeCredito

            Dim dsMedioPago As DataSet = Me.WS_POS.POS_ActualizaPagos("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, Int32.Parse(Me.txtCorrelativo.Text), contador, "NCAF", 1, 0, 1, "", "", "", x.Codigo, _NotasDeCredito.Count, contador, "", x.Descripcion.Replace(".", ""), 1, "")

            Dim drMedioPago As DataRow = dsMedioPago.Tables(0).Rows(0)
            If drMedioPago(0).ToString = "-1" Then
                MsgBox("ERROR en el Procedimiento vb: EjecutaRespaldoTransferencia() -  Detalle:" + drMedioPago(1).ToString, MsgBoxStyle.Exclamation, "ERROR DE RESPALDO DE PAGO EN WOP")
            End If

            contador = contador + 1

        Next
    End Sub

    Public Sub EjecutaRespaldoCreditoSteward()


        Dim dsMedioPago As DataSet = Me.WS_POS.POS_ActualizaPagos("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, txtCorrelativo.Text, "", "CRED", 1, 0, 1, Me.txtCreditoRut.Text, "  ", Me.txtCredito_OrdendeCompra.Text, "", 1, 1, "", txtResumenCreditoSteward.Text, 1, "")
        Dim drMedioPago As DataRow = dsMedioPago.Tables(0).Rows(0)
        If drMedioPago(0).ToString = "-1" Then
            MsgBox("ERROR en el Procedimiento vb: EjecutaRespaldoCreditoSteward() -  Detalle:" + drMedioPago(1).ToString, MsgBoxStyle.Exclamation, "ERROR DE DEPURACION  STEWARD")
        End If


    End Sub

    Public Sub EjecutaRespaldoPagoEfectivo()
        Dim abono As Integer = 0

        If txtResumenDebito.Text = "" And txtResumenCredito.Text = "" And txtResumenCreditoSteward.Text = "" And txtResumenTransferencia.Text = "" And txtResumenCheque.Text = "" Then
            abono = Int32.Parse(txtFinal.Text.Replace(".", ""))
        Else
            abono = Int32.Parse(txtResumenEfectivo.Text.Replace(".", ""))
        End If

        Dim dsMedioPago As DataSet = Me.WS_POS.POS_ActualizaPagos("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, txtCorrelativo.Text, "", "EFEC", 1, 0, 1, "", "  ", " ", "", 1, 1, "", abono, 1, "")
        Dim drMedioPago As DataRow = dsMedioPago.Tables(0).Rows(0)
        If drMedioPago(0).ToString = "-1" Then
            MsgBox("ERROR en el Procedimiento vb: EjecutaRespaldoPagoEfectivo() -  Detalle:" + drMedioPago(1).ToString, MsgBoxStyle.Exclamation, "ERROR DE DEPURACION  STEWARD")
        End If

    End Sub

    Public Sub EjecutaRespaldoPagoDebito()
        Dim cuotadebito As Integer = Int32.Parse(txtResumenDebito.Text.Replace(".", ""))
        Dim dsMedioPago As DataSet = Me.WS_POS.POS_ActualizaPagos("N", _Empresa, _Bodega, _Pos, _tipoDocumentoVenta, txtCorrelativo.Text, "", "TDEB", 1, debito_codigo_banco.Text, 1, "", "", debito_txtNroOperacion.Text, Debito_txt_Codigo_Autorizacion.Text, 1, 1, "", cuotadebito, 1, "")
        Dim drMedioPago As DataRow = dsMedioPago.Tables(0).Rows(0)

        If drMedioPago(0).ToString = "-1" Then
            MsgBox("ERROR en el Procedimiento vb: EjecutaRespaldoPagoDebito) -  Detalle:" + drMedioPago(1).ToString, MsgBoxStyle.Exclamation, "ERROR DE DEPURACION  STEWARD")

        End If

    End Sub

    Public Sub EjecutaRespaldoPagoCredito()

        Dim cuotacredito As Integer = Int32.Parse(txtResumenCredito.Text.Replace(".", ""))
        Dim cuotas As Integer = Int32.Parse(txtCuotasCredito.Text)
        Dim monto As Integer = cuotacredito / cuotas
        Dim dif As Integer

        If (monto * cuotas) < cuotacredito Then
            dif = cuotacredito - (monto * cuotas)
        End If

        If (monto * cuotas) > cuotacredito Then
            dif = cuotacredito - (monto * cuotas)
        End If


        ' Dim objTarjeta As ListaObj = CreditoTipoTarjeta.SelectedItem
        For x As Integer = 1 To cuotas

            If x = cuotas Then
                monto = monto + dif
            End If
            Dim dsMedioPago As DataSet = Me.WS_POS.POS_ActualizaPagos("N", _Empresa, _Bodega, _Pos, TipoDocumentoVenta, txtCorrelativo.Text, "", "TCRE", Int32.Parse(credito_txt_codigo_tipoTarjeta.Text), creditotxtCodigoBanco.Text, 1, "", "", credito_txt_nro_operacion.Text, credito_txt_CodAutorizacion.Text, 2, x, _FechaSistema, monto, 1, "")
            Dim drMedioPago As DataRow = dsMedioPago.Tables(0).Rows(0)

        Next





    End Sub

    Public Sub EjecutaRespaldoPagoCheque()

        If cheque_grid_cheque.Rows.Count <> 0 Then
            Dim x As Integer = 0

            Dim totalcheques As Integer = cheque_grid_cheque.Rows.Count

            For Each gvr As DataGridViewRow In cheque_grid_cheque.Rows

                x = x + 1
                'MsgBox(gvr.Cells(0).Value)

                Dim CodigoBanco As String = gvr.Cells("CodigoBanco").Value
                Dim nrocheque As String = gvr.Cells("Nro_Cheque").Value
                Dim codigoautorizacion As String = gvr.Cells("Cod_Autorizacion").Value
                Dim rut_titular As String = gvr.Cells("Rut_Titular").Value
                Dim cta_cte As String = gvr.Cells("Cuenta").Value
                Dim fecha_Cuota As String = gvr.Cells("Fecha").Value
                Dim cuota As String = gvr.Cells("Monto").Value


                Dim dsMedioPago As DataSet = Me.WS_POS.POS_ActualizaPagos("N", _Empresa, _Bodega, _Pos, TipoDocumentoVenta, txtCorrelativo.Text, nrocheque, "CHEQ", 1, Int32.Parse(CodigoBanco), 1, rut_titular, cta_cte, "", codigoautorizacion, totalcheques, x, fecha_Cuota, cuota, 1, "")
                Dim drMedioPago As DataRow = dsMedioPago.Tables(0).Rows(0)

                Dim resultado As String = drMedioPago(0).ToString


            Next

        End If




    End Sub

    Public Function GrillaCheques_Fechas()

        Dim FechaHoy As String = Date.Now.ToString(("dd/MM/yyyy"))
        Dim contador As Integer = 0

        For Each gr As DataGridViewRow In cheque_grid_cheque.Rows
            gr.Cells("fecha").Value = FechaHoy


        Next

    End Function

    Public Function GrillaCheques_CalculaMontos()

        If Cheque_txt_Cantidad.Text <> "" Then

            Dim arrMontos As New ArrayList

            Dim cantidad As Integer = 0
            If Cheque_txt_Cantidad.Text <> "" Then
                cantidad = Int32.Parse(Cheque_txt_Cantidad.Text)
            End If

            Dim resumenPago As Integer = Integer.Parse(txtResumenCheque.Text.Replace(".", ""))

            Dim cuota As Integer = resumenPago \ cantidad

            ' Dim ultimodigito As Integer = PagoRestante.ToString.Substring(largo - 1, 1)

            Dim contador As Integer = 0
            Dim sumatoria As Integer = 0

            For Each gr As DataGridViewRow In cheque_grid_cheque.Rows

                contador = contador + 1
                'If ultimodigito <> 0 And cheque_grid_cheque.Rows.Count < 1 Then

                'Else
                gr.Cells("monto").Value = cuota
                sumatoria = cuota + sumatoria

            Next

            If txtResumenCheque.Text <> sumatoria.ToString Then
                Dim diferencia As Integer = Int32.Parse(txtResumenCheque.Text.Replace(".", "")) - sumatoria
                Me.cheque_grid_cheque.Rows(cheque_grid_cheque.Rows.Count - 1).Cells("Monto").Value = cuota + diferencia


            End If

        End If

    End Function

    Function PagoRestante() As Double

        Dim total As Double = Double.Parse(txtFinal.Text)

        Dim pagado As Double = 0
        If txtPagado.Text <> "" Then
            pagado = Double.Parse(txtPagado.Text)
        End If


        Dim resultado As Double = total - pagado
        If resultado <= 0 Then
            resultado = 0
        End If
        Return resultado

    End Function

    Public Sub GrillaCheques_AgregarCheques()



        Dim cantidad As Integer = Int32.Parse(Cheque_txt_Cantidad.Text)

        For i As Integer = 1 To cantidad
            Dim objCheque As New ChequeObj

            objCheque.Nro = i
            _ArregloCheques.Add(objCheque)
        Next

        Me.llenarGrilla(Me.cheque_grid_cheque, _ArregloCheques)
        Me.cheque_grid_cheque.Columns(5).ReadOnly = True
        Me.cheque_grid_cheque.Columns("CodigoBanco").Visible = False

        GrillaCheques_CalculaMontos()
        GrillaCheques_Fechas()

    End Sub

    Public Sub GrillaCheques_AutoCompleta_NumerodeCheques(ByVal fila As Integer)
        If fila = 0 Then

            Dim valorcentral As String

            If Me.cheque_grid_cheque.Rows(fila).Cells("Nro_cheque").Value <> "" Then
                valorcentral = Me.cheque_grid_cheque.Rows(fila).Cells("Nro_cheque").Value.ToString
                If IsNumeric(valorcentral) Then

                    Dim contador As Integer = 0
                    For Each gr As DataGridViewRow In cheque_grid_cheque.Rows

                        Dim suma As Integer = valorcentral + contador
                        gr.Cells("Nro_Cheque").Value = suma
                        contador = contador + 1
                    Next

                End If

            End If
        End If


    End Sub

    Private Sub Cheque_txt_Cantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cheque_txt_Cantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            IngresaCantidadCheques()
        End If


    End Sub

    Protected Sub IngresaCantidadCheques()


        If Cheque_txt_Cantidad.Text = "0" Then
            Exit Sub


        End If

        If Cheque_txt_Cantidad.Text <> "" Then
            If Me.cheque_grid_cheque.Rows.Count = 0 Then
                GrillaCheques_AgregarCheques()

                Me.cheque_txt_rut.Enabled = True
                Me.cheque_txt_rut.Focus()
            Else
                Dim dif As Integer

                If Me.cheque_grid_cheque.Rows.Count > Int32.Parse(Cheque_txt_Cantidad.Text) Then

                    dif = Me.cheque_grid_cheque.Rows.Count - Int32.Parse(Cheque_txt_Cantidad.Text)
                    For i As Integer = 1 To dif
                        _ArregloCheques.RemoveAt(Me.cheque_grid_cheque.Rows.Count - i)
                    Next
                Else
                    dif = Int32.Parse(Cheque_txt_Cantidad.Text) - Me.cheque_grid_cheque.Rows.Count



                    For i As Integer = 1 To dif
                        Dim ultimocheque As ChequeObj
                        ultimocheque = _ArregloCheques.Item(_ArregloCheques.Count - 1)

                        Dim chequenuevo As New ChequeObj
                        chequenuevo.Nro = ultimocheque.Nro + 1
                        chequenuevo.rut_titular = ultimocheque.rut_titular
                        chequenuevo.Nro_Cheque = ultimocheque.Nro_Cheque
                        chequenuevo.Fecha = ultimocheque.Fecha
                        chequenuevo.Banco = ultimocheque.Banco
                        chequenuevo.CodigoBanco = ultimocheque.CodigoBanco
                        chequenuevo.CodigoAutorizacion = ultimocheque.CodigoAutorizacion

                        _ArregloCheques.Add(chequenuevo)

                    Next
                End If


                Me.llenarGrilla(Me.cheque_grid_cheque, _ArregloCheques)
                GrillaCheques_CalculaMontos()
                GrillaCheques_Fechas()
            End If
        Else
            MsgBox("Ingrese Valor", MsgBoxStyle.Information)

        End If


    End Sub




    Private Sub Cheque_txt_Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cheque_txt_Cantidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosComodin(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub


    Public Sub ActualizaBancoCheque()
        Dim banco As String = cheque_Banco.Text
        Dim codigo As String = cheque_Banco_Codigo.Text

        For Each gr As DataGridViewRow In cheque_grid_cheque.Rows
            gr.Cells("banco").Value = banco
            gr.Cells("codigoBanco").Value = codigo

        Next
    End Sub

    Private Sub cheque_grid_cheque_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles cheque_grid_cheque.CellClick

        If e.ColumnIndex = 5 Then

            xBanco.txtFila.Text = e.RowIndex
            xBanco.ShowDialog()

        End If
    End Sub



    Private Sub cheque_grid_cheque_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles cheque_grid_cheque.CellEndEdit


        If e.ColumnIndex = 1 Then
            GrillaCheques_AutoCompleta_NumerodeCheques(e.RowIndex)
        End If

        If e.ColumnIndex = 6 Then

            Dim rut As String = Me.cheque_grid_cheque.Rows(e.RowIndex).Cells(6).Value

            If Me.objVal.ValidaRut(rut) = False Then
                MsgBox("Rut Invalido", MsgBoxStyle.Exclamation, "Error Validación")
                Me.cheque_grid_cheque.Rows(e.RowIndex).Cells(6).Style.ForeColor = Drawing.Color.Red
            Else
                Me.cheque_grid_cheque.Rows(e.RowIndex).Cells(6).Style.ForeColor = Drawing.Color.Black
            End If

        End If


    End Sub

    Private Sub cheque_grid_cheque_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles cheque_grid_cheque.CellContentClick




    End Sub



    Public Sub Cheque_TraeBancoDesdeDialog(ByVal codigo As String, ByVal descripcion As String, ByVal fila As Integer) Handles xBanco.GetCodigoBancoDialogo

        If fila <> 0 Then

            If cheque_grid_cheque.Rows(fila).Cells("CodigoBanco").Value <> codigo Then

                Me.cheque_grid_cheque.Rows(fila).Cells("Nro_Cheque").Value = ""
                Me.cheque_grid_cheque.Rows(fila).Cells("Cuenta").Value = ""

            End If

            Me.cheque_grid_cheque.Rows(fila).Cells("Banco").Value = descripcion
            Me.cheque_grid_cheque.Rows(fila).Cells("CodigoBanco").Value = codigo
        End If


    End Sub

    Function DetectaModalidad() As String

        If _Modalidad = "N" Then
            Return "V1"
        End If

        If _Modalidad = "SP" Then
            Return "V2"
        End If

        'If _Modalidad = "NCAF" Then
        'Return "V2"
        'End If

        If _Modalidad = "AP" Then
            Return "V3"
        End If

    End Function




    Public Function CalculaTotalesMultifactura(lista As ArrayList) As Array
        Dim nlineas = _NumeroLineas

        Dim arr4 = New String(Helper.MultiFacturaCantidad - 1) {}

        Dim inicio = 0
        Dim fin = nlineas
        If fin > lista.Count() Then
            fin = lista.Count()
        End If

        For i As Integer = 0 To Helper.MultiFacturaCantidad - 1
            Dim suma = 0
            For j As Integer = inicio To fin - 1

                Dim contenido As ArticuloStringObj = lista(j)
                Dim dato = Convert.ToInt32(contenido.CNeto * contenido.cantidad)
                suma = suma + dato
                
                'Console.WriteLine(contenido)
            Next

            Dim aux = (suma * 0.19)
            Dim aux2 = suma + aux
            arr4(i) = aux2.ToString()
            'Console.WriteLine("Corte")
            inicio = inicio + nlineas

            fin = fin + nlineas
            If fin > lista.Count() Then
                fin = lista.Count()
            End If
        Next

        Return arr4
    End Function

#Region "Ejecutaventa"
    Public Function Ejecutaventa(ByVal objventa As VentaObj) As Boolean
        Dim valorRetorno As Boolean = True
        concepto = _Concepto

        'detalle de los articulos solicitados.
        Dim objarticulos As ArrayList = objventa.ListaArticulos




        'string[] first = words.Take(mid).ToArray();

        '*************************** DocumentoPago
        Dim DocumentoPago_pos As String = objventa.codigo_Post
        Dim DocumentoPago_empresa As String = objventa.Codigo_Empresa
        Dim DocumentoPago_cliente As String = objventa.Cod_Cliente
        Dim DocumentoPago_fcreacion As String = objventa.FechaSistema
        Dim DocumentoPago_hcreacion As String = objventa.HoraSistema
        Dim DocumentoPago_motivo As String = "TRASPASO DE POS"
        Dim DocumentoPago_monto As String = objventa.total
        Dim DocumentoPago_caja As String = objventa.CajaRecepcion
        Dim DocumentoPago_Sede As String = objventa.Sede
        'duda
        Dim DocumentoPago_usuario As String = id_Cajero.ToString
        Dim DocumentoPago_Ultlineavoucher As String = "0"
        Dim DocumentoPago_Ultlineapresupuesto As String = "0"
        ' puede ser V1, V2,V3
        Dim DocumentoModalidad_Indicador As String = DetectaModalidad()
        '***** DOCUMEN>TO PAGO CARGO
        ' parametros de entrada para DocumentoPago_cargo
        Dim cargo_documento As String = objventa.DocumentoVenta
        Dim cargo_timbrado As String = objventa.nro_Documento
        Dim cargo_moneda As String = objventa.Moneda
        Dim cargo_cambio As String = "1" ' valor defecto
        'total del documento
        Dim cargo_saldo As String = objventa.total
        ''' recordar esto
        Dim cargo_abono As String = objventa.total
        Dim cargo_cambioAbono As String = "1" ' valor defecto segun browse 
        Dim cargo_vencto As String = _FechaBrowse(objventa.FechaVencimiento)
        Dim cargo_cuenta As String = "0" ' a la espera de preguntar si puede ir en null
        '500  duda?
        Dim cargo_lista_precio As String = objventa.Lista
        Dim cargo_contacto As String = ""
        Dim cargo_vendedor As String = objventa.CodigoVendedor  'codigo vendedor
        Dim cargo_cgestion_vendedor As String = objventa.CentrodeGestion

        Dim cargo_direccion_despacho

        cargo_direccion_despacho = objventa.DireccionDespacho

        Dim cargo_fono As String = objventa.FonoCliente


        Dim cargo_direccion_facturacion As String = objventa.DireccionFacturacion

        Dim cargo_nula As String = "N" 'valor defecto proporcionado por browse. del cual nos tenemos que detallar junto a ellos
        Dim cargo_observaciones As String = "OBSERVACIONES"
        Dim cargo_lineas_articulo As String = objventa.ListaArticulos.Count.ToString   'total de articulos en detalle
        Dim cargo_ultima_guia As String = "0" ' se inngresa el nro de la ultima guia de despacho de lo contrario se ingresa 0
        'ultima del detalle de traspaso
        Dim cargo_lineas_glosa As String = "0"
        ' hay que ver en que caso ingresamos lineas contable.
        'SI LA FACTURA CONTIENE UNA SERIE DE PRODUCTOS QUE NO SON CATALOGADOS
        'HAY QUE INFORMAR EL ASIENTO CONTABLE
        ' CUATRO LINEAS CONTABLE 4 SI NO HAY LINEAS CONTABLE SIEMPRE VA EN CERO
        Dim cargo_lineas_Contable As String = objventa.ListaArticulos.Count.ToString
        'CERO
        Dim cargo_lineas_Condicion As String = objventa.ListaArticulos.Count.ToString()
        'DESCUENTO DE CABESERA, DESCUENTO VALOR TOTAL EN PORCENTAJE
        Dim cargo_descuento1 As String = objventa.PorcentajeDescuento.ToString().Replace(",", ".")
        Dim cargo_descuento2 As String = "0"
        Dim cargo_descuento3 As String = "0"
        ' CUANTO DEL TOTAL DEL DOCUMENTO VA A SER EXENTO
        Dim cargo_monto_exento As String = ""
        Dim cargo_monto_iva As String = objventa.iva
        'SE INDICA SI ES INVENTARIABLE O VARIOS.
        Dim cargo_indicador_tipo As String = "I"
        ' LA BODEGA DE LA VENTA.
        Dim cargo_bodega As String = _Bodega
        'CODIGO DE LA CAJA

        Dim cargo_punto As String = objventa.PuntoFacturacion
        'SALDO TOTAL DEL DOCUMENTO EL VALOR TOTAL DE LA VENTA
        Dim cargo_saldo_documento As String = objventa.total
        'SIEMPRE DICE QUE SI
        'SI LE QUE PONGO QUE NO SIGNIFICA NO LA HE EMITIDO
        'NULO
        Dim cargo_indicador_impresion As String = "S"

        'Dim cargo_monto_indicador As String = ""
        '
        Dim cargo_monto_credito As String = "0"
        'NULO
        Dim cargo_indicador_servip As String = ""
        '
        Dim cargo_indicador_movpendientes As String = "N"
        Dim cargo_Folio_reparto As String = "0"
        'valor lo obtube de la tabla mbcve
        Dim cargo_concepto_venta As String = ConceptoVenta
        Dim cargo_tipo_transporte As String = "99"
        'aca en cargo_Termino va el tipo de pago contado en cuotas etc. credito steward
        Dim cargo_termino As String = GetTerminoPago()
        Dim cargo_paridad_lista As String = ""
        Dim cargo_ultlineapresupuesto As String = "0"
        Dim cargo_sucursal As String = ""
        Dim cargo_glosa_facturacion As String = ""


        '********************** DocumentoPago_detalle_cargo
        'Catalogado
        Dim Cargo_detalle_linea As String = ""
        Dim Cargo_detalle_articulo As String = ""
        Dim Cargo_detalle_cantidad_uvta As String = ""
        Dim Cargo_detalle_precio_articulo As String = ""
        Dim Cargo_detalle_descto_linea As String = ""
        Dim Cargo_detalle_indicador_envase As String = ""
        Dim Cargo_detalle_precio_lista As String = ""
        Dim Cargo_detalle_paridad_documento As String = ""
        Dim Cargo_detalle_tprecio_flete As String = ""
        Dim Cargo_detalle_Pdescto_vol As String = ""
        Dim Cargo_detalle_Pdescto_pago As String = ""
        Dim Cargo_detalle_Pdescto_otros As String = ""

        'DocumentoPago_detvarios_cargo

        Dim Cargo_detvarios_linea As String = ""
        Dim Cargo_detvarios_glosa As String = ""
        Dim Cargo_detvarios_precio_unitario As String = ""
        Dim Cargo_detvarios_cantidad As String = ""
        Dim Cargo_detvarios_desctos As String = ""
        Dim Cargo_detvarios_umedida As String = ""
        Dim Cargo_detvarios_ultlinea As String = ""
        Dim Cargo_detvarios_precio_bruto As String = ""
        Dim Cargo_detvarios_ultlinea_detglo As String = ""

        'DocumentoPago_impuesto_cargo

        Dim Cargo_impuesto_codigo As String = ""
        Dim Cargo_impuesto_valor As String = ""

        'DocumentoPago_voucher_cargo
        'solo catalogado, es un secuencial de linea. 
        Dim Cargo_voucher_linea As String = ""
        Dim Cargo_voucher_cuenta As String = ""
        Dim Cargo_voucher_auxiliar As String = ""
        Dim Cargo_voucher_debe As String = ""
        Dim Cargo_voucher_haber As String = ""
        Dim Cargo_voucher_cgestion As String = ""
        Dim Cargo_voucher_igestion As String = ""
        Dim Cargo_voucher_sede As String = ""
        Dim Cargo_voucher_glosa As String = ""

        'DocumentoPago_ppto_cargo
        Dim Cargo_ppto_linea As String = ""
        Dim Cargo_ppto_cgestion As String = ""
        Dim Cargo_ppto_cuenta As String = ""
        Dim Cargo_ppto_igestion As String = ""
        Dim Cargo_ppto_devengado As String = ""
        Dim Cargo_ppto_tipo_docto As String = ""
        Dim Cargo_ppto_numero_docto As String = ""



        Dim objDocumentoPago As New DocumentoPagox(DocumentoPago_pos, DocumentoPago_empresa, DocumentoPago_cliente, DocumentoPago_fcreacion, DocumentoPago_hcreacion, DocumentoPago_motivo, DocumentoPago_monto, DocumentoPago_caja, DocumentoPago_Sede, DocumentoPago_usuario, DocumentoPago_Ultlineavoucher, DocumentoPago_Ultlineapresupuesto, DocumentoModalidad_Indicador)



        Dim cargo_doc_timbrado As String = objDocumentoVenta.GrabaDocumento("aa", Date.Now)
        Dim objDocumentoPago_Cargo As New DocumentoPagoCargo(cargo_documento, cargo_timbrado, cargo_moneda, cargo_cambio, cargo_saldo, cargo_abono, cargo_cambioAbono, cargo_vencto,
        cargo_cuenta, cargo_lista_precio, cargo_contacto, cargo_vendedor, cargo_cgestion_vendedor, cargo_direccion_despacho, cargo_fono, cargo_direccion_facturacion,
        cargo_nula, cargo_observaciones, cargo_lineas_articulo, cargo_ultima_guia, cargo_lineas_glosa, cargo_lineas_Contable,
        cargo_lineas_Condicion, cargo_descuento1, cargo_descuento2, cargo_descuento3, cargo_monto_exento, cargo_monto_iva, cargo_indicador_tipo,
        cargo_bodega, cargo_punto, cargo_saldo_documento, cargo_indicador_impresion, cargo_monto_credito, cargo_indicador_servip, cargo_indicador_movpendientes _
        , cargo_Folio_reparto, cargo_concepto_venta, cargo_tipo_transporte, cargo_termino, cargo_paridad_lista, cargo_ultlineapresupuesto, cargo_sucursal, cargo_glosa_facturacion)

        Dim contador As Integer = 0

        Dim arregloDocumentoPagoDetalle_Cargo As New ArrayList
        For Each objar As ArticuloStringObj In objarticulos

            contador = contador + 1
            If Me.txtPorcentajeDescuento.Text <> "" Then
                objar.PorcentajeDescuento = Convert.ToDouble(Me.txtPorcentajeDescuento.Text.Replace(".", ","))
            End If

            Dim objDocumentoPago_detalle_cargo As New DocumentoPago_detalle_cargo(contador, objar.sku, objar.cantidad, objar.CNeto _
              , "", objar.Envase, objar.CNeto, "1", "0" _
                  , objar.PorcentajeDescuento, 0, 0, objar.unidadmedida, _Ubicacion)
            arregloDocumentoPagoDetalle_Cargo.Add(objDocumentoPago_detalle_cargo)
        Next

        Dim objDocumentoPago_detvarios_cargo As New DocumentoPago_detvarios_cargo(Cargo_detvarios_linea, Cargo_detvarios_glosa, Cargo_detvarios_precio_unitario _
          , Cargo_detvarios_cantidad, Cargo_detvarios_desctos, Cargo_detvarios_umedida, Cargo_detvarios_ultlinea, Cargo_detvarios_precio_bruto, Cargo_detvarios_ultlinea_detglo)

        Dim objDocumentoPago_impuesto_Cargo As New DocumentoPago_impuesto_cargo(Cargo_impuesto_codigo, Cargo_impuesto_valor)

        Dim objDocumentoPago_voucher_cargo As New DocumentoPago_voucher_cargo(Cargo_voucher_linea, Cargo_voucher_cuenta, Cargo_voucher_auxiliar, Cargo_voucher_debe _
                                                                              , Cargo_voucher_haber, Cargo_voucher_cgestion, Cargo_voucher_igestion, Cargo_voucher_sede, Cargo_voucher_glosa)
        Dim objDocumentoPago_ppto_cargo As New DocumentoPago_ppto_cargo(Cargo_ppto_linea, Cargo_ppto_cgestion, Cargo_ppto_cuenta, Cargo_ppto_igestion _
               , Cargo_ppto_devengado, Cargo_ppto_tipo_docto)

        Dim xmlvent As New VentaXML

        Dim doc As String = xmlvent.DocumentoPagoGetXML(objDocumentoPago, objDocumentoPago_Cargo, arregloDocumentoPagoDetalle_Cargo, objDocumentoPago_detvarios_cargo, objDocumentoPago_impuesto_Cargo, objDocumentoPago_voucher_cargo, objDocumentoPago_ppto_cargo, GetDocumentosPagoAbono, DetectaModalidad)

        If ExistenciaErroresFolios = True Then
            Return False
        End If




        Dim porpagar = _Modalidad

        If porpagar = "SP" Then 'POR PAGAR

            Try
                Dim docxml As New XmlDocument
                docxml.LoadXml(doc.ToString())
                docxml.Save(_RutaRespaldoXml + objventa.Correlativo + ".xml")

                If _esVentaRecuperada = False Then
                    EjecutaVentaRespaldo(objventa, 2)
                End If

                wsRecibeVenta.Timeout = 10000
                Dim resultado As String = wsRecibeVenta.Execute(doc.ToString())
                Dim docXmlt As New XmlDocument

                docXmlt.LoadXml(resultado)
                Dim lista As XmlNodeList
                Dim nodo As XmlNode
                Dim indicador As String = ""
                docXmlt.SelectNodes("/Respuesta")

                If docXmlt.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
                    lista = docXmlt.SelectNodes("/Respuesta/Respuesta_indicador_validez")
                    nodo = lista(0)
                    indicador = nodo.ChildNodes.Item(0).InnerText
                End If

                Dim patos As New ArrayList
                Dim msgerrores As String = ""
                If indicador = "0" Then
                    valorRetorno = False

                    For Each nodoerrores As XmlNode In docXmlt.GetElementsByTagName("Respuesta_Detalle")
                        msgerrores = msgerrores & nodoerrores.ChildNodes.Item(0).InnerText + " - " + nodoerrores.ChildNodes(1).InnerText & vbNewLine

                    Next
                    MsgBox("SE HAN PROVOCADO LOS SIGUIENTES  ERRORES EN LA TRANSACCION:" + msgerrores, MsgBoxStyle.Critical, "STEWARD ")
                ElseIf indicador = "" Then
                    valorRetorno = False
                    MsgBox("WEBSERVICE RETORNO NULO")
                Else
                    valorRetorno = True
                    'Dim objdocu As New DocumentoController
                    'objdocu.GuardarDocumento(objventa.Correlativo, objventa.DocumentoVenta, doc)
                End If

            Catch ex As Exception
                valorRetorno = False
                MsgBox("SE HA PROBOCADO UN ERROR EN LA TRANSACCION:" + ex.ToString, MsgBoxStyle.Critical, "STEWARD ")

            End Try

        Else 'NO ES POR PAGAR PROSIGO

            Dim valorStandAlone = _GetDatoFtp("POS" + txtNroCaja.Text + "_STANDALONE")

            If valorStandAlone = "1" Then 'ENVIA XML A SERVIDOR POR FTP PARA QUE SE EJECUTE CON DEMONIO

                Dim prueba = "<DocumentoPago><DocumentoPago_pos>40</DocumentoPago_pos><DocumentoPago_empresa>STE</DocumentoPago_empresa><DocumentoPago_cliente>76264020</DocumentoPago_cliente><DocumentoPago_fcreacion>20150505</DocumentoPago_fcreacion><DocumentoPago_hcreacion>19:00:09</DocumentoPago_hcreacion><DocumentoPago_motivo>TRASPASO DE POS</DocumentoPago_motivo><DocumentoPago_monto>17331</DocumentoPago_monto><DocumentoPago_caja>21</DocumentoPago_caja><DocumentoPago_sede>1</DocumentoPago_sede><DocumentoPago_usuario>447</DocumentoPago_usuario><DocumentoPago_Ultlineavoucher>0</DocumentoPago_Ultlineavoucher><DocumentoPago_Ultlineapresupuesto>0</DocumentoPago_Ultlineapresupuesto><DocumentoModalidad_Indicador>V1</DocumentoModalidad_Indicador><DocumentoPago_cargo><VtaCargo><Cargo_documento>FAAF</Cargo_documento><Cargo_timbrado>795833</Cargo_timbrado><Cargo_moneda>CLP</Cargo_moneda> <Cargo_cambio>1</Cargo_cambio> <Cargo_saldo>17331</Cargo_saldo> <Cargo_abono>17331</Cargo_abono> <Cargo_cambioabono>1</Cargo_cambioabono> <Cargo_vencto>20150505</Cargo_vencto> <Cargo_cuenta>0</Cargo_cuenta> <Cargo_lista_precio>500</Cargo_lista_precio> <Cargo_vendedor>POS95  </Cargo_vendedor> <Cargo_cgestion_vendedor>110218</Cargo_cgestion_vendedor> <Cargo_direccion_despacho>888</Cargo_direccion_despacho><Cargo_fono></Cargo_fono><Cargo_direccion_facturacion>999</Cargo_direccion_facturacion><Cargo_nula>N</Cargo_nula><Cargo_observaciones>OBSERVACIONES</Cargo_observaciones><Cargo_lineas_articulo>3</Cargo_lineas_articulo><Cargo_ultima_guia>0</Cargo_ultima_guia><Cargo_lineas_glosa>0</Cargo_lineas_glosa><Cargo_lineas_contable>3</Cargo_lineas_contable><Cargo_lineas_condicion>3</Cargo_lineas_condicion><Cargo_descuento1>0</Cargo_descuento1><Cargo_descuento2>0</Cargo_descuento2><Cargo_descuento3>0</Cargo_descuento3><Cargo_monto_exento></Cargo_monto_exento><Cargo_monto_iva>2767</Cargo_monto_iva><Cargo_indicador_tipo>I</Cargo_indicador_tipo><Cargo_bodega>1</Cargo_bodega><Cargo_punto>40</Cargo_punto><Cargo_saldo_documento>17331</Cargo_saldo_documento><Cargo_indicador_impresion>S</Cargo_indicador_impresion><Cargo_monto_credito>0</Cargo_monto_credito><Cargo_indicador_servip></Cargo_indicador_servip><Cargo_indicador_movpendientes>N</Cargo_indicador_movpendientes><Cargo_folio_reparto></Cargo_folio_reparto><Cargo_concepto_venta>5</Cargo_concepto_venta><Cargo_tipo_transporte>99</Cargo_tipo_transporte><Cargo_termino>1</Cargo_termino><Cargo_paridad_lista></Cargo_paridad_lista><Cargo_ultlinea_presupuesto>0</Cargo_ultlinea_presupuesto><Cargo_glosa_facturacion></Cargo_glosa_facturacion><DocumentoPago_detalle_cargo><VtaCargoDet><Cargo_detalle_linea>1</Cargo_detalle_linea><Cargo_detalle_articulo>010000566       </Cargo_detalle_articulo><Cargo_detalle_cantidad_uvta>4</Cargo_detalle_cantidad_uvta><Cargo_detalle_precio_articulo>874</Cargo_detalle_precio_articulo><Cargo_detalle_descto_linea></Cargo_detalle_descto_linea><Cargo_detalle_indicador_envase></Cargo_detalle_indicador_envase><Cargo_detalle_precio_lista>874</Cargo_detalle_precio_lista><Cargo_detalle_paridad_documento>1</Cargo_detalle_paridad_documento><Cargo_detalle_tprecio_flete>0</Cargo_detalle_tprecio_flete><Cargo_detalle_Pdescto_vol>0</Cargo_detalle_Pdescto_vol><Cargo_detalle_Pdescto_pago>0</Cargo_detalle_Pdescto_pago><Cargo_detalle_Pdescto_otros>0</Cargo_detalle_Pdescto_otros><Cargo_detalle_UM>CU</Cargo_detalle_UM><Cargo_detalle_ubicacion>100</Cargo_detalle_ubicacion></VtaCargoDet><VtaCargoDet><Cargo_detalle_linea>2</Cargo_detalle_linea><Cargo_detalle_articulo>010004777       </Cargo_detalle_articulo><Cargo_detalle_cantidad_uvta>1</Cargo_detalle_cantidad_uvta><Cargo_detalle_precio_articulo>1084</Cargo_detalle_precio_articulo><Cargo_detalle_descto_linea></Cargo_detalle_descto_linea><Cargo_detalle_indicador_envase> </Cargo_detalle_indicador_envase><Cargo_detalle_precio_lista>1084</Cargo_detalle_precio_lista><Cargo_detalle_paridad_documento>1</Cargo_detalle_paridad_documento><Cargo_detalle_tprecio_flete>0</Cargo_detalle_tprecio_flete><Cargo_detalle_Pdescto_vol>0</Cargo_detalle_Pdescto_vol><Cargo_detalle_Pdescto_pago>0</Cargo_detalle_Pdescto_pago><Cargo_detalle_Pdescto_otros>0</Cargo_detalle_Pdescto_otros><Cargo_detalle_UM>CU</Cargo_detalle_UM><Cargo_detalle_ubicacion>100</Cargo_detalle_ubicacion></VtaCargoDet><VtaCargoDet><Cargo_detalle_linea>3</Cargo_detalle_linea><Cargo_detalle_articulo>010004778       </Cargo_detalle_articulo><Cargo_detalle_cantidad_uvta>12</Cargo_detalle_cantidad_uvta><Cargo_detalle_precio_articulo>832</Cargo_detalle_precio_articulo><Cargo_detalle_descto_linea></Cargo_detalle_descto_linea><Cargo_detalle_indicador_envase> </Cargo_detalle_indicador_envase><Cargo_detalle_precio_lista>832</Cargo_detalle_precio_lista><Cargo_detalle_paridad_documento>1</Cargo_detalle_paridad_documento><Cargo_detalle_tprecio_flete>0</Cargo_detalle_tprecio_flete><Cargo_detalle_Pdescto_vol>0</Cargo_detalle_Pdescto_vol><Cargo_detalle_Pdescto_pago>0</Cargo_detalle_Pdescto_pago><Cargo_detalle_Pdescto_otros>0</Cargo_detalle_Pdescto_otros><Cargo_detalle_UM>CU</Cargo_detalle_UM><Cargo_detalle_ubicacion>100</Cargo_detalle_ubicacion></VtaCargoDet></DocumentoPago_detalle_cargo></VtaCargo></DocumentoPago_cargo><DocumentoPago_abono><VtaPago><Abono_documento>EFEC</Abono_documento><Abono_folio></Abono_folio><Abono_moneda>CLP</Abono_moneda><Abono_cambio>1</Abono_cambio><Abono_banco>45</Abono_banco><Abono_cuenta></Abono_cuenta><Abono_valor>17331</Abono_valor><Abono_emision>20150505</Abono_emision><Abono_vencto>20150505</Abono_vencto><Abono_autorizador></Abono_autorizador><Abono_codigo></Abono_codigo><Abono_tipo>2</Abono_tipo><Abono_referencia></Abono_referencia><Abono_terminal></Abono_terminal><Abono_observacion></Abono_observacion><Abono_lote></Abono_lote><Abono_punto>40</Abono_punto></VtaPago></DocumentoPago_abono></DocumentoPago>"
                Dim docxml As New XmlDocument
                docxml.LoadXml(doc.ToString().Trim())

                 Dim documentoxml = ""

                If AprobacionDeposito = True Then
                    docxml.Save(_RutaRespaldoXml + objventa.Correlativo + "_DEPO.xml")
                    documentoxml = _RutaRespaldoXml + objventa.Correlativo + "_DEPO.xml"
                    Else 
                    docxml.Save(_RutaRespaldoXml + objventa.Correlativo + ".xml")
                    documentoxml = _RutaRespaldoXml + objventa.Correlativo + ".xml"

                End If

                'docxml.LoadXml(prueba)
                

                'docxml.Save("d:\" + 111 + ".xml")

                'Dim documentoxml = _RutaRespaldoXml + objventa.Correlativo + ".xml"

                If _esVentaRecuperada = False Then
                    EjecutaVentaRespaldo(objventa, 2)
                End If

                'valorRetorno = FtpClient.UploadFileFtp("POS" + txtNroCaja.Text, documentoxml, objventa.Correlativo + ".xml")

            Else 'EJECUTA WEBSERVICE LISA DIRECTAMENTE

                Try
                    Dim docxml As New XmlDocument
                    docxml.LoadXml(doc.ToString())
                    docxml.Save(_RutaRespaldoXml + objventa.Correlativo + ".xml")

                    If _esVentaRecuperada = False Then
                        EjecutaVentaRespaldo(objventa, 2)
                    End If

                    wsRecibeVenta.Timeout = 10000
                    Dim resultado As String = wsRecibeVenta.Execute(doc.ToString())
                    Dim docXmlt As New XmlDocument

                    docXmlt.LoadXml(resultado)
                    Dim lista As XmlNodeList
                    Dim nodo As XmlNode
                    Dim indicador As String = ""
                    docXmlt.SelectNodes("/Respuesta")

                    If docXmlt.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
                        lista = docXmlt.SelectNodes("/Respuesta/Respuesta_indicador_validez")
                        nodo = lista(0)
                        indicador = nodo.ChildNodes.Item(0).InnerText
                    End If

                    Dim patos As New ArrayList
                    Dim msgerrores As String = ""
                    If indicador = "0" Then
                        valorRetorno = False

                        For Each nodoerrores As XmlNode In docXmlt.GetElementsByTagName("Respuesta_Detalle")
                            msgerrores = msgerrores & nodoerrores.ChildNodes.Item(0).InnerText + " - " + nodoerrores.ChildNodes(1).InnerText & vbNewLine

                        Next
                        MsgBox("SE HAN PROVOCADO LOS SIGUIENTES  ERRORES EN LA TRANSACCION:" + msgerrores, MsgBoxStyle.Critical, "STEWARD ")
                    ElseIf indicador = "" Then
                        valorRetorno = False
                        MsgBox("WEBSERVICE RETORNO NULO")
                    Else
                        valorRetorno = True
                        'Dim objdocu As New DocumentoController
                        'objdocu.GuardarDocumento(objventa.Correlativo, objventa.DocumentoVenta, doc)
                    End If

                Catch ex As Exception
                    valorRetorno = False
                    MsgBox("SE HA PROBOCADO UN ERROR EN LA TRANSACCION:" + ex.ToString, MsgBoxStyle.Critical, "STEWARD ")

                End Try
            End If

        End If

        Return valorRetorno
    End Function
#End Region

#Region "EjecutaventaMulti"
    Public Function EjecutaventaMulti(ByVal objventa As VentaObj) As Boolean
        Dim valorRetorno As Boolean = True
        concepto = _Concepto

        'detalle de los articulos solicitados.
        Dim objarticulos As ArrayList = objventa.ListaArticulos

        Dim tmf = CalculaTotalesMultifactura(objarticulos)



        Dim infoDocumentoPago As New DocumentoPago
        infoDocumentoPago.DocumentoPago_pos = objventa.codigo_Post
        infoDocumentoPago.DocumentoPago_empresa = objventa.Codigo_Empresa
        infoDocumentoPago.DocumentoPago_cliente = objventa.Cod_Cliente
        infoDocumentoPago.DocumentoPago_fcreacion = objventa.FechaSistema
        infoDocumentoPago.DocumentoPago_hcreacion = objventa.HoraSistema
        infoDocumentoPago.DocumentoPago_motivo = "TRASPASO POS"
        infoDocumentoPago.DocumentoPago_monto = objventa.total
        infoDocumentoPago.DocumentoPago_caja = objventa.CajaRecepcion
        infoDocumentoPago.DocumentoPago_sede = objventa.Sede
        infoDocumentoPago.DocumentoPago_usuario = id_Cajero.ToString
        infoDocumentoPago.DocumentoPago_Ultlineavoucher = "0"
        infoDocumentoPago.DocumentoPago_Ultlineapresupuesto = "0"
        infoDocumentoPago.DocumentoModalidad_Indicador = DetectaModalidad()

        Dim infoVtaCargo As New List(Of VtaCargo)
        Dim infoVtaPago As New List(Of VtaPago)


        Dim infoPagos = GetDocumentosPagoAbono()
        For Each o As DocumentoPago_abono In infoPagos
            infoVtaPago.Add(New VtaPago() With {
                    .Abono_documento = o.Abono_documento,
                    .Abono_folio = o.Abono_folio,
                    .Abono_moneda = o.Abono_moneda,
                    .Abono_cambio = o.Abono_cambio,
                    .Abono_banco = o.Abono_banco,
                    .Abono_cuenta = o.Abono_codigo,
                    .Abono_valor = o.Abono_valor,
                    .Abono_emision = o.Abono_emision,
                    .Abono_vencto = o.Abono_vencto,
                    .Abono_autorizador = o.Abono_autorizador,
                    .Abono_codigo = o.Abono_codigo,
                    .Abono_tipo = o.Abono_tipo,
                    .Abono_referencia = o.Abono_referencia,
                    .Abono_terminal = o.Abono_terminal,
                    .Abono_observacion = o.Abono_observacion,
                    .Abono_lote = o.Abono_lote,
                    .Abono_punto = o.Abono_punto
                   })

        Next



        Dim nlineas = _NumeroLineas



        Dim inicio = 0
        Dim fin = nlineas
        If fin > objarticulos.Count() Then
            fin = objarticulos.Count()
        End If

        For i As Integer = 0 To Helper.MultiFacturaCantidad - 1
            Dim infoVtaCargoDet As New List(Of VtaCargoDet)
            Dim contador = 1
            For j As Integer = inicio To fin - 1
                Dim infoDetalle As ArticuloStringObj = objarticulos(j)
                infoVtaCargoDet.Add(New VtaCargoDet() With {
                   .Cargo_detalle_linea = contador,
                   .Cargo_detalle_articulo = infoDetalle.sku,
                   .Cargo_detalle_cantidad_uvta = infoDetalle.cantidad,
                   .Cargo_detalle_precio_articulo = infoDetalle.precio.Replace(",", "").Replace(".",""),
                   .Cargo_detalle_descto_linea = If(txtPorcentajeDescuento.Text <> "", txtPorcentajeDescuento.Text.Replace(",", "").Replace(".",""), String.Empty),
                   .Cargo_detalle_indicador_envase = infoDetalle.Envase,
                   .Cargo_detalle_precio_lista = infoDetalle.precio.Replace(",", "").Replace(".",""),
                   .Cargo_detalle_paridad_documento = "1",
                   .Cargo_detalle_tprecio_flete = "0",
                   .Cargo_detalle_Pdescto_vol = "0",
                   .Cargo_detalle_Pdescto_pago = "0",
                   .Cargo_detalle_Pdescto_otros = "0",
                   .Cargo_detalle_UM = infoDetalle.unidadmedida,
                   .Cargo_detalle_ubicacion = _Ubicacion
                   })
                contador = contador + 1
            Next
            inicio = inicio + nlineas
            fin = fin + nlineas
            If fin > objarticulos.Count() Then
                fin = objarticulos.Count()
            End If

            dim total =  Convert.ToDouble(tmf(i)).ToString("N0").Replace(",", "").Replace(".","")
            Dim neto =  Convert.ToDouble(tmf(i) / 1.19)
            Dim iva = Convert.ToDouble(tmf(i) - neto).ToString("N0").Replace(",", "").Replace(".","")
            

            infoVtaCargo.Add(New VtaCargo() With {
                    .Cargo_documento = objventa.DocumentoVenta,
                    .Cargo_timbrado = Helper.MultifacturaArray(i),
                    .Cargo_moneda = objventa.Moneda,
                    .Cargo_cambio = "1", 'valor defecto
                    .Cargo_saldo = total, 'objventa.total
                    .Cargo_abono = total, 'objventa.total
                    .Cargo_cambioabono = "1", 'valor defecto segun browse 
                    .Cargo_vencto = _FechaBrowse(objventa.FechaVencimiento),
                    .Cargo_cuenta = "0", 'a la espera de preguntar si puede ir en null
                    .Cargo_lista_precio = objventa.Lista,
                    .Cargo_vendedor = objventa.CodigoVendedor, 'codigo vendedor
                    .Cargo_cgestion_vendedor = objventa.CentrodeGestion,
                    .Cargo_direccion_despacho = objventa.DireccionDespacho,
                    .Cargo_fono = objventa.FonoCliente,
                    .Cargo_direccion_facturacion = objventa.DireccionFacturacion,
                    .Cargo_nula = "N", 'valor defecto proporcionado por browse. del cual nos tenemos que detallar junto a ellos
                    .Cargo_observaciones = "OBSERVACIONES",
                    .Cargo_lineas_articulo = contador, 'objventa.ListaArticulos.Count.ToString   'total de articulos en detalle
                    .Cargo_ultima_guia = "0", 'se inngresa el nro de la ultima guia de despacho de lo contrario se ingresa 0
                    .Cargo_lineas_glosa = "0",
                    .Cargo_lineas_contable = contador, 'objventa.ListaArticulos.Count.ToString
                    .Cargo_lineas_condicion = contador, 'objventa.ListaArticulos.Count.ToString
                    .Cargo_descuento1 = objventa.PorcentajeDescuento,
                    .Cargo_descuento2 = "0",
                    .Cargo_descuento3 = "0",
                    .Cargo_monto_exento = String.Empty,
                    .Cargo_monto_iva = iva, 'objventa.iva
                    .Cargo_indicador_tipo = "I",
                    .Cargo_bodega = _Bodega,
                    .Cargo_punto = objventa.PuntoFacturacion,
                    .Cargo_saldo_documento = total, 'objventa.total
                    .Cargo_indicador_impresion = "S",
                    .Cargo_monto_credito = "0",
                    .Cargo_indicador_servip = String.Empty,
                    .Cargo_indicador_movpendientes = "N",
                    .Cargo_folio_reparto = String.Empty,
                    .Cargo_concepto_venta = ConceptoVenta,
                    .Cargo_tipo_transporte = "99",
                    .Cargo_termino = GetTerminoPago(),
                    .Cargo_paridad_lista = String.Empty,
                    .Cargo_ultlinea_presupuesto = "0",
                    .Cargo_glosa_facturacion = String.Empty,
                    .DocumentoPago_detalle_cargo = infoVtaCargoDet
                    })

        Next





        infoDocumentoPago.DocumentoPago_cargo = infoVtaCargo
        infoDocumentoPago.DocumentoPago_abono = infoVtaPago


        Dim valorStandAlone = _GetDatoFtp("POS" + txtNroCaja.Text + "_STANDALONE")

        If valorStandAlone = "1" Then 'ENVIA XML A SERVIDOR POR FTP PARA QUE SE EJECUTE CON DEMONIO

            Dim Folios = String.Join("_", Helper.MultifacturaArray)

            Dim serializer = New XmlSerializer(infoDocumentoPago.GetType())
            Dim ns = new XmlSerializerNamespaces() 
            ns.Add("", "")

            Dim settings = new XmlWriterSettings()
            settings.OmitXmlDeclaration = true

              
            

            Dim documentoxml = ""

            If AprobacionDeposito = True Then
                     documentoxml = _RutaRespaldoXml + Folios + "_DEPO.xml"
                Else 
                     documentoxml = _RutaRespaldoXml + Folios + ".xml"

            End If
           


            

            Using writer As New StreamWriter(documentoxml)
                serializer.Serialize(writer, infoDocumentoPago,ns)
            End Using


            If _esVentaRecuperada = False Then
                EjecutaVentaRespaldo(objventa, 2)
            End If

            'valorRetorno = FtpClient.UploadFileFtp("POS" + txtNroCaja.Text, documentoxml, Folios + ".xml")

        End If






        Return valorRetorno
    End Function
#End Region


    Public Function Ejecutaventasinpago(ByVal objventa As VentaObj) As Boolean


        Dim valorRetorno As Boolean = True
        concepto = _Concepto

        'detalle de los articulos solicitados.
        Dim objarticulos As ArrayList = objventa.ListaArticulos
        '*************************** DocumentoPago
        Dim DocumentoPago_pos As String = objventa.codigo_Post
        Dim DocumentoPago_empresa As String = objventa.Codigo_Empresa
        Dim DocumentoPago_cliente As String = objventa.Cod_Cliente
        Dim DocumentoPago_fcreacion As String = objventa.FechaSistema
        Dim DocumentoPago_hcreacion As String = objventa.HoraSistema
        Dim DocumentoPago_motivo As String = "Traspaso de Pos"
        Dim DocumentoPago_monto As String = objventa.total
        Dim DocumentoPago_caja As String = objventa.CajaRecepcion
        Dim DocumentoPago_Sede As String = objventa.Sede
        'duda
        Dim DocumentoPago_usuario As String = id_Cajero.ToString
        Dim DocumentoPago_Ultlineavoucher As String = "0"
        Dim DocumentoPago_Ultlineapresupuesto As String = "0"
        ' puede ser V1, V2,V3

        Dim DocumentoModalidad_Indicador As String = "V2"


        '***** DOCUMEN>TO PAGO CARGO
        ' parametros de entrada para DocumentoPago_cargo
        Dim cargo_documento As String = objventa.DocumentoVenta
        Dim cargo_timbrado As String = objventa.nro_Documento
        Dim cargo_moneda As String = objventa.Moneda
        Dim cargo_cambio As String = "1" ' valor defecto
        'total del documento
        Dim cargo_saldo As String = objventa.total

        Dim cargo_abono As String = objventa.total
        Dim cargo_cambioAbono As String = "1" ' valor defecto segun browse 
        Dim cargo_vencto As String


        If objventa.FechaVencimiento <> "" Then
            cargo_vencto = _FechaBrowse(objventa.FechaVencimiento)
        Else
            cargo_vencto = ""
        End If

        Dim cargo_cuenta As String = "0" ' a la espera de preguntar si puede ir en null
        '500  duda?
        Dim cargo_lista_precio As String = objventa.Lista
        Dim cargo_contacto As String = ""
        Dim cargo_vendedor As String = objventa.CodigoVendedor  'codigo vendedor
        Dim cargo_cgestion_vendedor As String = objventa.Cgestionvendedor

        Dim cargo_direccion_despacho

        cargo_direccion_despacho = objventa.DireccionDespacho

        Dim cargo_fono As String = objventa.FonoCliente


        Dim cargo_direccion_facturacion As String = objventa.DireccionFacturacion

        Dim cargo_nula As String = "N" 'valor defecto proporcionado por browse. del cual nos tenemos que detallar junto a ellos
        Dim cargo_observaciones As String = "OBSERVACIONES"
        Dim cargo_lineas_articulo As String = objventa.ListaArticulos.Count.ToString   'total de articulos en detalle
        Dim cargo_ultima_guia As String = "0" ' se inngresa el nro de la ultima guia de despacho de lo contrario se ingresa 0
        'ultima del detalle de traspaso
        Dim cargo_lineas_glosa As String = "0"
        ' hay que ver en que caso ingresamos lineas contable.
        'SI LA FACTURA CONTIENE UNA SERIE DE PRODUCTOS QUE NO SON CATALOGADOS
        'HAY QUE INFORMAR EL ASIENTO CONTABLE
        ' CUATRO LINEAS CONTABLE 4 SI NO HAY LINEAS CONTABLE SIEMPRE VA EN CERO
        Dim cargo_lineas_Contable As String = objventa.ListaArticulos.Count.ToString
        'CERO
        Dim cargo_lineas_Condicion As String = objventa.ListaArticulos.Count.ToString()
        'DESCUENTO DE CABESERA, DESCUENTO VALOR TOTAL EN PORCENTAJE
        Dim cargo_descuento2 As String = "0"
        Dim cargo_descuento3 As String = "0"
        ' CUANTO DEL TOTAL DEL DOCUMENTO VA A SER EXENTO
        Dim cargo_monto_exento As String = ""
        Dim cargo_monto_iva As String = objventa.iva
        'SE INDICA SI ES INVENTARIABLE O VARIOS.
        Dim cargo_indicador_tipo As String = "I"
        ' LA BODEGA DE LA VENTA.
        Dim cargo_bodega As String = "1"
        'CODIGO DE LA CAJA

        Dim cargo_punto As String = objventa.PuntoFacturacion
        'SALDO TOTAL DEL DOCUMENTO EL VALOR TOTAL DE LA VENTA
        Dim cargo_saldo_documento As String = objventa.total
        'SIEMPRE DICE QUE SI
        'SI LE QUE PONGO QUE NO SIGNIFICA NO LA HE EMITIDO
        'NULO
        Dim cargo_indicador_impresion As String = "S"

        'Dim cargo_monto_indicador As String = ""
        '
        Dim cargo_monto_credito As String = "0"
        'NULO
        Dim cargo_indicador_servip As String = ""
        '
        Dim cargo_indicador_movpendientes As String = "N"
        Dim cargo_Folio_reparto As String = "0"
        'valor lo obtube de la tabla mbcve
        Dim cargo_concepto_venta As String = concepto
        Dim cargo_tipo_transporte As String = "99"
        'aca en cargo_Termino va el tipo de pago contado en cuotas etc. credito steward
        Dim cargo_termino As String = GetTerminoPago()
        Dim cargo_paridad_lista As String = ""
        Dim cargo_ultlineapresupuesto As String = "0"
        Dim cargo_sucursal As String = ""
        Dim cargo_glosa_facturacion As String = ""


        '********************** DocumentoPago_detalle_cargo
        'Catalogado
        Dim Cargo_detalle_linea As String = ""
        Dim Cargo_detalle_articulo As String = ""
        Dim Cargo_detalle_cantidad_uvta As String = ""
        Dim Cargo_detalle_precio_articulo As String = ""
        Dim Cargo_detalle_descto_linea As String = ""
        Dim Cargo_detalle_indicador_envase As String = ""
        Dim Cargo_detalle_precio_lista As String = ""
        Dim Cargo_detalle_paridad_documento As String = ""
        Dim Cargo_detalle_tprecio_flete As String = ""
        Dim Cargo_detalle_Pdescto_vol As String = ""
        Dim Cargo_detalle_Pdescto_pago As String = ""
        Dim Cargo_detalle_Pdescto_otros As String = ""

        'DocumentoPago_detvarios_cargo

        Dim Cargo_detvarios_linea As String = ""
        Dim Cargo_detvarios_glosa As String = ""
        Dim Cargo_detvarios_precio_unitario As String = ""
        Dim Cargo_detvarios_cantidad As String = ""
        Dim Cargo_detvarios_desctos As String = ""
        Dim Cargo_detvarios_umedida As String = ""
        Dim Cargo_detvarios_ultlinea As String = ""
        Dim Cargo_detvarios_precio_bruto As String = ""
        Dim Cargo_detvarios_ultlinea_detglo As String = ""

        'DocumentoPago_impuesto_cargo

        Dim Cargo_impuesto_codigo As String = ""
        Dim Cargo_impuesto_valor As String = ""

        'DocumentoPago_voucher_cargo
        'solo catalogado, es un secuencial de linea. 
        Dim Cargo_voucher_linea As String = ""
        Dim Cargo_voucher_cuenta As String = ""
        Dim Cargo_voucher_auxiliar As String = ""
        Dim Cargo_voucher_debe As String = ""
        Dim Cargo_voucher_haber As String = ""
        Dim Cargo_voucher_cgestion As String = ""
        Dim Cargo_voucher_igestion As String = ""
        Dim Cargo_voucher_sede As String = ""
        Dim Cargo_voucher_glosa As String = ""

        'DocumentoPago_ppto_cargo
        Dim Cargo_ppto_linea As String = ""
        Dim Cargo_ppto_cgestion As String = ""
        Dim Cargo_ppto_cuenta As String = ""
        Dim Cargo_ppto_igestion As String = ""
        Dim Cargo_ppto_devengado As String = ""
        Dim Cargo_ppto_tipo_docto As String = ""
        Dim Cargo_ppto_numero_docto As String = ""



        Dim objDocumentoPago As New DocumentoPagox(DocumentoPago_pos, DocumentoPago_empresa, DocumentoPago_cliente, DocumentoPago_fcreacion, DocumentoPago_hcreacion, DocumentoPago_motivo, DocumentoPago_monto, DocumentoPago_caja, DocumentoPago_Sede, DocumentoPago_usuario, DocumentoPago_Ultlineavoucher, DocumentoPago_Ultlineapresupuesto, DocumentoModalidad_Indicador)

        Dim cargo_doc_timbrado As String = objDocumentoVenta.GrabaDocumento("aa", Date.Now)
        Dim objDocumentoPago_Cargo As New DocumentoPagoCargo(cargo_documento, cargo_timbrado, cargo_moneda, cargo_cambio, cargo_saldo, cargo_abono, cargo_cambioAbono, cargo_vencto,
        cargo_cuenta, cargo_lista_precio, cargo_contacto, cargo_vendedor, cargo_cgestion_vendedor, cargo_direccion_despacho, cargo_fono, cargo_direccion_facturacion,
        cargo_nula, cargo_observaciones, cargo_lineas_articulo, cargo_ultima_guia, cargo_lineas_glosa, cargo_lineas_Contable,
        cargo_lineas_Condicion, cargo_descuento2, cargo_descuento2, cargo_descuento3, cargo_monto_exento, cargo_monto_iva, cargo_indicador_tipo,
        cargo_bodega, cargo_punto, cargo_saldo_documento, cargo_indicador_impresion, cargo_monto_credito, cargo_indicador_servip, cargo_indicador_movpendientes _
        , cargo_Folio_reparto, cargo_concepto_venta, cargo_tipo_transporte, cargo_termino, cargo_paridad_lista, cargo_ultlineapresupuesto, cargo_sucursal, cargo_glosa_facturacion)

        Dim contador As Integer = 0

        Dim arregloDocumentoPagoDetalle_Cargo As New ArrayList
        For Each objar As ArticuloStringObj In objarticulos
            contador = contador + 1
            Dim objDocumentoPago_detalle_cargo As New DocumentoPago_detalle_cargo(contador, objar.sku, objar.cantidad, objar.precio.Replace(".", "") _
              , "", objar.Envase, objar.precio.Replace(".", ""), "1", "0" _
                  , 0, 0, 0, objar.unidadmedida, _Ubicacion)
            arregloDocumentoPagoDetalle_Cargo.Add(objDocumentoPago_detalle_cargo)
        Next

        Dim objDocumentoPago_detvarios_cargo As New DocumentoPago_detvarios_cargo(Cargo_detvarios_linea, Cargo_detvarios_glosa, Cargo_detvarios_precio_unitario _
          , Cargo_detvarios_cantidad, Cargo_detvarios_desctos, Cargo_detvarios_umedida, Cargo_detvarios_ultlinea, Cargo_detvarios_precio_bruto, Cargo_detvarios_ultlinea_detglo)





        Dim objDocumentoPago_impuesto_Cargo As New DocumentoPago_impuesto_cargo(Cargo_impuesto_codigo, Cargo_impuesto_valor)

        Dim objDocumentoPago_voucher_cargo As New DocumentoPago_voucher_cargo(Cargo_voucher_linea, Cargo_voucher_cuenta, Cargo_voucher_auxiliar, Cargo_voucher_debe _
                                                                              , Cargo_voucher_haber, Cargo_voucher_cgestion, Cargo_voucher_igestion, Cargo_voucher_sede, Cargo_voucher_glosa)
        Dim objDocumentoPago_ppto_cargo As New DocumentoPago_ppto_cargo(Cargo_ppto_linea, Cargo_ppto_cgestion, Cargo_ppto_cuenta, Cargo_ppto_igestion _
               , Cargo_ppto_devengado, Cargo_ppto_tipo_docto)







        Dim xmlvent As New VentaXML

        Dim doc As String = xmlvent.DocumentoPagoGetXMLSinPago(objDocumentoPago, objDocumentoPago_Cargo, arregloDocumentoPagoDetalle_Cargo, objDocumentoPago_detvarios_cargo, objDocumentoPago_impuesto_Cargo, objDocumentoPago_voucher_cargo, objDocumentoPago_ppto_cargo)

        If ExistenciaErroresFolios = True Then
            Return False
        End If

        Dim docxml As New XmlDocument
        docxml.LoadXml(doc)
        docxml.Save(_RutaRespaldoXml + objventa.Correlativo + ".xml")

        Try
            Dim resultado As String = wsRecibeVenta.Execute(doc)
            Dim docXMLT As New XmlDocument

            docXMLT.LoadXml(resultado)
            Dim lista As XmlNodeList
            Dim nodo As XmlNode
            Dim indicador As String = ""
            docXMLT.SelectNodes("/Respuesta")

            If docXMLT.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
                lista = docXMLT.SelectNodes("/Respuesta/Respuesta_indicador_validez")
                nodo = lista(0)
                indicador = nodo.ChildNodes.Item(0).InnerText
            End If

            Dim patos As New ArrayList
            Dim msgerrores As String = ""
            If indicador = "0" Then
                valorRetorno = False


                For Each nodoerrores As XmlNode In docXMLT.GetElementsByTagName("Respuesta_Detalle")
                    msgerrores = msgerrores & nodoerrores.ChildNodes.Item(0).InnerText + " - " + nodoerrores.ChildNodes(1).InnerText & vbNewLine

                Next
                MsgBox("SE HAN PROVOCADO LOS SIGUIENTES  ERRORES EN LA TRANSACCION:" + msgerrores, MsgBoxStyle.Critical, "STEWARD ")
            Else
                valorRetorno = True
                'Dim objdocu As New DocumentoController
                ' objdocu.GuardarDocumento(objventa.Correlativo, objventa.DocumentoVenta, doc)
            End If

        Catch ex As Exception
            MsgBox("SE HA PROBOCADO UN ERROR EN LA TRANSACCION:" + ex.ToString, MsgBoxStyle.Critical, "STEWARD ")
            Return valorRetorno = False

        End Try

        Return valorRetorno
    End Function


    Public Function EJECUTAAPLICAPAGO(ByVal objventa As VentaObj) As Boolean


        Dim valorRetorno As Boolean = True
        concepto = _Concepto


        'detalle de los articulos solicitados.
        Dim objarticulos As ArrayList = objventa.ListaArticulos
        '*************************** DocumentoPago
        Dim DocumentoPago_pos As String = objventa.codigo_Post
        Dim DocumentoPago_empresa As String = objventa.Codigo_Empresa
        Dim DocumentoPago_cliente As String = objventa.Cod_Cliente
        Dim DocumentoPago_fcreacion As String = objventa.FechaSistema
        Dim DocumentoPago_hcreacion As String = objventa.HoraSistema
        Dim DocumentoPago_motivo As String = "Traspaso de Pos"
        Dim DocumentoPago_monto As String = objventa.total
        Dim DocumentoPago_caja As String = objventa.CajaRecepcion
        Dim DocumentoPago_Sede As String = objventa.Sede
        'duda
        Dim DocumentoPago_usuario As String = id_Cajero.ToString
        Dim DocumentoPago_Ultlineavoucher As String = "0"
        Dim DocumentoPago_Ultlineapresupuesto As String = "0"
        ' puede ser V1, V2,V3

        Dim DocumentoModalidad_Indicador As String = "V3"


        '***** DOCUMEN>TO PAGO CARGO
        ' parametros de entrada para DocumentoPago_cargo
        Dim cargo_documento As String = objventa.DocumentoVenta
        Dim cargo_timbrado As String = objventa.nro_Documento
        Dim cargo_moneda As String = objventa.Moneda
        Dim cargo_cambio As String = "1" ' valor defecto
        'total del documento
        Dim cargo_saldo As String = objventa.total
        ''' recordar esto
        Dim cargo_abono As String = objventa.total
        Dim cargo_cambioAbono As String = "1" ' valor defecto segun browse 
        Dim cargo_vencto As String = _FechaBrowse(objventa.FechaVencimiento)
        Dim cargo_cuenta As String = "0" ' a la espera de preguntar si puede ir en null
        '500  duda?
        Dim cargo_lista_precio As String = objventa.Lista
        Dim cargo_contacto As String = ""
        Dim cargo_vendedor As String = objventa.CodigoVendedor  'codigo vendedor
        Dim cargo_cgestion_vendedor As String = objventa.Cgestionvendedor

        Dim cargo_direccion_despacho

        cargo_direccion_despacho = objventa.DireccionDespacho

        Dim cargo_fono As String = objventa.FonoCliente


        Dim cargo_direccion_facturacion As String = objventa.DireccionFacturacion

        Dim cargo_nula As String = "N" 'valor defecto proporcionado por browse. del cual nos tenemos que detallar junto a ellos
        Dim cargo_observaciones As String = "OBSERVACIONES"
        Dim cargo_lineas_articulo As String = objventa.ListaArticulos.Count.ToString   'total de articulos en detalle
        Dim cargo_ultima_guia As String = "0" ' se inngresa el nro de la ultima guia de despacho de lo contrario se ingresa 0
        'ultima del detalle de traspaso
        Dim cargo_lineas_glosa As String = "0"
        ' hay que ver en que caso ingresamos lineas contable.
        'SI LA FACTURA CONTIENE UNA SERIE DE PRODUCTOS QUE NO SON CATALOGADOS
        'HAY QUE INFORMAR EL ASIENTO CONTABLE
        ' CUATRO LINEAS CONTABLE 4 SI NO HAY LINEAS CONTABLE SIEMPRE VA EN CERO
        Dim cargo_lineas_Contable As String = objventa.ListaArticulos.Count.ToString
        'CERO
        Dim cargo_lineas_Condicion As String = objventa.ListaArticulos.Count.ToString()
        'DESCUENTO DE CABESERA, DESCUENTO VALOR TOTAL EN PORCENTAJE
        Dim cargo_descuento2 As String = "0"
        Dim cargo_descuento3 As String = "0"
        ' CUANTO DEL TOTAL DEL DOCUMENTO VA A SER EXENTO
        Dim cargo_monto_exento As String = ""
        Dim cargo_monto_iva As String = objventa.iva
        'SE INDICA SI ES INVENTARIABLE O VARIOS.
        Dim cargo_indicador_tipo As String = "I"
        ' LA BODEGA DE LA VENTA.
        Dim cargo_bodega As String = "1"
        'CODIGO DE LA CAJA

        Dim cargo_punto As String = objventa.PuntoFacturacion
        'SALDO TOTAL DEL DOCUMENTO EL VALOR TOTAL DE LA VENTA
        Dim cargo_saldo_documento As String = objventa.total
        'SIEMPRE DICE QUE SI
        'SI LE QUE PONGO QUE NO SIGNIFICA NO LA HE EMITIDO
        'NULO
        Dim cargo_indicador_impresion As String = "S"

        'Dim cargo_monto_indicador As String = ""
        '
        Dim cargo_monto_credito As String = "0"
        'NULO
        Dim cargo_indicador_servip As String = ""
        '
        Dim cargo_indicador_movpendientes As String = "N"
        Dim cargo_Folio_reparto As String = "0"
        'valor lo obtube de la tabla mbcve
        Dim cargo_concepto_venta As String = concepto
        Dim cargo_tipo_transporte As String = "99"
        'aca en cargo_Termino va el tipo de pago contado en cuotas etc. credito steward
        Dim cargo_termino As String = GetTerminoPago()
        Dim cargo_paridad_lista As String = ""
        Dim cargo_ultlineapresupuesto As String = "0"
        Dim cargo_sucursal As String = ""
        Dim cargo_glosa_facturacion As String = ""


        '********************** DocumentoPago_detalle_cargo
        'Catalogado
        Dim Cargo_detalle_linea As String = ""
        Dim Cargo_detalle_articulo As String = ""
        Dim Cargo_detalle_cantidad_uvta As String = ""
        Dim Cargo_detalle_precio_articulo As String = ""
        Dim Cargo_detalle_descto_linea As String = ""
        Dim Cargo_detalle_indicador_envase As String = ""
        Dim Cargo_detalle_precio_lista As String = ""
        Dim Cargo_detalle_paridad_documento As String = ""
        Dim Cargo_detalle_tprecio_flete As String = ""
        Dim Cargo_detalle_Pdescto_vol As String = ""
        Dim Cargo_detalle_Pdescto_pago As String = ""
        Dim Cargo_detalle_Pdescto_otros As String = ""

        'DocumentoPago_detvarios_cargo

        Dim Cargo_detvarios_linea As String = ""
        Dim Cargo_detvarios_glosa As String = ""
        Dim Cargo_detvarios_precio_unitario As String = ""
        Dim Cargo_detvarios_cantidad As String = ""
        Dim Cargo_detvarios_desctos As String = ""
        Dim Cargo_detvarios_umedida As String = ""
        Dim Cargo_detvarios_ultlinea As String = ""
        Dim Cargo_detvarios_precio_bruto As String = ""
        Dim Cargo_detvarios_ultlinea_detglo As String = ""

        'DocumentoPago_impuesto_cargo

        Dim Cargo_impuesto_codigo As String = ""
        Dim Cargo_impuesto_valor As String = ""

        'DocumentoPago_voucher_cargo
        'solo catalogado, es un secuencial de linea. 
        Dim Cargo_voucher_linea As String = ""
        Dim Cargo_voucher_cuenta As String = ""
        Dim Cargo_voucher_auxiliar As String = ""
        Dim Cargo_voucher_debe As String = ""
        Dim Cargo_voucher_haber As String = ""
        Dim Cargo_voucher_cgestion As String = ""
        Dim Cargo_voucher_igestion As String = ""
        Dim Cargo_voucher_sede As String = ""
        Dim Cargo_voucher_glosa As String = ""

        'DocumentoPago_ppto_cargo
        Dim Cargo_ppto_linea As String = ""
        Dim Cargo_ppto_cgestion As String = ""
        Dim Cargo_ppto_cuenta As String = ""
        Dim Cargo_ppto_igestion As String = ""
        Dim Cargo_ppto_devengado As String = ""
        Dim Cargo_ppto_tipo_docto As String = ""
        Dim Cargo_ppto_numero_docto As String = ""



        Dim objDocumentoPago As New DocumentoPagox(DocumentoPago_pos, DocumentoPago_empresa, DocumentoPago_cliente, DocumentoPago_fcreacion, DocumentoPago_hcreacion, DocumentoPago_motivo, DocumentoPago_monto, DocumentoPago_caja, DocumentoPago_Sede, DocumentoPago_usuario, DocumentoPago_Ultlineavoucher, DocumentoPago_Ultlineapresupuesto, DocumentoModalidad_Indicador)

        Dim cargo_doc_timbrado As String = objDocumentoVenta.GrabaDocumento("aa", Date.Now)
        Dim objDocumentoPago_Cargo As New DocumentoPagoCargo(cargo_documento, cargo_timbrado, cargo_moneda, cargo_cambio, cargo_saldo, cargo_abono, cargo_cambioAbono, cargo_vencto,
        cargo_cuenta, cargo_lista_precio, cargo_contacto, cargo_vendedor, cargo_cgestion_vendedor, cargo_direccion_despacho, cargo_fono, cargo_direccion_facturacion,
        cargo_nula, cargo_observaciones, cargo_lineas_articulo, cargo_ultima_guia, cargo_lineas_glosa, cargo_lineas_Contable,
        cargo_lineas_Condicion, cargo_descuento2, cargo_descuento2, cargo_descuento3, cargo_monto_exento, cargo_monto_iva, cargo_indicador_tipo,
        cargo_bodega, cargo_punto, cargo_saldo_documento, cargo_indicador_impresion, cargo_monto_credito, cargo_indicador_servip, cargo_indicador_movpendientes _
        , cargo_Folio_reparto, cargo_concepto_venta, cargo_tipo_transporte, cargo_termino, cargo_paridad_lista, cargo_ultlineapresupuesto, cargo_sucursal, cargo_glosa_facturacion)

        Dim contador As Integer = 0

        Dim arregloDocumentoPagoDetalle_Cargo As New ArrayList
        For Each objar As ArticuloStringObj In objarticulos
            contador = contador + 1
            Dim objDocumentoPago_detalle_cargo As New DocumentoPago_detalle_cargo(contador, objar.sku, objar.cantidad, objar.precio.Replace(".", "") _
              , "", objar.Envase, objar.precio.Replace(".", ""), "1", "0" _
                  , 0, 0, 0, objar.unidadmedida, _Ubicacion)
            arregloDocumentoPagoDetalle_Cargo.Add(objDocumentoPago_detalle_cargo)
        Next

        Dim objDocumentoPago_detvarios_cargo As New DocumentoPago_detvarios_cargo(Cargo_detvarios_linea, Cargo_detvarios_glosa, Cargo_detvarios_precio_unitario _
          , Cargo_detvarios_cantidad, Cargo_detvarios_desctos, Cargo_detvarios_umedida, Cargo_detvarios_ultlinea, Cargo_detvarios_precio_bruto, Cargo_detvarios_ultlinea_detglo)





        Dim objDocumentoPago_impuesto_Cargo As New DocumentoPago_impuesto_cargo(Cargo_impuesto_codigo, Cargo_impuesto_valor)

        Dim objDocumentoPago_voucher_cargo As New DocumentoPago_voucher_cargo(Cargo_voucher_linea, Cargo_voucher_cuenta, Cargo_voucher_auxiliar, Cargo_voucher_debe _
                                                                              , Cargo_voucher_haber, Cargo_voucher_cgestion, Cargo_voucher_igestion, Cargo_voucher_sede, Cargo_voucher_glosa)
        Dim objDocumentoPago_ppto_cargo As New DocumentoPago_ppto_cargo(Cargo_ppto_linea, Cargo_ppto_cgestion, Cargo_ppto_cuenta, Cargo_ppto_igestion _
               , Cargo_ppto_devengado, Cargo_ppto_tipo_docto)







        Dim xmlvent As New VentaXML

        Dim doc As String = xmlvent.DocumentoPagoGetXMLAbonoAplica(objDocumentoPago, objDocumentoPago_Cargo, arregloDocumentoPagoDetalle_Cargo, objDocumentoPago_detvarios_cargo, objDocumentoPago_impuesto_Cargo, objDocumentoPago_voucher_cargo, objDocumentoPago_ppto_cargo, GetDocumentosPagoAbono)

        If ExistenciaErroresFolios = True Then
            Return False
        End If

        Dim docxml As New XmlDocument
        docxml.LoadXml(doc)
        docxml.Save(_RutaRespaldoXml + objventa.Correlativo + ".xml")

        Try
            Dim resultado As String = wsRecibeVenta.Execute(doc)
            Dim docXMLT As New XmlDocument

            docXMLT.LoadXml(resultado)
            Dim lista As XmlNodeList
            Dim nodo As XmlNode
            Dim indicador As String = ""
            docXMLT.SelectNodes("/Respuesta")

            If docXMLT.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
                lista = docXMLT.SelectNodes("/Respuesta/Respuesta_indicador_validez")
                nodo = lista(0)
                indicador = nodo.ChildNodes.Item(0).InnerText
            End If

            Dim patos As New ArrayList
            Dim msgerrores As String = ""
            If indicador = "0" Then
                valorRetorno = False


                For Each nodoerrores As XmlNode In docXMLT.GetElementsByTagName("Respuesta_Detalle")
                    msgerrores = msgerrores & nodoerrores.ChildNodes.Item(0).InnerText + " - " + nodoerrores.ChildNodes(1).InnerText & vbNewLine

                Next
                MsgBox("SE HAN PROVOCADO LOS SIGUIENTES  ERRORES EN LA TRANSACCION:" + msgerrores, MsgBoxStyle.Critical, "STEWARD ")
            Else
                valorRetorno = True
                'Dim objdocu As New DocumentoController
                ' objdocu.GuardarDocumento(objventa.Correlativo, objventa.DocumentoVenta, doc)
            End If

        Catch ex As Exception
            MsgBox("SE HA PROBOCADO UN ERROR EN LA TRANSACCION:" + ex.ToString, MsgBoxStyle.Critical, "STEWARD ")
            Return valorRetorno = False

        End Try

        Return valorRetorno
    End Function


    Public Sub GUARDARVENTA(ByVal razon As String) Handles xRazon.GetRazon


        Dim docu As String = "<Documento>" &
        "<Correlativo>" + txtCorrelativo.Text + "</Correlativo>" &
        "<Cliente>" + txtRut.Text + "</Cliente>" &
        "<ListaPrecio>" + txtListaPrecio.Text + "</ListaPrecio>" &
        "<RazonSocial>" + txtNombreCliente.Text + "</RazonSocial>" &
        "<CodigoVendedor>" + txtCodigoVendedor.Text + "</CodigoVendedor>" &
        "<NombreVendedor>" + txtNombreVendedor.Text + "</NombreVendedor>" &
        "<IdDireccion>" + txtCodigoDirección.Text + "</IdDireccion>" &
        "<Direccion>" + txtNombreDireccion.Text + "</Direccion>" &
        "<Descuento>" + txtDescuento.Text + "</Descuento>" &
        "<TipoDocumento>" + TipoDocumentoVenta() + "</TipoDocumento>" &
        "<DescuentoCabesera>" + txtPorcentajeDescuento.Text.Replace(",", ".") + "</DescuentoCabesera>" &
        "<Detalle>" &
        retornaDetalleArticulos() &
        "</Detalle>" &
        "</Documento>"

           
        Dim fecha = DateTime.Now.ToString("yyyyMMddHHss")

        Dim docxml As New XmlDocument
        docxml.LoadXml(docu)
        Dim ruta As String = _RutaRespaldoXml + "PENDIENTE_" + fecha + "_" + txtCorrelativo.Text + ".xml"
        docxml.Save(ruta)

        WS_POS.POS_Documento("SAVE", _FechaSistemaWin, "PENDIENTE_" + fecha + "_" + txtCorrelativo.Text + ".xml", 1, razon, TipoDocumentoVenta, docu, 0, _Sede, _PuntoFacturacion)

    End Sub








    Public Function retornaDetalleArticulos() As String
        Dim tag As String = ""

        For Each gr As DataGridViewRow In gridDetalle.Rows
            Dim descuentodetalle As Integer = 0

            If gr.Cells("Porcentaje").Value <> 0 Then
                descuentodetalle = Int32.Parse(gr.Cells("Porcentaje").Value)
            End If

            tag = tag &
            "<Articulo>" &
            "<ArticuloCodigo>" + gr.Cells("Codigo").Value.ToString + "</ArticuloCodigo>" &
            "<ArticuloCantidad>" + gr.Cells("Cant").Value.ToString + "</ArticuloCantidad>" &
            "<ArticuloDescuento>" + descuentodetalle.ToString + "</ArticuloDescuento>" &
            "<ArticuloPrecioNeto>" + gr.Cells("Precio").Value.ToString + "</ArticuloPrecioNeto>" &
            "<ArticuloPrecioIva>" + gr.Cells("PrecioIva").Value.ToString + "</ArticuloPrecioIva>" &
            "</Articulo>"
        Next

        Return tag
    End Function



    Public Function GetTerminoPago() As Integer

        If totalMedioPagos() > 1 Then
            'si el total de los medios de pagos es mayor a 1 entonces hay que enviar el termino de pago mixto
            Return 1
        End If

        If Me.txtResumenEfectivo.Text <> "" Then
            Return 1
        End If

        If Me.txtResumenDebito.Text <> "" Then
            Return 25
        End If

        If Me.txtResumenCredito.Text <> "" Then
            Dim termicre As Integer = Int32.Parse(ObtieneTerminodePagoTarjetadeCredito())
            Return termicre
        End If

        If Me.txtResumenCheque.Text <> "" Then
            Dim Termicheque As Integer = Int32.Parse(cheque_txt_condicionPago_Codigo.Text)
            Return Termicheque
        End If

        If Me.txtResumenCreditoSteward.Text <> "" Then
            Return 99
        End If

        If txtResumenTransferencia.Text <> "" Then
            Return 20
        End If

        If txtResumenSinPago.Text <> "" Then
            Return 1
        End If


        If Me.txtResumenNotaCredito.Text <> "" Then
            Return 80
        End If

    End Function

    Function ObtieneTerminoPagoTarjetadeCredito(ByVal cuotas As Integer)
        CargaComboTerminoPagoCredito()
    End Function



    Public Function totalMedioPagos() As Integer
        Dim contador As Integer = 0


        If txtResumenEfectivo.Text <> "" Then
            contador = contador + 1
        End If

        If txtResumenDebito.Text <> "" Then
            contador = contador + 1
        End If

        If txtResumenCredito.Text <> "" Then
            contador = contador + 1
        End If

        If txtResumenCheque.Text <> "" Then
            contador = contador + 1

        End If

        If txtResumenCreditoSteward.Text <> "" Then
            contador = contador + 1
        End If

        If txtResumenNotaCredito.Text <> "" Then
            contador = contador + 1
        End If

        If txtResumenTransferencia.Text <> "" Then
            contador = contador + 1
        End If


        If txtResumenSinPago.Text <> "" Then
            contador = contador + 1
        End If

        Return contador

    End Function

    Public Function FormadePago(ByVal tipo As String) As String


        Dim forma As String = ""

        Dim contador As Integer = 0
        If tipo = "BOVT" Then

            If txtResumenEfectivo.Text <> "" Then
                contador = contador + 1
                forma = forma + "EFEC "
            End If

            If txtResumenDebito.Text <> "" Then
                contador = contador + 1
                forma = forma + "DEBITO "
            End If

            If txtResumenCredito.Text <> "" Then
                contador = contador + 1
                forma = forma + "TCRED"
            End If

            If txtResumenDebitoCredito.Text <> "" Then
                contador = contador + 1
                forma = forma + "TCRED"
            End If

            If txtResumenCheque.Text <> "" Then
                contador = contador + 1
                forma = forma + "CHEQUE "
            End If

            If txtResumenTransferencia.Text <> "" Then
                contador = contador + 1
                forma = forma + "TRANS "
            End If

            If txtResumenCreditoSteward.Text <> "" Then
                contador = contador + 1
                forma = forma + "LCRED "
            End If

            If txtResumenNotaCredito.Text <> "" Then
                contador = contador + 1
                forma = forma + "NOTA DE CREDITO"
            End If

        End If


        If tipo = "FAAF" Then

            If txtResumenEfectivo.Text <> "" Then
                contador = contador + 1
                forma = forma + "EFECTIVO "
            End If

            If txtResumenDebito.Text <> "" Then
                contador = contador + 1
                forma = forma + "DEBITO "
            End If

            If txtResumenDebitoCredito.Text <> "" Then
                contador = contador + 1
                forma = forma + "DEBITO "
            End If

            If txtResumenCredito.Text <> "" Then
                contador = contador + 1
                forma = forma + "TCREDITO"
            End If

            If txtResumenCheque.Text <> "" Then
                contador = contador + 1
                forma = forma + "CHEQUE "
            End If

            If txtResumenTransferencia.Text <> "" Then
                contador = contador + 1
                forma = forma + "TRANSFERENCIA "
            End If


            If txtResumenCreditoSteward.Text <> "" Then
                contador = contador + 1
                forma = forma + "CREDITO STEWARD "
            End If

            If txtResumenNotaCredito.Text <> "" Then
                contador = contador + 1
                forma = forma + "NOTA DE CREDITO"
            End If

        End If




        Return forma

    End Function

    Public Function GetDocumentosPagoAbono() As ArrayList

        ExistenciaErroresFolios = False

        Dim arr As New ArrayList

        If txtResumenEfectivo.Text <> "" Then

            Dim abono As Integer
            Dim Pagado As Integer = Int32.Parse(Me.txtPagado.Text.Replace(".", ""))
            Dim vuelto As Integer = 0
            If txtVuelto.Text <> "" Then
                vuelto = Int32.Parse(Me.txtVuelto.Text.Replace(".", ""))
            End If

            If vuelto <> 0 Then

                abono = Int32.Parse(Me.txtResumenEfectivo.Text.Replace(".", "")) - vuelto
            Else
                abono = Int32.Parse(Me.txtResumenEfectivo.Text.Replace(".", ""))

            End If

            If Me.txtResumenNotaCredito.Text <> "" Then
                abono = abono + Int32.Parse(Me.txtResumenNotaCredito.Text.Replace(".", ""))
            End If

            Dim objDocumentoPago_abono As New DocumentoPago_abono("EFEC", "", _Moneda, _AbonoCambio, "45", "", abono, _FechaSistema, _FechaSistema _
                                                           , "", "", "2", "", "", "", "", _Pos)
            arr.Add(objDocumentoPago_abono)

        End If


        '    If txtResumenEfectivo.Text <> "" Then

        '   Dim abono As Integer
        '  If txtResumenDebito.Text = "" And txtResumenCredito.Text = "" And txtResumenCreditoSteward.Text = "" And txtResumenTransferencia.Text = "" And txtResumenCheque.Text = "" Then
        'abono = Int32.Parse(txtFinal.Text.Replace(".", ""))
        'Else
        'abono = Int32.Parse(txtResumenEfectivo.Text.Replace(".", ""))
        'End If

        'Dim objDocumentoPago_abono As New DocumentoPago_abono("EFEC", "", _Moneda, _AbonoCambio, "45", "", abono, _FechaSistema, _FechaSistema _
        '   , "", "", "2", "", "", "", "", _Pos)
        'arr.Add(objDocumentoPago_abono)
        'End If



        If txtResumenDebito.Text <> "" Then


            Dim codigo As String = ""
            'Dim numerodeoperacion As String = debito_txtNroOperacion.Text
            ' numerodeoperacion = numerodeoperacion.Substring(numerodeoperacion.Length - 2, 2)
            'Dim correlativo As String = txtCorrelativo.Text
            'correlativo = correlativo.Substring(correlativo.Length - 3, 3)
            'correlativo = correlativo + numerodeoperacion
            codigo = _Pos + Me.Debito_txt_Codigo_Autorizacion.Text


            Dim objdocpago As New DocumentosPagoController
            If objdocpago.VALIDAEXISTENCIAFOLIO(codigo, "TDEB") = False Then
                Dim objDocumentoPago_abono As New DocumentoPago_abono("TDEB", codigo, _Moneda, _AbonoCambio, debito_codigo_banco.Text, "", Me.txtResumenDebito.Text.Replace(".", ""), _FechaSistema, _FechaSistema _
                                                                        , "", Debito_txt_Codigo_Autorizacion.Text, "2", "", "", "", "", _Pos)
                arr.Add(objDocumentoPago_abono)
            Else
                MsgBox("El Codigo de Autorización duplicado", MsgBoxStyle.Information, "TARJETA DE DEBITO")
                Me.ErrorProvider1.SetError(Me.Debito_txt_Codigo_Autorizacion, "Duplicado")
                ExistenciaErroresFolios = True
            End If


        End If

        If txtResumenCredito.Text <> "" Then


            Dim Codigo As String
            Codigo = _Pos + credito_txt_CodAutorizacion.Text

            Dim objdocpago As New DocumentosPagoController

            If objdocpago.VALIDAEXISTENCIAFOLIO(Codigo, "TCRE") = False Then

                Dim objDocumentoPago_abono As New DocumentoPago_abono("TCRE", Codigo, _Moneda, _AbonoCambio, Me.creditotxtCodigoBanco.Text, "", Me.txtResumenCredito.Text.Replace(".", ""), _FechaSistema, _FechaSistema _
                                                               , "", credito_txt_CodAutorizacion.Text, "1", "", "", "", "", "")
                arr.Add(objDocumentoPago_abono)
            Else
                MsgBox("El Codigo de Autorización duplicado", MsgBoxStyle.Information, " TARJETA DE CREDITO")
                Me.ErrorProvider1.SetError(Me.credito_txt_CodAutorizacion, "Duplicado")
                ExistenciaErroresFolios = True
            End If




        End If




        If txtResumenCheque.Text <> "" Then
            For Each gr As DataGridViewRow In cheque_grid_cheque.Rows
                Dim numero As String = gr.Cells("nro_cheque").Value
                Dim codigobanco As String = gr.Cells("CodigoBanco").Value
                Dim cuenta As String = gr.Cells("Cuenta").Value
                Dim FechaVencimiento As DateTime = gr.Cells("Fecha").Value
                Dim objDocumentoPago_abono As New DocumentoPago_abono("CHEQ", numero, _Moneda, _AbonoCambio, codigobanco, cuenta, gr.Cells("MONTO").Value.ToString.Replace(".", ""), _FechaSistema, FechaVencimiento.ToString("yyyyMMdd") _
                                                                     , "", gr.Cells("nro_cheque").Value, "1", "", "", "", "", _PuntoFacturacion)
                arr.Add(objDocumentoPago_abono)
            Next

        End If

        If txtResumenCreditoSteward.Text <> "" Then

            Dim objDocumentoPago_abono As New DocumentoPago_abono("CRED", "", _Moneda, _AbonoCambio, 0, "", txtResumenCreditoSteward.Text.Replace(".", ""), _FechaSistema, _FechaSistema _
                                                                     , "", Me.txtCreditoRut.Text, 1, txtCredito_OrdendeCompra.Text, "", CreditoSteward_txt_Observacion.Text, "", _PuntoFacturacion)
            arr.Add(objDocumentoPago_abono)

        End If


        If txtResumenTransferencia.Text <> "" Then

            Dim corre As String = txtTransferenciaNro.Text
            corre = corre.Substring(corre.Length - 2, 2)
            Dim objDocumentoPago_abono As New DocumentoPago_abono("DEPO", txtCorrelativo.Text + corre, _Moneda, _AbonoCambio, Me.txt_transferencia_codigobanco.Text, Me.txtTransferenciaNro.Text, txtResumenTransferencia.Text.Replace(".", ""), _FechaSistema, _FechaSistema _
                                                                     , "", txtTransferenciaNro.Text, 1, "", "", txt_Debito_Banco.Text, "", _PuntoFacturacion)
            arr.Add(objDocumentoPago_abono)

        End If


        If txtResumenNotaCredito.Text <> "" And txtResumenEfectivo.Text = "" Then
            Dim abono As Integer = 0
            Dim vuelto As Double = 0
            abono = Int32.Parse(Me.txtResumenNotaCredito.Text.Replace(".", ""))


            If Double.Parse(txtPagado.Text) > Double.Parse(Me.txtFinal.Text) Then
                vuelto = Double.Parse(Me.txtVuelto.Text)
                abono = Double.Parse(txtPagado.Text) - vuelto
            End If


            Dim objDocumentoPago_abono As New DocumentoPago_abono("EFEC", "", _Moneda, _AbonoCambio, "45", "", abono, _FechaSistema, _FechaSistema _
                                                           , "", "", "2", "", "", "", "", _Pos)
            arr.Add(objDocumentoPago_abono)
        End If


        Return arr

    End Function


    Public Function ObtieneTerminodePagoTarjetadeCredito() As String

        Dim obj As New TerminoPagoController
        Dim x1 As Integer = 0

        Dim arreglo As ArrayList = obj.GetTerminoTarjetaCredito()

        For i As Integer = 0 To arreglo.Count - 1

            Dim obj2 As ListaObj = arreglo(i)

            If obj2.Descripcion.Trim = txtCuotasCredito.Text Then
                Me.txtCreditoTerminoPago.Text = obj2.Codigo
                Return obj2.Codigo
            End If

        Next

        End

    End Function

    Private Sub Cheque_btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim monto As Double = 0

        For Each gr As DataGridViewRow In cheque_grid_cheque.Rows
            monto = monto + Double.Parse(gr.Cells("Monto").Value)
        Next

        If monto <> 0 Then
            Me.txtResumenCheque.Text = monto
            ValidaTotaldePagos()
        Else
            MsgBox("ingrese cheques!", MsgBoxStyle.Exclamation, "STEWARD")

        End If



    End Sub




    Private Sub txtRut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRut.TextChanged






    End Sub


    Public Function _GetDireccionFacturacion() As String


        Return _direccionFacturacion.Codigo

    End Function



    Public Function _GetDireccionDespacho() As String

        'Dim direccion As String = ""
        'Dim objdir As ListaObj = Me.Direcciones_Combo_Despacho.SelectedItem

        'If Not IsNothing(objdir) Then
        '    If objdir.Codigo <> "-" Then
        '        direccion = Direcciones_Combo_Despacho.SelectedValue

        '        Return direccion
        '    Else
        '        Return RetornaDirDespacho()
        '    End If
        'Else
        '    Return RetornaDirDespacho()

        'End If

        Return _direccionDespacho.Codigo

    End Function

    Public Function RetornaDirDespacho() As String


        Dim existe As Boolean = False
        For Each x As DireccionObj In _perfilCliente.Direcciones
            If x.Codigo = "888" Then
                existe = True
                Return x.Codigo
            End If
        Next

        If existe = False Then

            If _perfilCliente.Direcciones.Count <> 0 Then
                Dim obj As DireccionObj = _perfilCliente.Direcciones.Item(0)
                Return obj.Codigo
            End If
        End If


    End Function


    Public Function _GetFonoCLiente()




    End Function


    Private Sub txtEfectivo_monto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub credito_txt_nro_operacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles credito_txt_nro_operacion.KeyDown

        If e.KeyValue = Keys.Enter Then
            If credito_txt_nro_operacion.Text <> "" Then
                Me.credito_txt_CodAutorizacion.Enabled = True
                Me.credito_txt_CodAutorizacion.Focus()

            End If

        End If

    End Sub

    Private Sub credito_txt_nro_operacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles credito_txt_nro_operacion.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSincero(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub credito_txt_nro_operacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles credito_txt_nro_operacion.TextChanged

    End Sub

    Private Sub credito_txt_CodAutorizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles credito_txt_CodAutorizacion.KeyDown

        If e.KeyValue = Keys.Enter Then

            Me.txtCuotasCredito.Enabled = True
            Me.txtCuotasCredito.Focus()
        End If
    End Sub

    Private Sub credito_txt_CodAutorizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles credito_txt_CodAutorizacion.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSincero(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub credito_txt_CodAutorizacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles credito_txt_CodAutorizacion.TextChanged

    End Sub

    Private Sub credito_txt_monto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)



    End Sub

    Private Sub credito_txt_monto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub credito_txt_cuotas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        'If e.KeyValue = Keys.Enter Then

        '  Button2_Click_1(sender, e)

        ' End If

    End Sub

    Private Sub credito_txt_cuotas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    Private Sub CreditoSteward_txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)




    End Sub

    Private Sub CreditoSteward_txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Public Function _GetRut() As String

        Dim rut As String = Replace(Mid(txtRut.Text.ToString, 1, Me.txtRut.Text.ToString.IndexOf("-")), ".", "")

        Return rut
    End Function

    Private Sub btnDespacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDespacho.Click
        VuelveModalidadN()
        Me.RemoverPaneles()
        Me.TabMedioPago.TabPages.Add(TabDirecciones)
        Me.CargarDireccionesDespacho(_Empresa, _GetRut)
    End Sub


    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles gridDetalle.EditingControlShowing
        ' referencia a la celda
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna
        Dim columna As Integer = gridDetalle.CurrentCell.ColumnIndex
        ' comprobar si la celda en edicin corresponde a la columna 0 o 1
        If columna = 0 Or columna = 6 Then
            ' Obtener caracter
            Dim caracter As Char = e.KeyChar
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub


    Private Sub btn_Descuento_Cabesera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Descuento_Cabesera.Click


        xDescuento.lblTitulo.Text = "Aplicar Descuento a Documento"
        xDescuento.txtTipo.Text = 1
        xDescuento.ShowDialog()


    End Sub


    Private Sub AplicarDescuento(ByVal tipo As Integer, ByVal porcentaje As Integer)

        If tipo = 1 Then

            Me.lblSaldo1.Visible = True
            txtDescuento.Visible = True
            Dim total As Double = Double.Parse(txtSubTotal.Text)
            Dim resultado As Double = total * porcentaje
            resultado = resultado / 100
            Me.txtDescuento.Text = resultado.ToString("N0")
            Dim subtotal As Double = txtSubTotal.Text
            subtotal = subtotal - resultado
            txtBruto.Text = subtotal.ToString("N0")
            CalculaIvaYTotalfinal(Double.Parse(txtSubTotal.Text))

        End If

    End Sub



    Public Sub ActualizaValoresDescuentos()

        If Me.List_Descuentos.Items.Count <> 0 Then

            For Each a As ListaObj In Me.List_Descuentos.Items

                For Each gr As DataGridViewRow In Me.gridDetalle.Rows

                    If gr.Cells("codigo").Value = a.Codigo Then

                        Dim Descuento As Double = Double.Parse(a.Descripcion)
                        Dim fila As DataGridViewRow = traefila(a.Codigo)
                        Dim valor As Double = fila.Cells("valor").Value
                        Dim valordes As Double = valor * Descuento / 100

                        fila.Cells("Descuento").Value = valordes.ToString("N0")
                        fila.Cells("Porcentaje").Value = a.Descripcion


                    End If
                Next

            Next


        End If

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Protected Sub AplicaSeparadoresdeMil()

        If Me.gridDetalle.Rows.Count <> 0 Then

            For Each dvr As DataGridViewRow In gridDetalle.Rows


                'dvr.Cells("Precio").Value = dvr.Cells("Precio").Value.ToString("N0")

                'dvr.Cells("valor").Value = valor.ToString("N0")

            Next

        End If


    End Sub


    Public Function ObtieneTerminoPago()
        Dim TerminoPago As Integer = 1

        Dim contador As Integer = 0

        If Me.txtResumenEfectivo.Text.Length <> 0 Then
            contador = contador + 1
            TerminoPago = _TerminoPagoContadoEfectivo
        End If

        If Me.txtResumenDebito.Text.Length <> 0 Then
            TerminoPago = _TerminoPagoDebito
        End If

        If Me.txtResumenCredito.Text.Length <> 0 Then
            contador = contador + 1
        End If

        If Me.txtResumenCreditoSteward.Text.Length <> 0 Then
            contador = contador + 1
        End If

        If Me.txtResumenCheque.Text.Length <> 0 Then
            contador = contador + 1

        End If

        If Me.txtResumenTransferencia.Text.Length <> 0 Then
            contador = contador + 1
            TerminoPago = 20
        End If


        If contador > 1 Then
            TerminoPago = 1
        End If

        Return TerminoPago

    End Function

    Public Function ObtieneCondicionesCargo() As ArrayList

        Dim arreglo As New ArrayList
        Dim efectivo As Decimal

        If Me.txtResumenEfectivo.Text <> 0 Then
            efectivo = Decimal.Parse(txtResumenEfectivo.Text)
            efectivo = efectivo * 100
            efectivo = efectivo / Decimal.Parse(txtFinal.Text)
            Dim documento As New DocumentoPago_Condicion_Cargo(1, 1, 100, txtFinal.Text, "", "EFEC")
            arreglo.Add(documento)
        End If

        Return arreglo

    End Function

    Private Sub btnNuevaVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnNuevaVenta.KeyDown

    End Sub

    Private Sub btn_Reeimpresion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub txtNombreCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreCliente.KeyDown

    End Sub

    Private Sub txtCorrelativo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCorrelativo.KeyDown

        If e.KeyValue = Keys.Enter Then
            If Me.txtCorrelativo.Text <> "" Then

                recuperaVentaLisa(txtCorrelativo.Text, True)
                _Modalidad = "N"


            Else
                MsgBox("Ingrese Folio", MsgBoxStyle.Information, "STEWARD")
            End If

        End If


    End Sub


    Public Sub pagaDocumento(ByVal codigo) Handles XDocumentosCliente.TraeVenta

        recuperaVentaLisaParaPago(codigo)
    End Sub



    Public Function recuperaVentaLisa(ByVal codigo As String, ByVal CargaDetalle As Boolean) As VentaObj

        Me.txtBruto.Text = ""
        Me.txtSubTotal.Text = ""
        Me.txtDescuento.Text = ""
        Me.txtFinal.Text = ""

        Dim rut As String = ""
        Dim objdocumento As New DocumentoController
        Dim objDocu As VentaObj = objdocumento.GetDoc(codigo)
        If objDocu.Correlativo <> "" Then

            esVentaRecuperada = True

            If (gridDetalle.Rows.Count > 0) Then
                ArregloItems.Clear()
                gridDetalle.Rows.Clear()
                gridDetalle.Refresh()
            End If



            Me.txtRut.Text = objDocu.Cod_Cliente

            If objDocu.Cod_Cliente = "10" Then
                Me.txtRut.Text = "10-8"
            End If
            ' Me.btn_Anular.Enabled = True
            If txtRut.Text.Length = 7 Or txtRut.Text.Length = 8 Then
                Dim dv As String = _digitoverificador(Int32.Parse(txtRut.Text))
                rut = txtRut.Text + "-" + dv
                Me.txtRut.Text = rut
            End If

            Me.BuscarCliente()
            Me.btnGuardar.Enabled = True
            Me.txtListaPrecio.Text = objDocu.Lista
            Me.txtCodigoVendedor.Text = objDocu.CodigoVendedor
            Dim Vendedor_Controller As New VendedorController
            Me.txtNombreVendedor.Text = Vendedor_Controller.Buscar(objDocu.CodigoVendedor).Nombre

            Me.txtCodigoDirección.Text = objDocu.CodigoDireccion
            Me.txtNombreDireccion.Text = objDocu.DireccionFacturacion

            Me.txtCodigoDirecciónDespacho.Text = objDocu.CodigoDireccionDespa
            Me.txtNombreDireccionDespacho.Text = objDocu.DireccionDespacho
            Me.lblFechaDocumento.Text = objDocu.FechaEmision
            Me.lblFechaDocumento.Visible = True

            _direccionFacturacion.Direccion = objDocu.DireccionFacturacion
            _direccionFacturacion.Region = objDocu.Region
            _direccionFacturacion.Ciudad = objDocu.Ciudad
            _direccionFacturacion.Comuna = objDocu.Comuna

            _direccionDespacho.Direccion = objDocu.DireccionDespacho
            _direccionDespacho.Region = objDocu.RegionDespa
            _direccionDespacho.Ciudad = objDocu.CiudadDespa
            _direccionDespacho.Comuna = objDocu.ComunaDespa

            Me.txtDescuento.Text = objDocu.Descuento

            If txtDescuento.Text <> "" Then

                pos_Descuento(1, txtDescuento.Text, "")

            End If

            If CargaDetalle = True Then

                For Each objdetalle As ArticuloStringObj In objDocu.ListaArticulos

                    ArregloItems.Add(objdetalle)
                    llenarGrilla(gridDetalle, ArregloItems)
                    Me.btn_Descuento_Cabesera.Enabled = True
                    DestacaProductoEnOferta()
                    APlicaColoresGrillaDetalle()



                    ' Me.IngresaArticuloGrid(objDocu.Cod_Cliente, objdetalle.sku, Int32.Parse(objdetalle.cantidad))
                Next

                CalculaSubTotal()

                'articulo.Descuento = descuento


            End If

            Return objDocu

        Else
            MsgBox("EL DOCUMENTO NO SE HA ENCONTRADO EN LISA", MsgBoxStyle.Exclamation)

        End If

    End Function

    Public Sub recuperaVentaLisaParaPago(ByVal codigo As String) Handles XFormularioPagos.TraeVenta
        recuperaVentaLisa(codigo, True)

    End Sub


    Protected Sub RecuperaVentaLisa_(ByVal codigo)
        Dim objdocumento As New DocumentoController
        Dim objDocu As VentaObj = objdocumento.GetDoc(codigo)
        If objDocu.Correlativo <> "" Then
            Me.txtCorrelativo.Text = objDocu.Correlativo
            Me.txtRut.Text = objDocu.Cod_Cliente
            ' Me.btn_Anular.Enabled = True
            Me.btnPagar.Enabled = True
            If txtRut.Text.Length = 7 Or txtRut.Text.Length = 8 Then
                Dim dv As String = _digitoverificador(Int32.Parse(txtRut.Text))
                Me.txtRut.Text = txtRut.Text + "-" + dv
            End If

            Me.BuscarCliente()
            Me.txtListaPrecio.Text = objDocu.Lista
            Me.txtCodigoVendedor.Text = objDocu.CodigoVendedor
            Dim Vendedor_Controller As New VendedorController
            Me.txtNombreVendedor.Text = Vendedor_Controller.Buscar(objDocu.CodigoVendedor).Nombre

            'llena el detalle.

            For Each objdetalle As ArticuloStringObj In objDocu.ListaArticulos

                Me.IngresaArticuloGrid(objDocu.Cod_Cliente, objdetalle.sku, Int32.Parse(objdetalle.cantidad))

            Next



        End If
    End Sub

    Public Sub PagosDocumentosExistentes(ByVal documentos As ArrayList, ByVal saldo As Double, ByVal rut As String, ByVal nombre As String) Handles XFormularioPagosAplicar.SaldoPorPagar

        Me.RemoverPanelesCabecera()
        Me.TabControlCabecera.TabPages.Add(TabAplicaPago)

        ResetFormulario()

        Me.btnPagar.Enabled = False
        _DocumentosAplicarPago = documentos


        If _DocumentosAplicarPago.Count <> 0 Then
            Me.abonoGridDocumentos.DataSource = _DocumentosAplicarPago
        End If

        _Modalidad = "AP"



        For Each doc As DocumentoObj In documentos
            _tipoDocumentoVenta = doc.TipoDocumento
            recuperaVentaLisa(doc.Folio, False)
            Exit For
        Next



        Dim iva As Double = objTrans.ExtraeIva(saldo)
        Me.abono_iva.Text = iva.ToString("N0")
        Me.abono_total.Text = saldo.ToString("N0")
        Me.abono_subtotal.Text = (saldo - iva).ToString("N0")
        Me.txtRut.Text = rut
        Me.abono_TxtRut.Text = rut
        Me.abono_TxtNombre.Text = nombre
        Me.txtSubTotal.Text = (saldo - iva).ToString("N0")
        Me.txtIva.Text = iva.ToString("N0")
        Me.txtBruto.Text = (saldo - iva).ToString("N0")
        Me.txtFinal.Text = saldo.ToString("N0")


        If TabControl.TabPages(0).Name = "TabArticulos" Then
            Me.TabControl.TabPages.Remove(TabArticulos)
            Me.TabControl.TabPages.Add(txt_Debito_Banco)
        End If

        If totalMedioPagos() = 0 Then
            Me.RemoverPaneles()
            Me.TXTMEDIOPAGO.Text = "1"
            Me.btnCompraEfectivo.Focus()
        End If

        Me.btnDetalle.Enabled = False
        Me.btnPagar.Enabled = True
        Me.btnCerrarCompra.Enabled = False
        '  Me.btn_Anular.Enabled = False
        If objCLiente.TieneCredito(objStw.LimpiaRut(txtRut.Text)) <> "1" And _tipoDocumentoVenta = _CodigoFactura Then

            Me.btn_Credito_Steward.Enabled = True

        End If

    End Sub



    Public Sub TraeDocumentoBD(ByVal doc As String)

        Dim DOCXML As New XmlDocument
        DOCXML.LoadXml(doc)
        Dim NodoPrincipal As XmlNodeList
        Dim nodo As XmlNode
        Dim nodochicodetalle As XmlNode
        Dim nodoDetalle As XmlNodeList
        Dim descuentocabesera As Integer = 0


        If DOCXML.GetElementsByTagName("DocumentoPago").Count > 0 Then ' Existen Resultad

            NodoPrincipal = DOCXML.SelectNodes("/DocumentoPago")
            nodoDetalle = DOCXML.SelectNodes("Documento/Detalle/Articulo")

            Dim nodochico As XmlNode = NodoPrincipal.Item(0)

            Dim rut As Integer = Int32.Parse(NodoPrincipal.Item(0)("DocumentoPago_cliente").InnerText)
            txtRut.Text = rut.ToString + "-" + _digitoverificador(rut).ToString
            BuscarCliente()

            Exit Sub

            txtRut.ReadOnly = False
            txtNombreCliente.Text = nodochico("RazonSocial").InnerText
            txtListaPrecio.Text = nodochico("ListaPrecio").InnerText
            txtCodigoVendedor.Text = nodochico("CodigoVendedor").InnerText
            txtNombreVendedor.Text = nodochico("NombreVendedor").InnerText
            Dim tipoDocumento As String = nodochico("TipoDocumento").InnerText

            If tipoDocumento = "BOVT" Then
                txtCorrelativo.ForeColor = Color.Red
                txtCorrelativo.Text = WS_POS.POS_Correlativo("wop")
            End If
            If tipoDocumento = "FAAF" Then
                txtCorrelativo.ForeColor = Color.Red
                txtCorrelativo.Text = WS_POS.POS_Correlativo("wop")
            End If
            If nodochico("DescuentoCabesera").InnerText <> "" Then
                descuentocabesera = Int32.Parse(nodochico("DescuentoCabesera").InnerText)
                pos_Descuento(1, descuentocabesera, "")
            End If


            'Dim x As Integer = listanodoSedes.Count

            For Each nodochicodetalle In nodoDetalle

                Dim codigo As String = nodochicodetalle("ArticuloCodigo").InnerText.ToString
                Dim cantidad As Integer = nodochicodetalle("ArticuloCantidad").InnerText.ToString
                Dim descuento As Integer = nodochicodetalle("ArticuloDescuento").InnerText.ToString
                Me.txtCodigoProducto.Text = codigo
                Me.txtCantidad.Text = cantidad
                IngresaArticuloGrid(rut, codigo, cantidad)

                If descuento <> 0 Then
                    pos_Descuento(2, descuento, codigo)
                End If
            Next


            'secccion de descuentos
        End If


    End Sub


    Private Sub txtCorrelativo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCorrelativo.TextChanged

    End Sub



    Public Sub Guardar()
        If Me.gridDetalle.Rows.Count <> 0 Then

            Try

                xRazon.ShowDialog()


            Catch ex As Exception
                MsgBox("Error:" + ex.ToString)
            End Try

        Else
            MsgBox("Deben existir articulos en el detalle para realizar la Copia", MsgBoxStyle.Information)
        End If


    End Sub

    Public Sub Pegar()

        xPendiente.ShowDialog()

    End Sub

    Private Sub RadBoleta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub



    Private Sub RadFactura_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RadFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub gridDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridDetalle.KeyDown

    End Sub

    Private Sub btnBuscarVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnBuscarVendedor.KeyDown

    End Sub

    Private Sub txtListaPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtListaPrecio.KeyDown


        If e.KeyValue = Keys.Enter Then

            Xautorizacion.Tipo.Text = "ListaPrecio"
            Xautorizacion.txtUsuario.Focus()
            Xautorizacion.ShowDialog()
            Exit Sub

            Dim obj As New ListaPrecioController

            If obj.Valida(txtListaPrecio.Text) = True Then

                If esVentaRecuperada = False Then
                    ActualizaDetalleListaPrecio()
                End If

            Else
                Me.txtListaPrecio.Text = _listaPrecio
                MsgBox("Lista de Precio Invalida", MsgBoxStyle.Information, "Información")
            End If

        End If

    End Sub

    Private Sub txtListaPrecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtListaPrecio.TextChanged

    End Sub

    Private Sub btn_ListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Protected Sub ActualizaValoresCheques()



    End Sub


    Private Sub txtResumenCheque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenCheque.KeyDown

        If e.KeyValue = Keys.Enter Then


            If txtResumenCheque.Text = "" Then
                DesactivarMediosPagosVacios()
                RemoverPaneles()
            Else
                ValidaTotaldePagos()

                If PagoRestante() <> 0 Then
                    txtResumenCheque.Text = (Int32.Parse(txtResumenCheque.Text.Replace(".", ""))).ToString("N0")
                End If

                If TabMedioPago.TabCount = 0 Then
                    Me.TabMedioPago.TabPages.Add(btn_Condicion_Pago)
                    'Me.CargarComboBancoCheque()


                End If

                GrillaCheques_CalculaMontos()

            End If


            ValidaTotaldePagos()

        End If

    End Sub

    Private Sub txtResumenCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtResumenCheque.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosComodin(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtResumenCheque_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenCheque.KeyUp

    End Sub

    Private Sub txtResumenCheque_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenCheque.LostFocus
        If txtResumenCheque.Text.Length = 0 Then
            txtResumenCheque.Enabled = False
            TabMedioPago.TabPages.Clear()
        End If
    End Sub

    Private Sub txtResumenCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenCheque.TextChanged
        ValidaTotaldePagos()
    End Sub

    Public Sub RecuperarVenta(ByVal documento As String) Handles xPendiente.RecuperaVenta

        ResetFormulario()

        'Creamos el XML Reader

        Dim DOCXML As New XmlDocument
        DOCXML.LoadXml(documento)
        Dim NodoPrincipal As XmlNodeList
        Dim nodo As XmlNode
        Dim nodochicodetalle As XmlNode
        Dim nodoDetalle As XmlNodeList
        Dim descuentocabesera As Integer = 0
        DOCXML.SelectNodes("/Documento")

        If DOCXML.GetElementsByTagName("Documento").Count > 0 Then ' Existen Resultad

            NodoPrincipal = DOCXML.SelectNodes("/Documento")
            nodoDetalle = DOCXML.SelectNodes("Documento/Detalle/Articulo")

            Dim nodochico As XmlNode = NodoPrincipal.Item(0)


            txtRut.Text = nodochico("Cliente").InnerText
            Dim rut As Integer = Int32.Parse(Me.objTrans.LimpiaRut(txtRut.Text))
            BuscarCliente()

            txtRut.ReadOnly = False
            'txtNombreCliente.Text = nodochico("RazonSocial").InnerText
            txtListaPrecio.Text = nodochico("ListaPrecio").InnerText
            txtCodigoVendedor.Text = nodochico("CodigoVendedor").InnerText
            txtNombreVendedor.Text = nodochico("NombreVendedor").InnerText
            txtCodigoDirección.Text = nodochico("IdDireccion").InnerText
            txtNombreDireccion.Text = nodochico("Direccion").InnerText

            Me.txtCodigoProducto.ReadOnly = False
            Me.txtDescripcionProducto.ReadOnly = False
            txtCodigoProducto.Enabled = True

            Dim tipoDocumento As String = nodochico("TipoDocumento").InnerText

            If tipoDocumento = "BOVT" Then
                Me.txtDocumento.Text = "BOLETA"
                txtCorrelativo.ForeColor = Color.Red
                _tipoDocumentoVenta = tipoDocumento
                txtCorrelativo.Text = objDocumentoVenta.GetFolio(_Sede, _PuntoFacturacion, _tipoDocumentoVenta)
            End If
            If tipoDocumento = "FAAF" Then
                Me.txtDocumento.Text = "FACTURA"
                txtCorrelativo.ForeColor = Color.Blue
                _tipoDocumentoVenta = tipoDocumento
                txtCorrelativo.Text = objDocumentoVenta.GetFolio(_Sede, _PuntoFacturacion, _tipoDocumentoVenta)
            End If


            'If tipoDocumento = "BOVT" Then
            'Me.RadBoleta.Checked = True
            'End If
            'If tipoDocumento = "FAAF" Then
            'Me.RadFactura.Checked = True
            'End If

            'Dim x As Integer = listanodoSedes.Count

            For Each nodochicodetalle In nodoDetalle

                Dim codigo As String = nodochicodetalle("ArticuloCodigo").InnerText.ToString
                Dim cantidad As Integer = nodochicodetalle("ArticuloCantidad").InnerText.ToString
                Dim descuento As Integer = nodochicodetalle("ArticuloDescuento").InnerText.ToString
                Dim precioIva As Double = nodochicodetalle("ArticuloPrecioIva").InnerText.ToString
                Dim precio As Double = Double.Parse(nodochicodetalle("ArticuloPrecioNeto").InnerText.ToString)

                Me.txtCodigoProducto.Text = codigo
                Me.txtCantidad.Text = cantidad
                IngresaArticuloGrid(rut, codigo, cantidad)
                InsertaValordeArticulo(codigo, precio, precioIva)
                If descuento <> 0 Then
                    pos_Descuento(2, descuento, codigo)
                End If
            Next

            If nodochico("Descuento").InnerText <> "" Then
                descuentocabesera = Int32.Parse(nodochico("Descuento").InnerText)
                pos_Descuento(1, descuentocabesera, "")
            End If

            Me.btnGuardar.Enabled = True
            esVentaRecuperada = True
            'secccion de descuentos
        End If

    End Sub
    Private Sub InsertaValordeArticulo(ByVal Codigo As String, ByVal precio As Double, ByVal PrecioIva As Double)

        Dim gr As DataGridViewRow = traefila(Codigo)

        If gr.Cells("PrecioIva").Value <> PrecioIva Then

            gr.Cells("PrecioIva").Value = PrecioIva

        End If

    End Sub

    Private Sub btn_Reeimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnCierreCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCierreCaja.Click


        Try

            Dim DOC As String = ""
            If _tipoDocumentoVenta = "BOVT" Then
                DOC = "BOLETA"
            End If

            If _tipoDocumentoVenta = "FAAF" Then
                DOC = "FACTURA"
            End If

            If _MENSAJE_CONFIRMACION("¿DESEA IMPRIMIR EL DOCUMENTO" + DOC + "  NUMERO: " + txtCorrelativo.Text, "STEWARD") = True Then

                Dim objVenta As VentaObj = VentaSetParametros()
                objVenta.PerfilCliente = _perfilCliente

                Dim esdescuento As Boolean = False

                If txtDescuento.Text <> "" Then
                    esdescuento = True
                End If

                If DetectaModalidad() = "V1" Then
                    Dim objDoc As New DocumentoController

                    If TipoDocumentoVenta() = "FAAF" Then
                        objVentaController.GeneraDocumentoImpresionFactura(objVenta, esdescuento)
                        objDoc.CambiaEstadoImpresion(objVenta.Correlativo, "FAAF", 1)
                    Else
                        objVentaController.GeneraDocumentoImpresionBoleta(objVenta)
                        objDoc.CambiaEstadoImpresion(objVenta.Correlativo, "BOVT", 1)
                    End If

                    MsgBox("RETIRE IMPRESIÓN", MsgBoxStyle.Information, "VENTA")
                    Me.btnPagar.Enabled = False
                    ResetFormulario()
                End If

            End If


        Catch ex As Exception



        End Try


    End Sub

    Private Sub btnCierreCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnCierreCaja.KeyDown

    End Sub

    Private Sub btnAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnAdmin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown

    End Sub

    Private Sub txtSubTotal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubTotal.KeyDown

    End Sub

    Private Sub txtSubTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubTotal.TextChanged

    End Sub

    Private Sub txtDescuento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescuento.KeyDown

    End Sub

    Private Sub txtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescuento.TextChanged

    End Sub

    Private Sub txtSubDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBruto.KeyDown

    End Sub

    Private Sub txtSubDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBruto.TextChanged

    End Sub

    Private Sub txtIva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIva.KeyDown

    End Sub

    Private Sub txtIva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIva.TextChanged

    End Sub

    Private Sub txtFinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFinal.KeyDown

    End Sub

    Private Sub txtFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinal.TextChanged

    End Sub

    Private Sub btnBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub btnCerrarCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub btn_Descuento_Cabesera_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_Descuento_Cabesera.KeyDown

    End Sub

    Private Sub txtNombreVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreVendedor.KeyDown

    End Sub

    Private Sub txtNombreVendedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreVendedor.TextChanged

    End Sub

    Private Sub btnDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnDetalle.KeyDown

    End Sub

    Private Sub txtResumenEfectivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenEfectivo.KeyDown


        If e.KeyValue = Keys.Enter Then
            DesactivarMediosPagosVacios()
            If txtResumenEfectivo.Text <> "" Then
                Dim efectivo As Integer = Int32.Parse(Me.txtResumenEfectivo.Text.Replace(".", ""))
                Me.txtResumenEfectivo.Text = efectivo.ToString("N0")
            End If
            'txtPagado.Text = efectivo.ToString("N0")
            ValidaTotaldePagos()
        End If


    End Sub

    Private Sub txtResumenEfectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtResumenEfectivo.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosComodin(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtResumenEfectivo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenEfectivo.KeyUp

    End Sub

    Private Sub txtResumenEfectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenEfectivo.LostFocus

        If txtResumenEfectivo.Text = "" Then
            txtResumenEfectivo.ReadOnly = True
            TabMedioPago.TabPages.Clear()
        End If

    End Sub

    Private Sub txtResumenEfectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenEfectivo.TextChanged
        ValidaTotaldePagos()
    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub btnCompraEfectivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnCompraEfectivo.KeyDown

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        For i = 0 To 255
            If GetAsyncKeyState(i) = -32767 Then

                Dim s As String = Chr(i)

                If teclacontrol = True Then

                    ' PARA ACER ACCESOS RAPIDOS CON CONTROL


                End If




                If Chr(i) = "x" Then


                    If Me.gridDetalle.Rows.Count <> 0 Then
                        Dim fila As Integer = gridDetalle.CurrentRow.Index
                        Dim cantidad As Integer = 0
                        Dim gr As DataGridViewRow = gridDetalle.Rows(fila)
                        cantidad = Int32.Parse(gr.Cells("Cant").Value)
                        XFormCantidad.cantidad = cantidad
                        XFormCantidad.fila = fila
                        XFormCantidad.ShowDialog()
                    End If




                End If

                If (Chr(i)) = "r" Then
                    AccionBotonBoleta(sender, e)
                End If

                If (Chr(i)) = "s" Then
                    AccionBotonFactura(sender, e)
                End If



                If (Chr(i)) = "q" Then
                    '   AccionBotonFactura(sender, e)

                    If Me.gridDetalle.Rows.Count <> 0 Then
                        Dim fila As Integer = gridDetalle.CurrentRow.Index
                        Dim cantidad As Integer = 0
                        Dim gr As DataGridViewRow = gridDetalle.Rows(fila)
                        cantidad = Int32.Parse(gr.Cells("Cant").Value)
                        XFormCantidad.cantidad = cantidad
                        XFormCantidad.fila = fila
                        XFormCantidad.ShowDialog()
                    End If


                End If

                If (Chr(i)) = "r" Then
                    If txtNombreCliente.Text <> "" Then
                        Me.txtCodigoProducto.Focus()
                    End If
                End If

                If (Chr(i)) = "z" Then
                    Dim help As New Help
                    help.ShowDialog()
                End If


                If (Chr(i)) = "t" Then
                    pasaAmediosdePago()
                End If


                If Chr(i) = "." And gridDetalle.Focused = True Then
                    EliminarItem()
                End If


                If (Chr(i)) = "{" Then
                    AccionFinalizaVenta()
                End If

                If (Chr(i)) = "¢" Then
                    teclacontrol = True
                Else
                    teclacontrol = False
                End If

            End If


        Next

    End Sub

    Private Sub txtResumenCredito_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenCredito.ClientSizeChanged

    End Sub

    Private Sub txtResumenCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenCredito.KeyDown



        If e.KeyValue = Keys.Enter Then

            If txtResumenCredito.Text = "" Then
                DesactivarMediosPagosVacios()
                Me.RemoverPaneles()
                ValidaTotaldePagos()
            Else

                If TabMedioPago.TabPages.Count > 0 Then

                    If TabMedioPago.TabPages(0).Name <> "TabCredito" Then
                        RemoverPaneles()
                        Me.TabMedioPago.TabPages.Add(TabCredito)
                        Dim credito As Integer = Int32.Parse(txtResumenCredito.Text.Replace(".", ""))
                        txtResumenCredito.Text = credito.ToString("N0")
                    Else
                        Dim credito As Integer = Int32.Parse(txtResumenCredito.Text.Replace(".", ""))
                        txtResumenCredito.Text = credito.ToString("N0")
                    End If


                End If



                ValidaTotaldePagos()

            End If

        End If



    End Sub

    Private Sub txtResumenCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtResumenCredito.KeyPress


        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosComodin(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtResumenCredito_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenCredito.KeyUp


    End Sub

    Private Sub txtResumenCredito_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles txtResumenCredito.Layout

    End Sub

    Private Sub txtResumenCredito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenCredito.LostFocus
        If txtResumenCredito.Text = "" Then
            Me.txtResumenCredito.ReadOnly = True
            TabMedioPago.TabPages.Clear()
        End If
    End Sub


    Private Sub txtResumenCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenCredito.TextChanged
        ValidaTotaldePagos()

    End Sub


    Public Function validaDetallePagos() As Boolean

        Dim todook As Boolean = True

        If txtResumenDebito.Text <> "" Then

            If debito_codigo_banco.Text = "" Then
                MsgBox("Seleccione Banco, Tarjeta de Debito ", MsgBoxStyle.Information, "VALIDACIÓN")
                Return False
            End If

            If Debito_txt_Codigo_Autorizacion.Text = "" Then
                MsgBox("Ingrese Codigo Autorizacion, Tarjeta de Debito ", MsgBoxStyle.Information, "VALIDACIÓN")
                todook = False
                Return False
            End If

            If debito_txtNroOperacion.Text = "" Then
                MsgBox("Ingrese Nro Operación, Tarjeta de Debito ", MsgBoxStyle.Information, "VALIDACIÓN")
                todook = False
                Return False
            End If


        End If


        If txtResumenCredito.Text <> "" Then

            If creditotxtCodigoBanco.Text = "-" Then
                MsgBox("Seleccione Banco, Tarjeta de Crédito ", MsgBoxStyle.Information, "VALIDACIÓN")
                Return False
            End If

            If credito_txt_codigo_tipoTarjeta.Text = "" Then
                MsgBox("Seleccione el Tipo de Tarjeta, Tarjeta de Crédito ", MsgBoxStyle.Information, "VALIDACIÓN")
                Return False
            End If

            If credito_txt_CodAutorizacion.Text = "" Then
                MsgBox("Ingrese Codigo de Autorización, Tarjeta de Crédito ", MsgBoxStyle.Information, "VALIDACIÓN")
                Return False
            End If



            If credito_txt_nro_operacion.Text = "" Then
                MsgBox("Ingrese numero de Operación, Tarjeta de Crédito ", MsgBoxStyle.Information, "VALIDACIÓN")
                Return False
            End If


            If txtCuotasCredito.Text = "" Then
                MsgBox("Ingrese numero de Cuotas, Tarjeta de Crédito ", MsgBoxStyle.Information, "VALIDACIÓN")
                Return False
            End If

            'If Int32.Parse(txtCuotasCredito.Text) > 0 And Int32.Parse(txtCuotasCredito.Text) < 25 Then
            '    'ok
            'Else

            '    MsgBox("el rango permitido es de 1 a 24 cuotas, Tarjeta de Crédito ", MsgBoxStyle.Information, "VALIDACIÓN")
            '    Return False
            'End If





        End If


        If txtResumenCheque.Text <> "" Then

            'If Me.txtRut.Text.Trim = "10-8" Then
            '    MsgBox("Rut es Obligatorio para la venta con Cheque", MsgBoxStyle.Information)
            '    Return False
            'End If


            If cheque_grid_cheque.Rows.Count = 0 Then
                MsgBox("Ingrese los cheques en el Detalle, Cheque ", MsgBoxStyle.Information, "VALIDACIÓN")
                Return False
            Else

                Dim totalfilas As Integer = cheque_grid_cheque.Rows.Count
                Dim recuento_nro_Cheque As Integer = 0
                Dim recuento_codigo_autorizacion As Integer = 0
                Dim recuento_cta_cte As Integer = 0
                Dim recuento_banco As Integer = 0
                Dim recuento_rut_titular As Integer = 0
                Dim SumatoriaMontos As Integer = 0


                For Each gr As DataGridViewRow In cheque_grid_cheque.Rows

                    If gr.Cells("Nro_Cheque").Value <> "" Then
                        recuento_nro_Cheque = recuento_nro_Cheque + 1
                    End If

                    If gr.Cells("Cuenta").Value <> "" Then
                        recuento_cta_cte = recuento_cta_cte + 1
                    End If


                    If gr.Cells("Banco").Value <> "" Then
                        recuento_banco = recuento_banco + 1
                    End If

                    If gr.Cells("Rut_Titular").Value <> "" Then
                        recuento_rut_titular = recuento_rut_titular + 1
                    End If

                    If gr.Cells("Cod_Autorizacion").Value <> "" Then
                        recuento_codigo_autorizacion = recuento_codigo_autorizacion + 1
                    End If

                    If gr.Cells("Monto").Value.ToString <> "" Then
                        SumatoriaMontos = SumatoriaMontos + Double.Parse(gr.Cells("Monto").Value)
                    End If

                Next

                'valida repeciones de Nro Cheque.

                Dim nroDeChequesDuplicados As Boolean = False

                For Each gr As DataGridViewRow In cheque_grid_cheque.Rows

                    Dim contadorRepeticiones As Integer = 0
                    For Each gr2 As DataGridViewRow In cheque_grid_cheque.Rows

                        If gr.Cells("Nro_Cheque").Value = gr2.Cells("Nro_Cheque").Value Then
                            contadorRepeticiones = contadorRepeticiones + 1
                        End If

                    Next

                    If contadorRepeticiones > 1 Then

                        nroDeChequesDuplicados = True
                    End If


                Next



                If nroDeChequesDuplicados = True Then
                    MsgBox("existen Nros de Cheques Duplicados", MsgBoxStyle.Information, "VALIDACIÓN")
                    Return False

                End If


                If SumatoriaMontos <> txtResumenCheque.Text Then
                    MsgBox("los montos de los cheques no Concuerdan ", MsgBoxStyle.Information, "VALIDACIÓN")
                    Return False
                End If


                If recuento_nro_Cheque <> totalfilas Then
                    MsgBox("Ingrese el Numero de serie  a todos los Cheques, Cheque ", MsgBoxStyle.Information, "VALIDACIÓN")
                    Return False
                End If

                If recuento_cta_cte <> totalfilas Then
                    MsgBox("Ingrese  numero de Cuenta Corriente a todos los items del detalle, Cheque ", MsgBoxStyle.Information, "VALIDACIÓN")
                    Return False
                End If

                If recuento_banco <> totalfilas Then
                    MsgBox("cada cheque debe estar asociado a un Banco, Cheque ", MsgBoxStyle.Information, "VALIDACIÓN")
                    Return False
                End If


                If recuento_rut_titular <> totalfilas Then
                    MsgBox("cada cheque debe estar asociado a el Rut  del titular,  Cheque ", MsgBoxStyle.Information, "VALIDACIÓN")
                    Return False
                End If

                If recuento_codigo_autorizacion <> totalfilas And aprobacionchequesautorizacion = False Then

                    If _MENSAJE_CONFIRMACION("Falta(n) Codigos de Autorizacion, Desea aprobarlo por un supervisor ", "Aprobación de Cheques") = True Then
                        Xautorizacion.Tipo.Text = "AutorizacionCheque"
                        Xautorizacion.ShowDialog()
                    End If


                    Return False
                End If

            End If




        End If



        If txtResumenTransferencia.Text <> "" Then
            Me.ErrorProvider1.Clear()
            If txtTransferenciaRut.Text = "" Then

                Me.ErrorProvider1.SetError(Me.txtTransferenciaRut, "Obligatorio")
                MsgBox("Campo Requerido", MsgBoxStyle.Exclamation)
                Return False
            End If

            If txtTransferenciaNombre.Text = "" Then
                MsgBox("Campo Requerido", MsgBoxStyle.Exclamation)
                Me.ErrorProvider1.SetError(Me.txtTransferenciaNombre, "Obligatorio")
                Return False
            End If

            If txtTransferenciaNro.Text = "" Then
                Me.ErrorProvider1.SetError(Me.txtTransferenciaNro, "Obligatorio")
                MsgBox("Campo Requerido", MsgBoxStyle.Exclamation)
                Return False
            End If

            If Me.txt_transferencia_codigobanco.Text = "" Then
                Me.ErrorProvider1.SetError(Me.txt_Transferencia_Banco, "Obligatorio")
                MsgBox("Campo Requerido", MsgBoxStyle.Exclamation)
                Return False
            End If


            Dim objval As New STWVal

            If objval.ValidaRut(txtTransferenciaRut.Text) = False Then
                Me.ErrorProvider1.SetError(Me.txtTransferenciaRut, "Invalido")
                MsgBox("Rut Invalido", MsgBoxStyle.Exclamation)
                Return False
            End If



        End If

        If txtResumenCreditoSteward.Text <> "" Then

            If txtCreditoRut.Text = "" Then
                MsgBox("ingrese rut ", MsgBoxStyle.Exclamation)
                Return False
            End If

            If objVal.ValidaRut(txtCreditoRut.Text) = False Then
                Me.ErrorProvider1.SetError(Me.txtCreditoRut, "Invalido")
                MsgBox("Rut Invalido", MsgBoxStyle.Exclamation)
                Return False
            End If




        End If

        If txtResumenNotaCredito.Text <> "" Then

            If Me.grillaNotasCredito.Rows.Count = 0 Then

                Me.ErrorProvider1.SetError(Me.txtNota_nro_nota_Credito, "Obligatorio")
                MsgBox("Ingrese numero(s) de nota de credito", MsgBoxStyle.Exclamation)
                Return False
            End If

            If _NotasDeCredito.Count <> 0 Then

                For Each x As ListaObj In _NotasDeCredito

                    Dim objValidanota As New NotaCreditoController
                    If objValidanota.ValidaExistencia(x.Codigo) = False Then

                        Me.ErrorProvider1.SetError(Me.txtNota_nro_nota_Credito, "Obligatorio")
                        MsgBox("Este Numero de Nota:" + x.Codigo + " de credito No puede ser aplicado", MsgBoxStyle.Exclamation)
                        Return False

                    Else
                        'hacemos la otra validacion

                        Dim dsVAL As DataSet = WS_POS.POS_Documentos_Wop("N", Int32.Parse(x.Codigo), 0, "", "", "", 0)

                        If dsVAL.Tables(0).Rows.Count > 0 Then
                            Dim drCabecera As DataRow = dsVAL.Tables(0).Rows(0)
                            'MsgBox(drCabecera(0).ToString + " " + drCabecera(1).ToString)
                            Dim form As New MsgNotaCredito
                            form.ds = dsVAL
                            form.lblMsg.Text = "La Nota de Credito:" + x.Codigo.ToString + " Ya ha sido Aplicada"
                            form.ShowDialog()
                            Return False

                        End If



                    End If

                Next
            End If



        End If




        Return todook


    End Function


    Public Function DesactivarMediosPagosVacios()

        If txtResumenEfectivo.Text = "" And txtResumenEfectivo.ReadOnly = False Then
            txtResumenEfectivo.ReadOnly = True
            RemoverPaneles()
        End If


        If txtResumenDebito.Text = "" And txtResumenDebito.ReadOnly = False Then
            txtResumenDebito.ReadOnly = True
            debito_Banco.Text = ""
            debito_txtNroOperacion.Text = ""
            Debito_txt_Codigo_Autorizacion.Text = ""
            RemoverPaneles()
        End If

        If txtResumenCheque.Text = "" And txtResumenCheque.ReadOnly = False Then
            txtResumenCheque.ReadOnly = True
            Cheque_txt_Cantidad.Text = ""
            cheque_txt_rut.Text = ""
            cheque_txt_nroCuenta.Text = ""
            chequetxtCondicionPago.Text = ""
            cheque_Banco.Text = ""
            cheque_txt_condicionPago_Codigo.Text = ""
            cheque_Banco_Codigo.Text = ""
            cheque_grid_cheque.Rows.Clear()

            RemoverPaneles()
        End If

        If txtResumenCredito.Text = "" And txtResumenCredito.ReadOnly = False Then
            txtResumenCredito.ReadOnly = True
            credito_txt_banco.Text = ""
            credito_txt_tipotarjeta.Text = ""
            credito_txt_nro_operacion.Text = ""
            credito_txt_CodAutorizacion.Text = ""
            txtCuotasCredito.Text = ""
            txtCreditoTerminoPago.Text = ""

            RemoverPaneles()
        End If

        If txtResumenCreditoSteward.Text = "" And txtResumenCreditoSteward.ReadOnly = False Then
            txtResumenCreditoSteward.ReadOnly = True

            txtCreditoRut.Text = ""
            txtCredito_OrdendeCompra.Text = ""
            CreditoSteward_txt_Observacion.Text = ""
            RemoverPaneles()
        End If


    End Function

    Private Sub txtResumenCreditoSteward_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenCreditoSteward.GotFocus

    End Sub


    Private Sub txtResumenCreditoSteward_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenCreditoSteward.KeyDown


        If e.KeyValue = Keys.Enter Then

            AccionTextCreditoSteward()

        End If

    End Sub

    Public Sub AccionTextCreditoSteward()
        If txtResumenCreditoSteward.Text = "" Then
            DesactivarMediosPagosVacios()
            RemoverPaneles()
            ValidaTotaldePagos()
        Else
            Dim objlisa As New ws_lisa.WS_Lisa
            Dim monto As Double = Double.Parse(txtResumenCreditoSteward.Text)

            Try
                Dim ds As DataSet = objlisa.ConsultaCreditoSteward("STE", _GetRut, monto)
                Dim drRespuesta As DataRow = ds.Tables(0).Rows(0)
                Dim indicador As String = drRespuesta(0).ToString
                Dim monto_disponible As String = drRespuesta(1).ToString



                Select Case indicador

                    Case Is = "-1"
                        MsgBox("El Cliente no tiene Credito Steward", MsgBoxStyle.Exclamation, "STEWARD")

                    Case Is = "0"
                        MsgBox("El cliente no tiene cupo. el cupo disponible es de :" + monto_disponible, MsgBoxStyle.Exclamation, "STEWARD")

                    Case Is = 1

                        ValidaTotaldePagos()



                End Select
            Catch ex As Exception
                MsgBox("Error: " + ex.ToString, MsgBoxStyle.Exclamation, "Error")
            End Try



        End If



    End Sub


    Private Sub txtResumenCreditoSteward_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtResumenCreditoSteward.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosComodin(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtResumenCreditoSteward_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenCreditoSteward.KeyUp


    End Sub


    Private Sub txtResumenCreditoSteward_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenCreditoSteward.TextChanged
        ValidaTotaldePagos()
    End Sub

    Private Sub ActualizaDetalleListaPrecio()

        Dim espromo As String = "N"
        If Me.chkOferta.Checked = True Then
            espromo = "S"
        End If

        Dim linea = 0
        For Each gr As DataGridViewRow In gridDetalle.Rows
            Dim codigo As String = gr.Cells("Codigo").Value
            Dim nombre As String = gr.Cells("Descripcion").Value
            Dim valor As String = gr.Cells("Precio").Value
            Dim objArticuloController As New ArticuloController
            Dim rut As String = objTrans.LimpiaRut(txtRut.Text)

            Dim objArticulo As ArticuloObj = objArticuloController.GetArticuloCodigo(Int32.Parse(rut), codigo, Me.txtListaPrecio.Text, espromo)

            If (objArticulo.precio <> 0) Then
                gr.Cells("PrecioIva").Value = objArticulo.PrecioIva.ToString("N0")
                gr.Cells("Precio").Value = objArticulo.precio
                Dim calculo As Integer = objArticulo.PrecioIva * Int32.Parse(gr.Cells("Cant").Value)
                gr.Cells("valor").Value = calculo.ToString("N0")

                gr.Cells("CBruto").Value = objArticulo.CBruto
                gr.Cells("CNeto").Value = objArticulo.CNeto
                gr.Cells("CIva").Value = objArticulo.CIva
               
            Else
                Select Case MsgBox(codigo & " | " & nombre & " por " & valor & vbCr & "No tiene lista de precio " & Me.txtListaPrecio.Text & vbCr & "Conservar producto y precio (Si)" & vbCr & "Eliminar Producto (No)", vbInformation Or vbYesNo, "Información")
                    Case vbYes
                        ' Ja
                    Case vbNo
                        ' Nein
                        EliminaArticulo(Me.gridDetalle.Rows(linea).Cells("CODIGO").Value)
                End Select
            End If

            linea = linea + 1
        Next

        CalculaSubTotal()
        CalculaItemsTotalesLineasdeDetalle()
    End Sub

    Private Sub cheque_txt_nroCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cheque_txt_nroCuenta.KeyDown

        If e.KeyValue = Keys.Enter Then
            If cheque_grid_cheque.Rows.Count <> 0 Then


                For Each gr As DataGridViewRow In cheque_grid_cheque.Rows
                    gr.Cells("cuenta").Value = cheque_txt_nroCuenta.Text
                Next



            End If
        End If


    End Sub

    Private Sub cheque_txt_nroCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cheque_txt_nroCuenta.TextChanged

    End Sub

    Private Sub cheque_txt_rut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cheque_txt_rut.KeyDown




        If e.KeyValue = Keys.Enter Then
            If cheque_txt_rut.Text.Length = 7 Or cheque_txt_rut.Text.Length = 8 Then

                Dim dv As String = _digitoverificador(Int32.Parse(cheque_txt_rut.Text))
                Me.cheque_txt_rut.Text = cheque_txt_rut.Text + "-" + dv
            End If


            If objVal.ValidaRut(cheque_txt_rut.Text) = False Then
                MsgBox("rut Invalido", MsgBoxStyle.Information, "Validación")
                cheque_txt_rut.Focus()
            Else
                For Each gr As DataGridViewRow In cheque_grid_cheque.Rows


                    gr.Cells("rut_titular").Value = cheque_txt_rut.Text

                Next

                cheque_txt_nroCuenta.Enabled = True
                cheque_txt_nroCuenta.Focus()
            End If

        End If
    End Sub

    Private Sub cheque_txt_rut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cheque_txt_rut.TextChanged

    End Sub



    Private Sub txtPrecioIva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioIva.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter






































































































































































    End Sub

    Private Sub debito_drop_banco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub debito_txtNroOperacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles debito_txtNroOperacion.KeyDown

        If e.KeyValue = Keys.Enter Then
            Debito_txt_Codigo_Autorizacion.Focus()
        End If

    End Sub

    Private Sub debito_txtNroOperacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles debito_txtNroOperacion.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSincero(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub debito_txtNroOperacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles debito_txtNroOperacion.TextChanged

    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (_MENSAJE_CONFIRMACION("Desea Continuar una venta pendiente?", "Confirmación") = True) Then
            Pegar()
        End If
    End Sub


    Public Sub pasaAmediosdePago()
        If Me.gridDetalle.Rows.Count <> 0 Then


            CalculaSubTotal()


            If TabControl.TabPages(0).Name = "TabArticulos" Then
                Me.TabControl.TabPages.Remove(TabArticulos)
                Me.TabControl.TabPages.Add(txt_Debito_Banco)

            End If


            If totalMedioPagos() = 0 Then
                Me.RemoverPaneles()
                Me.TXTMEDIOPAGO.Text = "1"
                Me.btnCompraEfectivo.Focus()
            Else
                ValidaTotaldePagos()
            End If


            If objCLiente.TieneCredito(objStw.LimpiaRut(txtRut.Text)) <> "1" And _tipoDocumentoVenta = _CodigoFactura Then
                '' monto de credito

                Me.btn_Credito_Steward.Enabled = True
            Else
                Me.btn_Credito_Steward.Enabled = True
                _CreditoPendienteAutorizar = True

            End If

            If _tipoDocumentoVenta = _CodigoFactura Then
                Me.btn_sin_Pago.Enabled = True
            End If

            If _tipoDocumentoVenta = _CodigoBoleta And txtRut.Text.Substring(0, 2) <> "10" Then
                Me.btn_sin_Pago.Enabled = True
            End If

            Me.btnDetalle.Enabled = True

        Else
            MsgBox("NO EXISTEN PRODUCTOS A PAGAR EN LA LISTA", MsgBoxStyle.Information, "STEWARD")
        End If

    End Sub

    Private Sub btnpgo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarCompra.Click

        pasaAmediosdePago()

    End Sub



    Private Sub btnPagodeDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Emision_Documentos.Click

        XFormularioPagosAplicar.ShowDialog()


    End Sub


    Public Sub DestacaProductoEnOferta()

        For Each dg As DataGridViewRow In gridDetalle.Rows

            'MsgBox(dg.Cells("Oferta").Value)

        Next

    End Sub

    Private Sub btnNuevaBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevaBoleta.Click
        esVentaRecuperada = False
        _cab_Id = 0
        Me.chkOferta.Checked = False

        AccionBotonBoleta(sender, e)

    End Sub

    Public Sub AccionBotonBoleta(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If gridDetalle.Rows.Count <> 0 Then

            If _MENSAJE_CONFIRMACION("Desea Realizar una Nueva Venta", "STEWARD") = True Then

                If _MENSAJE_CONFIRMACION("¿ Desea Conservar los Items de la Compra ?", "STEWARD") = False Then
                    ResetFormulario()
                End If

                'ResetFormulario()
                _tipoDocumentoVenta = "BOVT"
                Me.txtCorrelativo.Text = ""
                btnPagar.Enabled = True
                Try

                    txtCorrelativo.ForeColor = Color.Red
                    _tipoDocumentoVenta = _CodigoBoleta
                    txtRut.Enabled = True
                    txtRut.ReadOnly = False
                    btnBuscarCliente.Enabled = True
                    txtCorrelativo.Text = objDocumentoVenta.GetFolio(_Sede, _PuntoFacturacion, _tipoDocumentoVenta)


                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try


                Me.txtRut.Text = "10-8"
                Me.BuscarCliente()
            End If
        Else
            Try
                _tipoDocumentoVenta = "BOVT"
                txtCorrelativo.ForeColor = Color.Red
                _tipoDocumentoVenta = _CodigoBoleta
                txtRut.Enabled = True
                txtRut.ReadOnly = False
                Me.btnBuscarCliente.Enabled = True

                txtCorrelativo.Text = objDocumentoVenta.GetFolio(_Sede, _PuntoFacturacion, TipoDocumentoVenta).ToString

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Me.txtRut.Text = "10-8"
            Me.BuscarCliente()

        End If

        Dim objdoc As New DocumentoController
        If objdoc.verificaexistenciafolio("BOVT", Me.txtCorrelativo.Text) = True Then
            Dim objdocven As New DocumentosVentaController
            Me.btnNuevaBoleta_Click(sender, e)
        End If
        Me.txtDocumento.Text = "BOLETA"
        Me.btnNuevaBoleta.BackColor = Color.Aqua
        Me.btnNuevaVenta.BackColor = Color.Gainsboro
    End Sub


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub


    Protected Function APlicaColoresGrillaDetalle()

        For Each gr As DataGridViewRow In Me.gridDetalle.Rows

            gr.Cells("Cant").Style.BackColor = Color.AliceBlue
            gr.Cells("Valor").Style.BackColor = Color.YellowGreen
        Next


    End Function


    Private Sub txtCreditoStewardCodigoAutorizacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub AccionBotonDeposito()
        If validaDetallePagos() = True Then
            If PagoRestante() <> 0 Then

                If Me.TabMedioPago.TabPages.Count > 0 Then

                    If Me.TabMedioPago.TabPages(0).Name <> "TabTransferencia" Then
                        Me.TabMedioPago.TabPages.Clear()
                        If AprobacionDeposito = True Then
                            Me.TabMedioPago.TabPages.Add(TabTransferencia)
                        End If

                    End If
                Else
                    If AprobacionDeposito = True Then
                        Me.TabMedioPago.TabPages.Add(TabTransferencia)
                        txtTransferenciaRut.Focus()
                    End If

                End If


                txtResumenTransferencia.Text = PagoRestante().ToString("N0")
                txtResumenTransferencia.ReadOnly = False
                txtResumenTransferencia.Focus()
                ' CargarComboTransferenciaBancaria()
                ValidaTotaldePagos()


                If AprobacionDeposito = False Then
                    Xautorizacion.Tipo.Text = "Deposito"
                    Xautorizacion.ShowDialog()
                End If


            Else
                MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")
            End If

        End If

    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        VuelveModalidadN()
        AccionBotonDeposito()
    End Sub



    Private Sub txtTransferenciaRut_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransferenciaRut.KeyDown


        If e.KeyValue = Keys.Enter Then
            If txtTransferenciaRut.Text.Length = 7 Or txtTransferenciaRut.Text.Length = 8 Then
                Dim dv As String = _digitoverificador(Int32.Parse(txtTransferenciaRut.Text))
                txtTransferenciaRut.Text = txtTransferenciaRut.Text + "-" + dv

            End If

            If objVal.ValidaRut(txtTransferenciaRut.Text) = False Then
                MsgBox("rut Invalido", MsgBoxStyle.Information, "Validación")

            Else

                txtTransferenciaNombre.Enabled = True
                Me.txtTransferenciaNombre.Focus()

            End If
        End If


    End Sub

    Private Sub txtTransferenciaRut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferenciaRut.TextChanged

    End Sub

    Private Sub txtTransferenciaNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransferenciaNombre.KeyDown
        If e.KeyValue = 13 Then
            Me.txtTransferenciaNro.Enabled = True
            Me.txtTransferenciaNro.Focus()

        End If

    End Sub

    Private Sub txtTransferenciaNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferenciaNombre.TextChanged

    End Sub

    Private Sub txtTransferenciaNro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransferenciaNro.KeyDown

        If e.KeyValue = 13 Then
            ' Me.Transferencia_drop_Banco.Enabled = True
            'Me.Transferencia_drop_Banco.Focus()
        End If
    End Sub

    Private Sub txtTransferenciaNro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransferenciaNro.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtResumenTransferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenTransferencia.KeyDown



        If e.KeyValue = 13 Then

            AccionTransferencia()


        End If
    End Sub


    Public Sub AccionTransferencia()
        If Me.txtResumenTransferencia.Text = "" Then
            DesactivarMediosPagosVacios()
            Me.TabMedioPago.TabPages.Clear()
            Me.txtResumenTransferencia.ReadOnly = True
            ValidaTotaldePagos()
        Else
            Me.txtResumenTransferencia.Text = Int32.Parse(Me.txtResumenTransferencia.Text.ToString.Replace(".", "")).ToString("N0")
            ValidaTotaldePagos()
        End If
    End Sub

    Private Sub txtResumenTransferencia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenTransferencia.KeyUp

    End Sub

    Private Sub txtResumenTransferencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenTransferencia.LostFocus

        If txtResumenTransferencia.Text = "" Then
            Me.txtResumenTransferencia.ReadOnly = True
            Me.TabMedioPago.TabPages.Clear()
        End If

    End Sub

    Private Sub txtResumenTransferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenTransferencia.TextChanged
        ValidaTotaldePagos()
    End Sub







    Private Sub TransferenciaFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciaFecha.ValueChanged
        Me.txtTransferenciaObservaciones.Enabled = True

        Me.txtTransferenciaObservaciones.Focus()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleDescuento.Click
        Dim form As New DetalleDescuento
        form.txtDetalle.Text = obtenerSumaTotalDescuentosDetalle().ToString("N0")
        form.txtDocumento.Text = ObtenerDescuentoCabeseraDocumento().ToString("N0")
        form.ShowDialog()

    End Sub




    Public Sub CargaPendientes(ByVal codigo As String) Handles XDocumentosPendientes.CargaDocumento

        Try


            _cab_Id = Int32.Parse(codigo)
            Dim wswop As New ws_pos.Pos
            Dim ds As DataSet = wswop.POS_Documentos_Wop("C", Int32.Parse(codigo), 0, "", "", "", 0)
            _esVentaRecuperada = True
            Dim drCabecera As DataRow = ds.Tables(0).Rows(0)


            If drCabecera("tdc_id").ToString = "2" Then
                _tipoDocumentoVenta = _CodigoFactura
                txtCorrelativo.Text = objDocumentoVenta.GetFolio(_Sede, _PuntoFacturacion, _tipoDocumentoVenta)
                Me.txtDocumento.Text = "FACTURA"
            End If

            If drCabecera("tdc_id").ToString = "3" Then
                _tipoDocumentoVenta = _CodigoBoleta
                txtCorrelativo.Text = objDocumentoVenta.GetFolio(_Sede, _PuntoFacturacion, _tipoDocumentoVenta)
                Me.txtDocumento.Text = "BOLETA"
            End If


            'llenado de cabsera


            'Me.txtCorrelativo.Text = drCabecera("Folio").ToString

            'rut
            Dim rut As String = drCabecera("CodCliente").ToString
            If rut = "10" Then
                rut = "10-8"
            End If


            If rut.Length = 7 Or rut.Length = 8 Then
                Dim dv As String = _digitoverificador(Int32.Parse(rut))
                rut = rut + "-" + dv
            End If


            Me.txtRut.Text = rut
            BuscarCliente()
            Me.txtListaPrecio.Text = drCabecera("ListaPrecio").ToString




            'carga detalle
            Dim dsDetalle As DataSet = wswop.POS_Documentos_Wop("D", Int32.Parse(codigo), 0, "", "", "", 0)

            If dsDetalle.Tables(0).Rows.Count Then

                For Each drDetalle As DataRow In dsDetalle.Tables(0).Rows
                    Dim objArt As New ArticuloStringObj

                    objArt.sku = drDetalle("Sku").ToString
                    objArt.nombre = drDetalle("Descripcion").ToString
                    objArt.unidadmedida = drDetalle("UM").ToString
                    objArt.cantidad = drDetalle("Cantidad").ToString
                    objArt.precio = drDetalle("Precio").ToString
                    objArt.PrecioIva = drDetalle("Precio").ToString
                    objArt.valortotal = objArt.precio * objArt.cantidad
                    objArt.Envase = "C"
                    ArregloItems.Add(objArt)


                Next
                llenarGrilla(gridDetalle, ArregloItems)
                Me.btn_Descuento_Cabesera.Enabled = True
                DestacaProductoEnOferta()
                APlicaColoresGrillaDetalle()
                CalculaSubTotal()

            End If


            ' carga Medio de Pagos.

            Dim dsPagos As DataSet = wswop.POS_Documentos_Wop("P", Int32.Parse(codigo), 0, "", "", "", 0)

            Dim totalpagos As Integer = 0
            For Each drPagos As DataRow In dsPagos.Tables(0).Rows
                totalpagos = totalpagos + 1


                If drPagos("tmp_id") = "2" Then

                    AccionBotonEfectivo()
                    Me.txtResumenEfectivo.Text = drPagos("ValorCuota").ToString

                End If

                'credito
                If drPagos("tmp_id") = "3" Then

                    Dim totalcuotas As Integer = 0
                    Dim valortotal As Double = 0
                    For Each drpagoscredito As DataRow In dsPagos.Tables(0).Rows
                        If drpagoscredito("tmp_id") = "3" Then
                            totalcuotas = totalcuotas + 1
                            valortotal = valortotal + Double.Parse(drpagoscredito("ValorCuota").ToString)
                        End If
                    Next

                    AccionBotonCredito()
                    Me.txtResumenCredito.Text = valortotal.ToString("N0")
                    Me.credito_txt_banco.Text = drPagos("Banco").ToString
                    Me.creditotxtCodigoBanco.Text = drPagos("CodBanco").ToString
                    Me.credito_txt_tipotarjeta.Text = drPagos("TIPOTC").ToString
                    Me.credito_txt_codigo_tipoTarjeta.Text = drPagos("TTC_ID").ToString
                    Me.txtCuotasCredito.Text = totalcuotas
                    Me.credito_txt_CodAutorizacion.Text = drPagos("NroAutorizacion").ToString
                    Me.credito_txt_nro_operacion.Text = drPagos("NroOperacion").ToString
                    'Me.debito_txtNroOperacion.Text = drPagos("NroOperacion").ToString

                End If


                'debito
                If drPagos("tmp_id") = "4" Then

                    accionBotonCompraDebito()
                    Me.txtResumenDebito.Text = drPagos("ValorCuota").ToString
                    Me.debito_Banco.Text = drPagos("Banco").ToString
                    Me.debito_codigo_banco.Text = drPagos("CodBanco").ToString
                    Me.Debito_txt_Codigo_Autorizacion.Text = drPagos("NroAutorizacion").ToString
                    Me.debito_txtNroOperacion.Text = drPagos("NroOperacion").ToString


                End If



                If drPagos("tmp_id") = "5" Then

                    AccionBotonCreditoSteward()
                    Me.txtResumenCreditoSteward.Enabled = True
                    Me.txtResumenCreditoSteward.Text = Int32.Parse(drPagos("ValorCuota")).ToString("N0")
                    AccionTextCreditoSteward()
                    Me.txtCreditoRut.Enabled = True
                    Me.txtCreditoRut.Text = drPagos("RutTitular").ToString
                    txtCredito_OrdendeCompra.Enabled = True
                    txtCredito_OrdendeCompra.Text = drPagos("NroOperacion").ToString


                End If



                If drPagos("MedioPago") = "Cheque" Then

                    Dim totalcheques As Integer = 0

                    For Each drpagos2 As DataRow In dsPagos.Tables(0).Rows
                        totalcheques = totalcheques + 1
                    Next

                    txtResumenCheque.Text = drPagos("ValorCuota").ToString
                    Cheque_txt_Cantidad.Text = totalcheques
                    IngresaCantidadCheques()

                End If




                ' transferencia.

                If drPagos("tmp_id") = "8" Then

                    VuelveModalidadN()

                    AccionBotonDeposito()
                    Me.txtResumenTransferencia.Enabled = True
                    txtResumenTransferencia.Text = drPagos("ValorCuota").ToString

                    AccionTransferencia()
                    Me.txtTransferenciaRut.Enabled = True
                    Me.txtTransferenciaRut.Text = drPagos("RutTitular").ToString
                    Me.txtTransferenciaNro.Enabled = True
                    Me.txtTransferenciaNro.Text = drPagos("NroOperacion").ToString
                    Me.txt_Transferencia_Banco.Enabled = True
                    Me.txt_Transferencia_Banco.Text = drPagos("Banco").ToString
                    Me.txt_transferencia_codigobanco.Text = drPagos("CodBanco").ToString
                    Me.txtTransferenciaNombre.Enabled = True
                    Me.txtTransferenciaNombre.Text = drPagos("NombreTitular").ToString
                    Me.TransferenciaFecha.Enabled = True


                End If





            Next






            If totalpagos > 0 Then
                Me.btnPagar.Enabled = True
            End If



        Catch ex As Exception
            MsgBox("Se ha Probocado una excepción" + ex.ToString, MsgBoxStyle.Exclamation)
        End Try






    End Sub







    Public Sub Autorizaciones(ByVal codigo As String) Handles Xautorizacion.Autorizacion

        Dim chrArray() As Char = {","c}
        If (CInt(codigo.Split(chrArray).Length) = 3) Then
            Dim chrArray1() As Char = {","c}
            If (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(codigo.Split(chrArray1).GetValue(0), "Stock", False)) Then
                Dim xFormCantidad As FormCantidadItems = Me.XFormCantidad
                chrArray1 = New Char() {","c}
                xFormCantidad.cantidad = Convert.ToInt32(codigo.Split(chrArray1).GetValue(2))
                chrArray1 = New Char() {","c}
                Dim [integer] As Integer = Convert.ToInt32(codigo.Split(chrArray1).GetValue(1))
                chrArray = New Char() {","c}
                Me.actualizacantidad_([integer], Convert.ToInt32(codigo.Split(chrArray).GetValue(2)))
            End If

        End If
        If codigo = "Close" Then
            Me.txtResumenCreditoSteward.Text = ""
            Me.txtResumenCreditoSteward.Enabled = False
            ValidaTotaldePagos()
        End If

        If codigo = "CloseDeposito" Then
            txtResumenTransferencia.Enabled = False
            txtResumenTransferencia.Text = ""
            ValidaTotaldePagos()
        End If

        If codigo = "CloseLista" Then
            Me.txtListaPrecio.Text = _listaPrecio
        End If

        If codigo = "Credito" Then
            AprobacionExcesoCreditoSteward = True
        End If

        If codigo = "Deposito" Then
            AprobacionDeposito = True
            Me.txtResumenTransferencia.Enabled = True
            Me.TabMedioPago.TabPages.Add(TabTransferencia)
            Me.txtTransferenciaRut.Focus()
            Me.txtTransferenciaRut.Enabled = True
        End If

        If codigo = "ListaPrecio" Then
            Dim obj As New ListaPrecioController
            If obj.Valida(txtListaPrecio.Text) = True Then
                If esVentaRecuperada = False Then
                    ActualizaDetalleListaPrecio()
                End If

            Else
                MsgBox("Lista de Precio Invalida", MsgBoxStyle.Information, "Información")
                Me.txtListaPrecio.Text = _listaPrecio
            End If

        End If

        If codigo = "AutorizacionCheque" = True Then
            aprobacionchequesautorizacion = True
        End If

        If codigo = "SinCredito" Then


            AccionBotonCreditoSteward()

        End If


        If codigo = "" Then

        End If

    End Sub

    Private Sub txtPorcentajeDescuento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorcentajeDescuento.KeyDown

    End Sub

    Private Sub txtPorcentajeDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcentajeDescuento.TextChanged

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub txtDirección_Flete_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDirección_Flete.KeyDown

        If e.KeyValue = Keys.Enter Then

            If txtDirección_Flete.Text <> "" Then
                txtResumenDespacho.Text = Double.Parse(txtDirección_Flete.Text)
                CalculaIvaYTotalfinal(Int32.Parse(txtBruto.Text.Replace(".", "")))
            End If


        End If


    End Sub

    Private Sub txtDirección_Flete_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDirección_Flete.KeyPress

    End Sub

    Private Sub txtDirección_Flete_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDirección_Flete.TextChanged

    End Sub

    Private Sub btn_Flete_Ingresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Flete_Ingresar.Click


        If txtDirección_Flete.Text <> "" Then

            txtResumenDespacho.Text = Double.Parse(Me.txtDirección_Flete.Text).ToString("N0")
            CalculaIvaYTotalfinal(Int32.Parse(txtBruto.Text.Replace(".", "")))
        End If



    End Sub

    Private Sub btnDireccionesFacturacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDireccionesFacturacion.Click

        If txtRut.Text <> "" Then
            XDirecciones.rut = txtRut.Text.Remove(txtRut.Text.Length - 2, 2)
            XDirecciones.tipo = "1"
            XDirecciones.ShowDialog()
        End If

    End Sub

    Private Sub txtResumenDespacho_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResumenDespacho.KeyUp
        If e.KeyCode = "8" Then

            If txtResumenDespacho.Text.Length = 0 Then
                Me.txtResumenDespacho.ReadOnly = True
                ValidaTotaldePagos()
            End If

        End If

    End Sub

    Private Sub txtResumenDespacho_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenDespacho.TextChanged

    End Sub

    Private Sub btnEstudiante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstudiante.Click

        If busquedaAlumno = False Then
            busquedaAlumno = True
            Me.btnEstudiante.BackColor = Color.Cornsilk
        End If

    End Sub

    Private Sub credito_drop_termino_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)




    End Sub

    Private Sub credito_drop_termino_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Credito_Combo_Banco_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabDebito.Click

    End Sub

    Private Sub txtCuotasCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuotasCredito.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSincero(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtCuotasCredito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuotasCredito.LostFocus





    End Sub

    Private Sub txtCuotasCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuotasCredito.TextChanged

    End Sub

    Private Sub credito_txt_banco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles credito_txt_banco.KeyDown

        If e.KeyValue = Keys.Enter Then



        End If
    End Sub

    Private Sub credito_txt_banco_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles credito_txt_banco.TextChanged

    End Sub

    Private Sub credito_txt_codigo_tipotarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles credito_txt_tipotarjeta.KeyDown


        If e.KeyValue = Keys.Enter Then
            Dim tarjetacreditocontroller As New TarjetasCreditoController
            XListaDisplay.arreglo = tarjetacreditocontroller.GetTarjetas
            XListaDisplay.tipo = "CreditoTipoTarjeta"
            XListaDisplay.ShowDialog()
        End If

    End Sub

    Private Sub credito_txt_codigo_tipotarjeta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles credito_txt_tipotarjeta.TextChanged

    End Sub


    Private Sub btn_popup_Banco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_popup_Banco.Click
        Dim banco As New BancosController
        XListaDisplay.arreglo = banco.Ayuda
        XListaDisplay.tipo = "CreditoBanco"
        XListaDisplay.ShowDialog()
    End Sub

    Private Sub btn_Popup_TipoTarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Popup_TipoTarjeta.Click

        Dim tarjetacreditocontroller As New TarjetasCreditoController
        XListaDisplay.arreglo = tarjetacreditocontroller.GetTarjetas
        XListaDisplay.tipo = "CreditoTipoTarjeta"
        XListaDisplay.ShowDialog()

    End Sub

    Private Sub debito_btn_popup_banco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles debito_btn_popup_banco.Click

        Dim objcontrol As New BancosController

        XListaDisplay.tipo = "DebitoBanco"
        XListaDisplay.arreglo = objcontrol.Ayuda
        XListaDisplay.ShowDialog()



    End Sub

    Private Sub btn_CondicionPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CondicionPago.Click

        Dim objtermino As New TerminoPagoController
        XListaDisplay.tipo = "ChequeTermino"
        XListaDisplay.arreglo = objTerminoPagoController.GetTerminoCheque()
        XListaDisplay.ShowDialog()

    End Sub

    Private Sub cheque_btn_Banco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cheque_btn_Banco.Click

        Dim objBanco As New BancosController
        XListaDisplay.tipo = "ChequeBanco"
        XListaDisplay.arreglo = objBanco.Ayuda
        XListaDisplay.ShowDialog()

    End Sub

    Private Sub btn_transferencia_Banco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_transferencia_Banco.Click

        Dim objBanco As New BancosController
        XListaDisplay.tipo = "TransferenciaBanco"
        XListaDisplay.arreglo = objBanco.Ayuda
        XListaDisplay.ShowDialog()


    End Sub


    Public Sub CalculaItemsTotalesLineasdeDetalle()

        Dim total As Integer = Me.gridDetalle.Rows.Count

        Dim cant_items As Integer = 0

        For Each gr As DataGridViewRow In gridDetalle.Rows
            cant_items = gr.Cells("Cant").Value + cant_items
        Next


        lblLineasDetalle.Text = total.ToString
        lblItemsDetalle.Text = cant_items.ToString

    End Sub

    Private Sub Pos_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub btn_Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim form As New AnulaDocumento
        form.correlativo = Me.txtCorrelativo.Text
        form.ShowDialog()

    End Sub



    Private Sub btn_sin_Pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sin_Pago.Click

        If validaDetallePagos() = False Then
            Exit Sub
        End If

        RemoverPaneles()
        Me.TabMedioPago.TabPages.Add(TabSinPago)

        If PagoRestante() <> 0 Then
            If txtResumenEfectivo.Text = "" Then

                txtResumenSinPago.ReadOnly = False
                txtResumenSinPago.Focus()
                txtResumenSinPago.Text = PagoRestante().ToString("N0")
                _Modalidad = "SP"

            End If

            ValidaTotaldePagos()
        Else
            MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")
        End If
    End Sub


    Public Sub CantidadItemsCalcula()

    End Sub

    Private Sub lblItemsDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblItemsDetalle.Click

    End Sub

    Private Sub txtResumenSinPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenSinPago.LostFocus

        If txtResumenSinPago.Text = "" Then
            Me.txtResumenSinPago.ReadOnly = True
            Me.TabMedioPago.TabPages.Clear()
        End If

    End Sub

    Private Sub txtResumenSinPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenSinPago.TextChanged
        ValidaTotaldePagos()
    End Sub

    Public Sub actualizacantidad_(ByVal fila As Integer, ByVal cantidad As Integer)
        Me.gridDetalle.Rows(fila).Cells("Cant").Value = cantidad
        Dim codigo As String = Me.gridDetalle.Rows(fila).Cells("Codigo").Value
        Dim precio As Integer = Integer.Parse(Me.traefila(codigo).Cells("precioIva").Value.ToString().Replace(".", ""))
        Me.traefila(codigo).Cells("valor").Value = (precio * cantidad).ToString("N0")
        Me.CalculaSubTotal()
        Me.txtCodigoProducto.Focus()
        Me.CalculaItemsTotalesLineasdeDetalle()
    End Sub


    Public Sub ModificaCantidad(ByVal fila As Integer, ByVal cantidad As Integer) Handles XFormCantidad.ActualizaCantidad

        Dim sku As String = ""
        sku = Me.gridDetalle.Rows(fila).Cells("Codigo").Value

        Dim negativos = Convert.ToInt32(_GetDatoFtp("POS" + txtNroCaja.Text + "_NEGATIVOS"))

        If (negativos = 1) Then 'NO EJECUTA COMPROBACION DE STOCK

            Me.actualizacantidad_(fila, cantidad)

        Else 'EJECUTA COMPROBACION DE STOCK

            Dim objws As ws_pos.Pos = New ws_pos.Pos()
            Dim ds As DataSet = objws.POS_ValidaStock(_Bodega, _PuntoFacturacion, id_Cajero, sku, cantidad, _tipoDocumentoVenta, Convert.ToInt32(Me.txtCorrelativo.Text))
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dr(0).ToString().Trim(), "-1", False) <> 0) Then
                Me.actualizacantidad_(fila, cantidad)
            Else
                Dim emails As ArrayList = New ArrayList()
                Dim strArrays As String() = dr(2).ToString().Split(New Char() {";"c})
                Dim num As Integer = 0
                Do
                    emails.Add(strArrays(num))
                    num = num + 1
                Loop While num < CInt(strArrays.Length)
                _EnviaMail(dr(1), emails)
                Me.Xautorizacion.Tipo.Text = String.Concat("Stock,", fila.ToString(), ",", cantidad.ToString())
                Me.Xautorizacion.ShowDialog()
            End If

        End If



    End Sub

    Private Sub Debito_txt_Codigo_Autorizacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Debito_txt_Codigo_Autorizacion.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSincero(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Debito_txt_Codigo_Autorizacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Debito_txt_Codigo_Autorizacion.TextChanged

    End Sub

    Private Sub btn_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Pendientes.Click
        xPendiente.ShowDialog()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        With New Process
            .StartInfo.Verb = "print"
            .StartInfo.CreateNoWindow = False
            .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            .StartInfo.FileName = "c:\pos\comprobantes\Comprobante.log"
            .Start()
            '.CloseMainWindow()
            .Close()
        End With

    End Sub

    Private Sub btnEmision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmision.Click
        RemoverPanelesCabecera()
        Me.TabControlCabecera.TabPages.Add(TabCabeceraPrincipal)
        Me.TabControl.TabPages.Clear()
        Me.TabControl.TabPages.Add(TabArticulos)
        ResetFormulario()
    End Sub

    Private Sub btnNotaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaCredito.Click

        If validaDetallePagos() = False Then
            Exit Sub
        End If

        RemoverPaneles()
        Me.TabMedioPago.TabPages.Add(TabNotaCredito)


        If PagoRestante() <> 0 Then

            If txtResumenNotaCredito.Text = "" Then

                txtResumenNotaCredito.ReadOnly = True
                txtResumenNotaCredito.Focus()
                ' txtResumenNotaCredito.Text = PagoRestante().ToString("N0")



            End If

            ValidaTotaldePagos()
        Else
            MsgBox("ya esta cancelado el total de la compra", MsgBoxStyle.Information, "STEWARD")
        End If

    End Sub

    Private Sub txtResumenNotaCredito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResumenNotaCredito.LostFocus

        If txtResumenNotaCredito.Text = "" Then
            'Me.txtResumenNotaCredito.ReadOnly = True
            'Me.TabMedioPago.TabPages.Clear()
        End If

    End Sub

    Private Sub txtResumenNotaCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResumenNotaCredito.TextChanged
        ValidaTotaldePagos()
    End Sub

    Private Sub txtNota_nro_nota_Credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNota_nro_nota_Credito.KeyDown
        If e.KeyCode = Keys.Enter Then
            ObtieneMontoNotaCredito()
        End If
    End Sub

    Private Sub txtNota_nro_nota_Credito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNota_nro_nota_Credito.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosComodin(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNota_nro_nota_Credito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNota_nro_nota_Credito.LostFocus
        ObtieneMontoNotaCredito()

    End Sub

    Private Sub txtNota_nro_nota_Credito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNota_nro_nota_Credito.TextChanged

    End Sub


    Public Sub CreaCabeseraNotaCredito()

        Me.grillaNotasCredito.Columns.Add("Nro", "Nro")
        Me.grillaNotasCredito.Columns("Nro").DataPropertyName = "Codigo"
        Me.grillaNotasCredito.Columns("Nro").Width = 60
        Me.grillaNotasCredito.Columns("Nro").ReadOnly = True

        Me.grillaNotasCredito.Columns.Add("Monto", "Monto")
        Me.grillaNotasCredito.Columns("Monto").DataPropertyName = "Descripcion"
        Me.grillaNotasCredito.Columns("Monto").Width = 60
        Me.grillaNotasCredito.Columns("Monto").ReadOnly = True

    End Sub


    Public Sub ObtieneMontoNotaCredito()

        Try
            ErrorProvider1.Clear()
            If Me.txtNota_nro_nota_Credito.Text <> "" Then
                Dim objValidanota As New NotaCreditoController
                If objValidanota.ValidaExistencia(Int32.Parse(Me.txtNota_nro_nota_Credito.Text)) = True Then

                    'Me.txtNotaMonto.Text = objValidanota.Monto(Me.txtNota_nro_nota_Credito.Text).ToString("N0")
                    Dim monto As String = objValidanota.Monto(Me.txtNota_nro_nota_Credito.Text).ToString("N0")
                    Dim nronota As String = Me.txtNota_nro_nota_Credito.Text

                    Dim obj As New ListaObj
                    obj.Codigo = nronota
                    obj.Descripcion = monto

                    If ExisteNota(nronota) = False Then

                        _NotasDeCredito.Add(obj)

                        If Me.grillaNotasCredito.Rows.Count = 0 Then
                            CreaCabeseraNotaCredito()
                        End If


                        Dim bs As BindingSource = New BindingSource()
                        bs.DataSource = _NotasDeCredito

                        Me.grillaNotasCredito.DataSource = bs
                        bs.ResetBindings(True)

                        Me.txtNota_nro_nota_Credito.Text = ""
                        Me.grillaNotasCredito.Columns("nro").DisplayIndex = 0
                        Me.grillaNotasCredito.Columns("Monto").DisplayIndex = 1
                        Me.grillaNotasCredito.Columns("Quitar").DisplayIndex = 2
                        ' Me.grillaNotasCredito.Columns(3).DisplayIndex = 3

                        Me.grillaNotasCredito.Columns(3).Visible = False
                        Me.txtResumenNotaCredito.Text = MontoNotasCredito().ToString("N0")

                        ValidaTotaldePagos()
                    Else
                        MsgBox("La nota ingresada ya existe en la lista", MsgBoxStyle.Exclamation)
                    End If


                Else
                    ErrorProvider1.SetError(Me.txtNota_nro_nota_Credito, " no existe ")
                End If


            End If
        Catch ex As Exception

            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        End Try


    End Sub



    Public Function MontoNotasCredito() As Double

        Dim suma As Double = 0

        For Each obj As ListaObj In _NotasDeCredito

            suma = Double.Parse(obj.Descripcion) + suma

        Next

        Return suma
    End Function



    Public Function ExisteNota(ByVal NroNota As String) As Boolean
        Dim retorno As Boolean = False


        If _NotasDeCredito.Count <> 0 Then


            For Each obj As ListaObj In _NotasDeCredito

                If NroNota = obj.Codigo Then
                    retorno = True
                End If


            Next



        End If


        Return retorno


    End Function




    Private Sub btnNotaActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaActualizar.Click
        ObtieneMontoNotaCredito()
    End Sub

    Private Sub btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Limpiar.Click
        Me.txtResumenNotaCredito.Text = ""
        ValidaTotaldePagos()
    End Sub

    Private Sub btn_RecuperaDocu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RecuperaDocu.Click
        XDocumentosPendientes.ShowDialog()
    End Sub

    Private Sub grillaNotasCredito_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaNotasCredito.CellClick

        MsgBox(e.ColumnIndex)

        If e.ColumnIndex = 0 Then

            If Me.grillaNotasCredito.Rows.Count > 0 Then

                Dim obj As New ListaObj

                _NotasDeCredito.RemoveAt(e.RowIndex)


                Dim bs As BindingSource = New BindingSource()
                bs.DataSource = _NotasDeCredito
                Me.grillaNotasCredito.DataSource = bs

                '  Me.grillaNotasCredito.Columns("nro").DisplayIndex = 0
                '  Me.grillaNotasCredito.Columns("Monto").DisplayIndex = 1
                ' Me.grillaNotasCredito.Columns("Quitar").DisplayIndex = 2
                ' Me.grillaNotasCredito.Columns(3).DisplayIndex = 3


                Me.txtResumenNotaCredito.Text = MontoNotasCredito().ToString("N0")

                If _NotasDeCredito.Count = 0 Then
                    Me.txtResumenNotaCredito.Text = ""
                End If

            Else

                ValidaTotaldePagos()
                Me.txtResumenNotaCredito.Text = ""

            End If
        End If

    End Sub

    Private Sub grillaNotasCredito_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grillaNotasCredito.CellContentClick

    End Sub


    Public Sub CargaDireccion(ByVal codigo As String, ByVal descripcion As String, idtipo As String) Handles XDirecciones.CargaDireccion
        If (idtipo = "1") Then
            Me.txtCodigoDirección.Text = codigo
            Me.txtNombreDireccion.Text = descripcion
        Else
            Me.txtCodigoDirecciónDespacho.Text = codigo
            Me.txtNombreDireccionDespacho.Text = descripcion
        End If

    End Sub

    Private Sub btnDireccionesDespacho_Click(sender As Object, e As EventArgs) Handles btnDireccionesDespacho.Click
        If txtRut.Text <> "" Then
            XDirecciones.rut = txtRut.Text.Remove(txtRut.Text.Length - 2, 2)
            XDirecciones.tipo = "2"
            XDirecciones.ShowDialog()
        End If
    End Sub

    Private Sub btn_CopiaXML_Click(sender As Object, e As EventArgs) Handles btn_CopiaXML.Click
        XCopiaXml.ShowDialog()
    End Sub

    Private Sub txtCorrelativo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorrelativo.KeyPress

    End Sub


    Public Sub GeneraOferta(ByVal codigo As Boolean, ByVal nombre As String, ByVal rut As String, ByVal promo As String) Handles xPromocionTercera.GeneraOferta
           If codigo = True
                PromoNombre = promo + ">" + nombre + "|" + rut
                Dim rutx As String = objTrans.LimpiaRut(txtRut.Text)
                For Each gr As DataGridViewRow In gridDetalle.Rows
                    Dim skux = gr.Cells("Codigo").Value
                    Dim cntx = Convert.ToDouble(gr.Cells("Cant").Value)
                    Dim articulo As ArticuloObj = objArticuloController.GetArticuloCodigo(Int32.Parse(rutx), skux, txtListaPrecio.Text, "S")
                    gr.Cells("PrecioIva").Value = articulo.PrecioIva.ToString("N0")
                    gr.Cells("Valor").Value = (articulo.PrecioIva * cntx).ToString("N0")

                    gr.Cells("CBruto").Value = articulo.CBruto
                    gr.Cells("CNeto").Value = articulo.CNeto
                    gr.Cells("CIva").Value = articulo.CIva
                    If articulo.Oferta = 1 Then
                        gr.DefaultCellStyle.BackColor = Color.GreenYellow
                    End If
                Next

                CalculaSubTotal()
                DestacaProductoEnOferta()
                APlicaColoresGrillaDetalle()
                AplicaDestacadoProducto()
            Else 
            chkOferta.Checked = False
           End If
    End Sub

    Private Sub chkOferta_CheckStateChanged(sender As Object, e As EventArgs) Handles chkOferta.CheckStateChanged
        Dim rut As String = objTrans.LimpiaRut(txtRut.Text)
        If chkOferta.Checked = True Then
            If gridDetalle.RowCount > 0 Then

                xPromocionTercera.ShowDialog()
                
            End If
        ElseIf chkOferta.Checked = False
            If gridDetalle.RowCount > 0 Then
                For Each gr As DataGridViewRow In gridDetalle.Rows
                    Dim skux = gr.Cells("Codigo").Value
                    Dim cntx = Convert.ToDouble(gr.Cells("Cant").Value)
                    Dim articulo As ArticuloObj = objArticuloController.GetArticuloCodigo(Int32.Parse(rut), skux, txtListaPrecio.Text, "N")
                    gr.Cells("PrecioIva").Value = articulo.PrecioIva.ToString("N0")
                    gr.Cells("Valor").Value = (articulo.PrecioIva * cntx).ToString("N0")
                    gr.Cells("CBruto").Value = articulo.CBruto
                    gr.Cells("CNeto").Value = articulo.CNeto
                    gr.Cells("CIva").Value = articulo.CIva
                    gr.DefaultCellStyle.BackColor = Color.White

                Next
                CalculaSubTotal()
                DestacaProductoEnOferta()
                APlicaColoresGrillaDetalle()
                AplicaDestacadoProducto()
            End If


        End If

    End Sub

    Private Sub gridDetalle_Click_1(sender As Object, e As EventArgs) Handles gridDetalle.Click

    End Sub

    Private Sub gridDetalle_MouseClick(sender As Object, e As MouseEventArgs) Handles gridDetalle.MouseClick
        'If Me.gridDetalle.Rows.Count <> 0 Then
        '    Dim fila As Integer = gridDetalle.CurrentRow.Index
        '    gridDetalle.ClearSelection()
        '    gridDetalle.CurrentCell = gridDetalle.Rows(fila).Cells("Cant")
        'End If
    End Sub

    Private Sub TabCabeceraPrincipal_Click(sender As Object, e As EventArgs) Handles TabCabeceraPrincipal.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) 
        LibTbk.Configura(_PuertoTbk)

        Dim respuesta = LibTbk.GeneraVentasPos(Comprobante.Si, 15200, 111450,5)
    End Sub

    Private Sub btnDebitoCredito_Click(sender As Object, e As EventArgs) Handles btnDebitoCredito.Click
        VuelveModalidadN()
        accionBotonCompraDebitoCredito()
    End Sub

    Private Sub checkTBK_CheckedChanged(sender As Object, e As EventArgs) Handles checkTBK.CheckedChanged
        TransbankCheck(checkTBK.CheckState)
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        Dim valoracobrar = txtResumenDebito.Text.Replace(".","")
        dim ncuotas = tbkCuotas.Text
        Dim folio = Int32.Parse(txtCorrelativo.Text.Replace(".",""))

        LibTbk.Configura(_PuertoTbk)

         Dim respuestaTbk = LibTbk.GeneraVentasPos(Comprobante.Si, valoracobrar, folio, ncuotas)
        If respuestaTbk.Conexion = True
            If  respuestaTbk.DatosVenta.Codigo.Equals("00")
                tbkTarjeta.Text = respuestaTbk.DatosVenta.NombreTarjeta
                tbkOperacion.Text = respuestaTbk.DatosVenta.NOperacion
                tbkAutorizacion.Text = respuestaTbk.DatosVenta.CAutorizacion
                Button4.Enabled = True
                Else 
                MessageBox.Show(respuestaTbk.DatosVenta.CodigoDescripcion)
            End If  
            Else 
            MessageBox.Show(respuestaTbk.ConexionDescripcion)
        End If 

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        LibTbk.Configura(_PuertoTbk)

        Dim respuestaTbk = LibTbk.AnulaVentaPos(debito_txtNroOperacion.Text)
        If respuestaTbk.Conexion = True
            If  respuestaTbk.DatosAnulacion.Codigo.Equals("00")
                MessageBox.Show("Anulacion venta")
                tbkTarjeta.Text = ""
                tbkOperacion.Text = ""
                tbkAutorizacion.Text = ""
                Else 
                MessageBox.Show(respuestaTbk.DatosAnulacion.CodigoDescripcion)
            End If  
            Else 
            MessageBox.Show(respuestaTbk.ConexionDescripcion)
        End If
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
          Xautorizacion.Tipo.Text = "Transbank"
            Xautorizacion.txtUsuario.Focus()
            Xautorizacion.ShowDialog()
            Exit Sub

        xTBK.ShowDialog()
    End Sub
End Class
