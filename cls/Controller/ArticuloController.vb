Imports System.Xml
Imports System.Data


Public Class ArticuloController

    Dim objLisaMs As New wsLisa.WS_Lisa
    Dim ws08 As New wsBrowse.Pws0008
    Dim ws045 As New wsBrowse.Pws0045
    'valida codigo barra
    Dim ws07 As New wsBrowse.Pws0007

    Public Function GetArticuloCodigo(ByVal rutempresa As Integer, ByVal sku As String) As ArticuloObj

        Dim objArticulo As New ArticuloObj

        Dim ds As DataSet = objLisaMs.ConsultaPos("PRE", "STE", rutempresa, sku, 0)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            objArticulo.sku = dr("sku").ToString
            'objArticulo.descripcion = dr("NomCliente").ToString
            objArticulo.precio = Int32.Parse(dr("precio"))
            objArticulo.nombre = dr("nombre")
            objArticulo.unidadmedida = dr("um").ToString

        End If

        Return objArticulo
    End Function

    Public Function GetArticuloCodigoCantidad(ByVal rutempresa As Integer, ByVal sku As String, ByVal cantidad As Integer) As ArticuloObj

        Dim objArticulo As New ArticuloObj

        Dim ds As DataSet = objLisaMs.ConsultaPos("PRE", "STE", rutempresa, sku, cantidad)
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)

            objArticulo.sku = dr("sku").ToString.Trim
            objArticulo.precio = Int32.Parse(dr("precio"))
            objArticulo.nombre = dr("nombre").ToString.Trim
            objArticulo.unidadmedida = dr("um").ToString.Trim
            objArticulo.cantidad = cantidad
            objArticulo.valortotal = cantidad * Int32.Parse(dr("precio"))
            objArticulo.Envase = "C"

        End If

        Return objArticulo
    End Function


    Public Function ValidaUbicacionArticulo(ByVal codEmpresa As String, ByVal codArticulo As String, ByVal codBodega As String) As Boolean

        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + codEmpresa + "</Documento_empresa>" & _
       "<Documento_Articulo>" + codArticulo + "</Documento_Articulo>" & _
       "<Documento_Bodega>" + codBodega + "</Documento_Bodega>" & _
       "</Documento>"

        Dim resultado As String = ws08.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta")
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
               
            Next


        End If


        Return True
    End Function


    Public Function AyudaArticulos(ByVal codigoEmpresa As String, ByVal ListaPrecio As String, ByVal articulo As String) As ArrayList

        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + codigoEmpresa + "</Documento_empresa>" & _
       "<Documento_lista_precios>" + ListaPrecio + "</Documento_lista_precios>" & _
       "<Documento_articulo>" + articulo + "</Documento_articulo>" & _
       "</Documento>"

        Dim resultado As String = ws045.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta")
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText

            Next


        End If


        Return arreglo

    End Function


    ' valida codigo de barra
    Public Function ValidaArticulo(ByVal codigoempresa As String, ByVal articulo As String, ByVal barra As String) As ArrayList

        Dim arreglo As New ArrayList

        Dim cadena As String = "<?xml version='1.0' encoding='utf-8'?>" & _
       "<Documento>" & _
       "<Documento_empresa>" + codigoempresa + "</Documento_empresa>" & _
       "<Documento_articulo>" + articulo + "</Documento_articulo>" & _
       "<Documento_barra>" + barra + "</Documento_barra>" & _
       "</Documento>"

        Dim resultado As String = ws07.Execute(cadena)
        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode
        docXML.SelectNodes("/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/Respuesta")
            'hay que terminarlo bien
            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText

            Next


        End If


        Return arreglo

    End Function

End Class
