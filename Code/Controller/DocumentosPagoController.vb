Imports Microsoft.VisualBasic
Imports System.Xml

Public Class DocumentosPagoController



    Public Function Get_todos() As ArrayList

        Dim arreglo As New ArrayList

        Dim resultado As String = ""

        If standalone = True Then
            Dim objws31 As New _apws0031.Pws0031
            resultado = objws31.Execute()
        Else
            Dim objws31 As New apws0031.Pws0031
            resultado = objws31.Execute()
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



    Public Function VALIDAEXISTENCIAFOLIO(ByVal FOLIO As String, ByVal TipoPago As String) As Boolean
        Dim ds As New DataSet

        If standalone = True Then
            Dim ws As New _WS_LISA.WS_Lisa
            ds = ws.ExistenciaDocumentosPago(FOLIO, TipoPago)
        Else
            Dim ws As New ws_lisa.WS_Lisa
            ds = ws.ExistenciaDocumentosPago(FOLIO, TipoPago)
        End If

        Dim existencia As Boolean = False
        If ds.Tables(0).Rows.Count <> 0 Then
            existencia = True
        End If

        Return existencia
    End Function

End Class
