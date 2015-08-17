Public Class TarjetasCreditoController



    Public Function GetTarjetas() As ArrayList
        Try
            Dim arreglo As New ArrayList
            Dim ds As New DataSet

            If standalone = True Then
                '  Dim objPos As New _ws_pos.POS
                ' ds = objPos.POS_TipoTarjetasdeCreditoGet()
            Else
                Dim objPos As New ws_pos.POS
                ds = objPos.POS_TipoTarjetasdeCreditoGet()
            End If


            Dim obj2 As New ListaObj
            obj2.Codigo = "-"
            obj2.Descripcion = "[SELECCIONAR]"
            arreglo.Add(obj2)

            For Each dr As DataRow In ds.Tables(0).Rows

                Dim obj As New ListaObj
                obj.Codigo = dr("id").ToString
                obj.Descripcion = dr("Nombre").ToString
                If dr("id").ToString <> "1" Then
                    arreglo.Add(obj)
                End If
            Next


            Return arreglo
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

End Class
