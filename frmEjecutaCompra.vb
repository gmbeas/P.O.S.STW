Imports System.Xml
Imports System.IO

Public Class frmEjecutaCompra

    Private Sub frmEjecutaCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        EjecutaPos("D:\xml_phurtado\1161350.xml")

    End Sub






    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim ContadorDeArchivos As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
            Dim ArchivosRespaldo As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

            'le indicamos el path que queremos  
            ContadorDeArchivos = My.Computer.FileSystem.GetFiles(Me.TextBox1.Text)
            ArchivosRespaldo = My.Computer.FileSystem.GetFiles("c:\ventas xml\respaldo\")

            'nos devuelve la cantidad de archivos  
            Dim totalarchivos As Integer = ContadorDeArchivos.Count

            If ContadorDeArchivos.Count = 0 Then
                MsgBox("No se han Encontrado Archivos", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            For Each x1 As String In ContadorDeArchivos

                Dim duplicado As Integer = 0
                For Each x2 As String In ArchivosRespaldo
                    Dim compara As String = x1.Insert(14, "Respaldo\")

                    If UCase(compara) = UCase(x2) Then
                        duplicado = duplicado + 1
                    End If
                Next

                If duplicado = 0 Then
                    EjecutaPos(x1)
                End If
            Next

        Catch oExcep As Exception

            MsgBox("Descripción del error : " & _
                   oExcep.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub



    'Public Sub EjecutaWeb(ByVal archivo As String)

    '    Dim wsLisaerp As New ws_lisa.WS_Lisa
    '    Dim wsweb As New ws_Venta.Wsweb


    '    Dim XmlDoc As New System.Xml.XmlDocument()
    '    Try
    '        XmlDoc.Load(archivo)
    '    Catch ex As Exception
    '        MsgBox("No se ha encontrado el archivo", MsgBoxStyle.Exclamation)
    '    End Try


    '    Try
    '        Dim XmlResultado As New System.Xml.XmlDocument()
    '        Dim strFileName As String = ""
    '        Dim XmlDocto As String = XmlDoc.OuterXml
    '        Dim ORCO_FOLIO_LISA As String = ""
    '        Dim resultado As String = wsweb.Execute(XmlDocto)
    '        wsweb.Dispose()

    '        Dim docXMLT As New System.Xml.XmlDocument
    '        docXMLT.LoadXml(resultado)
    '        Dim lista As System.Xml.XmlNodeList
    '        Dim nodo As XmlNode
    '        Dim indicador As String = ""
    '        Dim folio As String = ""

    '        XmlResultado.LoadXml(resultado)
    '        XmlResultado.SelectNodes("/Respuesta")
    '        If XmlResultado.GetElementsByTagName("Respuesta_Indicador_Exito").Count > 0 Then ' Existen Resultado
    '            If XmlResultado.GetElementsByTagName("Respuesta_Indicador_Exito").Item(0).InnerText() = "1" Then 'EXITO
    '                folio = XmlResultado.GetElementsByTagName("Respuesta_Folio").Item(0).InnerText()
    '                Dim fichero As New FileInfo(archivo)
    '                Dim ficheroRespaldo As String = ""
    '                ficheroRespaldo = archivo.Insert(14, "Respaldo\")
    '                fichero.MoveTo(ficheroRespaldo)
    '                wsLisaerp.ConsultaPos("BOD", "STE", "", "", "1", Int32.Parse(folio), "", "")
    '                MsgBox("Documento Transferido" + folio.ToString, MsgBoxStyle.Information)
    '            End If
    '        End If

    '    Catch ex As Exception

    '        MsgBox("Error" + ex.ToString, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub


    Public Sub EjecutaPos(ByVal archivo As String)
        Dim wsweb As New apws0049.Pws0049


        Dim XmlDoc As New System.Xml.XmlDocument()
        Try
            XmlDoc.Load(archivo)
        Catch ex As Exception
            MsgBox("No se ha encontrado el archivo", MsgBoxStyle.Exclamation)
        End Try


        Try
            Dim XmlResultado As New System.Xml.XmlDocument()
            Dim strFileName As String = ""
            Dim XmlDocto As String = XmlDoc.OuterXml
            Dim ORCO_FOLIO_LISA As String = ""
            Dim resultado As String = wsweb.Execute(XmlDocto)
            wsweb.Dispose()

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
                'valorRetorno = False


                For Each nodoerrores As XmlNode In docXMLT.GetElementsByTagName("Respuesta_Detalle")
                    msgerrores = msgerrores & nodoerrores.ChildNodes.Item(0).InnerText + " - " + nodoerrores.ChildNodes(1).InnerText & vbNewLine

                Next
                MsgBox("SE HAN PROVOCADO LOS SIGUIENTES  ERRORES EN LA TRANSACCION:" + msgerrores, MsgBoxStyle.Critical, "STEWARD ")
            Else
                ' valorRetorno = True
                'Dim objdocu As New DocumentoController
                'objdocu.GuardarDocumento(objventa.Correlativo, objventa.DocumentoVenta, doc)
            End If



         

        Catch ex As Exception

            MsgBox("Error" + ex.ToString, MsgBoxStyle.Exclamation)
        End Try
      


        'Dim wsweb As New ws_Venta.Wsweb


        'Dim XmlDoc As New System.Xml.XmlDocument()
        'Try
        '    XmlDoc.Load(archivo)
        'Catch ex As Exception
        '    MsgBox("No se ha encontrado el archivo", MsgBoxStyle.Exclamation)
        'End Try


        'Try
        '    Dim XmlResultado As New System.Xml.XmlDocument()
        '    Dim strFileName As String = ""
        '    Dim XmlDocto As String = XmlDoc.OuterXml
        '    Dim ORCO_FOLIO_LISA As String = ""
        '    Dim resultado As String = wsweb.Execute(XmlDocto)
        '    wsweb.Dispose()

        '    Dim docXMLT As New System.Xml.XmlDocument
        '    docXMLT.LoadXml(resultado)
        '    Dim lista As System.Xml.XmlNodeList
        '    Dim nodo As XmlNode
        '    Dim indicador As String = ""
        '    Dim folio As String = ""

        '    XmlResultado.LoadXml(resultado)
        '    XmlResultado.SelectNodes("/Respuesta")
        '    If XmlResultado.GetElementsByTagName("Respuesta_Indicador_Exito").Count > 0 Then ' Existen Resultado
        '        If XmlResultado.GetElementsByTagName("Respuesta_Indicador_Exito").Item(0).InnerText() = "1" Then 'EXITO
        '            folio = XmlResultado.GetElementsByTagName("Respuesta_Folio").Item(0).InnerText()
        '            Dim fichero As New FileInfo(archivo)
        '            Dim ficheroRespaldo As String = ""
        '            ficheroRespaldo = archivo.Insert(14, "Respaldo\")
        '            fichero.MoveTo(ficheroRespaldo)
        '            'wsLisaerp.ConsultaPos("BOD", "STE", "", "", "1", Int32.Parse(folio), "")
        '            MsgBox("Documento Transferido" + folio.ToString, MsgBoxStyle.Information)
        '        End If
        '    End If

        'Catch ex As Exception

        '    MsgBox("Error" + ex.ToString, MsgBoxStyle.Exclamation)
        'End Try
    End Sub
End Class