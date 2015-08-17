Imports Microsoft.VisualBasic
Imports System.Xml


Public Class BancosController


    Public Function Ayuda() As ArrayList

        Dim arreglo As New ArrayList
        Dim resultado As String = ""

        If standalone = True Then
            Dim objws32 As New _apws0032.Pws0032
            resultado = objws32.Execute()
        Else
            Dim objws32 As New apws0032.Pws0032
            resultado = objws32.Execute()
        End If


        Dim docXML As New XmlDocument
        docXML.LoadXml(resultado)
        Dim listanodoSedes As XmlNodeList
        Dim nodo As XmlNode



        docXML.SelectNodes("/DefinicionRespuesta/Respuesta")
        If docXML.GetElementsByTagName("Respuesta").Count > 0 Then ' Existen Resultad
            listanodoSedes = docXML.SelectNodes("/DefinicionRespuesta/Respuesta/Banco")
            Dim x As Integer = listanodoSedes.Count

            Dim objsel As New ListaObj
            objsel.Codigo = "-"
            objsel.Descripcion = "[SELECCIONAR]"
            arreglo.Add(objsel)

            For Each nodo In listanodoSedes

                Dim codigo As String = nodo.ChildNodes.Item(0).InnerText
                Dim descripcion As String = nodo.ChildNodes.Item(1).InnerText
                Dim objDirecciones As New ListaObj

                objDirecciones.Codigo = codigo
                objDirecciones.Descripcion = descripcion


                If UCase(objDirecciones.Descripcion).Trim <> "EFECTIVO" Then

                    arreglo.Add(objDirecciones)
                End If

            Next


        End If

        Return arreglo
    End Function



End Class
