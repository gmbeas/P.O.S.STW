Imports System.Data.SqlClient
Public Class CajerosController


    Public Function Ayuda() As ArrayList

        Dim arreglo As New ArrayList
        Dim ds As New DataSet

        If standalone = True Then
            ' Dim obj As New _ws_pos.POS
            ' ds = obj.POS_Cajeros
        Else
            Dim obj As New ws_pos.POS
            ds = obj.POS_Cajeros

        End If




        If ds.Tables(0).Rows.Count Then

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim objcajero As New ListaObj

                objcajero.Codigo = dr(0).ToString
                objcajero.Descripcion = dr(1).ToString

                arreglo.Add(objcajero)

            Next

        End If

        Return arreglo

    End Function

End Class
