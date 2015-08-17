Public Class FormRazonDialog

    Event GetRazon(ByVal razon As String)

    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        RaiseEvent GetRazon(txtRazon.Text)
        Me.Close()
    End Sub

    Private Sub FormRazonDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class