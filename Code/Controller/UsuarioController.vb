



Public Class UsuarioController



    Public Function ValidaAutentificacion(ByVal Username As String, ByVal Password As String) As Boolean
        Dim valor As Boolean = False
        Dim ds As DataSet

        If standalone = True Then
            Dim objLisa As New _WS_LISA.WS_Lisa
            ds = objLisa.AutentificacionWOP(Username, Password)
        Else
            Dim objLisa As New ws_lisa.WS_Lisa()
            ds = objLisa.AutentificacionWOP(Username, Password)
        End If


        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)

            If dr(0).ToString.Substring(0, 1) <> "-" Then
                valor = True
            End If
        End If

        Return valor

    End Function

    Public Function ValidaRolUsuario(ByVal Username As String, ByVal Rol_id As String) As Boolean
        Dim valor As Boolean = False
        Dim ds As New DataSet

        If standalone = True Then
            'Dim objPos As New _ws_pos.POS
            '  ds = objPos.ValidaRolUsuarioWop(Username, Rol_id)
        Else
            Dim objPos As New WS_POS.POS
            ds = objPos.ValidaRolUsuarioWop(Username, Rol_id)
        End If


        If ds.Tables(0).Rows.Count <> 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)

            If dr(0).ToString.Substring(0, 1) = "S" Then
                valor = True
            End If
        End If

        Return valor

    End Function


End Class
