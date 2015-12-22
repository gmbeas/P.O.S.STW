Imports Microsoft.VisualBasic
Imports System.Xml

Public Class VentaXML



    Public Function DocumentoPagoGetXMLold(ByVal DocumentoPago_pos As String, _
                     ByVal DocumentoPago_Empresa As String, _
                     ByVal DocumentoPago_Cliente As String, _
                     ByVal DocumentoPago_fcreacion As String, _
                     ByVal DocumentoPago_hcreacion As String, _
                     ByVal DocumentoPago_motivo As String, _
                     ByVal DocumentoPago_Monto As String, _
                     ByVal DocumentoPago_Caja As String, _
                     ByVal DocumentoPago_Sede As String, _
                     ByVal DocumentoPago_Usuario As String, _
                     ByVal DocumentoPago_Ultlineavoucher As String, _
                     ByVal DocumentoPago_Ultlineapresupuesto As String, _
                     ByVal DocumentoModalidad_Indicador As String, _
                     ByVal Cargo_documento As String, _
                     ByVal Cargo_timbrado As String, _
                     ByVal Cargo_moneda As String, _
                     ByVal Cargo_cambio As String, _
                     ByVal Cargo_Saldo As String, _
                     ByVal Cargo_Abono As String, _
                     ByVal Cargo_cambioabono As String, _
                     ByVal Cargo_vencto As String, _
                     ByVal Cargo_cuenta As String, _
                     ByVal Cargo_lista_precio As String, _
                     ByVal Cargo_contacto As String, _
                     ByVal Cargo_vendedor As String, _
                     ByVal Cargo_direccion_despacho As String, _
                     ByVal Cargo_direccion_facturacion As String, _
                     ByVal Cargo_fono As String, _
                     ByVal Cargo_nula As String, _
                     ByVal Cargo_observaciones As String, _
                     ByVal Cargo_lineas_articulo As String _
                    ) As String


        Dim xmldoc As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<DocumentoPago>" & _
        "<DocumentoPago_Pos>" + DocumentoPago_pos + "</DocumentoPago_Pos>" & _
        "<DocumentoPago_Empresa>" + DocumentoPago_Empresa + "</DocumentoPago_Empresa>" & _
        "<DocumentoPago_Cliente>" + DocumentoPago_Cliente + "</DocumentoPago_Cliente>" & _
        "<DocumentoPago_fcreacion>" + DocumentoPago_fcreacion + "</DocumentoPago_fcreacion>" & _
        "<DocumentoPago_hcreacion>" + DocumentoPago_hcreacion + "</DocumentoPago_hcreacion>" & _
        "<DocumentoPago_motivo>" + DocumentoPago_motivo + "</DocumentoPago_motivo>" & _
        "<DocumentoPago_monto>" + DocumentoPago_Monto + "</DocumentoPago_monto>" & _
        "<DocumentoPago_Caja>" + DocumentoPago_Caja + "</DocumentoPago_Caja>" & _
        "<DocumentoPago_Sede>" + DocumentoPago_Sede + "</DocumentoPago_Sede>" & _
        "<DocumentoPago_Usuario>" + DocumentoPago_Usuario + "</DocumentoPago_Usuario>" & _
        "<DocumentoPago_Ultlineavoucher>" + DocumentoPago_Ultlineavoucher + "</DocumentoPago_Ultlineavoucher>" & _
        "<DocumentoPago_Ultlineapresupuesto>" + DocumentoPago_Ultlineapresupuesto + "</DocumentoPago_Ultlineapresupuesto>" & _
        "<DocumentoModalidad_Indicador>" + DocumentoModalidad_Indicador + "</DocumentoModalidad_Indicador>" & _
            "<DocumentoPago_cargo>" & _
                 "<Cargo_documento>" + Cargo_documento + "</Cargo_documento>" & _
                 "<Cargo_timbrado>" + Cargo_timbrado + "</Cargo_timbrado>" & _
                 "<Cargo_moneda>" + Cargo_moneda + "</Cargo_moneda> " & _
                 "<Cargo_cambio>" + Cargo_cambio + "</Cargo_cambio> " & _
                 "<Cargo_saldo>" + Cargo_Saldo + "</Cargo_saldo> " & _
                 "<Cargo_abono>" + Cargo_Abono + "</Cargo_abono> " & _
                 "<Cargo_cambioabono>" + Cargo_cambioabono + "</Cargo_cambioabono> " & _
                 "<Cargo_vencto>" + Cargo_vencto + "</Cargo_vencto> " & _
                 "<Cargo_cuenta>" + Cargo_cuenta + "</Cargo_cuenta> " & _
                 "<Cargo_lista_precio>" + Cargo_lista_precio + "</Cargo_lista_precio> " & _
                 "<Cargo_contacto>" + Cargo_contacto + "</Cargo_contacto> " & _
                 "<Cargo_vendedor>" + Cargo_vendedor + "</Cargo_vendedor> " & _
                 "<Cargo_direccion_despacho>" + Cargo_direccion_despacho + "</Cargo_direccion_despacho>" & _
                 "<Cargo_fono>" + Cargo_fono + "</Cargo_fono>" & _
                 "<Cargo_direccion_facturacion>" + Cargo_direccion_facturacion + "</Cargo_direccion_facturacion>" & _
                 "<Cargo_nula>" + Cargo_nula + "</Cargo_nula>" & _
                 "<Cargo_observaciones>" + Cargo_observaciones + "</Cargo_observaciones>" & _
                 "<Cargo_lineas_articulo>" + Cargo_lineas_articulo + "</Cargo_lineas_articulo>" & _
                 "<Cargo_ultima_guia>" + "" + "</Cargo_ultima_guia>" & _
                 "<Cargo_lineas_glosa>" + "" + "</Cargo_lineas_glosa>" & _
                 "<Cargo_lineas_contable>" + "" + "</Cargo_lineas_contable>" & _
                 "<Cargo_lineas_condicion>" + "" + "</Cargo_lineas_condicion>" & _
                 "<Cargo_descuento1>" + "a" + "</Cargo_descuento1>" & _
                 "<Cargo_descuento2>" + "a" + "</Cargo_descuento2>" & _
                 "<Cargo_descuento3>" + "a" + "</Cargo_descuento3>" & _
                 "<Cargo_monto_exento>" + "a" + "</Cargo_monto_exento>" & _
                 "<Cargo_monto_iva>" + "a" + "</Cargo_monto_iva>" & _
                 "<Cargo_indicador_tipo>" + "a" + "</Cargo_indicador_tipo>" & _
                 "<Cargo_bodega>" + "a" + "</Cargo_bodega>" & _
                 "<Cargo_punto>" + "a" + "</Cargo_punto>" & _
                 "<Cargo_saldo_documento>" + "a" + "</Cargo_saldo_documento>" & _
                 "<Cargo_indicador_impresion>" + "a" + "</Cargo_indicador_impresion>" & _
                 "<Cargo_monto_credito>" + "a" + "</Cargo_monto_credito>" & _
                 "<Cargo_indicador_servip>" + "a" + "</Cargo_indicador_servip>" & _
                 "<Cargo_indicador_movpendientes>" + "a" + "</Cargo_indicador_movpendientes>" & _
                 "<Cargo_folio_reparto>" + "a" + "</Cargo_folio_reparto>" & _
                 "<Cargo_concepto_venta>" + "a" + "</Cargo_concepto_venta>" & _
                 "<Cargo_tipo_transporte>" + "a" + "</Cargo_tipo_transporte>" & _
                 "<Cargo_paridad_lista>" + "a" + "</Cargo_paridad_lista>" & _
                 "<Cargo_termino>" + "a" + "</Cargo_termino>" & _
                 "<Cargo_paridad_lista>" + "a" + "</Cargo_paridad_lista>" & _
                 "<Cargo_ultlinea_presupuesto>" + "a" + "</Cargo_ultlinea_presupuesto>" & _
                 "<Cargo_sucursal>" + "a" + "</Cargo_sucursal> " & _
                 "<Cargo_glosa_facturacion>" + "a" + "</Cargo_glosa_facturacion>" & _
                 "<DocumentoPago_detalle_cargo>" & _
                            "<Cargo_detalle_linea>" + "a" + "</Cargo_detalle_linea>" & _
                            "<Cargo_detalle_articulo>" + "a" + "</Cargo_detalle_articulo>" & _
                            "<Cargo_detalle_cantidad_uvta>" + "a" + "</Cargo_detalle_cantidad_uvta>" & _
                            "<Cargo_detalle_precio_articulo>" + "a" + "</Cargo_detalle_precio_articulo>" & _
                            "<Cargo_detalle_descto_linea>" + "a" + "</Cargo_detalle_descto_linea>" & _
                            "<Cargo_detalle_indicador_envase>" + "a" + "</Cargo_detalle_indicador_envase>" & _
                            "<Cargo_detalle_precio_lista>" + "a" + "</Cargo_detalle_precio_lista>" & _
                            "<Cargo_detalle_paridad_documento>" + "a" + "</Cargo_detalle_paridad_documento>" & _
                            "<Cargo_detalle_tprecio_flete>" + "a" + "</Cargo_detalle_tprecio_flete>" & _
                            "<Cargo_detalle_descto_vol>" + "a" + "</Cargo_detalle_descto_vol>" & _
                            "<Cargo_detalle_descto_pago>" + "a" + "</Cargo_detalle_descto_pago>" & _
                            "<Cargo_detalle_descto_otros>" + "a" + "</Cargo_detalle_descto_otros>" & _
                 "</DocumentoPago_detalle_cargo>" & _
                 "<DocumentoPago_detvarios_cargo>" & _
                           "<Cargo_detalle_linea>" + "a" + "</Cargo_detalle_linea>" & _
                           "<Cargo_detvarios_glosa>" + "a" + "</Cargo_detvarios_glosa>" & _
                           "<Cargo_detvarios_precio_unitario>" + "a" + "</Cargo_detvarios_precio_unitario>" & _
                           "<Cargo_detvarios_cantidad>" + "a" + "</Cargo_detvarios_cantidad>" & _
                           "<Cargo_detvarios_desctos>" + "a" + "</Cargo_detvarios_desctos>" & _
                           "<Cargo_detvarios_umedida>" + "a" + "</Cargo_detvarios_umedida>" & _
                           "<Cargo_detvarios_ultlinea>" + "a" + "</Cargo_detvarios_ultlinea>" & _
                           "<Cargo_detvarios_precio_bruto>" + "a" + "</Cargo_detvarios_precio_bruto>" & _
                           "<Cargo_detvarios_ultlinea_detglo>" + "a" + "</Cargo_detvarios_ultlinea_detglo>" & _
                 "</DocumentoPago_detvarios_cargo>" & _
                 "<DocumentoPago_impuesto_cargo>" & _
                           "<Cargo_impuesto_codigo>" + "A" + "</Cargo_impuesto_codigo>" & _
                           "<Cargo_impuesto_valor>" + "A" + "</Cargo_impuesto_valor>" & _
                 "</DocumentoPago_impuesto_cargo>" & _
                 "<DocumentoPago_voucher_cargo>" & _
                           "<Cargo_voucher_linea>" + "A" + "</Cargo_voucher_linea>" & _
                           "<Cargo_voucher_cuenta>" + "A" + "</Cargo_voucher_cuenta>" & _
                           "<Cargo_voucher_auxiliar>" + "A" + "</Cargo_voucher_auxiliar>" & _
                           "<Cargo_voucher_debe>" + "A" + "</Cargo_voucher_debe>" & _
                           "<Cargo_voucher_haber>" + "A" + "</Cargo_voucher_haber>" & _
                           "<Cargo_voucher_cgestion>" + "A" + "</Cargo_voucher_cgestion>" & _
                           "<Cargo_voucher_igestion>" + "A" + "</Cargo_voucher_igestion>" & _
                           "<Cargo_voucher_sede>" + "A" + "</Cargo_voucher_sede>" & _
                           "<Cargo_voucher_glosa>" + "A" + "</Cargo_voucher_glosa>" & _
                 "</DocumentoPago_voucher_cargo>" & _
                 "<DocumentoPago_ppto_cargo> " & _
                           "<Cargo_ppto_linea>" + "A" + "</Cargo_ppto_linea>" & _
                           "<cargo_ppto_cgestion>" + "A" + "</cargo_ppto_cgestion>" & _
                           "<Cargo_ppto_cuenta>" + "A" + "</Cargo_ppto_cuenta>" & _
                           "<Cargo_ppto_igestion>" + "A" + "</Cargo_ppto_igestion>" & _
                           "<Cargo_ppto_devengado>" + "A" + "</Cargo_ppto_devengado>" & _
                           "<Cargo_ppto_tipo_docto>" + "A" + "</Cargo_ppto_tipo_docto>" & _
                           "<Cargo_ppto_numero_docto>" + "A" + "</Cargo_ppto_numero_docto>" & _
                 "</DocumentoPago_ppto_cargo>" & _
         "</DocumentoPago_cargo>" & _
         "<DocumentoPago_abono>" & _
                   "<Abono_documento>" + "A" + "</Abono_documento>" & _
                   "<Abono_folio>" + "A" + "</Abono_folio>" & _
                   "<Abono_moneda>" + "A" + "</Abono_moneda>" & _
                   "<Abono_cambio>" + "A" + "</Abono_cambio>" & _
                   "<Abono_banco>" + "A" + "</Abono_banco>" & _
                   "<Abono_cuenta>" + "A" + "</Abono_cuenta>" & _
                   "<Abono_valor>" + "A" + "</Abono_valor>" & _
                   "<Abono_emision>" + "A" + "</Abono_emision>" & _
                   "<Abono_vencto>" + "A" + "</Abono_vencto>" & _
                   "<Abono_autorizador>" + "A" + "</Abono_autorizador>" & _
                   "<Abono_codigo>" + "A" + "</Abono_codigo>" & _
                   "<Abono_referencia>" + "A" + "</Abono_referencia>" & _
                   "<Abono_terminal>" + "A" + "</Abono_terminal>" & _
                   "<Abono_observacion>" + "A" + "</Abono_observacion>" & _
                   "<Abono_lote>" + "A" + "</Abono_lote>" & _
                   "<Abono_punto>" + "A" + "</Abono_punto>" & _
         "</DocumentoPago_abono>" & _
        "</DocumentoPago>"



        Return xmldoc
    End Function
    Public Function DocumentoPagoGetXMLold2(ByVal dp As DocumentoPagox, ByVal dpc As DocumentoPagoCargo, ByVal dpcd As DocumentoPago_detalle_cargo, ByVal dpdvc As DocumentoPago_detvarios_cargo, ByVal Dpic As DocumentoPago_impuesto_cargo, ByVal dpvc As DocumentoPago_voucher_cargo, ByVal dpcc As DocumentoPago_ppto_cargo, ByVal dpa As DocumentoPago_abono) As String


        Dim xmldoc As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<DocumentoPago>" & _
        "<DocumentoPago_Pos>" + dp.DocumentoPago_pos + "</DocumentoPago_Pos>" & _
        "<DocumentoPago_Empresa>" + dp.DocumentoPago_Empresa + "</DocumentoPago_Empresa>" & _
        "<DocumentoPago_Cliente>" + dp.DocumentoPago_Cliente + "</DocumentoPago_Cliente>" & _
        "<DocumentoPago_fcreacion>" + dp.DocumentoPago_fcreacion + "</DocumentoPago_fcreacion>" & _
        "<DocumentoPago_hcreacion>" + dp.DocumentoPago_hcreacion + "</DocumentoPago_hcreacion>" & _
        "<DocumentoPago_motivo>" + dp.DocumentoPago_motivo + "</DocumentoPago_motivo>" & _
        "<DocumentoPago_monto>" + dp.DocumentoPago_Monto + "</DocumentoPago_monto>" & _
        "<DocumentoPago_Caja>" + dp.DocumentoPago_Caja + "</DocumentoPago_Caja>" & _
        "<DocumentoPago_Sede>" + dp.DocumentoPago_Sede + "</DocumentoPago_Sede>" & _
        "<DocumentoPago_Usuario>" + dp.DocumentoPago_Usuario + "</DocumentoPago_Usuario>" & _
        "<DocumentoPago_Ultlineavoucher>" + dp.DocumentoPago_Ultlineavoucher + "</DocumentoPago_Ultlineavoucher>" & _
        "<DocumentoPago_Ultlineapresupuesto>" + dp.DocumentoPago_Ultlineapresupuesto + "</DocumentoPago_Ultlineapresupuesto>" & _
        "<DocumentoModalidad_Indicador>" + dp.DocumentoModalidad_Indicador + "</DocumentoModalidad_Indicador>" & _
            "<DocumentoPago_cargo>" & _
                 "<Cargo_documento>" + dpc.Cargo_documento + "</Cargo_documento>" & _
                 "<Cargo_timbrado>" + dpc.Cargo_timbrado + "</Cargo_timbrado>" & _
                 "<Cargo_moneda>" + dpc.Cargo_moneda + "</Cargo_moneda> " & _
                 "<Cargo_cambio>" + dpc.Cargo_cambio + "</Cargo_cambio> " & _
                 "<Cargo_saldo>" + dpc.Cargo_saldo + "</Cargo_saldo> " & _
                 "<Cargo_abono>" + dpc.Cargo_abono + "</Cargo_abono> " & _
                 "<Cargo_cambioabono>" + dpc.Cargo_cambioabono + "</Cargo_cambioabono> " & _
                 "<Cargo_vencto>" + dpc.Cargo_vencto + "</Cargo_vencto> " & _
                 "<Cargo_cuenta>" + dpc.Cargo_cuenta + "</Cargo_cuenta> " & _
                 "<Cargo_lista_precio>" + dpc.Cargo_lista_precio + "</Cargo_lista_precio> " & _
                 "<Cargo_contacto>" + dpc.Cargo_contacto + "</Cargo_contacto> " & _
                 "<Cargo_vendedor>" + dpc.Cargo_vendedor + "</Cargo_vendedor> " & _
                 "<Cargo_direccion_despacho>" + dpc.Cargo_direccion_despacho + "</Cargo_direccion_despacho>" & _
                 "<Cargo_fono>" + dpc.Cargo_fono + "</Cargo_fono>" & _
                 "<Cargo_direccion_facturacion>" + dpc.Cargo_direccion_facturacion + "</Cargo_direccion_facturacion>" & _
                 "<Cargo_nula>" + dpc.Cargo_nula + "</Cargo_nula>" & _
                 "<Cargo_observaciones>" + dpc.Cargo_observaciones + "</Cargo_observaciones>" & _
                 "<Cargo_lineas_articulo>" + dpc.Cargo_lineas_articulo + "</Cargo_lineas_articulo>" & _
                 "<Cargo_ultima_guia>" + dpc.Cargo_ultima_guia + "</Cargo_ultima_guia>" & _
                 "<Cargo_lineas_glosa>" + dpc.Cargo_lineas_glosa + "</Cargo_lineas_glosa>" & _
                 "<Cargo_lineas_contable>" + dpc.Cargo_lineas_contable + "</Cargo_lineas_contable>" & _
                 "<Cargo_lineas_condicion>" + dpc.Cargo_lineas_condicion + "</Cargo_lineas_condicion>" & _
                 "<Cargo_descuento1>" + dpc.Cargo_descuento1 + "</Cargo_descuento1>" & _
                 "<Cargo_descuento2>" + dpc.Cargo_descuento2 + "</Cargo_descuento2>" & _
                 "<Cargo_descuento3>" + dpc.Cargo_descuento3 + "</Cargo_descuento3>" & _
                 "<Cargo_monto_exento>" + dpc.Cargo_monto_exento + "</Cargo_monto_exento>" & _
                 "<Cargo_monto_iva>" + dpc.Cargo_monto_iva + "</Cargo_monto_iva>" & _
                 "<Cargo_indicador_tipo>" + dpc.Cargo_indicador_tipo + "</Cargo_indicador_tipo>" & _
                 "<Cargo_bodega>" + dpc.Cargo_bodega + "</Cargo_bodega>" & _
                 "<Cargo_punto>" + dpc.Cargo_bodega + "</Cargo_punto>" & _
                 "<Cargo_saldo_documento>" + dpc.Cargo_saldo_documento + "</Cargo_saldo_documento>" & _
                 "<Cargo_indicador_impresion>" + dpc.Cargo_indicador_impresion + "</Cargo_indicador_impresion>" & _
                 "<Cargo_monto_credito>" + dpc.Cargo_monto_credito + "</Cargo_monto_credito>" & _
                 "<Cargo_indicador_servip>" + dpc.Cargo_indicador_servip + "</Cargo_indicador_servip>" & _
                 "<Cargo_indicador_movpendientes>" + dpc.Cargo_indicador_movpendientes + "</Cargo_indicador_movpendientes>" & _
                 "<Cargo_folio_reparto>" + dpc.Cargo_folio_reparto + "</Cargo_folio_reparto>" & _
                 "<Cargo_concepto_venta>" + dpc.Cargo_concepto_venta + "</Cargo_concepto_venta>" & _
                 "<Cargo_tipo_transporte>" + dpc.Cargo_tipo_transporte + "</Cargo_tipo_transporte>" & _
                 "<Cargo_paridad_lista>" + dpc.Cargo_paridad_lista + "</Cargo_paridad_lista>" & _
                 "<Cargo_termino>" + "a" + dpc.Cargo_termino + "</Cargo_termino>" & _
                 "<Cargo_paridad_lista>" + dpc.Cargo_paridad_lista + "</Cargo_paridad_lista>" & _
                 "<Cargo_ultlinea_presupuesto>" + dpc.Cargo_ultlinea_presupuesto + "</Cargo_ultlinea_presupuesto>" & _
                 "<Cargo_sucursal>" + dpc.Cargo_sucursal + "</Cargo_sucursal> " & _
                 "<Cargo_glosa_facturacion>" + dpc.Cargo_glosa_facturacion + "</Cargo_glosa_facturacion>" & _
                 "<DocumentoPago_detalle_cargo>" & _
                            "<Cargo_detalle_linea>" + dpcd.Cargo_detalle_linea + "</Cargo_detalle_linea>" & _
                            "<Cargo_detalle_articulo>" + dpcd.Cargo_detalle_articulo + "</Cargo_detalle_articulo>" & _
                            "<Cargo_detalle_cantidad_uvta>" + dpcd.Cargo_detalle_cantidad_uvta + "</Cargo_detalle_cantidad_uvta>" & _
                            "<Cargo_detalle_precio_articulo>" + dpcd.Cargo_detalle_precio_articulo + "</Cargo_detalle_precio_articulo>" & _
                            "<Cargo_detalle_descto_linea>" + dpcd.Cargo_detalle_descto_linea + "</Cargo_detalle_descto_linea>" & _
                            "<Cargo_detalle_indicador_envase>" + dpcd.Cargo_detalle_indicador_envase + "</Cargo_detalle_indicador_envase>" & _
                            "<Cargo_detalle_precio_lista>" + dpcd.Cargo_detalle_precio_lista + "</Cargo_detalle_precio_lista>" & _
                            "<Cargo_detalle_paridad_documento>" + dpcd.Cargo_detalle_paridad_documento + "</Cargo_detalle_paridad_documento>" & _
                            "<Cargo_detalle_tprecio_flete>" + dpcd.Cargo_detalle_tprecio_flete + "</Cargo_detalle_tprecio_flete>" & _
                            "<Cargo_detalle_Pdescto_vol>" + dpcd.Cargo_detalle_Pdescto_vol + "</Cargo_detalle_Pdescto_vol>" & _
                            "<Cargo_detalle_Pdescto_pago>" + dpcd.Cargo_detalle_Pdescto_pago + "</Cargo_detalle_Pdescto_pago>" & _
                            "<Cargo_detalle_Pdescto_otros>" + dpcd.Cargo_detalle_Pdescto_otros + "</Cargo_detalle_Pdescto_otros>" & _
                 "</DocumentoPago_detalle_cargo>" & _
                 "<DocumentoPago_detvarios_cargo>" & _
                           "<Cargo_detvarios_linea>" + dpdvc.Cargo_detvarios_linea + "</Cargo_detvarios_linea>" & _
                           "<Cargo_detvarios_glosa>" + dpdvc.Cargo_detvarios_glosa + "</Cargo_detvarios_glosa>" & _
                           "<Cargo_detvarios_precio_unitario>" + dpdvc.Cargo_detvarios_precio_unitario + "</Cargo_detvarios_precio_unitario>" & _
                           "<Cargo_detvarios_cantidad>" + dpdvc.Cargo_detvarios_cantidad + "</Cargo_detvarios_cantidad>" & _
                           "<Cargo_detvarios_desctos>" + dpdvc.Cargo_detvarios_desctos + "</Cargo_detvarios_desctos>" & _
                           "<Cargo_detvarios_umedida>" + dpdvc.Cargo_detvarios_umedida + "</Cargo_detvarios_umedida>" & _
                           "<Cargo_detvarios_ultlinea>" + dpdvc.Cargo_detvarios_ultlinea + "</Cargo_detvarios_ultlinea>" & _
                           "<Cargo_detvarios_precio_bruto>" + dpdvc.Cargo_detvarios_precio_bruto + "</Cargo_detvarios_precio_bruto>" & _
                           "<Cargo_detvarios_ultlinea_detglo>" + dpdvc.Cargo_detvarios_ultlinea_detglo + "</Cargo_detvarios_ultlinea_detglo>" & _
                 "</DocumentoPago_detvarios_cargo>" & _
                 "<DocumentoPago_impuesto_cargo>" & _
                           "<Cargo_impuesto_codigo>" + Dpic.Cargo_impuesto_codigo + "</Cargo_impuesto_codigo>" & _
                           "<Cargo_impuesto_valor>" + Dpic.Cargo_impuesto_valor + "</Cargo_impuesto_valor>" & _
                 "</DocumentoPago_impuesto_cargo>" & _
                 "<DocumentoPago_voucher_cargo>" & _
                           "<Cargo_voucher_linea>" + dpvc.Cargo_voucher_linea + "</Cargo_voucher_linea>" & _
                           "<Cargo_voucher_cuenta>" + dpvc.Cargo_voucher_cuenta + "</Cargo_voucher_cuenta>" & _
                           "<Cargo_voucher_auxiliar>" + dpvc.Cargo_voucher_auxiliar + "</Cargo_voucher_auxiliar>" & _
                           "<Cargo_voucher_debe>" + dpvc.Cargo_voucher_debe + "</Cargo_voucher_debe>" & _
                           "<Cargo_voucher_haber>" + dpvc.Cargo_voucher_haber + "</Cargo_voucher_haber>" & _
                           "<Cargo_voucher_cgestion>" + dpvc.Cargo_voucher_cgestion + "</Cargo_voucher_cgestion>" & _
                           "<Cargo_voucher_igestion>" + dpvc.Cargo_voucher_igestion + "</Cargo_voucher_igestion>" & _
                           "<Cargo_voucher_sede>" + dpvc.Cargo_voucher_sede + "</Cargo_voucher_sede>" & _
                           "<Cargo_voucher_glosa>" + dpvc.Cargo_voucher_glosa + "</Cargo_voucher_glosa>" & _
                 "</DocumentoPago_voucher_cargo>" & _
                 "<DocumentoPago_ppto_cargo> " & _
                           "<Cargo_ppto_linea>" + dpcc.Cargo_ppto_linea + "</Cargo_ppto_linea>" & _
                           "<cargo_ppto_cgestion>" + dpcc.Cargo_ppto_cgestion + "</cargo_ppto_cgestion>" & _
                           "<Cargo_ppto_cuenta>" + dpcc.Cargo_ppto_cuenta + "</Cargo_ppto_cuenta>" & _
                           "<Cargo_ppto_igestion>" + dpcc.Cargo_ppto_igestion + "</Cargo_ppto_igestion>" & _
                           "<Cargo_ppto_devengado>" + dpcc.Cargo_ppto_devengado + "</Cargo_ppto_devengado>" & _
                           "<Cargo_ppto_tipo_docto>" + dpcc.Cargo_ppto_tipo_docto + "</Cargo_ppto_tipo_docto>" & _
                           "<Cargo_ppto_numero_docto>" + dpcc.Cargo_ppto_numero_docto + "</Cargo_ppto_numero_docto>" & _
                 "</DocumentoPago_ppto_cargo>" & _
         "</DocumentoPago_cargo>" & _
         "<DocumentoPago_abono>" & _
                   "<Abono_documento>" + dpa.Abono_documento + "</Abono_documento>" & _
                   "<Abono_folio>" + dpa.Abono_folio + "</Abono_folio>" & _
                   "<Abono_moneda>" + dpa.Abono_moneda + "</Abono_moneda>" & _
                   "<Abono_cambio>" + dpa.Abono_cambio + "</Abono_cambio>" & _
                   "<Abono_banco>" + dpa.Abono_banco + "</Abono_banco>" & _
                   "<Abono_cuenta>" + dpa.Abono_cuenta + "</Abono_cuenta>" & _
                   "<Abono_valor>" + dpa.Abono_valor + "</Abono_valor>" & _
                   "<Abono_emision>" + dpa.Abono_emision + "</Abono_emision>" & _
                   "<Abono_vencto>" + dpa.Abono_vencto + "</Abono_vencto>" & _
                   "<Abono_autorizador>" + dpa.Abono_autorizador + "</Abono_autorizador>" & _
                   "<Abono_codigo>" + dpa.Abono_codigo + "</Abono_codigo>" & _
                   "<Abono_referencia>" + dpa.Abono_referencia + "</Abono_referencia>" & _
                   "<Abono_terminal>" + dpa.Abono_terminal + "</Abono_terminal>" & _
                   "<Abono_observacion>" + dpa.Abono_observacion + "</Abono_observacion>" & _
                   "<Abono_lote>" + dpa.Abono_lote + "</Abono_lote>" & _
                   "<Abono_punto>" + dpa.Abono_punto + "</Abono_punto>" & _
         "</DocumentoPago_abono>" & _
        "</DocumentoPago>"



        Return xmldoc
    End Function

    Public Function DocumentoPagoGetXML(ByVal dp As DocumentoPagox, ByVal dpc As DocumentoPagoCargo, ByVal dpcd As ArrayList, ByVal dpdvc As DocumentoPago_detvarios_cargo, ByVal Dpic As DocumentoPago_impuesto_cargo, ByVal dpvc As DocumentoPago_voucher_cargo, ByVal dpcc As DocumentoPago_ppto_cargo, ByVal dpaarr As ArrayList, ByVal Modalidad As String) As String
        Dim tagPago_detalle_cargo As String = ""
        Dim tag_condicion_cargo As String = ""

        Dim X As String = dpc.Cargo_bodega
        tagPago_detalle_cargo = tagPago_detalle_cargo & _
                                 "<DocumentoPago_detalle_cargo>"

        For Each objdpcd As DocumentoPago_detalle_cargo In dpcd

            Dim valorn As String = objdpcd.Cargo_detalle_indicador_envase
            tagPago_detalle_cargo = tagPago_detalle_cargo & _
                                   "<VtaCargoDet>" & _
                                   "<Cargo_detalle_linea>" + objdpcd.Cargo_detalle_linea + "</Cargo_detalle_linea>" & _
                                   "<Cargo_detalle_articulo>" + objdpcd.Cargo_detalle_articulo + "</Cargo_detalle_articulo>" & _
                                   "<Cargo_detalle_cantidad_uvta>" + objdpcd.Cargo_detalle_cantidad_uvta + "</Cargo_detalle_cantidad_uvta>" & _
                                   "<Cargo_detalle_precio_articulo>" + objdpcd.Cargo_detalle_precio_articulo + "</Cargo_detalle_precio_articulo>" & _
                                   "<Cargo_detalle_descto_linea>" + objdpcd.Cargo_detalle_descto_linea + "</Cargo_detalle_descto_linea>" & _
                                   "<Cargo_detalle_indicador_envase>" + objdpcd.Cargo_detalle_indicador_envase + "</Cargo_detalle_indicador_envase>" & _
                                   "<Cargo_detalle_precio_lista>" + objdpcd.Cargo_detalle_precio_lista + "</Cargo_detalle_precio_lista>" & _
                                   "<Cargo_detalle_paridad_documento>" + objdpcd.Cargo_detalle_paridad_documento + "</Cargo_detalle_paridad_documento>" & _
                                   "<Cargo_detalle_tprecio_flete>" + objdpcd.Cargo_detalle_tprecio_flete + "</Cargo_detalle_tprecio_flete>" & _
                                   "<Cargo_detalle_Pdescto_vol>" + objdpcd.Cargo_detalle_Pdescto_vol + "</Cargo_detalle_Pdescto_vol>" & _
                                   "<Cargo_detalle_Pdescto_pago>" + objdpcd.Cargo_detalle_Pdescto_pago + "</Cargo_detalle_Pdescto_pago>" & _
                                   "<Cargo_detalle_Pdescto_otros>" + objdpcd.Cargo_detalle_Pdescto_otros + "</Cargo_detalle_Pdescto_otros>" & _
                                   "<Cargo_detalle_UM>" + objdpcd.Cargo_Detalle_UnidaddeMedida + "</Cargo_detalle_UM>" & _
                                   "<Cargo_detalle_ubicacion>" + objdpcd.Cargo_detalle_ubicacion + "</Cargo_detalle_ubicacion>" & _
                                    "</VtaCargoDet>"
        Next
        tagPago_detalle_cargo = tagPago_detalle_cargo + "</DocumentoPago_detalle_cargo>"

        If Modalidad = "V3" Then
            tagPago_detalle_cargo = ""
        End If


        Dim DPagos As String = ""
        DPagos = "<DocumentoPago_abono>"
        For Each dpa As DocumentoPago_abono In dpaarr
            DPagos = DPagos & _
                      "<VtaPago>" & _
                                 "<Abono_documento>" + dpa.Abono_documento + "</Abono_documento>" & _
                                 "<Abono_folio>" + dpa.Abono_folio + "</Abono_folio>" & _
                                 "<Abono_moneda>" + dpa.Abono_moneda + "</Abono_moneda>" & _
                                 "<Abono_cambio>" + dpa.Abono_cambio + "</Abono_cambio>" & _
                                 "<Abono_banco>" + dpa.Abono_banco + "</Abono_banco>" & _
                                 "<Abono_cuenta>" + dpa.Abono_codigo + "</Abono_cuenta>" & _
                                 "<Abono_valor>" + dpa.Abono_valor + "</Abono_valor>" & _
                                 "<Abono_emision>" + dpa.Abono_emision + "</Abono_emision>" & _
                                 "<Abono_vencto>" + dpa.Abono_vencto + "</Abono_vencto>" & _
                                 "<Abono_autorizador>" + dpa.Abono_autorizador + "</Abono_autorizador>" & _
                                 "<Abono_codigo>" + dpa.Abono_codigo + "</Abono_codigo>" & _
                                 "<Abono_tipo>" + dpa.Abono_tipo + "</Abono_tipo>" & _
                                 "<Abono_referencia>" + dpa.Abono_referencia + "</Abono_referencia>" & _
                                 "<Abono_terminal>" + dpa.Abono_terminal + "</Abono_terminal>" & _
                                 "<Abono_observacion>" + dpa.Abono_observacion + "</Abono_observacion>" & _
                                 "<Abono_lote>" + dpa.Abono_lote + "</Abono_lote>" & _
                                 "<Abono_punto>" + dpa.Abono_punto + "</Abono_punto>" & _
                       "</VtaPago>"
        Next
        DPagos = DPagos & _
            "</DocumentoPago_abono>"




        If Modalidad = "V2" Then
            DPagos = ""
        End If



        Dim DpagoCargo As String
        If Modalidad <> "V3" Then

            DpagoCargo = "<DocumentoPago_cargo>" & _
                "<VtaCargo>" & _
                     "<Cargo_documento>" + dpc.Cargo_documento + "</Cargo_documento>" & _
                     "<Cargo_timbrado>" + dpc.Cargo_timbrado + "</Cargo_timbrado>" & _
                     "<Cargo_moneda>" + dpc.Cargo_moneda + "</Cargo_moneda> " & _
                     "<Cargo_cambio>" + dpc.Cargo_cambio + "</Cargo_cambio> " & _
                     "<Cargo_saldo>" + dpc.Cargo_saldo + "</Cargo_saldo> " & _
                     "<Cargo_abono>" + dpc.Cargo_abono + "</Cargo_abono> " & _
                     "<Cargo_cambioabono>" + dpc.Cargo_cambioabono + "</Cargo_cambioabono> " & _
                     "<Cargo_vencto>" + dpc.Cargo_vencto + "</Cargo_vencto> " & _
                     "<Cargo_cuenta>" + dpc.Cargo_cuenta + "</Cargo_cuenta> " & _
                     "<Cargo_lista_precio>" + dpc.Cargo_lista_precio + "</Cargo_lista_precio> "
            If dpc.Cargo_contacto <> "" Then
                DpagoCargo = DpagoCargo & _
                "<Cargo_contacto>" + dpc.Cargo_contacto + "</Cargo_contacto> "
            End If
            DpagoCargo = DpagoCargo & _
                     "<Cargo_vendedor>" + dpc.Cargo_vendedor + "</Cargo_vendedor> " & _
                     "<Cargo_cgestion_vendedor>" + dpc.Cargo_cgestion_vendedor + "</Cargo_cgestion_vendedor> " & _
                     "<Cargo_direccion_despacho>" + dpc.Cargo_direccion_despacho + "</Cargo_direccion_despacho>" & _
                     "<Cargo_fono>" + dpc.Cargo_fono + "</Cargo_fono>" & _
                     "<Cargo_direccion_facturacion>" + dpc.Cargo_direccion_facturacion + "</Cargo_direccion_facturacion>" & _
                     "<Cargo_nula>" + dpc.Cargo_nula + "</Cargo_nula>" & _
                     "<Cargo_observaciones>" + dpc.Cargo_observaciones + "</Cargo_observaciones>" & _
                     "<Cargo_lineas_articulo>" + dpc.Cargo_lineas_articulo + "</Cargo_lineas_articulo>" & _
                     "<Cargo_ultima_guia>" + dpc.Cargo_ultima_guia + "</Cargo_ultima_guia>" & _
                     "<Cargo_lineas_glosa>" + dpc.Cargo_lineas_glosa + "</Cargo_lineas_glosa>" & _
                     "<Cargo_lineas_contable>" + dpc.Cargo_lineas_contable + "</Cargo_lineas_contable>" & _
                     "<Cargo_lineas_condicion>" + dpc.Cargo_lineas_condicion + "</Cargo_lineas_condicion>" & _
                     "<Cargo_descuento1>" + dpc.Cargo_descuento1 + "</Cargo_descuento1>" & _
                     "<Cargo_descuento2>" + dpc.Cargo_descuento2 + "</Cargo_descuento2>" & _
                     "<Cargo_descuento3>" + dpc.Cargo_descuento3 + "</Cargo_descuento3>" & _
                     "<Cargo_monto_exento>" + dpc.Cargo_monto_exento + "</Cargo_monto_exento>" & _
                     "<Cargo_monto_iva>" + dpc.Cargo_monto_iva + "</Cargo_monto_iva>" & _
                     "<Cargo_indicador_tipo>" + dpc.Cargo_indicador_tipo + "</Cargo_indicador_tipo>" & _
                     "<Cargo_bodega>" + dpc.Cargo_bodega + "</Cargo_bodega>" & _
                     "<Cargo_punto>" + dpc.Cargo_punto + "</Cargo_punto>" & _
                     "<Cargo_saldo_documento>" + dpc.Cargo_saldo_documento + "</Cargo_saldo_documento>" & _
                     "<Cargo_indicador_impresion>" + dpc.Cargo_indicador_impresion + "</Cargo_indicador_impresion>" & _
                     "<Cargo_monto_credito>" + dpc.Cargo_monto_credito + "</Cargo_monto_credito>" & _
                     "<Cargo_indicador_servip>" + dpc.Cargo_indicador_servip + "</Cargo_indicador_servip>" & _
                     "<Cargo_indicador_movpendientes>" + dpc.Cargo_indicador_movpendientes + "</Cargo_indicador_movpendientes>" & _
                     "<Cargo_folio_reparto>" + dpc.Cargo_folio_reparto + "</Cargo_folio_reparto>" & _
                     "<Cargo_concepto_venta>" + dpc.Cargo_concepto_venta + "</Cargo_concepto_venta>" & _
                     "<Cargo_tipo_transporte>" + dpc.Cargo_tipo_transporte + "</Cargo_tipo_transporte>" & _
                     "<Cargo_termino>" + dpc.Cargo_termino + "</Cargo_termino>" & _
                     "<Cargo_paridad_lista>" + dpc.Cargo_paridad_lista + "</Cargo_paridad_lista>" & _
                     "<Cargo_ultlinea_presupuesto>" + dpc.Cargo_ultlinea_presupuesto + "</Cargo_ultlinea_presupuesto>"
            If dpc.Cargo_sucursal <> "" Then
                DpagoCargo = DpagoCargo & _
               "<Cargo_sucursal>" + dpc.Cargo_sucursal + "</Cargo_sucursal> "
            End If

            DpagoCargo = DpagoCargo & _
                     "<Cargo_glosa_facturacion>" + dpc.Cargo_glosa_facturacion + "</Cargo_glosa_facturacion>" & _
                       "" + tagPago_detalle_cargo + "" & _
                        "</VtaCargo>" & _
             "</DocumentoPago_cargo>"
        End If


        If Modalidad = "V3" Then
            DpagoCargo = DpagoCargo + "<DocumentoPago_cargo>"

            For Each doc_a As DocumentoObj In _DocumentosAplicarPago
                DpagoCargo = DpagoCargo + "<VtaCargo>" & _
                    "<Cargo_documento>" + doc_a.TipoDocumento + "</Cargo_documento>" & _
                         "<Cargo_timbrado>" + doc_a.Folio + "</Cargo_timbrado>" & _
                          "</VtaCargo>"

            Next

            DpagoCargo = DpagoCargo + "</DocumentoPago_cargo>"
        End If

        Dim xmldoc As String = "<DocumentoPago>" & _
        "<DocumentoPago_pos>" + dp.DocumentoPago_pos + "</DocumentoPago_pos>" & _
        "<DocumentoPago_empresa>" + dp.DocumentoPago_Empresa + "</DocumentoPago_empresa>" & _
        "<DocumentoPago_cliente>" + dp.DocumentoPago_Cliente + "</DocumentoPago_cliente>" & _
        "<DocumentoPago_fcreacion>" + dp.DocumentoPago_fcreacion + "</DocumentoPago_fcreacion>" & _
        "<DocumentoPago_hcreacion>" + dp.DocumentoPago_hcreacion + "</DocumentoPago_hcreacion>" & _
        "<DocumentoPago_motivo>" + dp.DocumentoPago_motivo + "</DocumentoPago_motivo>" & _
        "<DocumentoPago_monto>" + dp.DocumentoPago_Monto + "</DocumentoPago_monto>" & _
        "<DocumentoPago_caja>" + dp.DocumentoPago_Caja + "</DocumentoPago_caja>" & _
        "<DocumentoPago_sede>" + dp.DocumentoPago_Sede + "</DocumentoPago_sede>" & _
        "<DocumentoPago_usuario>" + dp.DocumentoPago_Usuario + "</DocumentoPago_usuario>" & _
        "<DocumentoPago_Ultlineavoucher>" + dp.DocumentoPago_Ultlineavoucher + "</DocumentoPago_Ultlineavoucher>" & _
        "<DocumentoPago_Ultlineapresupuesto>" + dp.DocumentoPago_Ultlineapresupuesto + "</DocumentoPago_Ultlineapresupuesto>" & _
        "<DocumentoModalidad_Indicador>" + dp.DocumentoModalidad_Indicador + "</DocumentoModalidad_Indicador>" & _
            DpagoCargo & _
        DPagos
        xmldoc = xmldoc & _
        "</DocumentoPago>"

        Return xmldoc
    End Function

