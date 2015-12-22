<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pos))
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Efectivo_err_Monto = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.XmlNodeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.TabControlCabecera = New System.Windows.Forms.TabControl()
        Me.TabCabeceraPrincipal = New System.Windows.Forms.TabPage()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.checkTBK = New System.Windows.Forms.CheckBox()
        Me.btn_CopiaXML = New System.Windows.Forms.Button()
        Me.txtNroCaja = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblFechaDocumento = New System.Windows.Forms.Label()
        Me.btnDireccionesDespacho = New System.Windows.Forms.Button()
        Me.txtNombreDireccionDespacho = New System.Windows.Forms.TextBox()
        Me.txtCodigoDirecciónDespacho = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.chkOferta = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.txtPorcentajeDescuento = New System.Windows.Forms.TextBox()
        Me.btn_Descuento_Cabesera = New System.Windows.Forms.Button()
        Me.btnEstudiante = New System.Windows.Forms.Button()
        Me.btnDireccionesFacturacion = New System.Windows.Forms.Button()
        Me.txtNombreDireccion = New System.Windows.Forms.TextBox()
        Me.txtCodigoDirección = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtDescripcionVendedorAsignado = New System.Windows.Forms.TextBox()
        Me.txtListaPrecio = New System.Windows.Forms.TextBox()
        Me.txtCodigoVendedorAsignado = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarVendedor = New System.Windows.Forms.Button()
        Me.txtCodigoVendedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombreVendedor = New System.Windows.Forms.TextBox()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRut = New System.Windows.Forms.TextBox()
        Me.lblCampoBusquedaRut = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnDetalleDescuento = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtFinal = New System.Windows.Forms.TextBox()
        Me.lblSaldo1 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.txtIva = New System.Windows.Forms.TextBox()
        Me.txtBruto = New System.Windows.Forms.TextBox()
        Me.lblSaldo2 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_RecuperaDocu = New System.Windows.Forms.Button()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtCorrelativo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNuevaBoleta = New System.Windows.Forms.Button()
        Me.btnNuevaVenta = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCierreCaja = New System.Windows.Forms.Button()
        Me.TabAplicaPago = New System.Windows.Forms.TabPage()
        Me.btnEmision = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.abono_TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.abono_TxtRut = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.abonoGridDocumentos = New System.Windows.Forms.DataGridView()
        Me.TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoXPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.abono_total = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.abono_iva = New System.Windows.Forms.TextBox()
        Me.abono_subtotal = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabArticulos = New System.Windows.Forms.TabPage()
        Me.Cantidad = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtPrecioIva = New System.Windows.Forms.TextBox()
        Me.gridDetalle = New System.Windows.Forms.DataGridView()
        Me.descuento_ = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtCodigoProducto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPrecioProducto = New System.Windows.Forms.TextBox()
        Me.txtDescripcionProducto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.txtUm = New System.Windows.Forms.TextBox()
        Me.txt_Debito_Banco = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtResumenDebitoCredito = New System.Windows.Forms.TextBox()
        Me.btnDebitoCredito = New System.Windows.Forms.Button()
        Me.btnNotaCredito = New System.Windows.Forms.Button()
        Me.txtResumenNotaCredito = New System.Windows.Forms.TextBox()
        Me.txtResumenSinPago = New System.Windows.Forms.TextBox()
        Me.btn_sin_Pago = New System.Windows.Forms.Button()
        Me.txtResumenDespacho = New System.Windows.Forms.TextBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.btnDespacho = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtResumenTransferencia = New System.Windows.Forms.TextBox()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTMEDIOPAGO = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtResumenCheque = New System.Windows.Forms.TextBox()
        Me.txtVuelto = New System.Windows.Forms.TextBox()
        Me.txtPagado = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtResumenCredito = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtResumenCreditoSteward = New System.Windows.Forms.TextBox()
        Me.btnCompraEfectivo = New System.Windows.Forms.Button()
        Me.txtResumenEfectivo = New System.Windows.Forms.TextBox()
        Me.btn_Credito_Steward = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btnCompraDebito = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btn_Compra_credito = New System.Windows.Forms.Button()
        Me.txtResumenDebito = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnCompraCheque = New System.Windows.Forms.Button()
        Me.TabMedioPago = New System.Windows.Forms.TabControl()
        Me.TabEfectivo = New System.Windows.Forms.TabPage()
        Me.TabDebito = New System.Windows.Forms.TabPage()
        Me.debito_btn_popup_banco = New System.Windows.Forms.Button()
        Me.debito_codigo_banco = New System.Windows.Forms.TextBox()
        Me.debito_Banco = New System.Windows.Forms.TextBox()
        Me.Debito_txt_Codigo_Autorizacion = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.debito_txtNroOperacion = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TabCredito = New System.Windows.Forms.TabPage()
        Me.btn_Popup_TipoTarjeta = New System.Windows.Forms.Button()
        Me.btn_popup_Banco = New System.Windows.Forms.Button()
        Me.credito_txt_codigo_tipoTarjeta = New System.Windows.Forms.TextBox()
        Me.credito_txt_tipotarjeta = New System.Windows.Forms.TextBox()
        Me.creditotxtCodigoBanco = New System.Windows.Forms.TextBox()
        Me.credito_txt_banco = New System.Windows.Forms.TextBox()
        Me.txtCreditoTerminoPago = New System.Windows.Forms.TextBox()
        Me.txtCuotasCredito = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.credito_txt_CodAutorizacion = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.credito_txt_nro_operacion = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btn_Condicion_Pago = New System.Windows.Forms.TabPage()
        Me.cheque_grid_cheque = New System.Windows.Forms.DataGridView()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cheque_btn_Banco = New System.Windows.Forms.Button()
        Me.cheque_Banco_Codigo = New System.Windows.Forms.TextBox()
        Me.cheque_Banco = New System.Windows.Forms.TextBox()
        Me.cheque_txt_condicionPago_Codigo = New System.Windows.Forms.TextBox()
        Me.btn_CondicionPago = New System.Windows.Forms.Button()
        Me.chequetxtCondicionPago = New System.Windows.Forms.TextBox()
        Me.cheque_txt_nroCuenta = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cheque_txt_rut = New System.Windows.Forms.TextBox()
        Me.Cheque_txt_Cantidad = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TabCreditoSteward = New System.Windows.Forms.TabPage()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtCredito_OrdendeCompra = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.CreditoSteward_txt_Observacion = New System.Windows.Forms.TextBox()
        Me.txtCreditoRut = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TabDirecciones = New System.Windows.Forms.TabPage()
        Me.btn_Flete_Ingresar = New System.Windows.Forms.Button()
        Me.txtDirección_Flete = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Direcciones_Combo_Despacho = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TabTransferencia = New System.Windows.Forms.TabPage()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txt_transferencia_codigobanco = New System.Windows.Forms.TextBox()
        Me.btn_transferencia_Banco = New System.Windows.Forms.Button()
        Me.txt_Transferencia_Banco = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtTransferenciaObservaciones = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtTransferenciaNro = New System.Windows.Forms.TextBox()
        Me.txtTransferenciaRut = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TransferenciaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtTransferenciaNombre = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TabSinPago = New System.Windows.Forms.TabPage()
        Me.TabNotaCredito = New System.Windows.Forms.TabPage()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.grillaNotasCredito = New System.Windows.Forms.DataGridView()
        Me.Quitar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.btnNotaActualizar = New System.Windows.Forms.Button()
        Me.txtNota_nro_nota_Credito = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.TabTransbank = New System.Windows.Forms.TabPage()
        Me.tbkTipo = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tbkTarjeta = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.tbkCuotas = New System.Windows.Forms.TextBox()
        Me.tbkAutorizacion = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.tbkOperacion = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.List_Descuentos = New System.Windows.Forms.ListBox()
        Me.btn_Pendientes = New System.Windows.Forms.Button()
        Me.lblItemsDetalle = New System.Windows.Forms.Label()
        Me.lblLineasDetalle = New System.Windows.Forms.Label()
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.btnCerrarCompra = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btn_Emision_Documentos = New System.Windows.Forms.Button()
        CType(Me.Efectivo_err_Monto,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.XmlNodeBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabControlCabecera.SuspendLayout
        Me.TabCabeceraPrincipal.SuspendLayout
        Me.GroupBox3.SuspendLayout
        Me.GroupBox9.SuspendLayout
        CType(Me.PictureBox7,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox4.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.TabAplicaPago.SuspendLayout
        Me.GroupBox11.SuspendLayout
        Me.GroupBox10.SuspendLayout
        CType(Me.abonoGridDocumentos,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox8.SuspendLayout
        Me.TabControl.SuspendLayout
        Me.TabArticulos.SuspendLayout
        CType(Me.gridDetalle,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox6,System.ComponentModel.ISupportInitialize).BeginInit
        Me.txt_Debito_Banco.SuspendLayout
        Me.GroupBox6.SuspendLayout
        CType(Me.PictureBox9,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox8,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabMedioPago.SuspendLayout
        Me.TabDebito.SuspendLayout
        Me.TabCredito.SuspendLayout
        Me.btn_Condicion_Pago.SuspendLayout
        CType(Me.cheque_grid_cheque,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox7.SuspendLayout
        Me.TabCreditoSteward.SuspendLayout
        Me.TabDirecciones.SuspendLayout
        Me.TabTransferencia.SuspendLayout
        Me.GroupBox5.SuspendLayout
        Me.TabNotaCredito.SuspendLayout
        CType(Me.grillaNotasCredito,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabTransbank.SuspendLayout
        Me.SuspendLayout
        '
        'Label15
        '
        Me.Label15.AutoSize = true
        Me.Label15.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label15.Location = New System.Drawing.Point(381, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 32)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Efectivo"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox2.Location = New System.Drawing.Point(356, 135)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(192, 26)
        Me.TextBox2.TabIndex = 0
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox3.Location = New System.Drawing.Point(242, 115)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(250, 26)
        Me.TextBox3.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = true
        Me.Label19.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label19.Location = New System.Drawing.Point(113, 123)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 18)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Nro. Operación"
        '
        'Label20
        '
        Me.Label20.AutoSize = true
        Me.Label20.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label20.Location = New System.Drawing.Point(174, 75)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 18)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Banco"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ComboBox1.FormattingEnabled = true
        Me.ComboBox1.Location = New System.Drawing.Point(242, 72)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(405, 26)
        Me.ComboBox1.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = true
        Me.Label21.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label21.Location = New System.Drawing.Point(373, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(101, 32)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Débito"
        '
        'Timer1
        '
        Me.Timer1.Enabled = true
        Me.Timer1.Interval = 1
        '
        'Efectivo_err_Monto
        '
        Me.Efectivo_err_Monto.ContainerControl = Me
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label45
        '
        Me.Label45.AutoSize = true
        Me.Label45.Location = New System.Drawing.Point(17, 68)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(101, 13)
        Me.Label45.TabIndex = 2
        Me.Label45.Text = "Codigo Autorización"
        '
        'Label46
        '
        Me.Label46.AutoSize = true
        Me.Label46.Location = New System.Drawing.Point(17, 32)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(101, 13)
        Me.Label46.TabIndex = 1
        Me.Label46.Text = "Codigo Autorización"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(135, 32)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 0
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Eliminar"
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"),System.Drawing.Image)
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 30
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = CType(resources.GetObject("DataGridViewImageColumn2.Image"),System.Drawing.Image)
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Width = 30
        '
        'XmlNodeBindingSource
        '
        Me.XmlNodeBindingSource.DataSource = GetType(System.Xml.XmlNode)
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = true
        '
        'TabControlCabecera
        '
        Me.TabControlCabecera.Controls.Add(Me.TabCabeceraPrincipal)
        Me.TabControlCabecera.Controls.Add(Me.TabAplicaPago)
        Me.TabControlCabecera.Location = New System.Drawing.Point(6, 3)
        Me.TabControlCabecera.Name = "TabControlCabecera"
        Me.TabControlCabecera.SelectedIndex = 0
        Me.TabControlCabecera.Size = New System.Drawing.Size(1006, 224)
        Me.TabControlCabecera.TabIndex = 29
        '
        'TabCabeceraPrincipal
        '
        Me.TabCabeceraPrincipal.Controls.Add(Me.Button6)
        Me.TabCabeceraPrincipal.Controls.Add(Me.checkTBK)
        Me.TabCabeceraPrincipal.Controls.Add(Me.btn_CopiaXML)
        Me.TabCabeceraPrincipal.Controls.Add(Me.txtNroCaja)
        Me.TabCabeceraPrincipal.Controls.Add(Me.GroupBox3)
        Me.TabCabeceraPrincipal.Controls.Add(Me.GroupBox4)
        Me.TabCabeceraPrincipal.Controls.Add(Me.GroupBox2)
        Me.TabCabeceraPrincipal.Controls.Add(Me.GroupBox1)
        Me.TabCabeceraPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.TabCabeceraPrincipal.Name = "TabCabeceraPrincipal"
        Me.TabCabeceraPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCabeceraPrincipal.Size = New System.Drawing.Size(998, 198)
        Me.TabCabeceraPrincipal.TabIndex = 0
        Me.TabCabeceraPrincipal.UseVisualStyleBackColor = true
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(752, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(81, 23)
        Me.Button6.TabIndex = 30
        Me.Button6.Text = "Config TBK"
        Me.Button6.UseVisualStyleBackColor = true
        '
        'checkTBK
        '
        Me.checkTBK.AutoSize = true
        Me.checkTBK.Checked = true
        Me.checkTBK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkTBK.Location = New System.Drawing.Point(870, 10)
        Me.checkTBK.Name = "checkTBK"
        Me.checkTBK.Size = New System.Drawing.Size(47, 17)
        Me.checkTBK.TabIndex = 29
        Me.checkTBK.Text = "TBK"
        Me.checkTBK.UseVisualStyleBackColor = true
        '
        'btn_CopiaXML
        '
        Me.btn_CopiaXML.Location = New System.Drawing.Point(925, 6)
        Me.btn_CopiaXML.Name = "btn_CopiaXML"
        Me.btn_CopiaXML.Size = New System.Drawing.Size(67, 23)
        Me.btn_CopiaXML.TabIndex = 28
        Me.btn_CopiaXML.Text = "Copia XML"
        Me.btn_CopiaXML.UseVisualStyleBackColor = true
        '
        'txtNroCaja
        '
        Me.txtNroCaja.Enabled = false
        Me.txtNroCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNroCaja.Location = New System.Drawing.Point(6, 14)
        Me.txtNroCaja.Name = "txtNroCaja"
        Me.txtNroCaja.Size = New System.Drawing.Size(80, 29)
        Me.txtNroCaja.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblFechaDocumento)
        Me.GroupBox3.Controls.Add(Me.btnDireccionesDespacho)
        Me.GroupBox3.Controls.Add(Me.txtNombreDireccionDespacho)
        Me.GroupBox3.Controls.Add(Me.txtCodigoDirecciónDespacho)
        Me.GroupBox3.Controls.Add(Me.Label62)
        Me.GroupBox3.Controls.Add(Me.chkOferta)
        Me.GroupBox3.Controls.Add(Me.GroupBox9)
        Me.GroupBox3.Controls.Add(Me.btnEstudiante)
        Me.GroupBox3.Controls.Add(Me.btnDireccionesFacturacion)
        Me.GroupBox3.Controls.Add(Me.txtNombreDireccion)
        Me.GroupBox3.Controls.Add(Me.txtCodigoDirección)
        Me.GroupBox3.Controls.Add(Me.Label53)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Controls.Add(Me.txtDescripcionVendedorAsignado)
        Me.GroupBox3.Controls.Add(Me.txtListaPrecio)
        Me.GroupBox3.Controls.Add(Me.txtCodigoVendedorAsignado)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox3.Controls.Add(Me.btnBuscarVendedor)
        Me.GroupBox3.Controls.Add(Me.txtCodigoVendedor)
        Me.GroupBox3.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtNombreVendedor)
        Me.GroupBox3.Controls.Add(Me.txtNombreCliente)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtRut)
        Me.GroupBox3.Controls.Add(Me.lblCampoBusquedaRut)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(740, 146)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = false
        '
        'lblFechaDocumento
        '
        Me.lblFechaDocumento.AutoSize = true
        Me.lblFechaDocumento.Location = New System.Drawing.Point(446, 72)
        Me.lblFechaDocumento.Name = "lblFechaDocumento"
        Me.lblFechaDocumento.Size = New System.Drawing.Size(45, 13)
        Me.lblFechaDocumento.TabIndex = 28
        Me.lblFechaDocumento.Text = "Label63"
        Me.lblFechaDocumento.Visible = false
        '
        'btnDireccionesDespacho
        '
        Me.btnDireccionesDespacho.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDireccionesDespacho.Enabled = false
        Me.btnDireccionesDespacho.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnDireccionesDespacho.Image = CType(resources.GetObject("btnDireccionesDespacho.Image"),System.Drawing.Image)
        Me.btnDireccionesDespacho.Location = New System.Drawing.Point(560, 116)
        Me.btnDireccionesDespacho.Name = "btnDireccionesDespacho"
        Me.btnDireccionesDespacho.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDireccionesDespacho.Size = New System.Drawing.Size(26, 26)
        Me.btnDireccionesDespacho.TabIndex = 27
        Me.btnDireccionesDespacho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDireccionesDespacho.UseVisualStyleBackColor = false
        '
        'txtNombreDireccionDespacho
        '
        Me.txtNombreDireccionDespacho.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNombreDireccionDespacho.Location = New System.Drawing.Point(177, 119)
        Me.txtNombreDireccionDespacho.Name = "txtNombreDireccionDespacho"
        Me.txtNombreDireccionDespacho.ReadOnly = true
        Me.txtNombreDireccionDespacho.Size = New System.Drawing.Size(382, 22)
        Me.txtNombreDireccionDespacho.TabIndex = 26
        '
        'txtCodigoDirecciónDespacho
        '
        Me.txtCodigoDirecciónDespacho.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCodigoDirecciónDespacho.Location = New System.Drawing.Point(121, 119)
        Me.txtCodigoDirecciónDespacho.Name = "txtCodigoDirecciónDespacho"
        Me.txtCodigoDirecciónDespacho.ReadOnly = true
        Me.txtCodigoDirecciónDespacho.Size = New System.Drawing.Size(50, 22)
        Me.txtCodigoDirecciónDespacho.TabIndex = 25
        Me.txtCodigoDirecciónDespacho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label62
        '
        Me.Label62.AutoSize = true
        Me.Label62.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label62.Location = New System.Drawing.Point(8, 120)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(97, 16)
        Me.Label62.TabIndex = 24
        Me.Label62.Text = "Dire. Despacho"
        '
        'chkOferta
        '
        Me.chkOferta.AutoSize = true
        Me.chkOferta.BackColor = System.Drawing.Color.Red
        Me.chkOferta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkOferta.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chkOferta.Location = New System.Drawing.Point(618, 122)
        Me.chkOferta.Name = "chkOferta"
        Me.chkOferta.Size = New System.Drawing.Size(92, 18)
        Me.chkOferta.TabIndex = 14
        Me.chkOferta.Text = "PROMOCION"
        Me.chkOferta.UseVisualStyleBackColor = false
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.PictureBox7)
        Me.GroupBox9.Controls.Add(Me.txtPorcentajeDescuento)
        Me.GroupBox9.Controls.Add(Me.btn_Descuento_Cabesera)
        Me.GroupBox9.Location = New System.Drawing.Point(590, 52)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(144, 64)
        Me.GroupBox9.TabIndex = 23
        Me.GroupBox9.TabStop = false
        Me.GroupBox9.Text = "Descuento"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"),System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(15, 21)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(28, 29)
        Me.PictureBox7.TabIndex = 12
        Me.PictureBox7.TabStop = false
        '
        'txtPorcentajeDescuento
        '
        Me.txtPorcentajeDescuento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPorcentajeDescuento.Location = New System.Drawing.Point(49, 26)
        Me.txtPorcentajeDescuento.Name = "txtPorcentajeDescuento"
        Me.txtPorcentajeDescuento.ReadOnly = true
        Me.txtPorcentajeDescuento.Size = New System.Drawing.Size(42, 22)
        Me.txtPorcentajeDescuento.TabIndex = 14
        Me.txtPorcentajeDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_Descuento_Cabesera
        '
        Me.btn_Descuento_Cabesera.Enabled = false
        Me.btn_Descuento_Cabesera.Location = New System.Drawing.Point(97, 20)
        Me.btn_Descuento_Cabesera.Name = "btn_Descuento_Cabesera"
        Me.btn_Descuento_Cabesera.Size = New System.Drawing.Size(42, 33)
        Me.btn_Descuento_Cabesera.TabIndex = 13
        Me.btn_Descuento_Cabesera.Text = "%"
        Me.btn_Descuento_Cabesera.UseVisualStyleBackColor = true
        '
        'btnEstudiante
        '
        Me.btnEstudiante.Location = New System.Drawing.Point(6, 8)
        Me.btnEstudiante.Name = "btnEstudiante"
        Me.btnEstudiante.Size = New System.Drawing.Size(35, 23)
        Me.btnEstudiante.TabIndex = 22
        Me.btnEstudiante.Text = "A"
        Me.btnEstudiante.UseVisualStyleBackColor = true
        '
        'btnDireccionesFacturacion
        '
        Me.btnDireccionesFacturacion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDireccionesFacturacion.Enabled = false
        Me.btnDireccionesFacturacion.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnDireccionesFacturacion.Image = CType(resources.GetObject("btnDireccionesFacturacion.Image"),System.Drawing.Image)
        Me.btnDireccionesFacturacion.Location = New System.Drawing.Point(560, 90)
        Me.btnDireccionesFacturacion.Name = "btnDireccionesFacturacion"
        Me.btnDireccionesFacturacion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDireccionesFacturacion.Size = New System.Drawing.Size(26, 26)
        Me.btnDireccionesFacturacion.TabIndex = 21
        Me.btnDireccionesFacturacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDireccionesFacturacion.UseVisualStyleBackColor = false
        '
        'txtNombreDireccion
        '
        Me.txtNombreDireccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNombreDireccion.Location = New System.Drawing.Point(177, 93)
        Me.txtNombreDireccion.Name = "txtNombreDireccion"
        Me.txtNombreDireccion.ReadOnly = true
        Me.txtNombreDireccion.Size = New System.Drawing.Size(382, 22)
        Me.txtNombreDireccion.TabIndex = 20
        '
        'txtCodigoDirección
        '
        Me.txtCodigoDirección.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCodigoDirección.Location = New System.Drawing.Point(121, 93)
        Me.txtCodigoDirección.Name = "txtCodigoDirección"
        Me.txtCodigoDirección.ReadOnly = true
        Me.txtCodigoDirección.Size = New System.Drawing.Size(50, 22)
        Me.txtCodigoDirección.TabIndex = 19
        Me.txtCodigoDirección.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label53
        '
        Me.Label53.AutoSize = true
        Me.Label53.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label53.Location = New System.Drawing.Point(8, 94)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(107, 16)
        Me.Label53.TabIndex = 18
        Me.Label53.Text = "Dire. Facturación"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(419, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Lista Precio"
        '
        'Label41
        '
        Me.Label41.AutoSize = true
        Me.Label41.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label41.Location = New System.Drawing.Point(7, 70)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(110, 16)
        Me.Label41.TabIndex = 16
        Me.Label41.Text = "Vendedor Ejecuta"
        '
        'Label39
        '
        Me.Label39.AutoSize = true
        Me.Label39.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label39.Location = New System.Drawing.Point(339, 201)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(108, 16)
        Me.Label39.TabIndex = 12
        Me.Label39.Text = "Vendedor Cartera"
        '
        'txtDescripcionVendedorAsignado
        '
        Me.txtDescripcionVendedorAsignado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDescripcionVendedorAsignado.Location = New System.Drawing.Point(177, 41)
        Me.txtDescripcionVendedorAsignado.Name = "txtDescripcionVendedorAsignado"
        Me.txtDescripcionVendedorAsignado.ReadOnly = true
        Me.txtDescripcionVendedorAsignado.Size = New System.Drawing.Size(228, 22)
        Me.txtDescripcionVendedorAsignado.TabIndex = 11
        '
        'txtListaPrecio
        '
        Me.txtListaPrecio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtListaPrecio.Location = New System.Drawing.Point(499, 41)
        Me.txtListaPrecio.Name = "txtListaPrecio"
        Me.txtListaPrecio.ReadOnly = true
        Me.txtListaPrecio.Size = New System.Drawing.Size(58, 22)
        Me.txtListaPrecio.TabIndex = 3
        Me.txtListaPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCodigoVendedorAsignado
        '
        Me.txtCodigoVendedorAsignado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCodigoVendedorAsignado.Location = New System.Drawing.Point(121, 41)
        Me.txtCodigoVendedorAsignado.Name = "txtCodigoVendedorAsignado"
        Me.txtCodigoVendedorAsignado.ReadOnly = true
        Me.txtCodigoVendedorAsignado.Size = New System.Drawing.Size(50, 22)
        Me.txtCodigoVendedorAsignado.TabIndex = 10
        '
        'Label30
        '
        Me.Label30.AutoSize = true
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label30.Location = New System.Drawing.Point(7, 44)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(108, 16)
        Me.Label30.TabIndex = 9
        Me.Label30.Text = "Vendedor Cartera"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCodigoCliente.Location = New System.Drawing.Point(715, 11)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.ReadOnly = true
        Me.txtCodigoCliente.Size = New System.Drawing.Size(14, 22)
        Me.txtCodigoCliente.TabIndex = 8
        Me.txtCodigoCliente.Visible = false
        '
        'btnBuscarVendedor
        '
        Me.btnBuscarVendedor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBuscarVendedor.Enabled = false
        Me.btnBuscarVendedor.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnBuscarVendedor.Image = CType(resources.GetObject("btnBuscarVendedor.Image"),System.Drawing.Image)
        Me.btnBuscarVendedor.Location = New System.Drawing.Point(405, 64)
        Me.btnBuscarVendedor.Name = "btnBuscarVendedor"
        Me.btnBuscarVendedor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBuscarVendedor.Size = New System.Drawing.Size(26, 26)
        Me.btnBuscarVendedor.TabIndex = 7
        Me.btnBuscarVendedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuscarVendedor.UseVisualStyleBackColor = false
        '
        'txtCodigoVendedor
        '
        Me.txtCodigoVendedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCodigoVendedor.Location = New System.Drawing.Point(121, 67)
        Me.txtCodigoVendedor.Name = "txtCodigoVendedor"
        Me.txtCodigoVendedor.ReadOnly = true
        Me.txtCodigoVendedor.Size = New System.Drawing.Size(50, 22)
        Me.txtCodigoVendedor.TabIndex = 6
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Enabled = false
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"),System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(176, 8)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 25)
        Me.btnBuscarCliente.TabIndex = 6
        Me.btnBuscarCliente.UseVisualStyleBackColor = true
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 18)
        Me.Label3.TabIndex = 5
        '
        'txtNombreVendedor
        '
        Me.txtNombreVendedor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNombreVendedor.Location = New System.Drawing.Point(177, 67)
        Me.txtNombreVendedor.Name = "txtNombreVendedor"
        Me.txtNombreVendedor.ReadOnly = true
        Me.txtNombreVendedor.Size = New System.Drawing.Size(228, 22)
        Me.txtNombreVendedor.TabIndex = 4
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNombreCliente.Location = New System.Drawing.Point(254, 11)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = true
        Me.txtNombreCliente.Size = New System.Drawing.Size(455, 22)
        Me.txtNombreCliente.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(207, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cliente"
        '
        'txtRut
        '
        Me.txtRut.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtRut.Location = New System.Drawing.Point(75, 10)
        Me.txtRut.Name = "txtRut"
        Me.txtRut.ReadOnly = true
        Me.txtRut.Size = New System.Drawing.Size(96, 22)
        Me.txtRut.TabIndex = 1
        '
        'lblCampoBusquedaRut
        '
        Me.lblCampoBusquedaRut.AutoSize = true
        Me.lblCampoBusquedaRut.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCampoBusquedaRut.Location = New System.Drawing.Point(50, 12)
        Me.lblCampoBusquedaRut.Name = "lblCampoBusquedaRut"
        Me.lblCampoBusquedaRut.Size = New System.Drawing.Size(28, 16)
        Me.lblCampoBusquedaRut.TabIndex = 0
        Me.lblCampoBusquedaRut.Text = "Rut"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnDetalleDescuento)
        Me.GroupBox4.Controls.Add(Me.lblTotal)
        Me.GroupBox4.Controls.Add(Me.txtFinal)
        Me.GroupBox4.Controls.Add(Me.lblSaldo1)
        Me.GroupBox4.Controls.Add(Me.txtDescuento)
        Me.GroupBox4.Controls.Add(Me.lblIva)
        Me.GroupBox4.Controls.Add(Me.txtIva)
        Me.GroupBox4.Controls.Add(Me.txtBruto)
        Me.GroupBox4.Controls.Add(Me.lblSaldo2)
        Me.GroupBox4.Controls.Add(Me.txtSubTotal)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.ImeMode = System.Windows.Forms.ImeMode.AlphaFull
        Me.GroupBox4.Location = New System.Drawing.Point(752, 29)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(246, 167)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = false
        '
        'btnDetalleDescuento
        '
        Me.btnDetalleDescuento.Enabled = false
        Me.btnDetalleDescuento.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnDetalleDescuento.Image = CType(resources.GetObject("btnDetalleDescuento.Image"),System.Drawing.Image)
        Me.btnDetalleDescuento.Location = New System.Drawing.Point(208, 38)
        Me.btnDetalleDescuento.Name = "btnDetalleDescuento"
        Me.btnDetalleDescuento.Size = New System.Drawing.Size(35, 29)
        Me.btnDetalleDescuento.TabIndex = 19
        Me.btnDetalleDescuento.UseVisualStyleBackColor = true
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = true
        Me.lblTotal.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTotal.Location = New System.Drawing.Point(3, 135)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(58, 24)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "Total"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFinal
        '
        Me.txtFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtFinal.Location = New System.Drawing.Point(64, 128)
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.ReadOnly = true
        Me.txtFinal.Size = New System.Drawing.Size(180, 35)
        Me.txtFinal.TabIndex = 8
        Me.txtFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldo1
        '
        Me.lblSaldo1.AutoSize = true
        Me.lblSaldo1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblSaldo1.ForeColor = System.Drawing.Color.Black
        Me.lblSaldo1.Location = New System.Drawing.Point(6, 74)
        Me.lblSaldo1.Name = "lblSaldo1"
        Me.lblSaldo1.Size = New System.Drawing.Size(33, 16)
        Me.lblSaldo1.TabIndex = 7
        Me.lblSaldo1.Text = "Bruto"
        Me.lblSaldo1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDescuento.ForeColor = System.Drawing.Color.Red
        Me.txtDescuento.Location = New System.Drawing.Point(65, 40)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = true
        Me.txtDescuento.Size = New System.Drawing.Size(140, 26)
        Me.txtDescuento.TabIndex = 6
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIva
        '
        Me.lblIva.AutoSize = true
        Me.lblIva.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblIva.Location = New System.Drawing.Point(7, 104)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(23, 16)
        Me.lblIva.TabIndex = 5
        Me.lblIva.Text = "Iva"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIva
        '
        Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtIva.Location = New System.Drawing.Point(65, 99)
        Me.txtIva.Name = "txtIva"
        Me.txtIva.ReadOnly = true
        Me.txtIva.Size = New System.Drawing.Size(178, 26)
        Me.txtIva.TabIndex = 4
        Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBruto
        '
        Me.txtBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtBruto.Location = New System.Drawing.Point(65, 70)
        Me.txtBruto.Name = "txtBruto"
        Me.txtBruto.ReadOnly = true
        Me.txtBruto.Size = New System.Drawing.Size(178, 26)
        Me.txtBruto.TabIndex = 3
        Me.txtBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldo2
        '
        Me.lblSaldo2.AutoSize = true
        Me.lblSaldo2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblSaldo2.Location = New System.Drawing.Point(5, 44)
        Me.lblSaldo2.Name = "lblSaldo2"
        Me.lblSaldo2.Size = New System.Drawing.Size(58, 16)
        Me.lblSaldo2.TabIndex = 2
        Me.lblSaldo2.Text = "Descuento"
        Me.lblSaldo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtSubTotal.Location = New System.Drawing.Point(65, 11)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = true
        Me.txtSubTotal.Size = New System.Drawing.Size(178, 26)
        Me.txtSubTotal.TabIndex = 1
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Sub -Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_RecuperaDocu)
        Me.GroupBox2.Controls.Add(Me.txtDocumento)
        Me.GroupBox2.Controls.Add(Me.Label54)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.txtCorrelativo)
        Me.GroupBox2.Location = New System.Drawing.Point(98, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(342, 45)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = false
        '
        'btn_RecuperaDocu
        '
        Me.btn_RecuperaDocu.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btn_RecuperaDocu.Image = CType(resources.GetObject("btn_RecuperaDocu.Image"),System.Drawing.Image)
        Me.btn_RecuperaDocu.Location = New System.Drawing.Point(303, 12)
        Me.btn_RecuperaDocu.Name = "btn_RecuperaDocu"
        Me.btn_RecuperaDocu.Size = New System.Drawing.Size(37, 29)
        Me.btn_RecuperaDocu.TabIndex = 20
        Me.btn_RecuperaDocu.UseVisualStyleBackColor = true
        '
        'txtDocumento
        '
        Me.txtDocumento.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtDocumento.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDocumento.ForeColor = System.Drawing.Color.Black
        Me.txtDocumento.Location = New System.Drawing.Point(201, 13)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(98, 26)
        Me.txtDocumento.TabIndex = 7
        Me.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label54
        '
        Me.Label54.AutoSize = true
        Me.Label54.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label54.Location = New System.Drawing.Point(125, 15)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(77, 20)
        Me.Label54.TabIndex = 6
        Me.Label54.Text = "Documento"
        '
        'Label38
        '
        Me.Label38.AutoSize = true
        Me.Label38.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label38.Location = New System.Drawing.Point(2, 15)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(39, 20)
        Me.Label38.TabIndex = 5
        Me.Label38.Text = "Folio"
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtCorrelativo.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCorrelativo.ForeColor = System.Drawing.Color.Black
        Me.txtCorrelativo.Location = New System.Drawing.Point(44, 12)
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(79, 26)
        Me.txtCorrelativo.TabIndex = 2
        Me.txtCorrelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNuevaBoleta)
        Me.GroupBox1.Controls.Add(Me.btnNuevaVenta)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnCierreCaja)
        Me.GroupBox1.Location = New System.Drawing.Point(446, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 45)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = false
        '
        'btnNuevaBoleta
        '
        Me.btnNuevaBoleta.Location = New System.Drawing.Point(6, 11)
        Me.btnNuevaBoleta.Name = "btnNuevaBoleta"
        Me.btnNuevaBoleta.Size = New System.Drawing.Size(60, 29)
        Me.btnNuevaBoleta.TabIndex = 6
        Me.btnNuevaBoleta.Text = "N Boleta"
        Me.btnNuevaBoleta.UseVisualStyleBackColor = true
        '
        'btnNuevaVenta
        '
        Me.btnNuevaVenta.BackColor = System.Drawing.Color.Gainsboro
        Me.btnNuevaVenta.Location = New System.Drawing.Point(70, 11)
        Me.btnNuevaVenta.Name = "btnNuevaVenta"
        Me.btnNuevaVenta.Size = New System.Drawing.Size(67, 29)
        Me.btnNuevaVenta.TabIndex = 0
        Me.btnNuevaVenta.Text = "N Factura"
        Me.btnNuevaVenta.UseVisualStyleBackColor = false
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(216, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 28)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Cerrar Sesión"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'btnCierreCaja
        '
        Me.btnCierreCaja.Location = New System.Drawing.Point(140, 11)
        Me.btnCierreCaja.Name = "btnCierreCaja"
        Me.btnCierreCaja.Size = New System.Drawing.Size(70, 29)
        Me.btnCierreCaja.TabIndex = 3
        Me.btnCierreCaja.Text = "Cierre Caja"
        Me.btnCierreCaja.UseVisualStyleBackColor = true
        '
        'TabAplicaPago
        '
        Me.TabAplicaPago.Controls.Add(Me.btnEmision)
        Me.TabAplicaPago.Controls.Add(Me.GroupBox11)
        Me.TabAplicaPago.Controls.Add(Me.GroupBox10)
        Me.TabAplicaPago.Controls.Add(Me.GroupBox8)
        Me.TabAplicaPago.Controls.Add(Me.Label43)
        Me.TabAplicaPago.Location = New System.Drawing.Point(4, 22)
        Me.TabAplicaPago.Name = "TabAplicaPago"
        Me.TabAplicaPago.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAplicaPago.Size = New System.Drawing.Size(998, 198)
        Me.TabAplicaPago.TabIndex = 1
        Me.TabAplicaPago.UseVisualStyleBackColor = true
        '
        'btnEmision
        '
        Me.btnEmision.Location = New System.Drawing.Point(85, 131)
        Me.btnEmision.Name = "btnEmision"
        Me.btnEmision.Size = New System.Drawing.Size(154, 34)
        Me.btnEmision.TabIndex = 16
        Me.btnEmision.Text = "Emisión de Documentos"
        Me.btnEmision.UseVisualStyleBackColor = true
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.abono_TxtNombre)
        Me.GroupBox11.Controls.Add(Me.Label59)
        Me.GroupBox11.Controls.Add(Me.Label57)
        Me.GroupBox11.Controls.Add(Me.abono_TxtRut)
        Me.GroupBox11.Location = New System.Drawing.Point(11, 27)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(352, 100)
        Me.GroupBox11.TabIndex = 15
        Me.GroupBox11.TabStop = false
        Me.GroupBox11.Text = "Cliente"
        '
        'abono_TxtNombre
        '
        Me.abono_TxtNombre.Location = New System.Drawing.Point(59, 42)
        Me.abono_TxtNombre.Name = "abono_TxtNombre"
        Me.abono_TxtNombre.Size = New System.Drawing.Size(239, 20)
        Me.abono_TxtNombre.TabIndex = 10
        '
        'Label59
        '
        Me.Label59.AutoSize = true
        Me.Label59.Location = New System.Drawing.Point(6, 45)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(47, 13)
        Me.Label59.TabIndex = 14
        Me.Label59.Text = "Nombre:"
        '
        'Label57
        '
        Me.Label57.AutoSize = true
        Me.Label57.Location = New System.Drawing.Point(14, 16)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(27, 13)
        Me.Label57.TabIndex = 12
        Me.Label57.Text = "Rut:"
        '
        'abono_TxtRut
        '
        Me.abono_TxtRut.Location = New System.Drawing.Point(59, 16)
        Me.abono_TxtRut.Name = "abono_TxtRut"
        Me.abono_TxtRut.Size = New System.Drawing.Size(102, 20)
        Me.abono_TxtRut.TabIndex = 9
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.abonoGridDocumentos)
        Me.GroupBox10.Location = New System.Drawing.Point(375, 13)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(368, 141)
        Me.GroupBox10.TabIndex = 13
        Me.GroupBox10.TabStop = false
        Me.GroupBox10.Text = "Documentos"
        '
        'abonoGridDocumentos
        '
        Me.abonoGridDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.abonoGridDocumentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoDocumento, Me.Folio, Me.SaldoXPagar})
        Me.abonoGridDocumentos.Location = New System.Drawing.Point(6, 19)
        Me.abonoGridDocumentos.Name = "abonoGridDocumentos"
        Me.abonoGridDocumentos.Size = New System.Drawing.Size(348, 107)
        Me.abonoGridDocumentos.TabIndex = 11
        '
        'TipoDocumento
        '
        Me.TipoDocumento.DataPropertyName = "TipoDocumento"
        Me.TipoDocumento.HeaderText = "Tipo Doc."
        Me.TipoDocumento.Name = "TipoDocumento"
        '
        'Folio
        '
        Me.Folio.DataPropertyName = "Folio"
        Me.Folio.HeaderText = "Folio"
        Me.Folio.Name = "Folio"
        '
        'SaldoXPagar
        '
        Me.SaldoXPagar.DataPropertyName = "SaldoXPagar"
        Me.SaldoXPagar.HeaderText = "Saldo"
        Me.SaldoXPagar.Name = "SaldoXPagar"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label56)
        Me.GroupBox8.Controls.Add(Me.abono_total)
        Me.GroupBox8.Controls.Add(Me.Label58)
        Me.GroupBox8.Controls.Add(Me.abono_iva)
        Me.GroupBox8.Controls.Add(Me.abono_subtotal)
        Me.GroupBox8.Controls.Add(Me.Label60)
        Me.GroupBox8.ImeMode = System.Windows.Forms.ImeMode.AlphaFull
        Me.GroupBox8.Location = New System.Drawing.Point(743, 13)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(251, 134)
        Me.GroupBox8.TabIndex = 8
        Me.GroupBox8.TabStop = false
        '
        'Label56
        '
        Me.Label56.AutoSize = true
        Me.Label56.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label56.Location = New System.Drawing.Point(6, 79)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(58, 24)
        Me.Label56.TabIndex = 9
        Me.Label56.Text = "Total"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'abono_total
        '
        Me.abono_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.abono_total.Location = New System.Drawing.Point(67, 79)
        Me.abono_total.Name = "abono_total"
        Me.abono_total.ReadOnly = true
        Me.abono_total.Size = New System.Drawing.Size(181, 35)
        Me.abono_total.TabIndex = 8
        '
        'Label58
        '
        Me.Label58.AutoSize = true
        Me.Label58.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label58.Location = New System.Drawing.Point(38, 48)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(23, 16)
        Me.Label58.TabIndex = 5
        Me.Label58.Text = "Iva"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'abono_iva
        '
        Me.abono_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.abono_iva.Location = New System.Drawing.Point(67, 42)
        Me.abono_iva.Name = "abono_iva"
        Me.abono_iva.ReadOnly = true
        Me.abono_iva.Size = New System.Drawing.Size(178, 26)
        Me.abono_iva.TabIndex = 4
        '
        'abono_subtotal
        '
        Me.abono_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.abono_subtotal.Location = New System.Drawing.Point(65, 10)
        Me.abono_subtotal.Name = "abono_subtotal"
        Me.abono_subtotal.ReadOnly = true
        Me.abono_subtotal.Size = New System.Drawing.Size(181, 26)
        Me.abono_subtotal.TabIndex = 1
        '
        'Label60
        '
        Me.Label60.AutoSize = true
        Me.Label60.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label60.Location = New System.Drawing.Point(5, 13)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(57, 16)
        Me.Label60.TabIndex = 0
        Me.Label60.Text = "Sub -Total"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label43
        '
        Me.Label43.AutoSize = true
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label43.Location = New System.Drawing.Point(8, 3)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(171, 18)
        Me.Label43.TabIndex = 0
        Me.Label43.Text = "Pago de Documentos"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabArticulos)
        Me.TabControl.Controls.Add(Me.txt_Debito_Banco)
        Me.TabControl.Location = New System.Drawing.Point(6, 233)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(928, 464)
        Me.TabControl.TabIndex = 30
        '
        'TabArticulos
        '
        Me.TabArticulos.Controls.Add(Me.Cantidad)
        Me.TabArticulos.Controls.Add(Me.Label11)
        Me.TabArticulos.Controls.Add(Me.txtCantidad)
        Me.TabArticulos.Controls.Add(Me.txtPrecioIva)
        Me.TabArticulos.Controls.Add(Me.gridDetalle)
        Me.TabArticulos.Controls.Add(Me.txtCodigoProducto)
        Me.TabArticulos.Controls.Add(Me.Label7)
        Me.TabArticulos.Controls.Add(Me.Label9)
        Me.TabArticulos.Controls.Add(Me.Label10)
        Me.TabArticulos.Controls.Add(Me.txtPrecioProducto)
        Me.TabArticulos.Controls.Add(Me.txtDescripcionProducto)
        Me.TabArticulos.Controls.Add(Me.Label8)
        Me.TabArticulos.Controls.Add(Me.PictureBox6)
        Me.TabArticulos.Controls.Add(Me.txtUm)
        Me.TabArticulos.Location = New System.Drawing.Point(4, 22)
        Me.TabArticulos.Name = "TabArticulos"
        Me.TabArticulos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabArticulos.Size = New System.Drawing.Size(920, 438)
        Me.TabArticulos.TabIndex = 0
        Me.TabArticulos.UseVisualStyleBackColor = true
        '
        'Cantidad
        '
        Me.Cantidad.AutoSize = true
        Me.Cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Cantidad.Location = New System.Drawing.Point(856, 0)
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(42, 12)
        Me.Cantidad.TabIndex = 11
        Me.Cantidad.Text = "Cantidad"
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label11.Location = New System.Drawing.Point(782, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 12)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Precio Iva"
        '
        'txtCantidad
        '
        Me.txtCantidad.Enabled = false
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(855, 15)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(56, 22)
        Me.txtCantidad.TabIndex = 10
        '
        'txtPrecioIva
        '
        Me.txtPrecioIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPrecioIva.Location = New System.Drawing.Point(761, 15)
        Me.txtPrecioIva.Name = "txtPrecioIva"
        Me.txtPrecioIva.ReadOnly = true
        Me.txtPrecioIva.Size = New System.Drawing.Size(84, 22)
        Me.txtPrecioIva.TabIndex = 13
        '
        'gridDetalle
        '
        Me.gridDetalle.AllowUserToAddRows = false
        Me.gridDetalle.AllowUserToDeleteRows = false
        Me.gridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.descuento_, Me.Eliminar})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridDetalle.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridDetalle.Location = New System.Drawing.Point(6, 43)
        Me.gridDetalle.Name = "gridDetalle"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 14.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridDetalle.Size = New System.Drawing.Size(905, 389)
        Me.gridDetalle.TabIndex = 10
        '
        'descuento_
        '
        Me.descuento_.HeaderText = ""
        Me.descuento_.Image = Global.pos_Steward.My.Resources.Resources.descuento
        Me.descuento_.Name = "descuento_"
        Me.descuento_.Width = 30
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = ""
        Me.Eliminar.Image = Global.pos_Steward.My.Resources.Resources.borrar
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Width = 30
        '
        'txtCodigoProducto
        '
        Me.txtCodigoProducto.Enabled = false
        Me.txtCodigoProducto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCodigoProducto.Location = New System.Drawing.Point(24, 15)
        Me.txtCodigoProducto.Name = "txtCodigoProducto"
        Me.txtCodigoProducto.ReadOnly = true
        Me.txtCodigoProducto.Size = New System.Drawing.Size(92, 22)
        Me.txtCodigoProducto.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label7.Location = New System.Drawing.Point(55, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Codigo"
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label9.Location = New System.Drawing.Point(681, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Precio Neto"
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label10.Location = New System.Drawing.Point(628, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "U.M"
        '
        'txtPrecioProducto
        '
        Me.txtPrecioProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPrecioProducto.Location = New System.Drawing.Point(666, 15)
        Me.txtPrecioProducto.Name = "txtPrecioProducto"
        Me.txtPrecioProducto.ReadOnly = true
        Me.txtPrecioProducto.Size = New System.Drawing.Size(81, 22)
        Me.txtPrecioProducto.TabIndex = 3
        '
        'txtDescripcionProducto
        '
        Me.txtDescripcionProducto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDescripcionProducto.Location = New System.Drawing.Point(139, 15)
        Me.txtDescripcionProducto.Name = "txtDescripcionProducto"
        Me.txtDescripcionProducto.ReadOnly = true
        Me.txtDescripcionProducto.Size = New System.Drawing.Size(470, 22)
        Me.txtDescripcionProducto.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label8.Location = New System.Drawing.Point(353, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Descripción"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"),System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(811, 283)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(70, 64)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 11
        Me.PictureBox6.TabStop = false
        '
        'txtUm
        '
        Me.txtUm.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtUm.Location = New System.Drawing.Point(620, 15)
        Me.txtUm.Name = "txtUm"
        Me.txtUm.ReadOnly = true
        Me.txtUm.Size = New System.Drawing.Size(40, 22)
        Me.txtUm.TabIndex = 4
        '
        'txt_Debito_Banco
        '
        Me.txt_Debito_Banco.Controls.Add(Me.GroupBox6)
        Me.txt_Debito_Banco.Controls.Add(Me.TabMedioPago)
        Me.txt_Debito_Banco.Controls.Add(Me.List_Descuentos)
        Me.txt_Debito_Banco.Location = New System.Drawing.Point(4, 22)
        Me.txt_Debito_Banco.Name = "txt_Debito_Banco"
        Me.txt_Debito_Banco.Padding = New System.Windows.Forms.Padding(3)
        Me.txt_Debito_Banco.Size = New System.Drawing.Size(920, 438)
        Me.txt_Debito_Banco.TabIndex = 1
        Me.txt_Debito_Banco.UseVisualStyleBackColor = true
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtResumenDebitoCredito)
        Me.GroupBox6.Controls.Add(Me.btnDebitoCredito)
        Me.GroupBox6.Controls.Add(Me.btnNotaCredito)
        Me.GroupBox6.Controls.Add(Me.txtResumenNotaCredito)
        Me.GroupBox6.Controls.Add(Me.txtResumenSinPago)
        Me.GroupBox6.Controls.Add(Me.btn_sin_Pago)
        Me.GroupBox6.Controls.Add(Me.txtResumenDespacho)
        Me.GroupBox6.Controls.Add(Me.PictureBox9)
        Me.GroupBox6.Controls.Add(Me.PictureBox8)
        Me.GroupBox6.Controls.Add(Me.btnDespacho)
        Me.GroupBox6.Controls.Add(Me.Button2)
        Me.GroupBox6.Controls.Add(Me.txtResumenTransferencia)
        Me.GroupBox6.Controls.Add(Me.txtSaldo)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.TXTMEDIOPAGO)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.txtResumenCheque)
        Me.GroupBox6.Controls.Add(Me.txtVuelto)
        Me.GroupBox6.Controls.Add(Me.txtPagado)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.txtResumenCredito)
        Me.GroupBox6.Controls.Add(Me.PictureBox1)
        Me.GroupBox6.Controls.Add(Me.txtResumenCreditoSteward)
        Me.GroupBox6.Controls.Add(Me.btnCompraEfectivo)
        Me.GroupBox6.Controls.Add(Me.txtResumenEfectivo)
        Me.GroupBox6.Controls.Add(Me.btn_Credito_Steward)
        Me.GroupBox6.Controls.Add(Me.PictureBox5)
        Me.GroupBox6.Controls.Add(Me.btnCompraDebito)
        Me.GroupBox6.Controls.Add(Me.PictureBox4)
        Me.GroupBox6.Controls.Add(Me.btn_Compra_credito)
        Me.GroupBox6.Controls.Add(Me.txtResumenDebito)
        Me.GroupBox6.Controls.Add(Me.PictureBox2)
        Me.GroupBox6.Controls.Add(Me.PictureBox3)
        Me.GroupBox6.Controls.Add(Me.btnCompraCheque)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(308, 497)
        Me.GroupBox6.TabIndex = 16
        Me.GroupBox6.TabStop = false
        '
        'txtResumenDebitoCredito
        '
        Me.txtResumenDebitoCredito.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenDebitoCredito.Location = New System.Drawing.Point(161, 45)
        Me.txtResumenDebitoCredito.Name = "txtResumenDebitoCredito"
        Me.txtResumenDebitoCredito.ReadOnly = true
        Me.txtResumenDebitoCredito.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenDebitoCredito.TabIndex = 32
        Me.txtResumenDebitoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDebitoCredito
        '
        Me.btnDebitoCredito.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.btnDebitoCredito.Location = New System.Drawing.Point(38, 45)
        Me.btnDebitoCredito.Name = "btnDebitoCredito"
        Me.btnDebitoCredito.Size = New System.Drawing.Size(122, 32)
        Me.btnDebitoCredito.TabIndex = 31
        Me.btnDebitoCredito.Text = "Debito/T.Credito"
        Me.btnDebitoCredito.UseVisualStyleBackColor = true
        Me.btnDebitoCredito.Visible = false
        '
        'btnNotaCredito
        '
        Me.btnNotaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnNotaCredito.Location = New System.Drawing.Point(38, 257)
        Me.btnNotaCredito.Name = "btnNotaCredito"
        Me.btnNotaCredito.Size = New System.Drawing.Size(122, 32)
        Me.btnNotaCredito.TabIndex = 30
        Me.btnNotaCredito.Text = "Nota Credito"
        Me.btnNotaCredito.UseVisualStyleBackColor = true
        '
        'txtResumenNotaCredito
        '
        Me.txtResumenNotaCredito.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenNotaCredito.Location = New System.Drawing.Point(161, 257)
        Me.txtResumenNotaCredito.Name = "txtResumenNotaCredito"
        Me.txtResumenNotaCredito.ReadOnly = true
        Me.txtResumenNotaCredito.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenNotaCredito.TabIndex = 29
        Me.txtResumenNotaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtResumenSinPago
        '
        Me.txtResumenSinPago.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenSinPago.Location = New System.Drawing.Point(161, 221)
        Me.txtResumenSinPago.Name = "txtResumenSinPago"
        Me.txtResumenSinPago.ReadOnly = true
        Me.txtResumenSinPago.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenSinPago.TabIndex = 28
        Me.txtResumenSinPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtResumenSinPago.Visible = false
        '
        'btn_sin_Pago
        '
        Me.btn_sin_Pago.Enabled = false
        Me.btn_sin_Pago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btn_sin_Pago.Location = New System.Drawing.Point(38, 221)
        Me.btn_sin_Pago.Name = "btn_sin_Pago"
        Me.btn_sin_Pago.Size = New System.Drawing.Size(122, 32)
        Me.btn_sin_Pago.TabIndex = 27
        Me.btn_sin_Pago.Text = "Por Pagar"
        Me.btn_sin_Pago.UseVisualStyleBackColor = true
        Me.btn_sin_Pago.Visible = false
        '
        'txtResumenDespacho
        '
        Me.txtResumenDespacho.BackColor = System.Drawing.Color.LightCyan
        Me.txtResumenDespacho.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenDespacho.Location = New System.Drawing.Point(161, 293)
        Me.txtResumenDespacho.Name = "txtResumenDespacho"
        Me.txtResumenDespacho.ReadOnly = true
        Me.txtResumenDespacho.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenDespacho.TabIndex = 26
        Me.txtResumenDespacho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = Global.pos_Steward.My.Resources.Resources.despacho
        Me.PictureBox9.Location = New System.Drawing.Point(3, 291)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 25
        Me.PictureBox9.TabStop = false
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.pos_Steward.My.Resources.Resources.icono_transferencia
        Me.PictureBox8.Location = New System.Drawing.Point(3, 150)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox8.TabIndex = 24
        Me.PictureBox8.TabStop = false
        '
        'btnDespacho
        '
        Me.btnDespacho.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnDespacho.Location = New System.Drawing.Point(38, 293)
        Me.btnDespacho.Name = "btnDespacho"
        Me.btnDespacho.Size = New System.Drawing.Size(122, 32)
        Me.btnDespacho.TabIndex = 20
        Me.btnDespacho.Text = "Despacho"
        Me.btnDespacho.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Button2.Location = New System.Drawing.Point(39, 150)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 32)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Transf. Fondos"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'txtResumenTransferencia
        '
        Me.txtResumenTransferencia.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenTransferencia.Location = New System.Drawing.Point(162, 150)
        Me.txtResumenTransferencia.Name = "txtResumenTransferencia"
        Me.txtResumenTransferencia.ReadOnly = true
        Me.txtResumenTransferencia.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenTransferencia.TabIndex = 22
        Me.txtResumenTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldo
        '
        Me.txtSaldo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtSaldo.Location = New System.Drawing.Point(160, 363)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = true
        Me.txtSaldo.Size = New System.Drawing.Size(144, 32)
        Me.txtSaldo.TabIndex = 21
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label12.Location = New System.Drawing.Point(103, 369)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 19)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Saldo"
        '
        'TXTMEDIOPAGO
        '
        Me.TXTMEDIOPAGO.Location = New System.Drawing.Point(6, 402)
        Me.TXTMEDIOPAGO.Name = "TXTMEDIOPAGO"
        Me.TXTMEDIOPAGO.Size = New System.Drawing.Size(47, 20)
        Me.TXTMEDIOPAGO.TabIndex = 19
        Me.TXTMEDIOPAGO.Visible = false
        '
        'Label14
        '
        Me.Label14.AutoSize = true
        Me.Label14.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label14.Location = New System.Drawing.Point(99, 405)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 19)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Vuelto"
        '
        'txtResumenCheque
        '
        Me.txtResumenCheque.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenCheque.Location = New System.Drawing.Point(162, 115)
        Me.txtResumenCheque.Name = "txtResumenCheque"
        Me.txtResumenCheque.ReadOnly = true
        Me.txtResumenCheque.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenCheque.TabIndex = 13
        Me.txtResumenCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVuelto
        '
        Me.txtVuelto.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtVuelto.Location = New System.Drawing.Point(160, 399)
        Me.txtVuelto.Name = "txtVuelto"
        Me.txtVuelto.ReadOnly = true
        Me.txtVuelto.Size = New System.Drawing.Size(144, 32)
        Me.txtVuelto.TabIndex = 17
        Me.txtVuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPagado
        '
        Me.txtPagado.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtPagado.Location = New System.Drawing.Point(161, 328)
        Me.txtPagado.Name = "txtPagado"
        Me.txtPagado.ReadOnly = true
        Me.txtPagado.Size = New System.Drawing.Size(144, 32)
        Me.txtPagado.TabIndex = 16
        Me.txtPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = true
        Me.Label13.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label13.Location = New System.Drawing.Point(90, 337)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 19)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Pagado"
        '
        'txtResumenCredito
        '
        Me.txtResumenCredito.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenCredito.Location = New System.Drawing.Point(162, 80)
        Me.txtResumenCredito.Name = "txtResumenCredito"
        Me.txtResumenCredito.ReadOnly = true
        Me.txtResumenCredito.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenCredito.TabIndex = 14
        Me.txtResumenCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.pos_Steward.My.Resources.Resources.icono_billete
        Me.PictureBox1.Location = New System.Drawing.Point(4, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = false
        '
        'txtResumenCreditoSteward
        '
        Me.txtResumenCreditoSteward.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenCreditoSteward.Location = New System.Drawing.Point(162, 185)
        Me.txtResumenCreditoSteward.Name = "txtResumenCreditoSteward"
        Me.txtResumenCreditoSteward.ReadOnly = true
        Me.txtResumenCreditoSteward.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenCreditoSteward.TabIndex = 14
        Me.txtResumenCreditoSteward.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtResumenCreditoSteward.Visible = false
        '
        'btnCompraEfectivo
        '
        Me.btnCompraEfectivo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnCompraEfectivo.Location = New System.Drawing.Point(38, 10)
        Me.btnCompraEfectivo.Name = "btnCompraEfectivo"
        Me.btnCompraEfectivo.Size = New System.Drawing.Size(122, 32)
        Me.btnCompraEfectivo.TabIndex = 0
        Me.btnCompraEfectivo.Text = "Efectivo"
        Me.btnCompraEfectivo.UseVisualStyleBackColor = true
        '
        'txtResumenEfectivo
        '
        Me.txtResumenEfectivo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtResumenEfectivo.Location = New System.Drawing.Point(161, 10)
        Me.txtResumenEfectivo.Name = "txtResumenEfectivo"
        Me.txtResumenEfectivo.ReadOnly = true
        Me.txtResumenEfectivo.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenEfectivo.TabIndex = 11
        Me.txtResumenEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_Credito_Steward
        '
        Me.btn_Credito_Steward.Enabled = false
        Me.btn_Credito_Steward.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.btn_Credito_Steward.Location = New System.Drawing.Point(39, 185)
        Me.btn_Credito_Steward.Name = "btn_Credito_Steward"
        Me.btn_Credito_Steward.Size = New System.Drawing.Size(122, 32)
        Me.btn_Credito_Steward.TabIndex = 4
        Me.btn_Credito_Steward.Text = " Steward"
        Me.btn_Credito_Steward.UseVisualStyleBackColor = true
        Me.btn_Credito_Steward.Visible = false
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.pos_Steward.My.Resources.Resources.logo
        Me.PictureBox5.Location = New System.Drawing.Point(4, 185)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 9
        Me.PictureBox5.TabStop = false
        Me.PictureBox5.Visible = false
        '
        'btnCompraDebito
        '
        Me.btnCompraDebito.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.btnCompraDebito.Location = New System.Drawing.Point(38, 45)
        Me.btnCompraDebito.Name = "btnCompraDebito"
        Me.btnCompraDebito.Size = New System.Drawing.Size(122, 32)
        Me.btnCompraDebito.TabIndex = 2
        Me.btnCompraDebito.Text = "Debito"
        Me.btnCompraDebito.UseVisualStyleBackColor = true
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.pos_Steward.My.Resources.Resources.icono_visa
        Me.PictureBox4.Location = New System.Drawing.Point(4, 79)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 8
        Me.PictureBox4.TabStop = false
        '
        'btn_Compra_credito
        '
        Me.btn_Compra_credito.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.btn_Compra_credito.Location = New System.Drawing.Point(39, 80)
        Me.btn_Compra_credito.Name = "btn_Compra_credito"
        Me.btn_Compra_credito.Size = New System.Drawing.Size(122, 32)
        Me.btn_Compra_credito.TabIndex = 3
        Me.btn_Compra_credito.Text = "T.Crédito"
        Me.btn_Compra_credito.UseVisualStyleBackColor = true
        '
        'txtResumenDebito
        '
        Me.txtResumenDebito.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtResumenDebito.Location = New System.Drawing.Point(161, 45)
        Me.txtResumenDebito.Name = "txtResumenDebito"
        Me.txtResumenDebito.ReadOnly = true
        Me.txtResumenDebito.Size = New System.Drawing.Size(144, 32)
        Me.txtResumenDebito.TabIndex = 12
        Me.txtResumenDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.pos_Steward.My.Resources.Resources.icono_cheke
        Me.PictureBox2.Location = New System.Drawing.Point(3, 115)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = false
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.pos_Steward.My.Resources.Resources.icono_debito
        Me.PictureBox3.Location = New System.Drawing.Point(3, 44)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 7
        Me.PictureBox3.TabStop = false
        '
        'btnCompraCheque
        '
        Me.btnCompraCheque.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.btnCompraCheque.Location = New System.Drawing.Point(39, 115)
        Me.btnCompraCheque.Name = "btnCompraCheque"
        Me.btnCompraCheque.Size = New System.Drawing.Size(122, 32)
        Me.btnCompraCheque.TabIndex = 1
        Me.btnCompraCheque.Text = "Cheque"
        Me.btnCompraCheque.UseVisualStyleBackColor = true
        '
        'TabMedioPago
        '
        Me.TabMedioPago.Controls.Add(Me.TabEfectivo)
        Me.TabMedioPago.Controls.Add(Me.TabDebito)
        Me.TabMedioPago.Controls.Add(Me.TabCredito)
        Me.TabMedioPago.Controls.Add(Me.btn_Condicion_Pago)
        Me.TabMedioPago.Controls.Add(Me.TabCreditoSteward)
        Me.TabMedioPago.Controls.Add(Me.TabDirecciones)
        Me.TabMedioPago.Controls.Add(Me.TabTransferencia)
        Me.TabMedioPago.Controls.Add(Me.TabSinPago)
        Me.TabMedioPago.Controls.Add(Me.TabNotaCredito)
        Me.TabMedioPago.Controls.Add(Me.TabTransbank)
        Me.TabMedioPago.Location = New System.Drawing.Point(315, 6)
        Me.TabMedioPago.Name = "TabMedioPago"
        Me.TabMedioPago.SelectedIndex = 0
        Me.TabMedioPago.Size = New System.Drawing.Size(606, 336)
        Me.TabMedioPago.TabIndex = 10
        '
        'TabEfectivo
        '
        Me.TabEfectivo.Location = New System.Drawing.Point(4, 22)
        Me.TabEfectivo.Name = "TabEfectivo"
        Me.TabEfectivo.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEfectivo.Size = New System.Drawing.Size(598, 310)
        Me.TabEfectivo.TabIndex = 0
        Me.TabEfectivo.Text = "Efectivo"
        Me.TabEfectivo.UseVisualStyleBackColor = true
        '
        'TabDebito
        '
        Me.TabDebito.Controls.Add(Me.debito_btn_popup_banco)
        Me.TabDebito.Controls.Add(Me.debito_codigo_banco)
        Me.TabDebito.Controls.Add(Me.debito_Banco)
        Me.TabDebito.Controls.Add(Me.Debito_txt_Codigo_Autorizacion)
        Me.TabDebito.Controls.Add(Me.Label22)
        Me.TabDebito.Controls.Add(Me.debito_txtNroOperacion)
        Me.TabDebito.Controls.Add(Me.Label18)
        Me.TabDebito.Controls.Add(Me.Label17)
        Me.TabDebito.Controls.Add(Me.Label16)
        Me.TabDebito.Location = New System.Drawing.Point(4, 22)
        Me.TabDebito.Name = "TabDebito"
        Me.TabDebito.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDebito.Size = New System.Drawing.Size(598, 310)
        Me.TabDebito.TabIndex = 1
        Me.TabDebito.Text = "Débito"
        Me.TabDebito.UseVisualStyleBackColor = true
        '
        'debito_btn_popup_banco
        '
        Me.debito_btn_popup_banco.Location = New System.Drawing.Point(436, 80)
        Me.debito_btn_popup_banco.Name = "debito_btn_popup_banco"
        Me.debito_btn_popup_banco.Size = New System.Drawing.Size(44, 27)
        Me.debito_btn_popup_banco.TabIndex = 11
        Me.debito_btn_popup_banco.Text = "..."
        Me.debito_btn_popup_banco.UseVisualStyleBackColor = true
        '
        'debito_codigo_banco
        '
        Me.debito_codigo_banco.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.debito_codigo_banco.Location = New System.Drawing.Point(489, 80)
        Me.debito_codigo_banco.Name = "debito_codigo_banco"
        Me.debito_codigo_banco.Size = New System.Drawing.Size(45, 26)
        Me.debito_codigo_banco.TabIndex = 10
        Me.debito_codigo_banco.Visible = false
        '
        'debito_Banco
        '
        Me.debito_Banco.Enabled = false
        Me.debito_Banco.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.debito_Banco.Location = New System.Drawing.Point(179, 81)
        Me.debito_Banco.Name = "debito_Banco"
        Me.debito_Banco.Size = New System.Drawing.Size(250, 26)
        Me.debito_Banco.TabIndex = 9
        '
        'Debito_txt_Codigo_Autorizacion
        '
        Me.Debito_txt_Codigo_Autorizacion.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Debito_txt_Codigo_Autorizacion.Location = New System.Drawing.Point(179, 152)
        Me.Debito_txt_Codigo_Autorizacion.MaxLength = 8
        Me.Debito_txt_Codigo_Autorizacion.Name = "Debito_txt_Codigo_Autorizacion"
        Me.Debito_txt_Codigo_Autorizacion.Size = New System.Drawing.Size(123, 26)
        Me.Debito_txt_Codigo_Autorizacion.TabIndex = 8
        Me.Debito_txt_Codigo_Autorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = true
        Me.Label22.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label22.Location = New System.Drawing.Point(32, 159)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(131, 18)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "Cod. Autorización"
        '
        'debito_txtNroOperacion
        '
        Me.debito_txtNroOperacion.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.debito_txtNroOperacion.Location = New System.Drawing.Point(179, 116)
        Me.debito_txtNroOperacion.MaxLength = 8
        Me.debito_txtNroOperacion.Name = "debito_txtNroOperacion"
        Me.debito_txtNroOperacion.Size = New System.Drawing.Size(123, 26)
        Me.debito_txtNroOperacion.TabIndex = 6
        Me.debito_txtNroOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = true
        Me.Label18.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label18.Location = New System.Drawing.Point(49, 120)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 18)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Nro. Operación"
        '
        'Label17
        '
        Me.Label17.AutoSize = true
        Me.Label17.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label17.Location = New System.Drawing.Point(107, 84)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 18)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Banco"
        '
        'Label16
        '
        Me.Label16.AutoSize = true
        Me.Label16.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label16.Location = New System.Drawing.Point(241, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 32)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Débito"
        '
        'TabCredito
        '
        Me.TabCredito.Controls.Add(Me.btn_Popup_TipoTarjeta)
        Me.TabCredito.Controls.Add(Me.btn_popup_Banco)
        Me.TabCredito.Controls.Add(Me.credito_txt_codigo_tipoTarjeta)
        Me.TabCredito.Controls.Add(Me.credito_txt_tipotarjeta)
        Me.TabCredito.Controls.Add(Me.creditotxtCodigoBanco)
        Me.TabCredito.Controls.Add(Me.credito_txt_banco)
        Me.TabCredito.Controls.Add(Me.txtCreditoTerminoPago)
        Me.TabCredito.Controls.Add(Me.txtCuotasCredito)
        Me.TabCredito.Controls.Add(Me.Label5)
        Me.TabCredito.Controls.Add(Me.Label4)
        Me.TabCredito.Controls.Add(Me.credito_txt_CodAutorizacion)
        Me.TabCredito.Controls.Add(Me.Label27)
        Me.TabCredito.Controls.Add(Me.credito_txt_nro_operacion)
        Me.TabCredito.Controls.Add(Me.Label28)
        Me.TabCredito.Controls.Add(Me.Label29)
        Me.TabCredito.Controls.Add(Me.Label26)
        Me.TabCredito.Location = New System.Drawing.Point(4, 22)
        Me.TabCredito.Name = "TabCredito"
        Me.TabCredito.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCredito.Size = New System.Drawing.Size(598, 310)
        Me.TabCredito.TabIndex = 2
        Me.TabCredito.Text = "Credito"
        Me.TabCredito.UseVisualStyleBackColor = true
        '
        'btn_Popup_TipoTarjeta
        '
        Me.btn_Popup_TipoTarjeta.Location = New System.Drawing.Point(449, 82)
        Me.btn_Popup_TipoTarjeta.Name = "btn_Popup_TipoTarjeta"
        Me.btn_Popup_TipoTarjeta.Size = New System.Drawing.Size(39, 23)
        Me.btn_Popup_TipoTarjeta.TabIndex = 33
        Me.btn_Popup_TipoTarjeta.Text = "..."
        Me.btn_Popup_TipoTarjeta.UseVisualStyleBackColor = true
        '
        'btn_popup_Banco
        '
        Me.btn_popup_Banco.Location = New System.Drawing.Point(448, 47)
        Me.btn_popup_Banco.Name = "btn_popup_Banco"
        Me.btn_popup_Banco.Size = New System.Drawing.Size(39, 23)
        Me.btn_popup_Banco.TabIndex = 32
        Me.btn_popup_Banco.Text = "..."
        Me.btn_popup_Banco.UseVisualStyleBackColor = true
        '
        'credito_txt_codigo_tipoTarjeta
        '
        Me.credito_txt_codigo_tipoTarjeta.Location = New System.Drawing.Point(494, 85)
        Me.credito_txt_codigo_tipoTarjeta.Name = "credito_txt_codigo_tipoTarjeta"
        Me.credito_txt_codigo_tipoTarjeta.Size = New System.Drawing.Size(24, 20)
        Me.credito_txt_codigo_tipoTarjeta.TabIndex = 31
        Me.credito_txt_codigo_tipoTarjeta.Visible = false
        '
        'credito_txt_tipotarjeta
        '
        Me.credito_txt_tipotarjeta.Enabled = false
        Me.credito_txt_tipotarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.credito_txt_tipotarjeta.Location = New System.Drawing.Point(155, 81)
        Me.credito_txt_tipotarjeta.Name = "credito_txt_tipotarjeta"
        Me.credito_txt_tipotarjeta.Size = New System.Drawing.Size(287, 24)
        Me.credito_txt_tipotarjeta.TabIndex = 30
        '
        'creditotxtCodigoBanco
        '
        Me.creditotxtCodigoBanco.Location = New System.Drawing.Point(493, 47)
        Me.creditotxtCodigoBanco.Name = "creditotxtCodigoBanco"
        Me.creditotxtCodigoBanco.Size = New System.Drawing.Size(25, 20)
        Me.creditotxtCodigoBanco.TabIndex = 29
        Me.creditotxtCodigoBanco.Visible = false
        '
        'credito_txt_banco
        '
        Me.credito_txt_banco.Enabled = false
        Me.credito_txt_banco.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.credito_txt_banco.Location = New System.Drawing.Point(155, 45)
        Me.credito_txt_banco.Name = "credito_txt_banco"
        Me.credito_txt_banco.Size = New System.Drawing.Size(287, 24)
        Me.credito_txt_banco.TabIndex = 28
        '
        'txtCreditoTerminoPago
        '
        Me.txtCreditoTerminoPago.Enabled = false
        Me.txtCreditoTerminoPago.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCreditoTerminoPago.Location = New System.Drawing.Point(234, 187)
        Me.txtCreditoTerminoPago.Name = "txtCreditoTerminoPago"
        Me.txtCreditoTerminoPago.Size = New System.Drawing.Size(73, 26)
        Me.txtCreditoTerminoPago.TabIndex = 26
        Me.txtCreditoTerminoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCreditoTerminoPago.Visible = false
        '
        'txtCuotasCredito
        '
        Me.txtCuotasCredito.Enabled = false
        Me.txtCuotasCredito.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCuotasCredito.Location = New System.Drawing.Point(155, 187)
        Me.txtCuotasCredito.Name = "txtCuotasCredito"
        Me.txtCuotasCredito.Size = New System.Drawing.Size(73, 26)
        Me.txtCuotasCredito.TabIndex = 25
        Me.txtCuotasCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 18)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Tipo Tarjeta"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(81, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 18)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Banco"
        '
        'credito_txt_CodAutorizacion
        '
        Me.credito_txt_CodAutorizacion.Enabled = false
        Me.credito_txt_CodAutorizacion.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.credito_txt_CodAutorizacion.Location = New System.Drawing.Point(155, 149)
        Me.credito_txt_CodAutorizacion.MaxLength = 8
        Me.credito_txt_CodAutorizacion.Name = "credito_txt_CodAutorizacion"
        Me.credito_txt_CodAutorizacion.Size = New System.Drawing.Size(120, 26)
        Me.credito_txt_CodAutorizacion.TabIndex = 15
        Me.credito_txt_CodAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = true
        Me.Label27.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 153)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(131, 18)
        Me.Label27.TabIndex = 14
        Me.Label27.Text = "Cod. Autorización"
        '
        'credito_txt_nro_operacion
        '
        Me.credito_txt_nro_operacion.Enabled = false
        Me.credito_txt_nro_operacion.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.credito_txt_nro_operacion.Location = New System.Drawing.Point(155, 117)
        Me.credito_txt_nro_operacion.MaxLength = 8
        Me.credito_txt_nro_operacion.Name = "credito_txt_nro_operacion"
        Me.credito_txt_nro_operacion.Size = New System.Drawing.Size(120, 26)
        Me.credito_txt_nro_operacion.TabIndex = 13
        Me.credito_txt_nro_operacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = true
        Me.Label28.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label28.Location = New System.Drawing.Point(23, 121)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(114, 18)
        Me.Label28.TabIndex = 12
        Me.Label28.Text = "Nro. Operación"
        '
        'Label29
        '
        Me.Label29.AutoSize = true
        Me.Label29.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label29.Location = New System.Drawing.Point(76, 191)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 18)
        Me.Label29.TabIndex = 11
        Me.Label29.Text = "Cuotas"
        '
        'Label26
        '
        Me.Label26.AutoSize = true
        Me.Label26.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label26.Location = New System.Drawing.Point(256, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 32)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Crédito"
        '
        'btn_Condicion_Pago
        '
        Me.btn_Condicion_Pago.Controls.Add(Me.cheque_grid_cheque)
        Me.btn_Condicion_Pago.Controls.Add(Me.GroupBox7)
        Me.btn_Condicion_Pago.Controls.Add(Me.Label31)
        Me.btn_Condicion_Pago.Location = New System.Drawing.Point(4, 22)
        Me.btn_Condicion_Pago.Name = "btn_Condicion_Pago"
        Me.btn_Condicion_Pago.Size = New System.Drawing.Size(598, 310)
        Me.btn_Condicion_Pago.TabIndex = 3
        Me.btn_Condicion_Pago.Text = "Cheque"
        Me.btn_Condicion_Pago.UseVisualStyleBackColor = true
        '
        'cheque_grid_cheque
        '
        Me.cheque_grid_cheque.AllowUserToAddRows = false
        Me.cheque_grid_cheque.AllowUserToDeleteRows = false
        Me.cheque_grid_cheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.cheque_grid_cheque.Location = New System.Drawing.Point(0, 148)
        Me.cheque_grid_cheque.Name = "cheque_grid_cheque"
        Me.cheque_grid_cheque.Size = New System.Drawing.Size(595, 136)
        Me.cheque_grid_cheque.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cheque_btn_Banco)
        Me.GroupBox7.Controls.Add(Me.cheque_Banco_Codigo)
        Me.GroupBox7.Controls.Add(Me.cheque_Banco)
        Me.GroupBox7.Controls.Add(Me.cheque_txt_condicionPago_Codigo)
        Me.GroupBox7.Controls.Add(Me.btn_CondicionPago)
        Me.GroupBox7.Controls.Add(Me.chequetxtCondicionPago)
        Me.GroupBox7.Controls.Add(Me.cheque_txt_nroCuenta)
        Me.GroupBox7.Controls.Add(Me.Label36)
        Me.GroupBox7.Controls.Add(Me.Label35)
        Me.GroupBox7.Controls.Add(Me.Label34)
        Me.GroupBox7.Controls.Add(Me.Label32)
        Me.GroupBox7.Controls.Add(Me.cheque_txt_rut)
        Me.GroupBox7.Controls.Add(Me.Cheque_txt_Cantidad)
        Me.GroupBox7.Controls.Add(Me.Label33)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 38)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(562, 104)
        Me.GroupBox7.TabIndex = 16
        Me.GroupBox7.TabStop = false
        '
        'cheque_btn_Banco
        '
        Me.cheque_btn_Banco.Location = New System.Drawing.Point(526, 43)
        Me.cheque_btn_Banco.Name = "cheque_btn_Banco"
        Me.cheque_btn_Banco.Size = New System.Drawing.Size(30, 23)
        Me.cheque_btn_Banco.TabIndex = 28
        Me.cheque_btn_Banco.Text = " ...."
        Me.cheque_btn_Banco.UseVisualStyleBackColor = true
        '
        'cheque_Banco_Codigo
        '
        Me.cheque_Banco_Codigo.Enabled = false
        Me.cheque_Banco_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cheque_Banco_Codigo.Location = New System.Drawing.Point(417, 76)
        Me.cheque_Banco_Codigo.Name = "cheque_Banco_Codigo"
        Me.cheque_Banco_Codigo.Size = New System.Drawing.Size(24, 24)
        Me.cheque_Banco_Codigo.TabIndex = 27
        Me.cheque_Banco_Codigo.Visible = false
        '
        'cheque_Banco
        '
        Me.cheque_Banco.Enabled = false
        Me.cheque_Banco.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cheque_Banco.Location = New System.Drawing.Point(336, 42)
        Me.cheque_Banco.Name = "cheque_Banco"
        Me.cheque_Banco.Size = New System.Drawing.Size(184, 24)
        Me.cheque_Banco.TabIndex = 26
        '
        'cheque_txt_condicionPago_Codigo
        '
        Me.cheque_txt_condicionPago_Codigo.Enabled = false
        Me.cheque_txt_condicionPago_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cheque_txt_condicionPago_Codigo.Location = New System.Drawing.Point(369, 76)
        Me.cheque_txt_condicionPago_Codigo.Name = "cheque_txt_condicionPago_Codigo"
        Me.cheque_txt_condicionPago_Codigo.Size = New System.Drawing.Size(24, 24)
        Me.cheque_txt_condicionPago_Codigo.TabIndex = 25
        Me.cheque_txt_condicionPago_Codigo.Visible = false
        '
        'btn_CondicionPago
        '
        Me.btn_CondicionPago.Location = New System.Drawing.Point(526, 11)
        Me.btn_CondicionPago.Name = "btn_CondicionPago"
        Me.btn_CondicionPago.Size = New System.Drawing.Size(30, 23)
        Me.btn_CondicionPago.TabIndex = 24
        Me.btn_CondicionPago.Text = " ...."
        Me.btn_CondicionPago.UseVisualStyleBackColor = true
        '
        'chequetxtCondicionPago
        '
        Me.chequetxtCondicionPago.Enabled = false
        Me.chequetxtCondicionPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chequetxtCondicionPago.Location = New System.Drawing.Point(336, 12)
        Me.chequetxtCondicionPago.Name = "chequetxtCondicionPago"
        Me.chequetxtCondicionPago.Size = New System.Drawing.Size(184, 24)
        Me.chequetxtCondicionPago.TabIndex = 23
        '
        'cheque_txt_nroCuenta
        '
        Me.cheque_txt_nroCuenta.Enabled = false
        Me.cheque_txt_nroCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cheque_txt_nroCuenta.Location = New System.Drawing.Point(141, 69)
        Me.cheque_txt_nroCuenta.Name = "cheque_txt_nroCuenta"
        Me.cheque_txt_nroCuenta.Size = New System.Drawing.Size(159, 22)
        Me.cheque_txt_nroCuenta.TabIndex = 21
        Me.cheque_txt_nroCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = true
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label36.Location = New System.Drawing.Point(6, 75)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(77, 16)
        Me.Label36.TabIndex = 20
        Me.Label36.Text = "Nro. Cuenta"
        '
        'Label35
        '
        Me.Label35.AutoSize = true
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label35.Location = New System.Drawing.Point(267, 49)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(45, 16)
        Me.Label35.TabIndex = 18
        Me.Label35.Text = "Banco"
        '
        'Label34
        '
        Me.Label34.AutoSize = true
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label34.Location = New System.Drawing.Point(221, 16)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(117, 16)
        Me.Label34.TabIndex = 17
        Me.Label34.Text = "Condición de Pago"
        '
        'Label32
        '
        Me.Label32.AutoSize = true
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label32.Location = New System.Drawing.Point(3, 15)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(132, 16)
        Me.Label32.TabIndex = 12
        Me.Label32.Text = "Cantidad de Cheques"
        '
        'cheque_txt_rut
        '
        Me.cheque_txt_rut.Enabled = false
        Me.cheque_txt_rut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cheque_txt_rut.Location = New System.Drawing.Point(141, 40)
        Me.cheque_txt_rut.Name = "cheque_txt_rut"
        Me.cheque_txt_rut.Size = New System.Drawing.Size(84, 22)
        Me.cheque_txt_rut.TabIndex = 15
        '
        'Cheque_txt_Cantidad
        '
        Me.Cheque_txt_Cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Cheque_txt_Cantidad.Location = New System.Drawing.Point(141, 12)
        Me.Cheque_txt_Cantidad.Name = "Cheque_txt_Cantidad"
        Me.Cheque_txt_Cantidad.Size = New System.Drawing.Size(30, 22)
        Me.Cheque_txt_Cantidad.TabIndex = 13
        Me.Cheque_txt_Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.AutoSize = true
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label33.Location = New System.Drawing.Point(6, 46)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 16)
        Me.Label33.TabIndex = 14
        Me.Label33.Text = "Rut del Titular"
        '
        'Label31
        '
        Me.Label31.AutoSize = true
        Me.Label31.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label31.Location = New System.Drawing.Point(248, 3)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(116, 32)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Cheque"
        '
        'TabCreditoSteward
        '
        Me.TabCreditoSteward.Controls.Add(Me.Label63)
        Me.TabCreditoSteward.Controls.Add(Me.Label51)
        Me.TabCreditoSteward.Controls.Add(Me.txtCredito_OrdendeCompra)
        Me.TabCreditoSteward.Controls.Add(Me.Label42)
        Me.TabCreditoSteward.Controls.Add(Me.CreditoSteward_txt_Observacion)
        Me.TabCreditoSteward.Controls.Add(Me.txtCreditoRut)
        Me.TabCreditoSteward.Controls.Add(Me.Label44)
        Me.TabCreditoSteward.Location = New System.Drawing.Point(4, 22)
        Me.TabCreditoSteward.Name = "TabCreditoSteward"
        Me.TabCreditoSteward.Size = New System.Drawing.Size(598, 310)
        Me.TabCreditoSteward.TabIndex = 4
        Me.TabCreditoSteward.Text = "Crédito Steward"
        Me.TabCreditoSteward.UseVisualStyleBackColor = true
        '
        'Label63
        '
        Me.Label63.AutoSize = true
        Me.Label63.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label63.Location = New System.Drawing.Point(204, 4)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(226, 32)
        Me.Label63.TabIndex = 8
        Me.Label63.Text = "Crédito Steward"
        '
        'Label51
        '
        Me.Label51.AutoSize = true
        Me.Label51.Location = New System.Drawing.Point(34, 75)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(93, 13)
        Me.Label51.TabIndex = 7
        Me.Label51.Text = "Orden de Compra:"
        '
        'txtCredito_OrdendeCompra
        '
        Me.txtCredito_OrdendeCompra.Location = New System.Drawing.Point(140, 72)
        Me.txtCredito_OrdendeCompra.Name = "txtCredito_OrdendeCompra"
        Me.txtCredito_OrdendeCompra.Size = New System.Drawing.Size(100, 20)
        Me.txtCredito_OrdendeCompra.TabIndex = 6
        Me.txtCredito_OrdendeCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.AutoSize = true
        Me.Label42.Location = New System.Drawing.Point(46, 126)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(81, 13)
        Me.Label42.TabIndex = 5
        Me.Label42.Text = "Observaciones:"
        '
        'CreditoSteward_txt_Observacion
        '
        Me.CreditoSteward_txt_Observacion.Location = New System.Drawing.Point(140, 98)
        Me.CreditoSteward_txt_Observacion.Multiline = true
        Me.CreditoSteward_txt_Observacion.Name = "CreditoSteward_txt_Observacion"
        Me.CreditoSteward_txt_Observacion.Size = New System.Drawing.Size(437, 103)
        Me.CreditoSteward_txt_Observacion.TabIndex = 4
        '
        'txtCreditoRut
        '
        Me.txtCreditoRut.Enabled = false
        Me.txtCreditoRut.Location = New System.Drawing.Point(140, 40)
        Me.txtCreditoRut.Name = "txtCreditoRut"
        Me.txtCreditoRut.Size = New System.Drawing.Size(100, 20)
        Me.txtCreditoRut.TabIndex = 3
        '
        'Label44
        '
        Me.Label44.AutoSize = true
        Me.Label44.Location = New System.Drawing.Point(100, 46)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(27, 13)
        Me.Label44.TabIndex = 2
        Me.Label44.Text = "Rut:"
        '
        'TabDirecciones
        '
        Me.TabDirecciones.Controls.Add(Me.btn_Flete_Ingresar)
        Me.TabDirecciones.Controls.Add(Me.txtDirección_Flete)
        Me.TabDirecciones.Controls.Add(Me.Label52)
        Me.TabDirecciones.Controls.Add(Me.Direcciones_Combo_Despacho)
        Me.TabDirecciones.Controls.Add(Me.Label25)
        Me.TabDirecciones.Controls.Add(Me.Label23)
        Me.TabDirecciones.Location = New System.Drawing.Point(4, 22)
        Me.TabDirecciones.Name = "TabDirecciones"
        Me.TabDirecciones.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDirecciones.Size = New System.Drawing.Size(598, 310)
        Me.TabDirecciones.TabIndex = 6
        Me.TabDirecciones.Text = "Despacho"
        Me.TabDirecciones.UseVisualStyleBackColor = true
        '
        'btn_Flete_Ingresar
        '
        Me.btn_Flete_Ingresar.Location = New System.Drawing.Point(286, 178)
        Me.btn_Flete_Ingresar.Name = "btn_Flete_Ingresar"
        Me.btn_Flete_Ingresar.Size = New System.Drawing.Size(148, 34)
        Me.btn_Flete_Ingresar.TabIndex = 10
        Me.btn_Flete_Ingresar.Text = "Ingresar"
        Me.btn_Flete_Ingresar.UseVisualStyleBackColor = true
        '
        'txtDirección_Flete
        '
        Me.txtDirección_Flete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDirección_Flete.Location = New System.Drawing.Point(139, 133)
        Me.txtDirección_Flete.Name = "txtDirección_Flete"
        Me.txtDirección_Flete.Size = New System.Drawing.Size(176, 26)
        Me.txtDirección_Flete.TabIndex = 9
        '
        'Label52
        '
        Me.Label52.AutoSize = true
        Me.Label52.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label52.Location = New System.Drawing.Point(46, 137)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(87, 18)
        Me.Label52.TabIndex = 8
        Me.Label52.Text = " Valor Flete"
        '
        'Direcciones_Combo_Despacho
        '
        Me.Direcciones_Combo_Despacho.DisplayMember = "Descripcion"
        Me.Direcciones_Combo_Despacho.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Direcciones_Combo_Despacho.FormattingEnabled = true
        Me.Direcciones_Combo_Despacho.Location = New System.Drawing.Point(139, 94)
        Me.Direcciones_Combo_Despacho.Name = "Direcciones_Combo_Despacho"
        Me.Direcciones_Combo_Despacho.Size = New System.Drawing.Size(436, 26)
        Me.Direcciones_Combo_Despacho.TabIndex = 7
        Me.Direcciones_Combo_Despacho.ValueMember = "Codigo"
        '
        'Label25
        '
        Me.Label25.AutoSize = true
        Me.Label25.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label25.Location = New System.Drawing.Point(58, 99)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(75, 18)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Dirección"
        '
        'Label23
        '
        Me.Label23.AutoSize = true
        Me.Label23.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label23.Location = New System.Drawing.Point(241, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(146, 32)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Despacho"
        '
        'TabTransferencia
        '
        Me.TabTransferencia.Controls.Add(Me.Label64)
        Me.TabTransferencia.Controls.Add(Me.GroupBox5)
        Me.TabTransferencia.Location = New System.Drawing.Point(4, 22)
        Me.TabTransferencia.Name = "TabTransferencia"
        Me.TabTransferencia.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTransferencia.Size = New System.Drawing.Size(598, 310)
        Me.TabTransferencia.TabIndex = 7
        Me.TabTransferencia.Text = "Transferencia"
        Me.TabTransferencia.UseVisualStyleBackColor = true
        '
        'Label64
        '
        Me.Label64.AutoSize = true
        Me.Label64.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label64.Location = New System.Drawing.Point(153, 3)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(319, 32)
        Me.Label64.TabIndex = 24
        Me.Label64.Text = "Transferencia Bancaria"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txt_transferencia_codigobanco)
        Me.GroupBox5.Controls.Add(Me.btn_transferencia_Banco)
        Me.GroupBox5.Controls.Add(Me.txt_Transferencia_Banco)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.txtTransferenciaObservaciones)
        Me.GroupBox5.Controls.Add(Me.Label50)
        Me.GroupBox5.Controls.Add(Me.txtTransferenciaNro)
        Me.GroupBox5.Controls.Add(Me.txtTransferenciaRut)
        Me.GroupBox5.Controls.Add(Me.Label49)
        Me.GroupBox5.Controls.Add(Me.TransferenciaFecha)
        Me.GroupBox5.Controls.Add(Me.Label48)
        Me.GroupBox5.Controls.Add(Me.txtTransferenciaNombre)
        Me.GroupBox5.Controls.Add(Me.Label47)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(64, 59)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(478, 242)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = false
        Me.GroupBox5.Text = "Transferencia Bancaria"
        '
        'txt_transferencia_codigobanco
        '
        Me.txt_transferencia_codigobanco.Enabled = false
        Me.txt_transferencia_codigobanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txt_transferencia_codigobanco.Location = New System.Drawing.Point(386, 113)
        Me.txt_transferencia_codigobanco.Name = "txt_transferencia_codigobanco"
        Me.txt_transferencia_codigobanco.Size = New System.Drawing.Size(34, 22)
        Me.txt_transferencia_codigobanco.TabIndex = 31
        Me.txt_transferencia_codigobanco.Visible = false
        '
        'btn_transferencia_Banco
        '
        Me.btn_transferencia_Banco.Location = New System.Drawing.Point(339, 113)
        Me.btn_transferencia_Banco.Name = "btn_transferencia_Banco"
        Me.btn_transferencia_Banco.Size = New System.Drawing.Size(33, 23)
        Me.btn_transferencia_Banco.TabIndex = 30
        Me.btn_transferencia_Banco.Text = "..."
        Me.btn_transferencia_Banco.UseVisualStyleBackColor = true
        '
        'txt_Transferencia_Banco
        '
        Me.txt_Transferencia_Banco.Enabled = false
        Me.txt_Transferencia_Banco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txt_Transferencia_Banco.Location = New System.Drawing.Point(128, 114)
        Me.txt_Transferencia_Banco.Name = "txt_Transferencia_Banco"
        Me.txt_Transferencia_Banco.Size = New System.Drawing.Size(205, 22)
        Me.txt_Transferencia_Banco.TabIndex = 29
        '
        'Label40
        '
        Me.Label40.AutoSize = true
        Me.Label40.Location = New System.Drawing.Point(6, 92)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(116, 16)
        Me.Label40.TabIndex = 28
        Me.Label40.Text = "Nro Transferencia"
        '
        'Label37
        '
        Me.Label37.AutoSize = true
        Me.Label37.Location = New System.Drawing.Point(6, 119)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(47, 16)
        Me.Label37.TabIndex = 24
        Me.Label37.Text = "Banco"
        '
        'txtTransferenciaObservaciones
        '
        Me.txtTransferenciaObservaciones.Enabled = false
        Me.txtTransferenciaObservaciones.Location = New System.Drawing.Point(128, 178)
        Me.txtTransferenciaObservaciones.Multiline = true
        Me.txtTransferenciaObservaciones.Name = "txtTransferenciaObservaciones"
        Me.txtTransferenciaObservaciones.Size = New System.Drawing.Size(304, 57)
        Me.txtTransferenciaObservaciones.TabIndex = 26
        '
        'Label50
        '
        Me.Label50.AutoSize = true
        Me.Label50.Location = New System.Drawing.Point(6, 194)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(103, 16)
        Me.Label50.TabIndex = 25
        Me.Label50.Text = "Observaciones:"
        '
        'txtTransferenciaNro
        '
        Me.txtTransferenciaNro.Enabled = false
        Me.txtTransferenciaNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTransferenciaNro.Location = New System.Drawing.Point(128, 86)
        Me.txtTransferenciaNro.Name = "txtTransferenciaNro"
        Me.txtTransferenciaNro.Size = New System.Drawing.Size(205, 22)
        Me.txtTransferenciaNro.TabIndex = 23
        '
        'txtTransferenciaRut
        '
        Me.txtTransferenciaRut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTransferenciaRut.Location = New System.Drawing.Point(128, 27)
        Me.txtTransferenciaRut.Name = "txtTransferenciaRut"
        Me.txtTransferenciaRut.Size = New System.Drawing.Size(205, 22)
        Me.txtTransferenciaRut.TabIndex = 16
        '
        'Label49
        '
        Me.Label49.AutoSize = true
        Me.Label49.Location = New System.Drawing.Point(6, 151)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(107, 16)
        Me.Label49.TabIndex = 21
        Me.Label49.Text = "Fecha Deposito:"
        '
        'TransferenciaFecha
        '
        Me.TransferenciaFecha.Enabled = false
        Me.TransferenciaFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransferenciaFecha.Location = New System.Drawing.Point(128, 145)
        Me.TransferenciaFecha.Name = "TransferenciaFecha"
        Me.TransferenciaFecha.Size = New System.Drawing.Size(101, 22)
        Me.TransferenciaFecha.TabIndex = 22
        '
        'Label48
        '
        Me.Label48.AutoSize = true
        Me.Label48.Location = New System.Drawing.Point(6, 58)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(60, 16)
        Me.Label48.TabIndex = 20
        Me.Label48.Text = "Nombre:"
        '
        'txtTransferenciaNombre
        '
        Me.txtTransferenciaNombre.Enabled = false
        Me.txtTransferenciaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTransferenciaNombre.Location = New System.Drawing.Point(128, 58)
        Me.txtTransferenciaNombre.Name = "txtTransferenciaNombre"
        Me.txtTransferenciaNombre.Size = New System.Drawing.Size(205, 22)
        Me.txtTransferenciaNombre.TabIndex = 17
        '
        'Label47
        '
        Me.Label47.AutoSize = true
        Me.Label47.Location = New System.Drawing.Point(5, 27)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(31, 16)
        Me.Label47.TabIndex = 19
        Me.Label47.Text = "Rut:"
        '
        'TabSinPago
        '
        Me.TabSinPago.Location = New System.Drawing.Point(4, 22)
        Me.TabSinPago.Name = "TabSinPago"
        Me.TabSinPago.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSinPago.Size = New System.Drawing.Size(598, 310)
        Me.TabSinPago.TabIndex = 8
        Me.TabSinPago.UseVisualStyleBackColor = true
        '
        'TabNotaCredito
        '
        Me.TabNotaCredito.Controls.Add(Me.Label65)
        Me.TabNotaCredito.Controls.Add(Me.grillaNotasCredito)
        Me.TabNotaCredito.Controls.Add(Me.btn_Limpiar)
        Me.TabNotaCredito.Controls.Add(Me.btnNotaActualizar)
        Me.TabNotaCredito.Controls.Add(Me.txtNota_nro_nota_Credito)
        Me.TabNotaCredito.Controls.Add(Me.Label61)
        Me.TabNotaCredito.Location = New System.Drawing.Point(4, 22)
        Me.TabNotaCredito.Name = "TabNotaCredito"
        Me.TabNotaCredito.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNotaCredito.Size = New System.Drawing.Size(598, 310)
        Me.TabNotaCredito.TabIndex = 9
        Me.TabNotaCredito.Text = "Nota Credito"
        Me.TabNotaCredito.UseVisualStyleBackColor = true
        '
        'Label65
        '
        Me.Label65.AutoSize = true
        Me.Label65.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label65.Location = New System.Drawing.Point(191, 3)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(221, 32)
        Me.Label65.TabIndex = 7
        Me.Label65.Text = "Nota de Crédito"
        '
        'grillaNotasCredito
        '
        Me.grillaNotasCredito.AllowUserToAddRows = false
        Me.grillaNotasCredito.AllowUserToDeleteRows = false
        Me.grillaNotasCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grillaNotasCredito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Quitar})
        Me.grillaNotasCredito.Location = New System.Drawing.Point(87, 112)
        Me.grillaNotasCredito.Name = "grillaNotasCredito"
        Me.grillaNotasCredito.ReadOnly = true
        Me.grillaNotasCredito.Size = New System.Drawing.Size(428, 150)
        Me.grillaNotasCredito.TabIndex = 6
        '
        'Quitar
        '
        Me.Quitar.HeaderText = "Quitar"
        Me.Quitar.Image = Global.pos_Steward.My.Resources.Resources.borrar
        Me.Quitar.Name = "Quitar"
        Me.Quitar.ReadOnly = true
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Location = New System.Drawing.Point(402, 74)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(113, 32)
        Me.btn_Limpiar.TabIndex = 5
        Me.btn_Limpiar.Text = "Limpiar"
        Me.btn_Limpiar.UseVisualStyleBackColor = true
        '
        'btnNotaActualizar
        '
        Me.btnNotaActualizar.Location = New System.Drawing.Point(321, 74)
        Me.btnNotaActualizar.Name = "btnNotaActualizar"
        Me.btnNotaActualizar.Size = New System.Drawing.Size(75, 32)
        Me.btnNotaActualizar.TabIndex = 4
        Me.btnNotaActualizar.Text = "Ingresar"
        Me.btnNotaActualizar.UseVisualStyleBackColor = true
        '
        'txtNota_nro_nota_Credito
        '
        Me.txtNota_nro_nota_Credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNota_nro_nota_Credito.Location = New System.Drawing.Point(209, 77)
        Me.txtNota_nro_nota_Credito.Name = "txtNota_nro_nota_Credito"
        Me.txtNota_nro_nota_Credito.Size = New System.Drawing.Size(100, 24)
        Me.txtNota_nro_nota_Credito.TabIndex = 1
        '
        'Label61
        '
        Me.Label61.AutoSize = true
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label61.Location = New System.Drawing.Point(84, 80)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(121, 18)
        Me.Label61.TabIndex = 0
        Me.Label61.Text = "Nro Nota Credito"
        '
        'TabTransbank
        '
        Me.TabTransbank.Controls.Add(Me.tbkTipo)
        Me.TabTransbank.Controls.Add(Me.Button4)
        Me.TabTransbank.Controls.Add(Me.tbkTarjeta)
        Me.TabTransbank.Controls.Add(Me.Label69)
        Me.TabTransbank.Controls.Add(Me.tbkCuotas)
        Me.TabTransbank.Controls.Add(Me.tbkAutorizacion)
        Me.TabTransbank.Controls.Add(Me.Label66)
        Me.TabTransbank.Controls.Add(Me.tbkOperacion)
        Me.TabTransbank.Controls.Add(Me.Label67)
        Me.TabTransbank.Controls.Add(Me.Label68)
        Me.TabTransbank.Controls.Add(Me.Button3)
        Me.TabTransbank.Location = New System.Drawing.Point(4, 22)
        Me.TabTransbank.Name = "TabTransbank"
        Me.TabTransbank.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTransbank.Size = New System.Drawing.Size(598, 310)
        Me.TabTransbank.TabIndex = 10
        Me.TabTransbank.Text = "Transbank"
        Me.TabTransbank.UseVisualStyleBackColor = true
        '
        'tbkTipo
        '
        Me.tbkTipo.Location = New System.Drawing.Point(483, 267)
        Me.tbkTipo.Name = "tbkTipo"
        Me.tbkTipo.Size = New System.Drawing.Size(100, 20)
        Me.tbkTipo.TabIndex = 23
        Me.tbkTipo.Visible = false
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 272)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(98, 32)
        Me.Button4.TabIndex = 22
        Me.Button4.Text = "Anular cobro"
        Me.Button4.UseVisualStyleBackColor = true
        '
        'tbkTarjeta
        '
        Me.tbkTarjeta.Enabled = false
        Me.tbkTarjeta.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tbkTarjeta.Location = New System.Drawing.Point(267, 179)
        Me.tbkTarjeta.MaxLength = 8
        Me.tbkTarjeta.Name = "tbkTarjeta"
        Me.tbkTarjeta.Size = New System.Drawing.Size(123, 26)
        Me.tbkTarjeta.TabIndex = 21
        Me.tbkTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label69
        '
        Me.Label69.AutoSize = true
        Me.Label69.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label69.Location = New System.Drawing.Point(197, 184)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(54, 18)
        Me.Label69.TabIndex = 20
        Me.Label69.Text = "Tarjeta"
        '
        'tbkCuotas
        '
        Me.tbkCuotas.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tbkCuotas.Location = New System.Drawing.Point(356, 76)
        Me.tbkCuotas.Name = "tbkCuotas"
        Me.tbkCuotas.Size = New System.Drawing.Size(34, 26)
        Me.tbkCuotas.TabIndex = 19
        Me.tbkCuotas.Text = "0"
        Me.tbkCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbkAutorizacion
        '
        Me.tbkAutorizacion.Enabled = false
        Me.tbkAutorizacion.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tbkAutorizacion.Location = New System.Drawing.Point(267, 147)
        Me.tbkAutorizacion.MaxLength = 8
        Me.tbkAutorizacion.Name = "tbkAutorizacion"
        Me.tbkAutorizacion.Size = New System.Drawing.Size(123, 26)
        Me.tbkAutorizacion.TabIndex = 18
        Me.tbkAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label66
        '
        Me.Label66.AutoSize = true
        Me.Label66.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label66.Location = New System.Drawing.Point(120, 154)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(131, 18)
        Me.Label66.TabIndex = 17
        Me.Label66.Text = "Cod. Autorización"
        '
        'tbkOperacion
        '
        Me.tbkOperacion.Enabled = false
        Me.tbkOperacion.Font = New System.Drawing.Font("Arial Narrow", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tbkOperacion.Location = New System.Drawing.Point(267, 111)
        Me.tbkOperacion.MaxLength = 8
        Me.tbkOperacion.Name = "tbkOperacion"
        Me.tbkOperacion.Size = New System.Drawing.Size(123, 26)
        Me.tbkOperacion.TabIndex = 16
        Me.tbkOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label67
        '
        Me.Label67.AutoSize = true
        Me.Label67.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label67.Location = New System.Drawing.Point(137, 115)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(114, 18)
        Me.Label67.TabIndex = 15
        Me.Label67.Text = "Nro. Operación"
        '
        'Label68
        '
        Me.Label68.AutoSize = true
        Me.Label68.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label68.Location = New System.Drawing.Point(134, 80)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(117, 18)
        Me.Label68.TabIndex = 14
        Me.Label68.Text = "Numero Cuotas"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(292, 211)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 32)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Enviar cobro"
        Me.Button3.UseVisualStyleBackColor = true
        '
        'List_Descuentos
        '
        Me.List_Descuentos.FormattingEnabled = true
        Me.List_Descuentos.Location = New System.Drawing.Point(9, 509)
        Me.List_Descuentos.Name = "List_Descuentos"
        Me.List_Descuentos.Size = New System.Drawing.Size(61, 17)
        Me.List_Descuentos.TabIndex = 21
        Me.List_Descuentos.Visible = false
        '
        'btn_Pendientes
        '
        Me.btn_Pendientes.Image = Global.pos_Steward.My.Resources.Resources.find_doc
        Me.btn_Pendientes.Location = New System.Drawing.Point(936, 364)
        Me.btn_Pendientes.Name = "btn_Pendientes"
        Me.btn_Pendientes.Size = New System.Drawing.Size(71, 56)
        Me.btn_Pendientes.TabIndex = 40
        Me.btn_Pendientes.UseVisualStyleBackColor = true
        '
        'lblItemsDetalle
        '
        Me.lblItemsDetalle.AutoSize = true
        Me.lblItemsDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblItemsDetalle.Location = New System.Drawing.Point(988, 274)
        Me.lblItemsDetalle.Name = "lblItemsDetalle"
        Me.lblItemsDetalle.Size = New System.Drawing.Size(12, 15)
        Me.lblItemsDetalle.TabIndex = 39
        Me.lblItemsDetalle.Text = "-"
        '
        'lblLineasDetalle
        '
        Me.lblLineasDetalle.AutoSize = true
        Me.lblLineasDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblLineasDetalle.Location = New System.Drawing.Point(989, 257)
        Me.lblLineasDetalle.Name = "lblLineasDetalle"
        Me.lblLineasDetalle.Size = New System.Drawing.Size(12, 15)
        Me.lblLineasDetalle.TabIndex = 38
        Me.lblLineasDetalle.Text = "-"
        '
        'btnDetalle
        '
        Me.btnDetalle.Image = CType(resources.GetObject("btnDetalle.Image"),System.Drawing.Image)
        Me.btnDetalle.Location = New System.Drawing.Point(937, 486)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(71, 59)
        Me.btnDetalle.TabIndex = 35
        Me.btnDetalle.UseVisualStyleBackColor = true
        '
        'Label55
        '
        Me.Label55.AutoSize = true
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label55.Location = New System.Drawing.Point(936, 275)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(40, 16)
        Me.Label55.TabIndex = 37
        Me.Label55.Text = "Items"
        '
        'Label24
        '
        Me.Label24.AutoSize = true
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label24.Location = New System.Drawing.Point(936, 255)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(48, 16)
        Me.Label24.TabIndex = 36
        Me.Label24.Text = "Lineas"
        '
        'btnPagar
        '
        Me.btnPagar.Enabled = false
        Me.btnPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnPagar.Location = New System.Drawing.Point(938, 623)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(69, 71)
        Me.btnPagar.TabIndex = 33
        Me.btnPagar.Text = "Pagar"
        Me.btnPagar.UseVisualStyleBackColor = true
        '
        'btnCerrarCompra
        '
        Me.btnCerrarCompra.Enabled = false
        Me.btnCerrarCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnCerrarCompra.Location = New System.Drawing.Point(937, 550)
        Me.btnCerrarCompra.Name = "btnCerrarCompra"
        Me.btnCerrarCompra.Size = New System.Drawing.Size(71, 68)
        Me.btnCerrarCompra.TabIndex = 32
        Me.btnCerrarCompra.Text = "Medio de Pago"
        Me.btnCerrarCompra.UseVisualStyleBackColor = true
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = false
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"),System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(937, 425)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(70, 56)
        Me.btnGuardar.TabIndex = 31
        Me.btnGuardar.UseVisualStyleBackColor = true
        '
        'btn_Emision_Documentos
        '
        Me.btn_Emision_Documentos.Image = Global.pos_Steward.My.Resources.Resources.icono_clientes2
        Me.btn_Emision_Documentos.Location = New System.Drawing.Point(937, 302)
        Me.btn_Emision_Documentos.Name = "btn_Emision_Documentos"
        Me.btn_Emision_Documentos.Size = New System.Drawing.Size(71, 56)
        Me.btn_Emision_Documentos.TabIndex = 34
        Me.btn_Emision_Documentos.UseVisualStyleBackColor = true
        '
        'Pos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 703)
        Me.ControlBox = false
        Me.Controls.Add(Me.btn_Pendientes)
        Me.Controls.Add(Me.lblItemsDetalle)
        Me.Controls.Add(Me.lblLineasDetalle)
        Me.Controls.Add(Me.btnDetalle)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.btnPagar)
        Me.Controls.Add(Me.btnCerrarCompra)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btn_Emision_Documentos)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.TabControlCabecera)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "Pos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS STEWARD"
        CType(Me.Efectivo_err_Monto,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.XmlNodeBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabControlCabecera.ResumeLayout(false)
        Me.TabCabeceraPrincipal.ResumeLayout(false)
        Me.TabCabeceraPrincipal.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox9.ResumeLayout(false)
        Me.GroupBox9.PerformLayout
        CType(Me.PictureBox7,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.TabAplicaPago.ResumeLayout(false)
        Me.TabAplicaPago.PerformLayout
        Me.GroupBox11.ResumeLayout(false)
        Me.GroupBox11.PerformLayout
        Me.GroupBox10.ResumeLayout(false)
        CType(Me.abonoGridDocumentos,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox8.ResumeLayout(false)
        Me.GroupBox8.PerformLayout
        Me.TabControl.ResumeLayout(false)
        Me.TabArticulos.ResumeLayout(false)
        Me.TabArticulos.PerformLayout
        CType(Me.gridDetalle,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox6,System.ComponentModel.ISupportInitialize).EndInit
        Me.txt_Debito_Banco.ResumeLayout(false)
        Me.GroupBox6.ResumeLayout(false)
        Me.GroupBox6.PerformLayout
        CType(Me.PictureBox9,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox8,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabMedioPago.ResumeLayout(false)
        Me.TabDebito.ResumeLayout(false)
        Me.TabDebito.PerformLayout
        Me.TabCredito.ResumeLayout(false)
        Me.TabCredito.PerformLayout
        Me.btn_Condicion_Pago.ResumeLayout(false)
        Me.btn_Condicion_Pago.PerformLayout
        CType(Me.cheque_grid_cheque,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox7.ResumeLayout(false)
        Me.GroupBox7.PerformLayout
        Me.TabCreditoSteward.ResumeLayout(false)
        Me.TabCreditoSteward.PerformLayout
        Me.TabDirecciones.ResumeLayout(false)
        Me.TabDirecciones.PerformLayout
        Me.TabTransferencia.ResumeLayout(false)
        Me.TabTransferencia.PerformLayout
        Me.GroupBox5.ResumeLayout(false)
        Me.GroupBox5.PerformLayout
        Me.TabNotaCredito.ResumeLayout(false)
        Me.TabNotaCredito.PerformLayout
        CType(Me.grillaNotasCredito,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabTransbank.ResumeLayout(false)
        Me.TabTransbank.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents XmlNodeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Efectivo_err_Monto As System.Windows.Forms.ErrorProvider
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents btn_Pendientes As System.Windows.Forms.Button
    Friend WithEvents lblItemsDetalle As System.Windows.Forms.Label
    Friend WithEvents lblLineasDetalle As System.Windows.Forms.Label
    Friend WithEvents btnDetalle As System.Windows.Forms.Button
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnPagar As System.Windows.Forms.Button
    Friend WithEvents btnCerrarCompra As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btn_Emision_Documentos As System.Windows.Forms.Button
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabArticulos As System.Windows.Forms.TabPage
    Friend WithEvents Cantidad As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioIva As System.Windows.Forms.TextBox
    Friend WithEvents gridDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents descuento_ As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Eliminar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txtCodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents txtUm As System.Windows.Forms.TextBox
    Friend WithEvents txt_Debito_Banco As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNotaCredito As System.Windows.Forms.Button
    Friend WithEvents txtResumenNotaCredito As System.Windows.Forms.TextBox
    Friend WithEvents txtResumenSinPago As System.Windows.Forms.TextBox
    Friend WithEvents btn_sin_Pago As System.Windows.Forms.Button
    Friend WithEvents txtResumenDespacho As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents btnDespacho As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtResumenTransferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTMEDIOPAGO As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtResumenCheque As System.Windows.Forms.TextBox
    Friend WithEvents txtVuelto As System.Windows.Forms.TextBox
    Friend WithEvents txtPagado As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtResumenCredito As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtResumenCreditoSteward As System.Windows.Forms.TextBox
    Friend WithEvents btnCompraEfectivo As System.Windows.Forms.Button
    Friend WithEvents txtResumenEfectivo As System.Windows.Forms.TextBox
    Friend WithEvents btn_Credito_Steward As System.Windows.Forms.Button
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCompraDebito As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Compra_credito As System.Windows.Forms.Button
    Friend WithEvents txtResumenDebito As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCompraCheque As System.Windows.Forms.Button
    Friend WithEvents TabMedioPago As System.Windows.Forms.TabControl
    Friend WithEvents TabEfectivo As System.Windows.Forms.TabPage
    Friend WithEvents TabDebito As System.Windows.Forms.TabPage
    Friend WithEvents debito_btn_popup_banco As System.Windows.Forms.Button
    Friend WithEvents debito_codigo_banco As System.Windows.Forms.TextBox
    Friend WithEvents debito_Banco As System.Windows.Forms.TextBox
    Friend WithEvents Debito_txt_Codigo_Autorizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents debito_txtNroOperacion As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TabCredito As System.Windows.Forms.TabPage
    Friend WithEvents btn_Popup_TipoTarjeta As System.Windows.Forms.Button
    Friend WithEvents btn_popup_Banco As System.Windows.Forms.Button
    Friend WithEvents credito_txt_codigo_tipoTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents credito_txt_tipotarjeta As System.Windows.Forms.TextBox
    Friend WithEvents creditotxtCodigoBanco As System.Windows.Forms.TextBox
    Friend WithEvents credito_txt_banco As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditoTerminoPago As System.Windows.Forms.TextBox
    Friend WithEvents txtCuotasCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents credito_txt_CodAutorizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents credito_txt_nro_operacion As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btn_Condicion_Pago As System.Windows.Forms.TabPage
    Friend WithEvents cheque_grid_cheque As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cheque_btn_Banco As System.Windows.Forms.Button
    Friend WithEvents cheque_Banco_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents cheque_Banco As System.Windows.Forms.TextBox
    Friend WithEvents cheque_txt_condicionPago_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents btn_CondicionPago As System.Windows.Forms.Button
    Friend WithEvents chequetxtCondicionPago As System.Windows.Forms.TextBox
    Friend WithEvents cheque_txt_nroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cheque_txt_rut As System.Windows.Forms.TextBox
    Friend WithEvents Cheque_txt_Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TabCreditoSteward As System.Windows.Forms.TabPage
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtCredito_OrdendeCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents CreditoSteward_txt_Observacion As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditoRut As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents TabDirecciones As System.Windows.Forms.TabPage
    Friend WithEvents btn_Flete_Ingresar As System.Windows.Forms.Button
    Friend WithEvents txtDirección_Flete As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Direcciones_Combo_Despacho As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TabTransferencia As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_transferencia_codigobanco As System.Windows.Forms.TextBox
    Friend WithEvents btn_transferencia_Banco As System.Windows.Forms.Button
    Friend WithEvents txt_Transferencia_Banco As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtTransferenciaObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtTransferenciaNro As System.Windows.Forms.TextBox
    Friend WithEvents txtTransferenciaRut As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TransferenciaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtTransferenciaNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TabSinPago As System.Windows.Forms.TabPage
    Friend WithEvents TabNotaCredito As System.Windows.Forms.TabPage
    Friend WithEvents grillaNotasCredito As System.Windows.Forms.DataGridView
    Friend WithEvents Quitar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btnNotaActualizar As System.Windows.Forms.Button
    Friend WithEvents txtNota_nro_nota_Credito As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents List_Descuentos As System.Windows.Forms.ListBox
    Friend WithEvents TabControlCabecera As System.Windows.Forms.TabControl
    Friend WithEvents TabCabeceraPrincipal As System.Windows.Forms.TabPage
    Friend WithEvents btn_CopiaXML As System.Windows.Forms.Button
    Friend WithEvents txtNroCaja As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDireccionesDespacho As System.Windows.Forms.Button
    Friend WithEvents txtNombreDireccionDespacho As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoDirecciónDespacho As System.Windows.Forms.TextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents chkOferta As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPorcentajeDescuento As System.Windows.Forms.TextBox
    Friend WithEvents btn_Descuento_Cabesera As System.Windows.Forms.Button
    Friend WithEvents btnEstudiante As System.Windows.Forms.Button
    Friend WithEvents btnDireccionesFacturacion As System.Windows.Forms.Button
    Friend WithEvents txtNombreDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoDirección As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionVendedorAsignado As System.Windows.Forms.TextBox
    Friend WithEvents txtListaPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoVendedorAsignado As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarVendedor As System.Windows.Forms.Button
    Friend WithEvents txtCodigoVendedor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRut As System.Windows.Forms.TextBox
    Friend WithEvents lblCampoBusquedaRut As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDetalleDescuento As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtFinal As System.Windows.Forms.TextBox
    Friend WithEvents lblSaldo1 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents txtIva As System.Windows.Forms.TextBox
    Friend WithEvents txtBruto As System.Windows.Forms.TextBox
    Friend WithEvents lblSaldo2 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_RecuperaDocu As System.Windows.Forms.Button
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevaBoleta As System.Windows.Forms.Button
    Friend WithEvents btnNuevaVenta As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnCierreCaja As System.Windows.Forms.Button
    Friend WithEvents TabAplicaPago As System.Windows.Forms.TabPage
    Friend WithEvents btnEmision As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents abono_TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents abono_TxtRut As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents abonoGridDocumentos As System.Windows.Forms.DataGridView
    Friend WithEvents TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaldoXPagar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents abono_total As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents abono_iva As System.Windows.Forms.TextBox
    Friend WithEvents abono_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents lblFechaDocumento As System.Windows.Forms.Label
    Friend WithEvents Label63 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents checkTBK As CheckBox
    Friend WithEvents btnDebitoCredito As Button
    Friend WithEvents TabTransbank As TabPage
    Friend WithEvents tbkTarjeta As TextBox
    Friend WithEvents Label69 As Label
    Friend WithEvents tbkCuotas As TextBox
    Friend WithEvents tbkAutorizacion As TextBox
    Friend WithEvents Label66 As Label
    Friend WithEvents tbkOperacion As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents txtResumenDebitoCredito As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents tbkTipo As TextBox
End Class
