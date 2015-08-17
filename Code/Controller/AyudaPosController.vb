Public Class AyudaPosController


    Public Function Sedes() As ArrayList

        Dim arreglo As New ArrayList

        Dim ds As DataSet

        If standalone = True Then
            ' Dim objWs As New _ws_pos.POS
            ' ds = objWs.POS_Ayuda("LOCALESALL")
        Else
            Dim objWs As New ws_pos.POS
            ds = objWs.POS_Ayuda("LOCALESALL")
        End If

        If ds.Tables(0).Rows.Count <> 0 Then

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim objLista As New ListaObj

                objLista.Codigo = dr("id").ToString
                objLista.Descripcion = dr("Nombre").ToString
                arreglo.Add(objLista)

            Next

        End If
        Return arreglo

    End Function



    Public Function Cajas() As ArrayList

        Dim arreglo As New ArrayList


        Dim ds As New DataSet
        If standalone = True Then
            'Dim objWs As New _ws_pos.POS
            'ds = objWs.POS_Ayuda("CAJASALL")
        Else
            Dim objWs As New ws_pos.POS
            ds = objWs.POS_Ayuda("CAJASALL")
        End If


        If ds.Tables(0).Rows.Count <> 0 Then

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim objLista As New ListaObj

                objLista.Codigo = dr("id").ToString
                objLista.Descripcion = dr("Sigla").ToString + "." + dr("Nombre").ToString
                arreglo.Add(objLista)

            Next

        End If
        Return arreglo

    End Function


    Public Function TiposDoc() As ArrayList

        Dim arreglo As New ArrayList

        Dim ds As DataSet

        If standalone = True Then
            'Dim objWs As New _ws_pos.POS
            ' ds = objWs.POS_Ayuda("DOCUALL")
        Else
            Dim objWs As New ws_pos.POS
            ds = objWs.POS_Ayuda("DOCUALL")
        End If

        If ds.Tables(0).Rows.Count <> 0 Then

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim objLista As New ListaObj

                objLista.Codigo = dr("id").ToString
                objLista.Descripcion = dr("Sigla").ToString + "." + dr("Nombre").ToString
                arreglo.Add(objLista)

            Next

        End If
        Return arreglo

    End Function

    Public Function MediosPago() As ArrayList

        Dim arreglo As New ArrayList
        Dim ds As New DataSet

        If standalone = True Then

            ' Dim objWs As New _ws_pos.POS
            'ds = objWs.POS_Ayuda("MEDIOPALL")
        Else

            Dim objWs As New ws_pos.POS
            ds = objWs.POS_Ayuda("MEDIOPALL")

        End If



        If ds.Tables(0).Rows.Count <> 0 Then

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim objLista As New ListaObj

                objLista.Codigo = dr("id").ToString
                objLista.Descripcion = dr("Sigla").ToString + "." + dr("Nombre").ToString
                arreglo.Add(objLista)

            Next

        End If
        Return arreglo

    End Function


    Public Function Cajeros() As ArrayList

        Dim arreglo As New ArrayList
        Dim ds As New DataSet

        If standalone = True Then
            ' Dim objWs As New _ws_pos.POS
            ' ds = objWs.POS_Ayuda("CAJEROS")
        Else
            Dim objWs As New ws_pos.POS
            ds = objWs.POS_Ayuda("CAJEROS")
        End If



        If ds.Tables(0).Rows.Count <> 0 Then

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim objLista As New ListaObj

                objLista.Codigo = dr("id").ToString
                objLista.Descripcion = dr("Nombre").ToString
                arreglo.Add(objLista)

            Next

        End If
        Return arreglo

    End Function
End Class