#Region "DocumentoPagoGetXMLRespaldo NO SE USA"
    Public Function DocumentoPagoGetXMLRespaldo(ByVal dp As DocumentoPagox, ByVal dpc As DocumentoPagoCargo, ByVal dpcd As ArrayList, ByVal dpdvc As DocumentoPago_detvarios_cargo, ByVal Dpic As DocumentoPago_impuesto_cargo, ByVal dpvc As DocumentoPago_voucher_cargo, ByVal dpcc As DocumentoPago_ppto_cargo, ByVal dpaarr As ArrayList, ByVal Modalidad As String) As String

        Dim tagPago_detalle_cargo As String = ""
        Dim tag_condicion_cargo As String = ""

        Dim X As String = dpc.Cargo_bodega

        For Each objdpcd As DocumentoPago_detalle_cargo In dpcd

            Dim valorn As String = objdpcd.Cargo_detalle_indicador_envase
            tagPago_detalle_cargo = tagPago_detalle_cargo & _
                                   "<DocumentoPago_detalle_cargo>" & _
                                   "<Cargo_detalle_linea>" + objdpcd.Cargo_detalle_linea + "</Cargo_detalle_linea>" & _
                                   "<Cargo_detalle_articulo>" + objdpcd.Cargo_detalle_articulo + "</Cargo_detalle_articulo>" & _
                                   "<Cargo_detalle_cantidad_uvta>" + objdpcd.Cargo_detalle_cantidad_uvta + "</Cargo_detalle_cantidad_uvta>" & _
                                   "<Cargo_detalle_precio_articulo>" + objdpcd.Cargo_detalle_precio_articulo + "</Cargo_detalle_precio_articulo>" & _
                                   "<Cargo_detalle_descto_linea>" + objdpcd.Cargo_detalle_descto_linea + "</Cargo_detalle_descto_linea>" & _
                                   "<Cargo_detalle_indicador_envase>" + objdpcd.Cargo_detalle_indicador_envase + "</Cargo_detalle_indicador_envase>" & _
                                   "<Cargo_detalle_precio_lista>" + objdpcd.Cargo_detalle_precio_lista + "</Cargo_detalle_precio_lista>" & _
                                   "<Cargo_detalle_paridad_documento>" + objdpcd.Cargo_detalle_paridad_documento + "</Cargo_detalle_paridad_documento>" & _
                                   "<Cargo_detalle_tprecio_flete>" + objdpcd.Cargo_detalle_tprecio_flete + "</Cargo_detalle_tprecio_flete>" & _
                                   "<Cargo_detalle_Pdescto_vol>" + objdpcd.Cargo_detalle_Pdescto_vol + "</Cargo_detalle_Pdescto_vol>" & _
                                   "<Cargo_detalle_Pdescto_pago>" + objdpcd.Cargo_detalle_Pdescto_pago + "</Cargo_detalle_Pdescto_pago>" & _
                                   "<Cargo_detalle_Pdescto_otros>" + objdpcd.Cargo_detalle_Pdescto_otros + "</Cargo_detalle_Pdescto_otros>" & _
                                   "</DocumentoPago_detalle_cargo>"
        Next

        If Modalidad = "V3" Then
            tagPago_detalle_cargo = ""
        End If

        Dim xmldoc As String = "<DocumentoPago>" & _
        "<DocumentoPago_pos>" + dp.DocumentoPago_pos + "</DocumentoPago_pos>" & _
        "<DocumentoPago_empresa>" + dp.DocumentoPago_Empresa + "</DocumentoPago_empresa>" & _
        "<DocumentoPago_cliente>" + dp.DocumentoPago_Cliente + "</DocumentoPago_cliente>" & _
        "<DocumentoPago_fcreacion>" + dp.DocumentoPago_fcreacion + "</DocumentoPago_fcreacion>" & _
        "<DocumentoPago_hcreacion>" + dp.DocumentoPago_hcreacion + "</DocumentoPago_hcreacion>" & _
        "<DocumentoPago_motivo>" + dp.DocumentoPago_motivo + "</DocumentoPago_motivo>" & _
        "<DocumentoPago_monto>" + dp.DocumentoPago_Monto + "</DocumentoPago_monto>" & _
        "<DocumentoPago_caja>" + dp.DocumentoPago_Caja + "</DocumentoPago_caja>" & _
        "<DocumentoPago_sede>" + dp.DocumentoPago_Sede + "</DocumentoPago_sede>" & _
        "<DocumentoPago_usuario>" + dp.DocumentoPago_Usuario + "</DocumentoPago_usuario>" & _
        "<DocumentoPago_Ultlineavoucher>" + dp.DocumentoPago_Ultlineavoucher + "</DocumentoPago_Ultlineavoucher>" & _
        "<DocumentoPago_Ultlineapresupuesto>" + dp.DocumentoPago_Ultlineapresupuesto + "</DocumentoPago_Ultlineapresupuesto>" & _
        "<DocumentoModalidad_Indicador>" + dp.DocumentoModalidad_Indicador + "</DocumentoModalidad_Indicador>" & _
            "<DocumentoPago_cargo>" & _
                 "<Cargo_documento>" + dpc.Cargo_documento + "</Cargo_documento>" & _
                 "<Cargo_timbrado>" + dpc.Cargo_timbrado + "</Cargo_timbrado>" & _
                 "<Cargo_moneda>" + dpc.Cargo_moneda + "</Cargo_moneda> " & _
                 "<Cargo_cambio>" + dpc.Cargo_cambio + "</Cargo_cambio> " & _
                 "<Cargo_saldo>" + dpc.Cargo_saldo + "</Cargo_saldo> " & _
                 "<Cargo_abono>" + dpc.Cargo_abono + "</Cargo_abono> " & _
                 "<Cargo_cambioabono>" + dpc.Cargo_cambioabono + "</Cargo_cambioabono> " & _
                 "<Cargo_vencto>" + dpc.Cargo_vencto + "</Cargo_vencto> " & _
                 "<Cargo_cuenta>" + dpc.Cargo_cuenta + "</Cargo_cuenta> " & _
                 "<Cargo_lista_precio>" + dpc.Cargo_lista_precio + "</Cargo_lista_precio> "
        If dpc.Cargo_contacto <> "" Then
            xmldoc = xmldoc & _
            "<Cargo_contacto>" + dpc.Cargo_contacto + "</Cargo_contacto> "
        End If
        xmldoc = xmldoc & _
                 "<Cargo_vendedor>" + dpc.Cargo_vendedor + "</Cargo_vendedor> " & _
                 "<Cargo_direccion_despacho>" + dpc.Cargo_direccion_despacho + "</Cargo_direccion_despacho>" & _
                 "<Cargo_fono>" + dpc.Cargo_fono + "</Cargo_fono>" & _
                 "<Cargo_direccion_facturacion>" + dpc.Cargo_direccion_facturacion + "</Cargo_direccion_facturacion>" & _
                 "<Cargo_nula>" + dpc.Cargo_nula + "</Cargo_nula>" & _
                 "<Cargo_observaciones>" + dpc.Cargo_observaciones + "</Cargo_observaciones>" & _
                 "<Cargo_lineas_articulo>" + dpc.Cargo_lineas_articulo + "</Cargo_lineas_articulo>" & _
                 "<Cargo_ultima_guia>" + dpc.Cargo_ultima_guia + "</Cargo_ultima_guia>" & _
                 "<Cargo_lineas_glosa>" + dpc.Cargo_lineas_glosa + "</Cargo_lineas_glosa>" & _
                 "<Cargo_lineas_contable>" + dpc.Cargo_lineas_contable + "</Cargo_lineas_contable>" & _
                 "<Cargo_lineas_condicion>" + dpc.Cargo_lineas_condicion + "</Cargo_lineas_condicion>" & _
                 "<Cargo_descuento1>" + dpc.Cargo_descuento1 + "</Cargo_descuento1>" & _
                 "<Cargo_descuento2>" + dpc.Cargo_descuento2 + "</Cargo_descuento2>" & _
                 "<Cargo_descuento3>" + dpc.Cargo_descuento3 + "</Cargo_descuento3>" & _
                 "<Cargo_monto_exento>" + dpc.Cargo_monto_exento + "</Cargo_monto_exento>" & _
                 "<Cargo_monto_iva>" + dpc.Cargo_monto_iva + "</Cargo_monto_iva>" & _
                 "<Cargo_indicador_tipo>" + dpc.Cargo_indicador_tipo + "</Cargo_indicador_tipo>" & _
                 "<Cargo_bodega>" + dpc.Cargo_bodega + "</Cargo_bodega>" & _
                 "<Cargo_punto>" + dpc.Cargo_punto + "</Cargo_punto>" & _
                 "<Cargo_saldo_documento>" + dpc.Cargo_saldo_documento + "</Cargo_saldo_documento>" & _
                 "<Cargo_indicador_impresion>" + dpc.Cargo_indicador_impresion + "</Cargo_indicador_impresion>" & _
                 "<Cargo_monto_credito>" + dpc.Cargo_monto_credito + "</Cargo_monto_credito>" & _
                 "<Cargo_indicador_servip>" + dpc.Cargo_indicador_servip + "</Cargo_indicador_servip>" & _
                 "<Cargo_indicador_movpendientes>" + dpc.Cargo_indicador_movpendientes + "</Cargo_indicador_movpendientes>" & _
                 "<Cargo_folio_reparto>" + dpc.Cargo_folio_reparto + "</Cargo_folio_reparto>" & _
                 "<Cargo_concepto_venta>" + dpc.Cargo_concepto_venta + "</Cargo_concepto_venta>" & _
                 "<Cargo_tipo_transporte>" + dpc.Cargo_tipo_transporte + "</Cargo_tipo_transporte>" & _
                 "<Cargo_termino>" + dpc.Cargo_termino + "</Cargo_termino>" & _
                 "<Cargo_paridad_lista>" + dpc.Cargo_paridad_lista + "</Cargo_paridad_lista>" & _
                 "<Cargo_ultlinea_presupuesto>" + dpc.Cargo_ultlinea_presupuesto + "</Cargo_ultlinea_presupuesto>"
        If dpc.Cargo_sucursal <> "" Then
            xmldoc = xmldoc & _
           "<Cargo_sucursal>" + dpc.Cargo_sucursal + "</Cargo_sucursal> "
        End If

        xmldoc = xmldoc & _
                 "<Cargo_glosa_facturacion>" + dpc.Cargo_glosa_facturacion + "</Cargo_glosa_facturacion>" & _
                   +tagPago_detalle_cargo + "" & _
         "</DocumentoPago_cargo>"

        For Each dpa As DocumentoPago_abono In dpaarr
            xmldoc = xmldoc & _
           "<DocumentoPago_abono>" & _
                      "<Abono_documento>" + dpa.Abono_documento + "</Abono_documento>" & _
                      "<Abono_folio>" + dpa.Abono_folio + "</Abono_folio>" & _
                      "<Abono_moneda>" + dpa.Abono_moneda + "</Abono_moneda>" & _
                      "<Abono_cambio>" + dpa.Abono_cambio + "</Abono_cambio>" & _
                      "<Abono_banco>" + dpa.Abono_banco + "</Abono_banco>" & _
                      "<Abono_cuenta>" + dpa.Abono_cuenta + "</Abono_cuenta>" & _
                      "<Abono_valor>" + dpa.Abono_valor + "</Abono_valor>" & _
                      "<Abono_emision>" + dpa.Abono_emision + "</Abono_emision>" & _
                      "<Abono_vencto>" + dpa.Abono_vencto + "</Abono_vencto>" & _
                      "<Abono_autorizador>" + dpa.Abono_autorizador + "</Abono_autorizador>" & _
                      "<Abono_codigo>" + dpa.Abono_codigo + "</Abono_codigo>" & _
                      "<Abono_tipo>" + dpa.Abono_tipo + "</Abono_tipo>" & _
                      "<Abono_referencia>" + dpa.Abono_referencia + "</Abono_referencia>" & _
                      "<Abono_terminal>" + dpa.Abono_terminal + "</Abono_terminal>" & _
                      "<Abono_observacion>" + dpa.Abono_observacion + "</Abono_observacion>" & _
                      "<Abono_lote>" + dpa.Abono_lote + "</Abono_lote>" & _
                      "<Abono_punto>" + dpa.Abono_punto + "</Abono_punto>" & _
            "</DocumentoPago_abono>"
        Next

        xmldoc = xmldoc & _
        "</DocumentoPago>"



        Return xmldoc
    End Function
