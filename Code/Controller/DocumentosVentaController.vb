Imports Microsoft.VisualBasic
Imports System.Xml
Imports StewardLib
Imports System.Data.SqlClient
Imports System.Data

Public Class DocumentosVentaController

    ' Dim bd As String = ConfigurationManager.AppSettings("bd")
    Dim bd As String = ""

    Dim objSql As New STWSqlBD

    Public Function Ayuda() As ArrayList

        Dim arreglo As New ArrayList

        Dim resultado As String = ""

        If standalone = True Then

            Dim objws28 As New _apws0028.Pws0028
            resultado = objws28.Execute()
        Else
            Dim objws28 As New apws0028.Pws0028
            resultado = objws28.Execute()

        End If



        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta/Documento")
            Dim x As Integer = listanodoSedes.Count
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objDocumentosVenta As New DocumentosVentaObj
                objDocumentosVenta.Codigo = codigo
                objDocumentosVenta.Descripcion = descripcion
                arreglo.Add(objDocumentosVenta)

            Next


        End If

        Return arreglo
    End Function

    Public Function GrabaDocumento(ByVal descripcion As String, ByVal fecha As Date) As String

        Dim sqlparam As New SqlParameter()
        Dim x As String = ""
        Try

            Dim sqlParams(0 To 3 - 1) As SqlParameter
            sqlParams(0) = New SqlParameter("Descripcion", descripcion)
            sqlParams(1) = New SqlParameter("fecha", fecha)
            sqlParams(2) = New SqlParameter("tipo", "1")

            Dim ds As DataSet = objSql.ExeSPDataSet("SP_Pos_documento", sqlParams, bd)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            x = dr(0).ToString
        Catch ex As Exception

        End Try

        Return x
    End Function

    Public Function GetFolio(ByVal sede As Integer, ByVal ptovta As Integer, ByVal tipodocu As String) As Integer

        Dim folio As Integer = 0

        Dim objDoc As New DocumentoController
        Dim objdocpa As New DocumentosPagoController
        Dim ds As New DataSet

        If standalone = True Then
            Dim objLisa As New _WS_LISA.WS_Lisa
            ds = objLisa.Folios("C", "STE", sede, ptovta, tipodocu, 0)
        Else
            Dim objLisa As New ws_lisa.WS_Lisa
            ds = objLisa.Folios("C", "STE", sede, ptovta, tipodocu, 0)
        End If


        If ds.Tables(0).Rows.Count Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            folio = Int32.Parse(dr(1).ToString)

            If dr(0).ToString = "-1" Then
                MsgBox("Error el correlativo, no existen correlativos en el rango permitido, contacte el administrador del Sistema", MsgBoxStyle.Exclamation, "Error Correlativo")
                Exit Function
            End If

            If Int32.Parse(dr(0)) > 0 Then
                MsgBox("Solo Quedan " + dr(0).ToString + " Folios Disponibles, Informe esta advertencia al departamento de Sistemas", MsgBoxStyle.Exclamation)

            End If

            _Modalidad = "N"
        End If





        Return folio

    End Function


    Public Sub ActualizaCorrelativo(ByVal sede As Integer, ByVal punto As Integer, ByVal tipodoc As String, ByVal folio As Integer)

        If standalone = True Then

            Dim lisaws As New _WS_LISA.WS_Lisa
            lisaws.Folios("A", "STE", sede, punto, tipodoc, folio)

        Else
            Dim lisaws As New ws_lisa.WS_Lisa
            lisaws.Folios("A", "STE", sede, punto, tipodoc, folio)

        End If



    End Sub


    Public Function AnulaDocumento(ByVal codempresa As String, ByVal sede As String, ByVal puntofacturacion As String, ByVal tipodoc As String, ByVal Folio As String) As Boolean

        ' Dim objCuenta As New CuentaCorrienteObj

        ' Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
        '"<Documento>" & _
        '"<Documento_empresa>" + codempresa + "</Documento_empresa>" & _
        '"<Documento_sede>" + sede + "</Documento_sede>" & _
        '"<Documento_Punto_Facturacion>" + puntofacturacion + "</Documento_Punto_Facturacion>" & _
        '"<Documento_documento>" + tipodoc + "</Documento_documento>" & _
        ' "<Documento_impreso>" + Folio + "</Documento_impreso>" & _
        '"</Documento>"

        ' Dim resultado As String
        ' If standalone = True Then

        '     Dim ws48 As New _apws0048.Pws0048
        '     resultado = ws48.Execute(cadena)
        ' Else

        '     Dim ws48 As New apws0048.Pws0048
        '     resultado = ws48.Execute(cadena)

        ' End If


        ' Dim docXML As New XmlDocument
        ' docXML.LoadXml(resultado)
        ' Dim nodoPrincipal As XmlNodeList
        ' Dim nodoCredito As XmlNodeList


        ' docXML.SelectNodes("/Respuesta")
        ' If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
        '     nodoPrincipal = docXML.SelectNodes("/Respuesta")
        '     nodoCredito = docXML.SelectNodes("/Respuesta/Linea_credito_disponible")
        '     Dim nodochico As XmlNode = nodoPrincipal.Item(0)
        '     Dim nodochicocredito As XmlNode = nodoCredito(0)
        '     objCuenta.rut = Int32.Parse(nodochico("Respuesta_cta_cte_rut").InnerText())
        '     objCuenta.UltimaFactura = nodochico("Respuesta_cta_cte_ulima_factura").InnerText()
        '     objCuenta.Calificacion = nodochico("Respuesta_cta_cte_calificacion").InnerText()
        '     objCuenta.LineaCredito = nodochico("Respuesta_cta_cte_linea_credito").InnerText()
        '     ' objCuenta.LineaDisponible = Double.Parse(nodoCredito("Respuesta_linea_credito_disponible").InnerText())
        '     objCuenta.LineaDisponible = Double.Parse(nodochicocredito("Respuesta_linea_credito_disponible").InnerText())
        ' End If


    End Function



End Class
