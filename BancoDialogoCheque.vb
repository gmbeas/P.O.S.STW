Public Class BancoDialogoCheque
    Dim objController As New BancosController


    Event GetCodigoBancoDialogo(ByVal codigo As String, ByVal nombre As String, ByVal fila As Integer)

    Private Sub BancoDialogoCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dropBanco.DataSource = objController.Ayuda()
        Me.dropBanco.DisplayMember = "Descripcion"
        Me.dropBanco.ValueMember = "Codigo"

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAceptar.Click

        Dim codigo As String = Me.dropBanco.SelectedValue
        Dim descripcion As String = Me.dropBanco.Text
        Dim fila As Integer = Int32.Parse(txtFila.Text)
        RaiseEvent GetCodigoBancoDialogo(codigo, descripcion, fila)
        Me.Close()

    End Sub
End Class