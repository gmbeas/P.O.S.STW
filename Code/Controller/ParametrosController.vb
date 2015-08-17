Public Class ParametrosController



    Public Function TraeValor(ByVal parametro As String) As String
        Dim valor As String = ""
        Dim ds As DataSet
        If standalone = True Then

            ' Dim objWsPos As New _ws_pos.POS
            'ds = objWsPos.POS_Parametros_Configuracion(parametro)

        Else
            Dim objWsPos As New ws_pos.POS
            ds = objWsPos.POS_Parametros_Configuracion(parametro)
        End If


        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            valor = dr("valor").ToString
        End If

        Return valor

    End Function



End Class
