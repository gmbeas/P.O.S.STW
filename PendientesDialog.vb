Public Class PendientesDialog
   
    Event RecuperaVenta(ByVal documento As String)



    Private Sub Dialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objws As New WS_POS.POS
        Try
            Dim objController As New PendientesController
            Me.ListBox1.DataSource = objController.GetPendientes(_Sede, _PuntoFacturacion)
            Me.ListBox1.DisplayMember = "descripcion"
            Me.ListBox1.ValueMember = "Codigo"
        Catch ex As Exception
            MsgBox("Error", MsgBoxStyle.Information, "Error")
        End Try


    End Sub

    Private Sub btnRojo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
     
    End Sub

    Private Sub btnAzul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        Dim documento As String = ListBox1.SelectedValue.ToString
        RaiseEvent RecuperaVenta(documento)
        Me.Close()
    End Sub

    
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class