Imports Microsoft.VisualBasic
Imports System.Xml
Imports StewardLib


Public Class VentaController

    Dim objclienteC As New ClientesController
    Dim objEmpresaC As New EmpresaController
    Dim objDocumentoVenta As New DocumentosVentaController
    Dim wsRecibeVenta As New wsBrowse.Pws0049
    Dim objtrans As New STWSTrans

    Public Function EJECUTAVENTA(ByVal objventa As VentaObj) As Boolean

        Dim valor As Boolean = False

        Dim arregloDirecciones As ArrayList = objclienteC.GetDireccionesTodas("STE", "10")
        Dim clientesC As New ClientesController()
        Dim arrdirecciones As ArrayList = clientesC.GetDireccionesTodas("STE", "10")


        'Dim objperfil As PerfilClienteObj = clientesC.GetPerfil("STE", "1")
        Dim objcontactocliente As ArrayList = clientesC.GetContacto("STE", "1")
        Dim objCajas As ArrayList = objEmpresaC.GetCajas("STE")
        Dim objTipoTransporte As ArrayList = objEmpresaC.GetTipoTransporte("STE")
        Dim objarticulos As ArrayList = objventa.ListaArticulos




        '*************************** DocumentoPago
        '
        Dim DocumentoPago_pos As String = objventa.codigo_Post
        Dim DocumentoPago_empresa As String = objventa.Codigo_Empresa
        ' ?duda valor cliente
        Dim DocumentoPago_cliente As String =  objtrans.LimpiaRut (  objventa.Cod_Cliente)
        Dim DocumentoPago_fcreacion As String = objventa.FechaSistema
        Dim DocumentoPago_hcreacion As String = objventa.HoraSistema
        Dim DocumentoPago_motivo As String = "Traspaso de Pos"
        Dim DocumentoPago_monto As String = objventa.total
        Dim DocumentoPago_caja As String = objventa.CajaRecepcion
        'sede de vitacura, obj.GetSedes("STE")
        Dim DocumentoPago_Sede As String = objventa.Sede
        'duda?
        Dim DocumentoPago_usuario As String = ""

        Dim DocumentoPago_Ultlineavoucher As String = "0"
        Dim DocumentoPago_Ultlineapresupuesto As String = "0"
        ' puede ser V1, V2,V3
        Dim DocumentoModalidad_Indicador As String = "V1"

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
        Dim cargo_vencto As String = objventa.FechaSistema ' fecha emision segun browse
        Dim cargo_cuenta As String = "0" ' a la espera de preguntar si puede ir en null
        '500  duda?
        Dim cargo_lista_precio As String = objventa.Lista
        Dim cargo_contacto As String = ""
        Dim cargo_vendedor As String = objventa.CodigoVendedor  'codigo vendedor
        Dim cargo_cgestion_vendedor As String = objventa.Cgestionvendedor
        Dim cargo_direccion_despacho As String = "888" ' por ahora se incluye este código, que es una entrega inemediata en caja
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
        Dim cargo_lineas_Condicion As String = objventa.ListaArticulos.Count.ToString
        'DESCUENTO DE CABESERA, DESCUENTO VALOR TOTAL EN PORCENTAJE
        Dim cargo_descuento2 As String = "0"
        Dim cargo_descuento3 As String = "0"
        ' CUANTO DEL TOTAL DEL DOCUMENTO VA A SER EXENTO
        Dim cargo_monto_exento As String = objventa.subtotal
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
        Dim cargo_concepto_venta As String = "10"
        Dim cargo_tipo_transporte As String = "99"
        'aca en cargo_Termino va el tipo de pago contado en cuotas etc. credito steward
        Dim cargo_termino As String = "1"
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

        'DocumentoPago_abono

        Dim Abono_documento As String = "EFEC"
        Dim Abono_folio As String = "00079999"
        Dim Abono_moneda As String = objventa.Moneda
        Dim Abono_cambio As String = "1"
        Dim Abono_banco As String = objventa.Banco
        Dim Abono_cuenta As String = ""
        Dim Abono_valor As String = objventa.total
        Dim Abono_emision As String = objventa.FechaSistema
        Dim Abono_vencto As String = objventa.FechaSistema
        Dim Abono_autorizador As String = ""
        Dim Abono_codigo As String = ""
        Dim Abono_tipo As String = ""
        Dim Abono_referencia As String = ""
        Dim Abono_terminal As String = ""
        Dim Abono_observacion As String = "prueba prueba"
        Dim Abono_lote As String = ""
        Dim Abono_punto As String = ""

        Dim objDocumentoPago As New DocumentoPago(DocumentoPago_pos, DocumentoPago_empresa, DocumentoPago_cliente, DocumentoPago_fcreacion, DocumentoPago_hcreacion, DocumentoPago_motivo, DocumentoPago_monto, DocumentoPago_caja, DocumentoPago_Sede, DocumentoPago_usuario, DocumentoPago_Ultlineavoucher, DocumentoPago_Ultlineapresupuesto, DocumentoModalidad_Indicador)

        Dim cargo_doc_timbrado As String = objDocumentoVenta.GrabaDocumento("aa", Date.Now)
        Dim objDocumentoPago_Cargo As New DocumentoPagoCargo(cargo_documento, cargo_doc_timbrado, cargo_moneda, cargo_cambio, cargo_saldo, cargo_abono, cargo_cambioAbono, cargo_vencto, _
        cargo_cuenta, cargo_lista_precio, cargo_contacto, cargo_vendedor, cargo_cgestion_vendedor, cargo_direccion_despacho, cargo_fono, cargo_direccion_facturacion, _
        cargo_nula, cargo_observaciones, cargo_lineas_articulo, cargo_ultima_guia, cargo_lineas_glosa, cargo_lineas_Contable, _
        cargo_lineas_Condicion, cargo_descuento2, cargo_descuento2, cargo_descuento3, cargo_monto_exento, cargo_monto_iva, cargo_indicador_tipo, _
        cargo_bodega, cargo_punto, cargo_saldo_documento, cargo_indicador_impresion, cargo_monto_credito, cargo_indicador_servip, cargo_indicador_movpendientes _
        , cargo_Folio_reparto, cargo_concepto_venta, cargo_tipo_transporte, cargo_termino, cargo_paridad_lista, cargo_ultlineapresupuesto, cargo_sucursal, cargo_glosa_facturacion)

        Dim contador As Integer = 0

        Dim arregloDocumentoPagoDetalle_Cargo As New ArrayList
        For Each objar As ArticuloObj In objarticulos
            contador = contador + 1
            Dim objDocumentoPago_detalle_cargo As New DocumentoPago_detalle_cargo(contador, objar.sku, objar.cantidad, objar.precio _
              , 0, objar.Envase, objar.precio, "1", "0" _
                  , 0, 0, 0)
            arregloDocumentoPagoDetalle_Cargo.Add(objDocumentoPago_detalle_cargo)
        Next

        Dim objDocumentoPago_detvarios_cargo As New DocumentoPago_detvarios_cargo(Cargo_detvarios_linea, Cargo_detvarios_glosa, Cargo_detvarios_precio_unitario _
          , Cargo_detvarios_cantidad, Cargo_detvarios_desctos, Cargo_detvarios_umedida, Cargo_detvarios_ultlinea, Cargo_detvarios_precio_bruto, Cargo_detvarios_ultlinea_detglo)

        Dim objDocumentoPago_impuesto_Cargo As New DocumentoPago_impuesto_cargo(Cargo_impuesto_codigo, Cargo_impuesto_valor)

        Dim objDocumentoPago_voucher_cargo As New DocumentoPago_voucher_cargo(Cargo_voucher_linea, Cargo_voucher_cuenta, Cargo_voucher_auxiliar, Cargo_voucher_debe _
                                                                              , Cargo_voucher_haber, Cargo_voucher_cgestion, Cargo_voucher_igestion, Cargo_voucher_sede, Cargo_voucher_glosa)
        Dim objDocumentoPago_ppto_cargo As New DocumentoPago_ppto_cargo(Cargo_ppto_linea, Cargo_ppto_cgestion, Cargo_ppto_cuenta, Cargo_ppto_igestion _
               , Cargo_ppto_devengado, Cargo_ppto_tipo_docto)

        Dim objDocumentoPago_abono As New DocumentoPago_abono(Abono_documento, Abono_folio, Abono_moneda, Abono_cambio, Abono_banco, Abono_cuenta, Abono_valor, Abono_emision, Abono_vencto _
                                                              , Abono_autorizador, Abono_codigo, Abono_tipo, Abono_referencia, Abono_terminal, Abono_observacion, Abono_lote, Abono_punto)

        Dim xmlvent As New VentaXML

        Dim doc As String = xmlvent.DocumentoPagoGetXML(objDocumentoPago, objDocumentoPago_Cargo, arregloDocumentoPagoDetalle_Cargo, objDocumentoPago_detvarios_cargo, objDocumentoPago_impuesto_Cargo, objDocumentoPago_voucher_cargo, objDocumentoPago_ppto_cargo, objDocumentoPago_abono)
        Dim docxml As New XmlDocument
        docxml.LoadXml(doc)
        docxml.Save("c:\megapruebas\megaxml.xml")
        Dim resultado As String = wsRecibeVenta.Execute(doc)




    End Function


End Class