#End Region

    Public Function DocumentoPagoGetXMLAbonoAplica(ByVal dp As DocumentoPagox, ByVal dpc As DocumentoPagoCargo, ByVal dpcd As ArrayList, ByVal dpdvc As DocumentoPago_detvarios_cargo, ByVal Dpic As DocumentoPago_impuesto_cargo, ByVal dpvc As DocumentoPago_voucher_cargo, ByVal dpcc As DocumentoPago_ppto_cargo, ByVal dpaarr As ArrayList) As String


        Dim tag_condicion_cargo As String = ""

        Dim X As String = dpc.Cargo_bodega

        Dim docCargo As String = ""


        For Each doc_a As String In _DocumentosAplicarPago

            docCargo = docCargo + "<DocumentoPago_cargo>" & _
            "<Cargo_documento>" + "FAAF" + "</Cargo_documento>" & _
                 "<Cargo_timbrado>" + doc_a + "</Cargo_timbrado>" & _
            "</DocumentoPago_cargo>"
        Next

        Dim xmldoc As String = "<DocumentoPago>" & _
        "<DocumentoPago_pos>" + dp.DocumentoPago_pos + "</DocumentoPago_pos>" & _
        "<DocumentoPago_empresa>" + dp.DocumentoPago_Empresa + "</DocumentoPago_empresa>" & _
        "<DocumentoPago_cliente>" + dp.DocumentoPago_Cliente + "</DocumentoPago_cliente>" & _
        "<DocumentoPago_fcreacion>" + dp.DocumentoPago_fcreacion + "</DocumentoPago_fcreacion>" & _
        "<DocumentoPago_hcreacion>" + dp.DocumentoPago_hcreacion + "</DocumentoPago_hcreacion>" & _
        "<DocumentoPago_motivo>" + dp.DocumentoPago_motivo + "</DocumentoPago_motivo>" & _
        "<DocumentoPago_monto>" + dp.DocumentoPago_Monto + "</DocumentoPago_monto>" & _
        "<DocumentoPago_caja>" + dp.DocumentoPago_Caja + "</DocumentoPago_caja>" & _
        "<DocumentoPago_sede>" + dp.DocumentoPago_Sede + "</DocumentoPago_sede>" & _
        "<DocumentoPago_usuario>" + dp.DocumentoPago_Usuario + "</DocumentoPago_usuario>" & _
        "<DocumentoPago_Ultlineavoucher>" + dp.DocumentoPago_Ultlineavoucher + "</DocumentoPago_Ultlineavoucher>" & _
        "<DocumentoPago_Ultlineapresupuesto>" + dp.DocumentoPago_Ultlineapresupuesto + "</DocumentoPago_Ultlineapresupuesto>" & _
        "<DocumentoModalidad_Indicador>" + dp.DocumentoModalidad_Indicador + "</DocumentoModalidad_Indicador>" & _
        docCargo

        For Each dpa As DocumentoPago_abono In dpaarr
            xmldoc = xmldoc & _
           "<DocumentoPago_abono>" & _
                      "<Abono_documento>" + dpa.Abono_documento + "</Abono_documento>" & _
                      "<Abono_folio>" + dpa.Abono_folio + "</Abono_folio>" & _
                      "<Abono_moneda>" + dpa.Abono_moneda + "</Abono_moneda>" & _
                      "<Abono_cambio>" + dpa.Abono_cambio + "</Abono_cambio>" & _
                      "<Abono_banco>" + dpa.Abono_banco + "</Abono_banco>" & _
                      "<Abono_cuenta>" + dpa.Abono_cuenta + "</Abono_cuenta>" & _
                      "<Abono_valor>" + dpa.Abono_valor + "</Abono_valor>" & _
                      "<Abono_emision>" + dpa.Abono_emision + "</Abono_emision>" & _
                      "<Abono_vencto>" + dpa.Abono_vencto + "</Abono_vencto>" & _
                      "<Abono_autorizador>" + dpa.Abono_autorizador + "</Abono_autorizador>" & _
                      "<Abono_codigo>" + dpa.Abono_codigo + "</Abono_codigo>" & _
                      "<Abono_tipo>" + dpa.Abono_tipo + "</Abono_tipo>" & _
                      "<Abono_referencia>" + dpa.Abono_referencia + "</Abono_referencia>" & _
                      "<Abono_terminal>" + dpa.Abono_terminal + "</Abono_terminal>" & _
                      "<Abono_observacion>" + dpa.Abono_observacion + "</Abono_observacion>" & _
                      "<Abono_lote>" + dpa.Abono_lote + "</Abono_lote>" & _
                      "<Abono_punto>" + dpa.Abono_punto + "</Abono_punto>" & _
            "</DocumentoPago_abono>"
        Next

        xmldoc = xmldoc & _
        "</DocumentoPago>"



        Return xmldoc
    End Function
    Public Function DocumentoPagoGetXMLSinPago(ByVal dp As DocumentoPagox, ByVal dpc As DocumentoPagoCargo, ByVal dpcd As ArrayList, ByVal dpdvc As DocumentoPago_detvarios_cargo, ByVal Dpic As DocumentoPago_impuesto_cargo, ByVal dpvc As DocumentoPago_voucher_cargo, ByVal dpcc As DocumentoPago_ppto_cargo) As String

        Dim tagPago_detalle_cargo As String = ""
        Dim tag_condicion_cargo As String = ""

        Dim X As String = dpc.Cargo_bodega

        For Each objdpcd As DocumentoPago_detalle_cargo In dpcd

            Dim valorn As String = objdpcd.Cargo_detalle_indicador_envase
            tagPago_detalle_cargo = tagPago_detalle_cargo & _
                                   "<DocumentoPago_detalle_cargo>" & _
                                   "<Cargo_detalle_linea>" + objdpcd.Cargo_detalle_linea + "</Cargo_detalle_linea>" & _
                                   "<Cargo_detalle_articulo>" + objdpcd.Cargo_detalle_articulo + "</Cargo_detalle_articulo>" & _
                                   "<Cargo_detalle_cantidad_uvta>" + objdpcd.Cargo_detalle_cantidad_uvta + "</Cargo_detalle_cantidad_uvta>" & _
                                   "<Cargo_detalle_precio_articulo>" + objdpcd.Cargo_detalle_precio_articulo + "</Cargo_detalle_precio_articulo>" & _
                                   "<Cargo_detalle_descto_linea>" + objdpcd.Cargo_detalle_descto_linea + "</Cargo_detalle_descto_linea>" & _
                                   "<Cargo_detalle_indicador_envase>" + objdpcd.Cargo_detalle_indicador_envase + "</Cargo_detalle_indicador_envase>" & _
                                   "<Cargo_detalle_precio_lista>" + objdpcd.Cargo_detalle_precio_lista + "</Cargo_detalle_precio_lista>" & _
                                   "<Cargo_detalle_paridad_documento>" + objdpcd.Cargo_detalle_paridad_documento + "</Cargo_detalle_paridad_documento>" & _
                                   "<Cargo_detalle_tprecio_flete>" + objdpcd.Cargo_detalle_tprecio_flete + "</Cargo_detalle_tprecio_flete>" & _
                                   "<Cargo_detalle_Pdescto_vol>" + objdpcd.Cargo_detalle_Pdescto_vol + "</Cargo_detalle_Pdescto_vol>" & _
                                   "<Cargo_detalle_Pdescto_pago>" + objdpcd.Cargo_detalle_Pdescto_pago + "</Cargo_detalle_Pdescto_pago>" & _
                                   "<Cargo_detalle_Pdescto_otros>" + objdpcd.Cargo_detalle_Pdescto_otros + "</Cargo_detalle_Pdescto_otros>" & _
                                   "</DocumentoPago_detalle_cargo>"
        Next




        Dim xmldoc As String = "<DocumentoPago>" & _
        "<DocumentoPago_pos>" + dp.DocumentoPago_pos + "</DocumentoPago_pos>" & _
        "<DocumentoPago_empresa>" + dp.DocumentoPago_Empresa + "</DocumentoPago_empresa>" & _
        "<DocumentoPago_cliente>" + dp.DocumentoPago_Cliente + "</DocumentoPago_cliente>" & _
        "<DocumentoPago_fcreacion>" + dp.DocumentoPago_fcreacion + "</DocumentoPago_fcreacion>" & _
        "<DocumentoPago_hcreacion>" + dp.DocumentoPago_hcreacion + "</DocumentoPago_hcreacion>" & _
        "<DocumentoPago_motivo>" + dp.DocumentoPago_motivo + "</DocumentoPago_motivo>" & _
        "<DocumentoPago_monto>" + dp.DocumentoPago_Monto + "</DocumentoPago_monto>" & _
        "<DocumentoPago_caja>" + dp.DocumentoPago_Caja + "</DocumentoPago_caja>" & _
        "<DocumentoPago_sede>" + dp.DocumentoPago_Sede + "</DocumentoPago_sede>" & _
        "<DocumentoPago_usuario>" + dp.DocumentoPago_Usuario + "</DocumentoPago_usuario>" & _
        "<DocumentoPago_Ultlineavoucher>" + dp.DocumentoPago_Ultlineavoucher + "</DocumentoPago_Ultlineavoucher>" & _
        "<DocumentoPago_Ultlineapresupuesto>" + dp.DocumentoPago_Ultlineapresupuesto + "</DocumentoPago_Ultlineapresupuesto>" & _
        "<DocumentoModalidad_Indicador>" + dp.DocumentoModalidad_Indicador + "</DocumentoModalidad_Indicador>" & _
            "<DocumentoPago_cargo>" & _
                 "<Cargo_documento>" + dpc.Cargo_documento + "</Cargo_documento>" & _
                 "<Cargo_timbrado>" + dpc.Cargo_timbrado + "</Cargo_timbrado>" & _
                 "<Cargo_moneda>" + dpc.Cargo_moneda + "</Cargo_moneda> " & _
                 "<Cargo_cambio>" + dpc.Cargo_cambio + "</Cargo_cambio> " & _
                 "<Cargo_saldo>" + dpc.Cargo_saldo + "</Cargo_saldo> " & _
                 "<Cargo_abono>" + dpc.Cargo_abono + "</Cargo_abono> " & _
                 "<Cargo_cambioabono>" + dpc.Cargo_cambioabono + "</Cargo_cambioabono> " & _
                 "<Cargo_vencto>" + dpc.Cargo_vencto + "</Cargo_vencto> " & _
                 "<Cargo_cuenta>" + dpc.Cargo_cuenta + "</Cargo_cuenta> " & _
                 "<Cargo_lista_precio>" + dpc.Cargo_lista_precio + "</Cargo_lista_precio> "
        If dpc.Cargo_contacto <> "" Then
            xmldoc = xmldoc & _
            "<Cargo_contacto>" + dpc.Cargo_contacto + "</Cargo_contacto> "
        End If
        xmldoc = xmldoc & _
                 "<Cargo_vendedor>" + dpc.Cargo_vendedor + "</Cargo_vendedor> " & _
                 "<Cargo_direccion_despacho>" + dpc.Cargo_direccion_despacho + "</Cargo_direccion_despacho>" & _
                 "<Cargo_fono>" + dpc.Cargo_fono + "</Cargo_fono>" & _
                 "<Cargo_direccion_facturacion>" + dpc.Cargo_direccion_facturacion + "</Cargo_direccion_facturacion>" & _
                 "<Cargo_nula>" + dpc.Cargo_nula + "</Cargo_nula>" & _
                 "<Cargo_observaciones>" + dpc.Cargo_observaciones + "</Cargo_observaciones>" & _
                 "<Cargo_lineas_articulo>" + dpc.Cargo_lineas_articulo + "</Cargo_lineas_articulo>" & _
                 "<Cargo_ultima_guia>" + dpc.Cargo_ultima_guia + "</Cargo_ultima_guia>" & _
                 "<Cargo_lineas_glosa>" + dpc.Cargo_lineas_glosa + "</Cargo_lineas_glosa>" & _
                 "<Cargo_lineas_contable>" + dpc.Cargo_lineas_contable + "</Cargo_lineas_contable>" & _
                 "<Cargo_lineas_condicion>" + dpc.Cargo_lineas_condicion + "</Cargo_lineas_condicion>" & _
                 "<Cargo_descuento1>" + dpc.Cargo_descuento1 + "</Cargo_descuento1>" & _
                 "<Cargo_descuento2>" + dpc.Cargo_descuento2 + "</Cargo_descuento2>" & _
                 "<Cargo_descuento3>" + dpc.Cargo_descuento3 + "</Cargo_descuento3>" & _
                 "<Cargo_monto_exento>" + dpc.Cargo_monto_exento + "</Cargo_monto_exento>" & _
                 "<Cargo_monto_iva>" + dpc.Cargo_monto_iva + "</Cargo_monto_iva>" & _
                 "<Cargo_indicador_tipo>" + dpc.Cargo_indicador_tipo + "</Cargo_indicador_tipo>" & _
                 "<Cargo_bodega>" + dpc.Cargo_bodega + "</Cargo_bodega>" & _
                 "<Cargo_punto>" + dpc.Cargo_punto + "</Cargo_punto>" & _
                 "<Cargo_saldo_documento>" + dpc.Cargo_saldo_documento + "</Cargo_saldo_documento>" & _
                 "<Cargo_indicador_impresion>" + dpc.Cargo_indicador_impresion + "</Cargo_indicador_impresion>" & _
                 "<Cargo_monto_credito>" + dpc.Cargo_monto_credito + "</Cargo_monto_credito>" & _
                 "<Cargo_indicador_servip>" + dpc.Cargo_indicador_servip + "</Cargo_indicador_servip>" & _
                 "<Cargo_indicador_movpendientes>" + dpc.Cargo_indicador_movpendientes + "</Cargo_indicador_movpendientes>" & _
                 "<Cargo_folio_reparto>" + dpc.Cargo_folio_reparto + "</Cargo_folio_reparto>" & _
                 "<Cargo_concepto_venta>" + dpc.Cargo_concepto_venta + "</Cargo_concepto_venta>" & _
                 "<Cargo_tipo_transporte>" + dpc.Cargo_tipo_transporte + "</Cargo_tipo_transporte>" & _
                 "<Cargo_termino>" + dpc.Cargo_termino + "</Cargo_termino>" & _
                 "<Cargo_paridad_lista>" + dpc.Cargo_paridad_lista + "</Cargo_paridad_lista>" & _
                 "<Cargo_ultlinea_presupuesto>" + dpc.Cargo_ultlinea_presupuesto + "</Cargo_ultlinea_presupuesto>"
        If dpc.Cargo_sucursal <> "" Then
            xmldoc = xmldoc & _
           "<Cargo_sucursal>" + dpc.Cargo_sucursal + "</Cargo_sucursal> "
        End If

        xmldoc = xmldoc & _
                 "<Cargo_glosa_facturacion>" + dpc.Cargo_glosa_facturacion + "</Cargo_glosa_facturacion>" & _
                   " " + tagPago_detalle_cargo + "" & _
         "</DocumentoPago_cargo>"
        xmldoc = xmldoc & _
        "</DocumentoPago>"



        Return xmldoc
    End Function




    Public Function Xml() As String


        Dim xmldoc As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        "<Documento>" & _
        "<Documento_empresa>STE</Documento_empresa>" & _
        "<Documento_bodega>1</Documento_bodega>" & _
        "</Documento>"
        Return xmldoc

    End Function

End Class
