Imports System.Xml


Public Class CuentaCorriente



    Public Function GetCuenta(ByVal codEmpresa As String, ByVal Cliente As String, ByVal Moneda As String, ByVal fechaProceso As String, ByVal fechadesde As String, ByVal fechahasta As String) As CuentaCorrienteObj

        Cliente = Cliente.Remove(Cliente.Length - 2, 2)

        Dim objCuenta As New CuentaCorrienteObj

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + codEmpresa + "</Documento_empresa>" & _
       "<Documento_auxiliar>" + Cliente + "</Documento_auxiliar>" & _
       "<Documento_moneda>" + Moneda + "</Documento_moneda>" & _
       "<Documento_fecha_proceso>" + fechaProceso + "</Documento_fecha_proceso>" & _
       "<Documento_fecha_desde>" + "20100101" + "</Documento_fecha_desde>" & _
        "<Documento_fecha_hasta>" + "20120101" + "</Documento_fecha_hasta>" & _
       "</Documento>"




        Dim resultado As String = ""

        If standalone = True Then
            Dim ws51 As New _apws0051.Pws0051
            resultado = ws51.Execute(cadena)
        Else

            Dim ws51 As New apws0051.Pws0051
            resultado = ws51.Execute(cadena)

        End If

        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim nodoPrincipal As XmlNodeList
        Dim nodoCredito As XmlNodeList

        docXML.SelectNodes("/DefinicionRespuesta/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            nodoPrincipal = docXML.SelectNodes("/DefinicionRespuesta/Respuesta")
            nodoCredito = docXML.SelectNodes("/DefinicionRespuesta/Respuesta/Linea_credito_disponible")
            Dim nodochico As XmlNode = nodoPrincipal.Item(0)
            Dim nodochicocredito As XmlNode = nodoCredito(0)

            objCuenta.rut = Int32.Parse(nodochico("Respuesta_cta_cte_rut").InnerText())
            objCuenta.UltimaFactura = nodochico("Respuesta_cta_cte_ulima_factura").InnerText()
            objCuenta.Calificacion = nodochico("Respuesta_cta_cte_calificacion").InnerText()
            objCuenta.LineaCredito = nodochico("Respuesta_cta_cte_linea_credito").InnerText()
            ' objCuenta.LineaDisponible = Double.Parse(nodoCredito("Respuesta_linea_credito_disponible").InnerText())
            objCuenta.LineaDisponible = Double.Parse(nodochicocredito("Respuesta_linea_credito_disponible").InnerText())


        End If

        Return objCuenta

    End Function

End Class
