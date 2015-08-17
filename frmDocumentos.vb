Public Class frmDocumentos

    Event CargaDocumento(ByVal CabId As String)

    Private Sub btn_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Pendientes.Click

        Dim objws As New ws_pos.POS

        Dim ds As DataSet = objws.POS_Documentos_Wop("L", 0, 2, "", "", "", 0)

        If ds.Tables.Count <> 0 Then



            Me.DataGridView1.DataSource = ds.Tables(0)
            Me.DataGridView1.Columns("Cab_Id").Visible = False

        End If



    End Sub


    Private Sub btn_preventa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_preventa.Click

        Dim objws As New ws_pos.POS

        Dim ds As DataSet = objws.POS_Documentos_Wop("L", 0, 3, "", "", "", 0)

        If ds.Tables.Count <> 0 Then



            Me.DataGridView1.DataSource = ds.Tables(0)


        End If

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick


    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If e.ColumnIndex = 0 Then


            If _MENSAJE_CONFIRMACION("seguro", "STEWARD") = True Then



                RaiseEvent CargaDocumento(Me.DataGridView1.Rows(0).Cells("Cab_id").Value)
                Me.Close()


            End If

        End If




    End Sub



    Private Sub frmDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class