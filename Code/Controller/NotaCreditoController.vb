Public Class NotaCreditoController



    Public Function ValidaExistencia(ByVal nroNota As Integer) As Boolean

        Try
            Dim Existe As Boolean = False
            Dim ds As New DataSet

            If standalone = True Then
                Dim objws As New _WS_LISA.WS_Lisa
                ds = objws.ConsultaPos("CNC", "STE", "1", "14125194", nroNota.ToString, 1, 500)
            Else
                Dim objws As New ws_lisa.WS_Lisa
                ds = objws.ConsultaPos("CNC", "STE", "1", "14125194", nroNota.ToString, 1, 500, "")
            End If


            If ds.Tables(0).Rows.Count <> 0 Then
                Dim DR As DataRow = ds.Tables(0).Rows(0)

                If DR(0).ToString <> "N" Then

                    If nroNota.ToString = DR("FolioTi").ToString Then
                        Existe = True
                    End If

                End If

            End If

            Return Existe

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Function


    Public Function Monto(ByVal nronota As String) As Double

        Dim ds As New DataSet

        If standalone = True Then
            Dim objws As New _WS_LISA.WS_Lisa
            ds = objws.ConsultaPos("CNC", "STE", "1", "1", nronota.ToString, 1, 500)
        Else
            Dim objws As New ws_lisa.WS_Lisa
            ds = objws.ConsultaPos("CNC", "STE", "1", "1", nronota.ToString, 1, 500, "")
        End If

        Dim monto_ As Double = 0
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim DR As DataRow = ds.Tables(0).Rows(0)
            monto_ = Double.Parse(DR("valorBruto").ToString)
        End If
        Return monto_

    End Function

End Class
