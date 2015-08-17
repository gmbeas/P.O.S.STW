Public Class CiudadController


    Public Function GetCiudad(ByVal codigoregion As String, ByVal valordefecto As String) As ArrayList

        Try
            Dim arreglo As New ArrayList


            If valordefecto <> "" Then
                Dim obj As New ListaObj
                obj.Codigo = "-"
                obj.Descripcion = valordefecto
                arreglo.Add(obj)
            End If
            Dim ds As New DataSet

            If standalone = True Then
                ' Dim objwspos As New _ws_pos.POS
                ' ds = objwspos.POS_Ciudades(codigoregion)
            Else
                Dim objwspos As New ws_pos.POS
                ds = objwspos.POS_Ciudades(codigoregion)
            End If



            For Each dr In ds.Tables(0).Rows
                Dim obj As New ListaObj
                obj.Codigo = dr(0).ToString
                obj.Descripcion = dr(1).ToString
                arreglo.Add(obj)

            Next

            Return arreglo
        Catch ex As Exception

        End Try

    End Function


End Class
