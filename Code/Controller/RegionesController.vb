Public Class RegionesController




    Public Function Regiones(ByVal valordefecto As String) As ArrayList


        Try
            Dim ds As New DataSet

            If standalone = True Then
                '  Dim objwsPos As New _ws_pos.POS
                ' ds = objwsPos.POS_Regiones
            Else
                Dim objwsPos As New ws_pos.POS
                ds = objwsPos.POS_Regiones
            End If


            Dim arreglo As New ArrayList


            If valordefecto <> "" Then
                Dim obj As New ListaObj
                obj.Codigo = "-"
                obj.Descripcion = valordefecto
                arreglo.Add(obj)
            End If

            For Each dr In ds.Tables(0).Rows
                Dim obj As New ListaObj
                obj.Codigo = dr(0).ToString
                obj.Descripcion = dr(1).ToString
                arreglo.Add(obj)
            Next


            Return arreglo

        Catch ex As Exception
            Dim objLog As New PosLog
            objLog.GuardaMvto("E", ex.ToString)
            objLog.ReportaError("RegionesController.Vb", "Regiones", ex.ToString)
        End Try




    End Function

End Class
