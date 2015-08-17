Imports Microsoft.VisualBasic
Imports System.Xml
Imports StewardLib
Imports System.Data.SqlClient
Imports System.Data

Public Class DocumentosVentaController

    Dim bd As String = ConfigurationManager.AppSettings("bd")
    Dim objws28 As New wsBrowse.Pws0028
    Dim objSql As New STWSqlBD



    Public Function Ayuda() As ArrayList

        Dim arreglo As New ArrayList

        Dim resultado As String = objws28.Execute()
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

End Class
