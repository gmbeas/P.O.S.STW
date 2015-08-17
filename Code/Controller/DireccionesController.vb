Imports System.Xml

Public Class DireccionesController

    Public Function GetDirecciones(ByVal rut As Integer) As ArrayList


        Try
            Dim arreglo As New ArrayList
            Dim resultado As System.Xml.XmlNode

            If standalone = True Then
                Dim objWS As New _WS_LISA.WS_Lisa
                resultado = objWS.ConsultaCliente("STE", rut)

            Else
                Dim objWS As New ws_lisa.WS_Lisa
                resultado = objWS.ConsultaCliente("STE", rut)
                objWS.Dispose()
            End If



            Dim xml As New XmlDocument()
            xml.LoadXml(resultado.OuterXml)
            Dim xnList As XmlNodeList = xml.SelectNodes("/CLIENTE/DIRECCIONES/DIRECCION")

            If xnList.Count <> 0 Then

                For Each xn As XmlNode In xnList

                    Dim objDir As New DireccionObj
                    objDir.Codigo = Int32.Parse(xn.ChildNodes.Item(0).InnerText)
                    objDir.Direccion = UCase(xn.ChildNodes.Item(1).InnerText)
                    objDir.Region = xn.ChildNodes.Item(2).InnerText
                    objDir.Ciudad = xn.ChildNodes.Item(3).InnerText
                    objDir.Comuna = xn.ChildNodes.Item(4).InnerText
                    objDir.DescripcionCiudad = xn.ChildNodes.Item(6).InnerText
                    objDir.DescripcionComuna = xn.ChildNodes.Item(7).InnerText
                    objDir.DescripcionRegion = xn.ChildNodes.Item(5).InnerText

                    arreglo.Add(objDir)

                Next
                Return arreglo
            Else
                MsgBox("el CLiente no tiene direcciones asociadas, debe crearlas", MsgBoxStyle.Exclamation)
                Exit Function
            End If


        Catch ex As Exception

            Dim objPos As New PosLog
            objPos.GuardaMvto("E", "POS:" + ex.ToString)
            objPos.ReportaError("DireccionesController.vb", "GetDirecciones", "POS:" + _Pos + ex.ToString)
            MsgBox("Error" + ex.ToString, MsgBoxStyle.Exclamation)
        End Try


    End Function


End Class
