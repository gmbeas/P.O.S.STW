Public Class PendientesController



    Public Function GetPendientes(ByVal sede As Integer, ByVal caja As Integer) As ArrayList


        Dim arr As New ArrayList
        Dim ds As New DataSet
        Dim ap = _FechaSistemaWin()
        If standalone = True Then
            'Dim objws As New _ws_pos.POS
            'ds = objws.POS_Documento("SELECT", _FechaSistemaWin, "", 1, "", "FAAF", "", 0, sede, caja)
        Else
            Dim objws As New ws_pos.POS
            ds = objws.POS_Documento("SELECT", _FechaSistemaWin, "", 1, "", "FAAF", "", 0, sede, caja)
        End If


        For Each dr As DataRow In ds.Tables(0).Rows

            Dim obj As New ListaObj
            obj.Codigo = dr("DocXML").ToString
            obj.Descripcion = dr("razon").ToString
            arr.Add(obj)
        Next

        Return arr

    End Function


End Class
